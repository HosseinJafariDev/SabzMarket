using HttpClientToCurl.Utility;
using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
using SabzMarketBuyer.UI.Auth;
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
    public partial class UCProductMain : UserControl
    {
        public UCProductMain()
        {
            InitializeComponent();
        }
        public GetProductOutputViewModel Product { get; set; }
        public event EventHandler<ProductEventArgs<UCProductMain>> AddToCart;
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            AddToCartInputViewModel cartItemDTO = new AddToCartInputViewModel()
            {
                FarmerId = CurrentUser.FarmerId,
                ProductId = Product.Id,
                AddedDate = DateTime.Now
            };
            ProductEventArgs<UCProductMain> productEventArgs = new ProductEventArgs<UCProductMain>()
            {
                CartItemDTO = cartItemDTO
                ,uCProduct=this
            };
            AddToCart?.Invoke(sender, productEventArgs);
        }

        public void UCProduct_Load(object sender, EventArgs e)
        {
            pbImage.LoadAsync(Product.ImageProduct);
            lblDescription.Text = Product.Description;
            lblName.Text = Product.Name;
            lblPrice.Text = Product.Price.ToString("N0");
            lblNumber.Text = Product.Number.ToString();
            if (Product.Number == 0)
            {
                btnAddToCart.Enabled = false;
            }
        }
        public event EventHandler<SellerEventArgs> ShowSellerPage;
        private void btnShowSellerPage_Click(object sender, EventArgs e)
        {
            SellerEventArgs sellerEventArgs = new SellerEventArgs()
            {
                SellerId = Product.SellerId

            };

            ShowSellerPage?.Invoke(this, sellerEventArgs);
        }

        private void pbImage_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                pbImage.Image = Properties.Resources.defultprodect;
            }
        }
    }
}
