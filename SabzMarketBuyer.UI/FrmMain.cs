using SabzMarket.Share;
using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
using SabzMarketBuyer.UI.Auth;
using SabzMarketBuyer.UI.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SabzMarketBuyer.UI
{
    public partial class FrmMain : FormStyle
    {
        public FrmMain()
        {
            InitializeComponent();
            // pb_Profile.LoadCompleted += Pb_Profile_LoadCompleted;

            this.MouseClick += OpenClosed;
            //foreach (Control ctrl in guna2CustomGradientPanel1.Controls)
            //{
            //    ctrl.MouseClick += OpenClosed;
            //}
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != pnlHamburgerMenu && ctrl != btnShowMenu)
                    ctrl.MouseClick += OpenClosed;
            }
        }

        private void plSetting_MouseDown(object sender, MouseEventArgs e)
        {
            pnlSetting.BackColor = Color.LightGreen;
        }

        private void plSetting_MouseUp(object sender, MouseEventArgs e)
        {
            pnlSetting.BackColor = Color.PaleGreen;
        }

        private void btnSeting_Click(object sender, EventArgs e)
        {
            plSetting_Click(this, EventArgs.Empty);
        }

        private void lblSetting_Click(object sender, EventArgs e)
        {
            plSetting_Click(this, EventArgs.Empty);
        }

        private void plSetting_Click(object sender, EventArgs e)
        {
            FrmSettings frmSettings = new FrmSettings();
            frmSettings.LoodPanel += FrmSettings_LoodPanel;
            frmSettings.ShowDialog();
        }

        private async void FrmSettings_LoodPanel(object? sender, EventArgs e)
        {
            await SetUserHeaderInfo();
        }

        private void btnSeting_MouseUp(object sender, MouseEventArgs e)
        {
            plSetting_MouseUp(sender, e);
        }

        private void btnSeting_MouseDown(object sender, MouseEventArgs e)
        {
            plSetting_MouseDown(sender, e);
        }

        private void lblSetting_MouseDown(object sender, MouseEventArgs e)
        {
            plSetting_MouseDown(sender, e);
        }

        private void lblSetting_MouseUp(object sender, MouseEventArgs e)
        {
            plSetting_MouseUp(sender, e);
        }

        private void btnShowUser_Click(object sender, EventArgs e)
        {
            pnlHamburgerMenu.Visible = true;
        }
        private void OpenClosed(object sender, EventArgs e)
        {
            if (pnlHamburgerMenu.Visible)
            {
                pnlHamburgerMenu.Visible = false;
            }
        }

        private void pbProfile_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                ShowInfo("عکس بارگذاری نشد");
                pbProfile.Image = Properties.Resources.profile;
            }
        }
        public async Task SetUserHeaderInfo()
        {
            var client = HttpClientHelper.Instance;
            var rout = string.Format(ApiRoutes.GetFarmerFullByUsername, CurrentUser.UserName);
            var result = await client.GetAsync<OperationResult<GetFarmerByUsernameOutputViewModel>>(rout);
            if (result == null)
            {
                ShowInfoError(Messages.InternetErrorMessage);
                Application.Exit();
                return;
            }
            if (!result.Success)
            {
                if (!result.Result)
                {
                    ShowInfoError(result.Message!);
                    Application.Exit();
                    return;
                }
                ShowInfo(result.Message!);
                Application.Exit();
                return;
            }
            lblName.Text = $"{result.Data.FirstName} {result.Data.LastName}";
            lblUserName.Text = result.Data.UserName;
            pbProfile.LoadAsync(result.Data.ProfileImage);
            CurrentUser.UserId = result.Data.UserId;
            CurrentUser.FarmerId = result.Data.Id;
        }
        private void RenderProduct(List<GetProductOutputViewModel> products)
        {
            pnlShowProduct.Controls.Clear();
            foreach (var product in products)
            {
                UCProductMain uC_Products = new UCProductMain();
                uC_Products.Product = product;
                uC_Products.AddToCart += UC_Products_AddToCart1; ;
                uC_Products.ShowSellerPage += ShowSellerPage;
                pnlShowProduct.Controls.Add(uC_Products);
            }
        }
        private async void UC_Products_AddToCart1(object? sender, ProductEventArgs<UCProductMain> e)
        {
            var btnAddToCart = sender as Button;
            btnAddToCart.Enabled = false;
            btnAddToCart.Text = Messages.pleaseWaitText;
            var cliet = HttpClientHelper.Instance;
            var result = await cliet
                .PostAsync<OperationResult, AddToCartInputViewModel>(ApiRoutes.AddToCart, e.CartItemDTO);
            if (result == null)
            {
                btnAddToCart.Enabled = true;
                btnAddToCart.Text = Messages.TextbtnAddToCart;
                ShowInfoError(Messages.InternetErrorMessage);
                return;
            }
            if (!result.Success)
            {
                btnAddToCart.Enabled = true;
                btnAddToCart.Text = Messages.TextbtnAddToCart;
                ShowInfoError(result.Message!);
                return;
            }
            btnAddToCart.Enabled = true;
            btnAddToCart.Text = Messages.TextbtnAddToCart;
            ShowInfo(result.Message!);
            e.uCProduct.Product.Number -= 1;
            e.uCProduct.UCProduct_Load(null, e);
        }
        private void RenderSeller(List<GetSellerOutputViewModel> sellers)
        {
            pnlShowProduct.Controls.Clear();
            foreach (var seller in sellers)
            {
                UCSeller UC_Seller = new UCSeller();
                UC_Seller.ShowSellerPage += ShowSellerPage;
                UC_Seller.Sellers = seller;
                pnlShowProduct.Controls.Add(UC_Seller);
            }
        }

        private void ShowSellerPage(object? sender, SellerEventArgs e)
        {
            FrmSellerPage frmSellerPage = new FrmSellerPage();
            frmSellerPage.SellerId = e.SellerId;
            frmSellerPage.LoodFormMain += FrmSellerPage_LoodFormMain;
            frmSellerPage.ShowDialog();
        }

        private void FrmSellerPage_LoodFormMain(object? sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                myButon2_Click(sender, e);
                return;
            }
            FrmMain_Load(sender, e);
        }

        private async void FrmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            await SetUserHeaderInfo();
            await GetFeaturedSeller();
            if (sellers != null || sellers!.Count != 0)
            {
                RenderSeller(sellers);
            }
        }
        List<GetSellerOutputViewModel> sellers;
        private async Task GetFeaturedSeller()
        {
            var client = HttpClientHelper.Instance;
            var rou = ApiRoutes.GetFeaturedSeller;
            var result = await client.GetAsync<OperationResult<List<GetAllFeaturedSellerOutputViewModel>>>(rou);
            if (result == null)
            {
                ShowInfoError(result.Message!);
                return;
            }
            if (!result.Success)
            {
                if (!result.Result)
                {
                    ShowInfoError(result.Message!);
                }
                ShowInfo(result.Message!);
            }
            var seller = result.Data.Select(x => new GetSellerOutputViewModel()
            {
                Id = x.SellerId,
                Address = x.Address,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserId = x.UserId,
                ProfileImage = x.ProfileImage
            }).ToList();
            
            sellers = seller;
        }
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        List<GetProductOutputViewModel> products;
        private async void myButon2_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;
            var client = HttpClientHelper.Instance;
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                await GetFeaturedSeller();
                if (sellers != null || sellers!.Count != 0)
                {
                    RenderSeller(sellers);
                }
                btnSearch.Enabled = true;
                return;
            }
            if (rbtSearchProduct.Checked)
            {
                var routProduct = string.Format(ApiRoutes.GetProductByName, Uri.EscapeDataString(txtSearch.Text));
                var resultProduct = await client.GetAsync<OperationResult<List<GetProductOutputViewModel>>>(routProduct);
                if (resultProduct == null)
                {
                    btnSearch.Enabled = true;
                    ShowInfoError(Messages.InternetErrorMessage);
                    return;
                }
                if (!resultProduct.Success)
                {
                    if (!resultProduct.Result)
                    {
                        ShowInfoError(resultProduct.Message!);
                        btnSearch.Enabled = true;
                        return;
                    }
                    ShowInfo(resultProduct.Message!);
                }
                products = resultProduct.Data;
                if (products != null && products.Count != 0)
                {
                    RenderProduct(products);
                }
                btnSearch.Enabled = true;
                return;
            }
            var rout = string.Format(ApiRoutes.GetSellerByPhoneNumber, Uri.EscapeDataString(txtSearch.Text));
            var result = await client.GetAsync<OperationResult<List<GetSellerOutputViewModel>>>(rout);
            if (result == null)
            {
                btnSearch.Enabled = true;
                ShowInfoError(Messages.InternetErrorMessage);
                return;
            }
            if (!result.Success)
            {
                if (!result.Result)
                {
                    btnSearch.Enabled = true;
                    ShowInfoError(result.Message!);
                    return;
                }
                btnSearch.Enabled = true;
                ShowInfo(result.Message!);
                return;
            }
            sellers = result.Data;
            if (result.Data != null || result.Data!.Count != 0)
            {
                btnSearch.Enabled = true;
                RenderSeller(result.Data);
            }
        }

        private void btnShoppingCart_Click(object sender, EventArgs e)
        {
            FrmCart frmCart = new FrmCart();
            frmCart.loodFormMain += FrmCart_loodFormMain;
            frmCart.ShowDialog();
        }

        private void FrmCart_loodFormMain(object? sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                myButon2_Click(sender, e);
                return;
            }
            FrmMain_Load(sender, e);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                myButon2_Click(sender, EventArgs.Empty);
            }
        }
    }
}
