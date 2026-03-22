using Guna.UI2.WinForms;
using SabzMarket.Http;
using SabzMarket.Share;
using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
using SabzMarket.UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SabzMarket
{
    public partial class frm_Home : FormStyle
    {
        public frm_Home()
        {
            InitializeComponent();
            pb_Profile.LoadCompleted += Pb_Profile_LoadCompleted;

            this.MouseClick += OpenClosed;
            foreach (Control ctrl in guna2CustomGradientPanel1.Controls)
            {
                ctrl.MouseClick += OpenClosed;
            }
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != pln_Menu2 && ctrl != btn_Menu)
                    ctrl.MouseClick += OpenClosed;
            }
        }

        private void Pb_Profile_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                ShowInfo("عکس بارگذاری نشد");
                pb_Profile.Image = Resources.profile;
            }
        }

        public async Task SetUserHeaderInfo()
        {
            var client = HttpClientHelper.Instance;
            string route = string.Format(ApiRoutes.GetSellerByUsername, CurrentUser.UserName);
            var seller = await client.GetAsync<OperationResult<GetSellerOutputViewModel>>(route);
            if (seller == null)
            {
                ShowInfoError(Messages.InternetErrorMessage);
                Application.Exit();
                return;
            }
            if (!seller!.Success)
            {
                if (!seller.Result)
                {
                    ShowInfoError(seller.Message!);
                    Application.Exit();
                    return;
                }
                ShowInfo(seller.Message!);
                Application.Exit();
                return;
            }
            CurrentUser.SellerId = seller.Data.Id;
            CurrentUser.UserId = seller.Data.UserId;
            lbl_Name.Text = $"{seller.Data.FirstName} {seller.Data.LastName}";
            lbl_UserName.Text = seller.Data.Username;
            pb_Profile.LoadAsync(seller.Data.ProfileImage);
        }
        private async void frm_Home_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            await SetUserHeaderInfo();
            RefreshProduct(this, EventArgs.Empty);

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pln_Menu2.Visible = true;
        }

        private void OpenClosed(object sender, EventArgs e)
        {
            if (pln_Menu2.Visible)
            {
                pln_Menu2.Visible = false;
            }
        }
        private void btn_Setting_Click(object sender, EventArgs e)
        {
            frm_Settings frm_Settings = new frm_Settings();
            frm_Settings.LoodPanel += Frm_Settings_LoodPanel; ; ;
            frm_Settings.ShowDialog();
        }

        private async void Frm_Settings_LoodPanel(object? sender, EventArgs e)
        {
            await SetUserHeaderInfo();
        }
        private void btn_Orders_Click(object sender, EventArgs e)
        {
            frm_Orders frm_Orders = new frm_Orders();
            frm_Orders.ShowDialog();
        }
        private void btn_Chat_Click(object sender, EventArgs e)
        {
            frm_Chat frm_Chat = new frm_Chat();
            frm_Chat.ShowDialog();
        }
        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            frm_ProductUpsert AddProducts = new frm_ProductUpsert();
            AddProducts.RefreshProduct += RefreshProduct;
            AddProducts.ShowDialog();
        }

        private async void RefreshProduct(object? sender, EventArgs e)
        {
            await GetProduct(CurrentUser.SellerId);
            if (ProductDTOs != null && ProductDTOs!.Count != 0)
                RenderOrders(ProductDTOs);
        }

        private void frm_Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void RenderOrders(List<GetProductOutputViewModel> products)
        {
            flp_ShowProduct.Controls.Clear();
            foreach (var product in products)
            {
                UC_Products uC_Products = new UC_Products();
                uC_Products.Product = product;
                uC_Products.Delete += UC_Products_Delete;
                uC_Products.Edit += UC_Products_Edit;
                flp_ShowProduct.Controls.Add(uC_Products);
            }
        }

        private void UC_Products_Edit(object? sender, ProductEventArgs e)
        {
            frm_ProductUpsert AddProducts = new frm_ProductUpsert();
            AddProducts.Product = e.Product;
            AddProducts.IsEdit = true;
            AddProducts.RefreshProduct += RefreshProduct;
            AddProducts.ShowDialog();
        }

        private async void UC_Products_Delete(object? sender, ProductEventArgs e)
        {
            if (ShowInfoWarning(Messages.ConfirmDeleteProduct) != DialogResult.Yes)
            { return; }

            var btnDelete = sender as MyButton;
            btnDelete.Enabled = false;
            btnDelete.Text = Messages.pleaseWaitText;

            var client = HttpClientHelper.Instance;
            var rout = string.Format(ApiRoutes.DeleteProduct, e.Product.Id);
            var result = await client.GetAsync<OperationResult>(rout);
            if (!result.Success)
            {
                if (!result.Result)
                {
                    btnDelete.Enabled = true;
                    btnDelete.Text = Messages.TxtbtnDelete;
                    ShowInfoError(result.Message!);
                    return;
                }
                btnDelete.Enabled = true;
                btnDelete.Text = Messages.TxtbtnDelete;
                ShowInfo(result.Message!);
                return;
            }
            btnDelete.Enabled = true;
            btnDelete.Text = Messages.TxtbtnDelete;
            ShowInfo(result.Message!);
            RefreshProduct(this, EventArgs.Empty);
        }

        List<GetProductOutputViewModel> ProductDTOs;
        public async Task GetProduct(long sellerId)
        {
            var client = HttpClientHelper.Instance;
            string rout = string
                .Format(ApiRoutes
                .GetProductBySellerId, sellerId);
            var result = await client.GetAsync<OperationResult<List<GetProductOutputViewModel>>>(rout);
            if (result == null)
            {
                ShowInfoError(Messages.InternetErrorMessage);
                return;
            }
            if (!result.Success)
            {
                if (!result.Result)
                {
                    ShowInfoError(result.Message!);
                    return;
                }
            }
            ProductDTOs = result.Data;
        }
    }
}
