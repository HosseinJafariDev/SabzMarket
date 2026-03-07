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
    public partial class frm_BuyerDetails : FormStyle
    {
        public frm_BuyerDetails()
        {
            InitializeComponent();
        }
        public GetOrdersForSellerOutputViewModel farmer { get; set; }
        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                ShowInfo("عکس بارگذاری نشد");
                pb_ProfileBuyer.Image = Resources.profile;
            }
        }

        private void frm_BuyerDetails_Load(object sender, EventArgs e)
        {
            txt_address.Text = farmer.Address;
            txt_CodePosti.Text=farmer.CodePosti;
            txt_Phone.Text = farmer.Phone;
            pb_ProfileBuyer.LoadAsync(farmer.FarmerProfileImage);
        }
    }
}
