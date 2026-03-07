using SabzMarket.Share.Mappers;
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
    public partial class UCSeller : UserControl
    {
        public UCSeller()
        {
            InitializeComponent();
        }
        public GetSellerOutputViewModel Sellers { get; set; }

        private void UCSeller_Load(object sender, EventArgs e)
        {
            pbProfileImage.LoadAsync(Sellers.ProfileImage);
            lblAddress.Text = Sellers.Address;
            lblName.Text = $"{Sellers.FirstName} {Sellers.LastName}";
        }
        public event EventHandler<SellerEventArgs> ShowSellerPage;
        private void btnShowSellerPage_Click(object sender, EventArgs e)
        {
            SellerEventArgs sellerEventArgs = new SellerEventArgs()
            {
                SellerId = Sellers.Id
            };

            ShowSellerPage?.Invoke(this, sellerEventArgs);
        }

        private void pbProfileImage_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                pbProfileImage.Image = Properties.Resources.profile;
            }
        }
    }
}
