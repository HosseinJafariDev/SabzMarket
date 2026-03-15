using SabzMarket.Share.Enums;
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
    public partial class UC_Orders : UserControl
    {
        public UC_Orders()
        {
            InitializeComponent();
        }
        public GetOrdersForSellerOutputViewModel Order { get; set; }
        public event EventHandler<BuyerDetailsEventArgs> ShowBuyerDetails;
        private void pb_Image_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                pb_Image.Image = Resources.DefultProduct;
            }
        }

        private void UC_Orders_Load(object sender, EventArgs e)
        {
            lbl_Name.Text = $"{Order.FirstName} {Order.LastName}";
            lbl_Number.Text = Order.Number.ToString();
            lbl_ProductName.Text = Order.ProductName;
            pb_Image.LoadAsync(Order.ImageProduct);
        }

        private void btn_Details_Click(object sender, EventArgs e)
        {
            BuyerDetailsEventArgs buyerDetails = new BuyerDetailsEventArgs();
            buyerDetails.FarmerViewModel = Order;
            ShowBuyerDetails?.Invoke(this, buyerDetails);
        }
        public event EventHandler<OrderDetailEventArgs> RejectOrder;
        public event EventHandler<OrderDetailEventArgs> SentOrder;
        private void btn_Reject_Click(object sender, EventArgs e)
        {
            OrderDetailEventArgs orderDetail = new OrderDetailEventArgs(Order,this);
            RejectOrder?.Invoke(sender, orderDetail);
        }
        public void UpdateStatusUI(string status)
        {
            lbl_Status.Text = status;

            if (status == OrderStatus.Sent.ToString())
            {
                lbl_Status.Text = "ارسال شده";
                lbl_Status.ForeColor = Color.Green;
                btn_Sent.Visible = false;
                btn_Reject.Visible = false;
            }
            else
            {
                lbl_Status.ForeColor = Color.Red;
                lbl_Status.Text = "رد شده";
                btn_Sent.Visible = false;
                btn_Reject.Visible = false;
            }
        }
        private void btn_Sent_Click(object sender, EventArgs e)
        {
            OrderDetailEventArgs orderDetail = new OrderDetailEventArgs(Order,this);
            SentOrder?.Invoke(sender, orderDetail);
        }
    }
}
