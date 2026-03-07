using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SabzMarket.Share;
using SabzMarket.Share.ViewModels;
using SabzMarket.Share.Models;
using SabzMarket.Http;





namespace SabzMarket
{
    public partial class frm_SignUp : FormStyle
    {

        public frm_SignUp()
        {
            InitializeComponent();
        }


        private void frm_SignUp_Load(object sender, EventArgs e)
        {


        }

        private async void btn_SignUp_Click(object sender, EventArgs e)
        {
            btn_SignUp.Enabled = false;
            btn_SignUp.Text = Messages.pleaseWaitText;
            var signUpInputViewModel = new SignUpInputViewModel()
            {
                FirstName = txt_FirstName.Text,
                LastName = txt_LastName.Text,
                Email = txt_Email.Text,
                UserName = txt_UserName.Text,
                Password1 = txt_Password1.Text,
                Password2 = txt_Password2.Text,
                Phone = txt_Phone.Text
            };
            if (!signUpInputViewModel.IsValid)
            {
                ShowInfo(signUpInputViewModel.ErrorMessage);
                btn_SignUp.Enabled = true;
                btn_SignUp.Text = Messages.SingUpText;
                return;
            }
            var client = HttpClientHelper.Instance;
            var result = await client.PostAsync<OperationResult, SignUpInputViewModel>(ApiRoutes.SignUp, signUpInputViewModel);
            if (result == null)
            {
                ShowInfoError(Messages.InternetErrorMessage);
                btn_SignUp.Enabled = true;
                btn_SignUp.Text = Messages.SingUpText;
                return;
            }
            if (!result!.Success)
            {
                if (!result.Result)
                {
                    ShowInfoError(result.Message!);
                    btn_SignUp.Enabled = true;
                    btn_SignUp.Text = Messages.SingUpText;
                    return;
                }
                ShowInfo(result.Message!);
                btn_SignUp.Enabled = true;
                btn_SignUp.Text = Messages.SingUpText;
                return;
            }
            ShowInfo(result.Message!);
            this.Close();
        }
    }
}
