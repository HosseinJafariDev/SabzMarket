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
    public partial class FrmFarmerProfile : FormStyle
    {
        public FrmFarmerProfile()
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
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png"; ;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathImage = openFileDialog.FileName;
                pbProfile.ImageLocation = pathImage;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            CreateFarmerInputViewModel farmer;
            int LandArea;
            var landAreaIsInt = int.TryParse(txtLandArea.Text, out LandArea);
            if (!landAreaIsInt)
            {
                farmer = new CreateFarmerInputViewModel()
                {
                    Address = txtAddress.Text,
                    CodePosti = txtCodePosti.Text,
                    CodParvaneBHB = txtCodParvaneBHB.Text,
                    DataBuilt = txtDataBuilt.Text,
                    NationalCode = txtNationalCode.Text,
                    ProfileImage = pathImage,
                };
                if (!farmer.IsValid)
                {
                    ShowInfo(farmer.ErrorMessage);
                    return;
                }
            }

            farmer = new CreateFarmerInputViewModel()
            {
                Address = txtAddress.Text,
                CodePosti = txtCodePosti.Text,
                CodParvaneBHB = txtCodParvaneBHB.Text,
                DataBuilt = txtDataBuilt.Text,
                NationalCode = txtNationalCode.Text,
                ProfileImage = pathImage,
                LandArea=LandArea
            };

            if (!farmer.IsValid)
            {
                ShowInfo(farmer.ErrorMessage);
                return;
            }
            btnSave.Enabled = false;
            btnSave.Text = Messages.pleaseWaitText;
            var client = HttpClientHelper.Instance;
            var rout = string.Format(ApiRoutes.CreateFarmer, CurrentUser.UserName);
            var result = await client.PostWithFileAsync<OperationResult, CreateFarmerInputViewModel>(rout, pathImage, farmer);
            if (result == null)
            {
                btnSave.Enabled = true;
                btnSave.Text = Messages.Save;
                ShowInfoError(Messages.InternetErrorMessage);
                return;
            }
            if (!result.Success)
            {
                btnSave.Enabled = true;
                btnSave.Text = Messages.Save;
                ShowInfoError(result.Message!);
                return;
            }
            btnSave.Enabled = true;
            btnSave.Text = Messages.Save;
            ShowInfo(result.Message!);
            FrmMain frmMain=new FrmMain();
            frmMain.Show();
            this.Hide();
        }
    }
}
