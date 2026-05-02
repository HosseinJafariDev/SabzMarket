using Guna.UI2.WinForms;
using SabzMarket.Http;
using SabzMarket.Share;
using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
using SabzMarket.UI;
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
    public partial class frm_SellerProfile : FormStyle
    {

        public frm_SellerProfile()
        {
            InitializeComponent();

        }

        private void Frm_SellerProfile_Load(object sender, EventArgs e)
        {

        }

        private void phb_Profile_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(pb_Profile, "لطفا برای انتخاب عکس کلیک کنید.");
        }
        string pathImage;
        private void phb_Profile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image.JPG|*.jpg|Image.JPEG|*.jpeg|Image.PNG|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathImage = openFileDialog.FileName;
                pb_Profile.ImageLocation = pathImage;
            }
        }

        //https://localhost:7267/Seller/SignUp
        private async void btn_registration_Click(object sender, EventArgs e)
        {
            CreateSellerInputViewModel seller = new CreateSellerInputViewModel
            {
                Username = CurrentUser.UserName,
                Address = txt_Address.Text,
                ProfileImage = pathImage,
                WorkHistory = cmb_WorkHistory.Text
            };
            if (!seller.IsValid)
            {
                ShowInfo(seller.ErrorMessage);
                return;
            }
            btn_Save.Enabled = false;
            btn_Save.Text = Messages.pleaseWaitText;
            var httpClientHelper = HttpClientHelper.Instance;
            var result = await httpClientHelper
                .PostWithFileAsync<OperationResult, CreateSellerInputViewModel>(ApiRoutes.SellerFillProfile, pathImage, seller);
            if (result == null)
            {
                btn_Save.Enabled = true;
                btn_Save.Text = Messages.Save;
                ShowInfoError(Messages.InternetErrorMessage);
                return;
            }
            if (!result.Success)
            {
                if (!result.Result)
                {
                    btn_Save.Enabled = true;
                    btn_Save.Text = Messages.Save;
                    ShowInfoError(result.Message!);
                    return;
                }
                btn_Save.Enabled = true;
                btn_Save.Text = Messages.Save;
                ShowInfo(result.Message!);
                return;
            }
            MessageBox.Show(result.Message);
            frm_Home frm_Home = new frm_Home();
            frm_Home.Show();
            this.Hide();
        }
    }
}
