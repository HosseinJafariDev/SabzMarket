using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
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
    public partial class UCCartProduct : UserControl
    {
        public GetCartItemByFarmerIdOutputViewModel CartItemDTo { get; set; }
        public UCCartProduct()
        {
            InitializeComponent();
        }

        private void UCCartProduct_Load(object sender, EventArgs e)
        {
            lblName.Text = CartItemDTo.ProductName;
            lblNumber.Text = CartItemDTo.Quantity.ToString();
            if (CartItemDTo.Quantity < 2)
            {
                btnDecrease.Visible = false;
            }
            lblPrice.Text = CartItemDTo.ProductPrice.ToString("N0");
            pbImage.LoadAsync(CartItemDTo.ProductImage);

        }
        public event EventHandler<ProductEventArgs<UCCartProduct>> DecreaseCart;
        private void btnDecrease_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (int.Parse(lblNumber.Text) - 1).ToString();

            ProductEventArgs<UCCartProduct> productEventArg = new ProductEventArgs<UCCartProduct>()
            {
                fullCartItemDTO = CartItemDTo,
                uCProduct = this
            };
            DecreaseCart?.Invoke(sender, productEventArg);
            if (int.Parse(lblNumber.Text) <= 1)
                btnDecrease.Visible = false;
        }
        public event EventHandler<ProductEventArgs<UCCartProduct>> DeleteCart;
        private void btnDeleteCart_Click(object sender, EventArgs e)
        {
            ProductEventArgs<UCCartProduct> productEventArgs = new ProductEventArgs<UCCartProduct>()
            {
                fullCartItemDTO = CartItemDTo,
                uCProduct = this
            };
            DeleteCart?.Invoke(sender, productEventArgs);
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
