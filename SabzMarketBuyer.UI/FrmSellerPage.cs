using SabzMarket.Share;
using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
using SabzMarketBuyer.UI.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SabzMarketBuyer.UI
{
    public partial class FrmSellerPage : FormStyle
    {
        public FrmSellerPage()
        {
            InitializeComponent();
        }
        public long SellerId { get; set; }
        GetSellerOutputViewModel getSellerOutputViewModel { get; set; }
        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                ShowInfo("عکس بارگذاری نشد");
                pbProfile.Image = Properties.Resources.profile;
            }
        }
        private void RenderProduct(List<GetProductOutputViewModel> products)
        {
            pnlShowProduct.Controls.Clear();
            foreach (var product in products)
            {
                UcProductPage uC_Products = new UcProductPage();
                uC_Products.AddToCart += UC_Products_AddToCart;
                uC_Products.Product = product;
                pnlShowProduct.Controls.Add(uC_Products);
            }
        }

        private async void UC_Products_AddToCart(object? sender, ProductEventArgs<UcProductPage> e)
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
            e.uCProduct.UcProductPage_Load(null, e);
        }

        private async void FrmSellerPage_Load(object sender, EventArgs e)
        {
            var cliet = HttpClientHelper.Instance;
            var sellerRout = string.Format(ApiRoutes.GetSellerById, SellerId);
            var seller = await cliet.GetAsync<OperationResult<GetSellerOutputViewModel>>(sellerRout);
            if (seller == null)
            {
                ShowInfoError(Messages.InternetErrorMessage);
                return;
            }
            if (!seller.Success)
            {
                ShowInfoError(seller.Message!);
                return;
            }
            getSellerOutputViewModel = seller.Data;
            lblAddress.Text = seller.Data.Address;
            lblName.Text = $"{seller.Data.FirstName} {seller.Data.LastName}";
            lblWorkHistory.Text = seller.Data.WorkHistory;
            lblUsername.Text = seller.Data.Username;
            pbProfile.LoadAsync(seller.Data.ProfileImage);
            var productRout = string.Format(ApiRoutes.GetProductBySellerId, SellerId);
            var product = await cliet.GetAsync<OperationResult<List<GetProductOutputViewModel>>>(productRout);
            if (product == null)
            {
                ShowInfoError(Messages.InternetErrorMessage);
                return;
            }
            if (!product.Success)
            {
                ShowInfoError(product.Message!);
                return;
            }
            RenderProduct(product.Data);
        }
        public event EventHandler LoodFormMain;
        private void FrmSellerPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoodFormMain?.Invoke(this, e);
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            FrmChat frmChat = new FrmChat();
            findUsersChattedOutputViewModel findUsers = new findUsersChattedOutputViewModel()
            {
                Firstname = getSellerOutputViewModel.FirstName,
                Lastname = getSellerOutputViewModel.LastName,
                Id = getSellerOutputViewModel.UserId,
                ProfileImage = getSellerOutputViewModel.ProfileImage,
                Username = getSellerOutputViewModel.Username
            };
            frmChat.user = findUsers;
            frmChat.openFromSellerPage = true;
            frmChat.ShowDialog();
        }
    }
}
