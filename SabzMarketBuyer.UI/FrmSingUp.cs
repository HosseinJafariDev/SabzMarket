using SabzMarket.Share;
using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
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
    public partial class FrmSingUp : FormStyle
    {
        public FrmSingUp()
        {
            InitializeComponent();
        }

        private async void btnSingUp_Click(object sender, EventArgs e)
        {
            btnSingUp.Enabled = false;
            btnSingUp.Text = Messages.pleaseWaitText;
            var userviewmodel = new SignUpInputViewModel()
            {
                FirstName = txtFirstname.Text,
                LastName = txtLastname.Text,
                Email = txtEmail.Text,
                UserName = txtUsername.Text,
                Password1 = txtPassword.Text,
                Password2 = txtPasswordRepeat.Text,
                Phone = txtPhone.Text
            };
            if (!userviewmodel.IsValid)
            {
                ShowInfo(userviewmodel.ErrorMessage);
                return;
            }
            var client = HttpClientHelper.Instance;
            var result = await client.PostAsync<OperationResult, SignUpInputViewModel>(ApiRoutes.SignUp, userviewmodel);
            if (result == null)
            {
                ShowInfoError(Messages.InternetErrorMessage);
                btnSingUp.Enabled = true;
                btnSingUp.Text = Messages.SingUpText;
                return;
            }
            if (!result!.Success)
            {
                if (!result.Result)
                {
                    ShowInfoError(result.Message!);
                    btnSingUp.Enabled = true;
                    btnSingUp.Text = Messages.SingUpText;
                    return;
                }
                ShowInfo(result.Message!);
                btnSingUp.Enabled = true;
                btnSingUp.Text = Messages.SingUpText;
                return;
            }
            ShowInfo(result.Message!);
            this.Close();
        }
    }
}
