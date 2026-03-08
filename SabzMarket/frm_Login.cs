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
    public partial class frm_Login : FormStyle
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        private async void btn_Login_Click(object sender, EventArgs e)
        {
            btn_Login.Enabled = false;
            btn_Login.Text = Messages.pleaseWaitText;
            LoginInputViewModel user = new LoginInputViewModel
            {
                UserName = txt_UserName.Text,
                Password = txt_Password.Text
            };
            var client = HttpClientHelper.Instance;
            var result = await client.PostAsync<OperationResult, LoginInputViewModel>(ApiRoutes.Login, user);

            if (result == null)
            {
                ShowInfoError(Messages.InternetErrorMessage);
                btn_Login.Enabled = true;
                btn_Login.Text = Messages.LoginText;
                return;
            }

            if (!result.Success)
            {
                if (result.Result)
                {
                    ShowInfo(result.Message!);
                    btn_Login.Enabled = true;
                    btn_Login.Text = Messages.LoginText;
                    return;
                }
                ShowInfoError(result.Message!);
                btn_Login.Enabled = true;
                btn_Login.Text = Messages.LoginText;
                return;
            }
            CurrentUser.UserName = txt_UserName.Text;
            string userName = Uri.EscapeDataString(txt_UserName.Text);
            var rout = string.Format(ApiRoutes.CheckUserInSeller, userName);
            var result1 = await client.GetAsync<OperationResult<bool>>(rout);
            if (result1 == null)
            {
                ShowInfoError(Messages.InternetErrorMessage);
                btn_Login.Enabled = true;
                btn_Login.Text = Messages.LoginText;
                return;
            }
            if (!result1!.Success)
            {

                ShowInfoError(result1.Message!);
                btn_Login.Enabled = true;
                btn_Login.Text = Messages.LoginText;
                return;
            }

            if (!result1.Data)
            {
                frm_SellerProfile frm_SellerProfile = new frm_SellerProfile();
                this.Hide();
                frm_SellerProfile.Show();
                return;
            }
            frm_Home frm_Home = new frm_Home();
            this.Hide();
            frm_Home.Show();
        }

        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            frm_SignUp frm = new frm_SignUp();
            frm.ShowDialog();
        }

        private void txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login_Click(sender, EventArgs.Empty);
            }
        }
    }
}
