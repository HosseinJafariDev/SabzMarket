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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SabzMarketBuyer.UI
{
    public partial class FrmLogin : FormStyle
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            btnLogin.Text = Messages.pleaseWaitText;
            LoginInputViewModel user = new LoginInputViewModel
            {
                UserName = txtUsername.Text,
                Password = txtPassword.Text
            };
            var client = HttpClientHelper.Instance;
            var result = await client.PostAsync<OperationResult, LoginInputViewModel>(ApiRoutes.Login, user);

            if (result == null)
            {
                ShowInfoError(Messages.InternetErrorMessage);
                btnLogin.Enabled = true;
                btnLogin.Text = Messages.LoginText;
                return;
            }

            if (!result!.Success)
            {
                if (result.Result)
                {
                    ShowInfo(result.Message!);
                    btnLogin.Enabled = true;
                    btnLogin.Text = Messages.LoginText;
                    return;
                }
                ShowInfoError(result.Message!);
                btnLogin.Enabled = true;
                btnLogin.Text = Messages.LoginText;
                return;
            }
            CurrentUser.UserName = txtUsername.Text;
            string userName = Uri.EscapeDataString(txtUsername.Text);
            var rout = string.Format(ApiRoutes.CheckUserInFarmer, userName);
            var result2 = await client.GetAsync<OperationResult>(rout);
            if (result2 == null)
            {
                ShowInfoError(Messages.InternetErrorMessage);
                btnLogin.Enabled = true;
                btnLogin.Text = Messages.LoginText;
                return;
            }
            if (!result2!.Success)
            {
                if (result2.Result)
                {
                    FrmFarmerProfile frmFarmerProfile = new FrmFarmerProfile();
                    this.Hide();
                    frmFarmerProfile.Show();
                    return;
                }
                ShowInfoError(result2.Message!);
                btnLogin.Enabled = true;
                btnLogin.Text = Messages.LoginText;
                return;
            }
            FrmMain frmMain = new FrmMain();
            this.Hide();
            frmMain.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSingUp frmSingUp = new FrmSingUp();
            frmSingUp.ShowDialog();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, EventArgs.Empty);
            }
        }
    }
}
