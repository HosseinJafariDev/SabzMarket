using SabzMarket.Http;
using SabzMarket.Share;
using SabzMarket.Share.Models;
using SabzMarket.Share.Requests;
using SabzMarket.Share.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SabzMarket.UI.Properties;
using static Guna.UI2.WinForms.Suite.Descriptions;
using System.Resources;

namespace SabzMarket
{
    public partial class frm_Settings : FormStyle
    {

        public frm_Settings()
        {
            InitializeComponent();
        }

        private void phb_Profile_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(pb_Profile, "لطفا برای انتخاب عکس کلیک کنید.");
        }

        string pathImage = "";
        private void pb_Profile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image.JPG|*.jpg|Image.JPEG|*.jpeg|Image.PNG|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathImage = openFileDialog.FileName;
                pb_Profile.ImageLocation = pathImage;
            }
        }
        private void Pb_Profile_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                ShowInfo("عکس بارگذاری نشد");
                pb_Profile.Image = Resources.profile;
            }
        }

        private async void frm_Settings_Load(object sender, EventArgs e)
        {
            var client = HttpClientHelper.Instance;
            string username = Uri.UnescapeDataString(CurrentUser.UserName!);
            string route = string.Format(ApiRoutes.GetSellerByUsername, username);
            var seller = await client
                .GetAsync<OperationResult<GetSellerOutputViewModel>>(route);

            if (seller == null)
            {
                ShowInfoError(Messages.InternetErrorMessage);
                return;
            }

            if (!seller.Success)
            {
                if (!seller.Result)
                {
                    ShowInfoError(seller.Message!);
                    return;
                }
                ShowInfo(seller.Message!);
                return;
            }

            pb_Profile.LoadAsync(seller.Data.ProfileImage);
            pathImage = seller.Data.ProfileImage!;
            txt_FirstName.Text = seller.Data.FirstName;
            txt_LastName.Text = seller.Data.LastName;
            txt_Phone.Text = seller.Data.Phone;
            txt_Email.Text = seller.Data.Email;
            txt_UserName.Text = seller.Data.Username;
            txt_Password.Text = seller.Data.Password;
            txt_Address.Text = seller.Data.Address;
            cmb_WorkHistory.Text = seller.Data.WorkHistory;
        }
        public event EventHandler LoodPanel;

        private async void btn_Update_Click(object sender, EventArgs e)
        {
            var client = HttpClientHelper.Instance;
            string route = string.Format(ApiRoutes.UpdateSeller, CurrentUser.UserName);
            SellerUpdateInputViewModel sellerUpdate = new SellerUpdateInputViewModel
            {
                UserId = CurrentUser.UserId,
                FirstName = txt_FirstName.Text,
                LastName = txt_LastName.Text,
                Phone = txt_Phone.Text,
                Email = txt_Email.Text,
                NewUsername = txt_UserName.Text,
                CurrentUsername = CurrentUser.UserName,
                Password = txt_Password.Text,
                Id = CurrentUser.SellerId,
                Address = txt_Address.Text,
                ProfileImage = pathImage,
                WorkHistory = cmb_WorkHistory.Text
            };
            if (!sellerUpdate.IsValid)
            {
                ShowInfo(sellerUpdate.ErrorMessage);
                return;
            }

            btn_Update.Enabled = false;
            btn_Update.Text = Messages.pleaseWaitText;
            var result = await client.PostAsync<OperationResult, SellerUpdateInputViewModel>(route, sellerUpdate);
            if (result == null)
            {
                btn_Update.Enabled = true;
                btn_Update.Text = Messages.TextUpdate;
                ShowInfoError(Messages.InternetErrorMessage);
                return;
            }
            if (!result.Success)
            {
                if (!result.Result)
                {
                    btn_Update.Enabled = true;
                    btn_Update.Text = Messages.TextUpdate;
                    ShowInfoError(result.Message!);
                    return;
                }
                btn_Update.Enabled = true;
                btn_Update.Text = Messages.TextUpdate;
                ShowInfo(result.Message);
                return;
            }
            btn_Update.Enabled = true;
            btn_Update.Text = Messages.TextUpdate;
            ShowInfo(result.Message!);
            LoodPanel?.Invoke(this, EventArgs.Empty);
            CurrentUser.UserName = txt_UserName.Text;
        }

        private void pb_Profile_LoadCompleted_1(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                ShowInfo("عکس بارگذاری نشد");
                pb_Profile.Image = Resources.profile;
            }
        }
    }
}
