using Microsoft.AspNetCore.SignalR.Client;
using SabzMarket.Http;
using SabzMarket.Share;
using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
using SabzMarket.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SabzMarket
{
    public partial class frm_Chat : FormStyle
    {
        public frm_Chat()
        {
            InitializeComponent();
        }
        private HubConnection connection;
        void ReadMessage(List<GetMessageOutputViewModel> message)
        {
            foreach (var item in message)
            {
                if (item.FromUserId == CurrentUser.UserId)
                {
                    UC_Messege uc_messege = new UC_Messege();
                    UC_Empty uC_Empty = new UC_Empty();
                    GetMessageOutputViewModel viewModel = new GetMessageOutputViewModel()
                    {
                        Message = item.Message!
                    };
                    uc_messege.Messege = viewModel;
                    pnlSent.Controls.Add(uc_messege);
                    pnlReceived.Controls.Add(uC_Empty);
                }
                else
                {
                    UC_ReceivedMessege uC_ReceivedMessege = new UC_ReceivedMessege();
                    UC_Empty uC_Empty = new UC_Empty();
                    GetMessageOutputViewModel viewModel = new GetMessageOutputViewModel()
                    {
                        Message = item.Message!
                    };
                    uC_ReceivedMessege.Messege = viewModel;
                    pnlReceived.Controls.Add(uC_ReceivedMessege);
                    pnlSent.Controls.Add(uC_Empty);
                }
            }
            pnlSent.VerticalScroll.Value = pnlSent.VerticalScroll.Maximum;
            pnlSent.PerformLayout();
            pnlReceived.VerticalScroll.Value = pnlReceived.VerticalScroll.Maximum;
            pnlReceived.PerformLayout();
        }
        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text != "")
            {
                if (receiverUserId != 0)
                {
                    string receiverUserName = this.receiverUserName;
                    string messageText = txtMessage.Text;
                    string senderUsername = CurrentUser.UserName!;

                    var client = HttpClientHelper.Instance;

                    SendMessageInputViewModel messageTable = new SendMessageInputViewModel()
                    {
                        FromUserId = CurrentUser.UserId,
                        ToUserId = receiverUserId,
                        Message = messageText,
                        IsDeleted = false,
                        IsFile = false,
                        IsRead = false,
                        SentAt = DateTime.Now
                    };

                    await client.PostAsync<OperationResult, SendMessageInputViewModel>(ApiRoutes.SendMessage, messageTable);
                    UC_Messege uc_messege = new UC_Messege();
                    UC_Empty uC_Empty = new UC_Empty();
                    GetMessageOutputViewModel info = new GetMessageOutputViewModel()
                    {
                        Message = txtMessage.Text,
                    };
                    uc_messege.Messege = info;
                    pnlSent.Controls.Add(uc_messege);
                    pnlReceived.Controls.Add(uC_Empty);
                    pnlSent.VerticalScroll.Value = pnlSent.VerticalScroll.Maximum;
                    pnlSent.PerformLayout();
                    pnlReceived.VerticalScroll.Value = pnlReceived.VerticalScroll.Maximum;
                    pnlReceived.PerformLayout();
                    txtMessage.Clear();

                    if (connection.State == HubConnectionState.Connected)
                    {
                        try
                        {

                            await connection.InvokeAsync("SendPrivateMessage", receiverUserName, messageText, senderUsername);

                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show($"Error sending message: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Not connected to the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSend_Click(sender, EventArgs.Empty);
            }
        }
        string receiverUserName;
        long receiverUserId;
        private async void frm_Chat_Load(object sender, EventArgs e)
        {
            var client = HttpClientHelper.Instance;
            var route = string.Format(ApiRoutes.FindUsersChattedWithId, CurrentUser.UserId);
            var message = await client.GetAsync<OperationResult<List<findUsersChattedOutputViewModel>>>(route);
            if (message.Data != null)
            {
                foreach (var item in message.Data)
                {
                    UC_Member uC_Member = new UC_Member();
                    uC_Member.User = item;
                    uC_Member.UC_Member_OpenChat += UC_Member_UC_Member_OpenChat; ; ;
                    pnlUser.Controls.Add(uC_Member);
                }
            }

            this.ActiveControl = txtMessage;

            pnlSent.VerticalScroll.Value = pnlSent.VerticalScroll.Maximum;
            pnlSent.PerformLayout();
            pnlReceived.VerticalScroll.Value = pnlReceived.VerticalScroll.Maximum;
            pnlReceived.PerformLayout();
            var chatUrl = $"{RouteConstants.BaseUrl}chatHub";
            connection = new HubConnectionBuilder()
                                .WithUrl(chatUrl)
                                .WithAutomaticReconnect()
                                .Build();


            connection.On<string, string>("ReceivePrivateMessage", (messageText, senderUsername) =>
            {
                if (senderUsername == receiverUserName)
                {
                    this.Invoke(() =>
                    {
                        UC_ReceivedMessege uC_ReceivedMessege = new UC_ReceivedMessege();
                        UC_Empty uC_Empty = new UC_Empty();
                        GetMessageOutputViewModel messegeInfo = new GetMessageOutputViewModel()
                        {
                            Message = messageText
                        };
                        uC_ReceivedMessege.Messege = messegeInfo;
                        pnlReceived.Controls.Add(uC_ReceivedMessege);
                        pnlSent.Controls.Add(uC_Empty);
                        pnlReceived.VerticalScroll.Value = pnlReceived.VerticalScroll.Maximum;
                        pnlReceived.PerformLayout();
                        pnlSent.VerticalScroll.Value = pnlSent.VerticalScroll.Maximum;
                        pnlSent.PerformLayout();
                    });
                }
            });

            connection.On<string, string>("UserStatusChanged", (username, status) =>
            {
                if (username == receiverUserName)
                {
                    this.Invoke(() =>
                    {
                        lblStatus.Text = $"{status}";
                    });
                }
            });

            try
            {
                await connection.StartAsync();
                await Task.Delay(200);
                await connection.InvokeAsync("SetUserId", CurrentUser.UserName!.ToString());
                MessageBox.Show("Connected to server");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error: " + ex.Message);
            }
        }

        private async void UC_Member_UC_Member_OpenChat(object? sender, UserInfoEventArgs e)
        {
            pnlTitle.Visible = true;
            pnlMessage.Visible = true;
            tableLayoutPanel1.Visible = true;
            var result = await connection.InvokeAsync<bool>("IsOnlineUser", e.User!.Username);
            if (result)
            {
                lblStatus.Text = "online";
            }
            else
            {
                lblStatus.Text = "Offline";
            }
            lblName.Text = $"{e.User!.Firstname} {e.User.Lastname}";
            receiverUserName = e.User.Username!;
            receiverUserId = e.User.Id;

            var client = HttpClientHelper.Instance;
            var rout = string.Format(ApiRoutes.GetMessage, CurrentUser.UserId, e.User.Id);
            var message = await client.GetAsync<OperationResult<List<GetMessageOutputViewModel>>>(rout);
            ReadMessage(message.Data);
        }

        private async void frm_Chat_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (connection != null)
            {
                await connection.DisposeAsync();
            }
        }

        private void pnlReceived_Scroll(object sender, ScrollEventArgs e)
        {
            if (pnlSent.VerticalScroll.Visible)
            {

                if (pnlReceived.VerticalScroll.Maximum > 0)
                {
                    double scrollRatio = (double)e.NewValue / pnlReceived.VerticalScroll.Maximum;
                    int newValueForPanel2 = (int)(scrollRatio * pnlSent.VerticalScroll.Maximum);


                    pnlSent.VerticalScroll.Value = newValueForPanel2;
                    pnlSent.PerformLayout();
                }
            }
        }

        private void pnlSent_Scroll(object sender, ScrollEventArgs e)
        {
            if (pnlReceived.VerticalScroll.Visible)
            {

                if (pnlSent.VerticalScroll.Maximum > 0)
                {
                    double scrollRatio = (double)e.NewValue / pnlSent.VerticalScroll.Maximum;
                    int newValueForPanel2 = (int)(scrollRatio * pnlReceived.VerticalScroll.Maximum);


                    pnlReceived.VerticalScroll.Value = newValueForPanel2;
                    pnlReceived.PerformLayout();
                }
            }
        }
    }
}
