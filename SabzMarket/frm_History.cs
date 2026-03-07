using SabzMarket.Http;
using SabzMarket.Share;
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

namespace SabzMarket
{
    public partial class frm_History : FormStyle
    {
        public frm_History()
        {
            InitializeComponent();
        }

        private void RenderOrders(List<GetOrdersForSellerOutputViewModel> orders)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var order in orders)
            {
                UC_HistoryOrders uC_History = new UC_HistoryOrders();
                uC_History.Order = order;
                uC_History.ShowBuyerDetails += UC_History_ShowBuyerDetails;
                flowLayoutPanel1.Controls.Add(uC_History);
            }
        }

        private void UC_History_ShowBuyerDetails(object? sender, BuyerDetailsEventArgs e)
        {
            frm_BuyerDetails frm_BuyerDetails = new frm_BuyerDetails();
            frm_BuyerDetails.farmer = e.FarmerViewModel!;
            frm_BuyerDetails.ShowDialog();
        }

        List<GetOrdersForSellerOutputViewModel> FullOrsers;
        public async Task GetOrder(string search = "")
        {
            var client = HttpClientHelper.Instance;
            string rout = string
                .Format(ApiRoutes
                .GetNonPendingOrdersForSeller, CurrentUser.SellerId, Uri.EscapeDataString(search));
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
        private async void frm_History_Load(object sender, EventArgs e)
        {
            await GetOrder();
            if (FullOrsers != null || FullOrsers!.Count != 0)
                RenderOrders(FullOrsers);
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
                if (FullOrsers != null || FullOrsers!.Count != 0)
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
