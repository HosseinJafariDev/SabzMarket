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
    public partial class FrmSettings : FormStyle
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void pbProfile_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(pbProfile, "لطفا برای انتخاب عکس کلیک کنید.");
        }
        string pathImage;

        private void pbProfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathImage = openFileDialog.FileName;
                pbProfile.ImageLocation = pathImage;
            }
        }
        public event EventHandler LoodPanel;
        private async void btnSave_Click(object sender, EventArgs e)
        {
            var client = HttpClientHelper.Instance;
            var farmer = new UpdateFarmerInputViewModel()
            {
                Address = txtAddress.Text,
                CodePosti = txtCodePosti.Text,
                FirstName = txtFirstname.Text,
                Email = txtEmail.Text,
                LastName = txtLastname.Text,
                Password = txtPassword.Text,
                NewUsername = txtUsername.Text,
                Phone = txtPhone.Text,
                ProfileImage = pathImage,
                FarmerId = CurrentUser.FarmerId,
                UserId = CurrentUser.UserId,
                CurrentUsername = CurrentUser.UserName
            };
            if (!farmer.IsValid)
            {
                ShowInfo(farmer.ErrorMessage);
                return;
            }
            btnSave.Enabled = false;
            btnSave.Text = Messages.pleaseWaitText;
            var rout = string.Format(ApiRoutes.UpdateFarmer, CurrentUser.UserName);
            var result = await client.PostWithFileAsync<OperationResult, UpdateFarmerInputViewModel>(rout, pathImage, farmer);
            if (result == null)
            {
                btnSave.Enabled = true;
                btnSave.Text = Messages.Save;
                ShowInfoError(Messages.InternetErrorMessage);
                return;
            }
            if (!result.Success)
            {
                if (!result.Result)
                {
                    btnSave.Enabled = true;
                    btnSave.Text = Messages.Save;
                    ShowInfoError(result.Message!);
                    return;
                }
                btnSave.Enabled = true;
                btnSave.Text = Messages.Save;
                ShowInfo(result.Message!);
                return;
            }
            btnSave.Enabled = true;
            btnSave.Text = Messages.Save;
            ShowInfo(result.Message!);
            LoodPanel?.Invoke(this, EventArgs.Empty);
        }
        private async void FrmSettings_Load(object sender, EventArgs e)
        {
            var client = HttpClientHelper.Instance;
            var rout = string.Format(ApiRoutes.GetFarmerFullByUsername, CurrentUser.UserName);
            var result = await client.GetAsync<OperationResult<GetFarmerByUsernameOutputViewModel>>(rout);
            if (result == null)
            {
                ShowInfoError(Messages.InternetErrorMessage);
                return;
            }
            if (!result.Success)
            {
                ShowInfoError(result.Message!);
                return;
            }
            txtAddress.Text = result.Data.Address;
            txtCodePosti.Text = result.Data.CodePosti;
            txtEmail.Text = result.Data.Email;
            txtFirstname.Text = result.Data.FirstName;
            txtLastname.Text = result.Data.LastName;
            txtPassword.Text = result.Data.Password;
            txtPhone.Text = result.Data.Phone;
            txtUsername.Text = result.Data.UserName;
            pbProfile.LoadAsync(result.Data.ProfileImage);
            pathImage = result.Data.ProfileImage!;
        }
    }
}
