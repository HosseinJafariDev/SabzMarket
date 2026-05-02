using SabzMarket.Http;
using SabzMarket.Share;
using SabzMarket.Share.Enums;
using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
using SabzMarket.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SabzMarket
{
    public partial class frm_Orders : FormStyle
    {
        public frm_Orders()
        {
            InitializeComponent();
        }

       
        private void btn_History_Click(object sender, EventArgs e)
        {
            frm_History frm_History = new frm_History();
            frm_History.ShowDialog();
        }
        List<GetOrdersForSellerOutputViewModel> FullOrsers;
        public async Task GetOrder( string search = "")
        {
            var client = HttpClientHelper.Instance;
            string rout = string
                .Format(ApiRoutes
                .GetPendingOrdersForSeller, CurrentUser.SellerId, Uri.EscapeDataString(search));
            var result = await client.GetAsync<OperationResult<List<GetOrdersForSellerOutputViewModel>>>(rout);
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
                ShowInfo(result.Message!);
                return;
            }
                FullOrsers = result.Data;
        }


        private async void frm_Orders_Load(object sender, EventArgs e)
        {
            await GetOrder();
            if (FullOrsers != null||FullOrsers!.Count!=0)
                RenderOrders(FullOrsers);
        }

        private void Orders_ShowBuyerDetails1(object? sender, BuyerDetailsEventArgs e)
        {
            frm_BuyerDetails frm_BuyerDetails = new frm_BuyerDetails();
            frm_BuyerDetails.farmer = e.FarmerViewModel!;
            frm_BuyerDetails.ShowDialog();
        }


        private void RenderOrders(List<GetOrdersForSellerOutputViewModel> orders)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var order in orders)
            {
                UC_Orders uC_Orders = new UC_Orders();
                uC_Orders.ShowBuyerDetails += Orders_ShowBuyerDetails1;
                uC_Orders.SentOrder += UC_Orders_SentOrder;
                uC_Orders.RejectOrder += UC_Orders_RejectOrder;
                uC_Orders.Order = order;
                flowLayoutPanel1.Controls.Add(uC_Orders);
            }
        }

        private async void UC_Orders_RejectOrder(object? sender, OrderDetailEventArgs e)
        {
            var btnReject = sender as MyButton;
            btnReject.Enabled = false;
            btnReject.Text = Messages.pleaseWaitText;
            var client = HttpClientHelper.Instance;
            string rout = string
                .Format(
                ApiRoutes.OrderDetailRejected,
                e.orderDTO.OrderDetailId,
                e.orderDTO.Number,
                e.orderDTO.OrderId
                );
            var result = await client.GetAsync<OperationResult>(rout);
            if (!result.Success)
            {
                if (!result.Result)
                {
                    btnReject.Enabled = true;
                    btnReject.Text = Messages.TextBtnReject;
                    ShowInfoError(result.Message!);
                    return;
                }
                btnReject.Enabled = true;
                btnReject.Text = Messages.TextBtnReject;
                ShowInfo(result.Message!);
                return;
            }
            btnReject.Enabled = true;
            btnReject.Text = Messages.TextBtnReject;
            ShowInfo(result.Message!);
            e.C_Orders.UpdateStatusUI(OrderStatus.Rejected.ToString());

        }

        private async void UC_Orders_SentOrder(object? sender, OrderDetailEventArgs e)
        {
            var btnSent=sender as MyButton;
            btnSent.Enabled = false;
            btnSent.Text = Messages.pleaseWaitText;
            var client = HttpClientHelper.Instance;
            string rout = string.Format(ApiRoutes.OrderDetailSent, e.orderDTO.OrderDetailId);
            var result = await client.GetAsync<OperationResult>(rout);
            if (!result.Success)
            {
                if (!result.Result)
                {
                    btnSent.Enabled = true;
                    btnSent.Text = Messages.TextBtnSent;
                    ShowInfoError(result.Message!);
                    return;
                }
                btnSent.Enabled = true;
                btnSent.Text = Messages.TextBtnSent;
                ShowInfo(result.Message!);
                return;
            }
            btnSent.Enabled = true;
            btnSent.Text = Messages.TextBtnSent;
            ShowInfo(result.Message!);
            e.C_Orders.UpdateStatusUI(OrderStatus.Sent.ToString());
        }

        private async void btn_Search_Click(object sender, EventArgs e)
        {
            if (txt_Search.Text == "")
            {
                await GetOrder();
                if (FullOrsers != null || FullOrsers!.Count != 0)
                    RenderOrders(FullOrsers);
            }
            else
            {
                if (FullOrsers != null||FullOrsers!.Count!=0)
                {
                    RenderOrders(FullOrsers
                        .Where(o => o
                        .ProductName!
                        .Contains(txt_Search.Text) || o
                        .FirstName!
                        .Contains(txt_Search.Text) || o
                        .LastName!
                        .Contains(txt_Search.Text))
                        .ToList());
                }
            }
        }
    }
}
