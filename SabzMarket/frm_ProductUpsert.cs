using SabzMarket.Http;
using SabzMarket.Share;
using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
using SabzMarket.UI.Properties;
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
    public partial class frm_ProductUpsert : FormStyle
    {
        public frm_ProductUpsert()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(pb_Products, "لطفا برای انتخاب عکس کلیک کنید.");
        }
        public event EventHandler RefreshProduct;
        private async void btn_Add_Click(object sender, EventArgs e)
        {
            btn_Add.Enabled = false;
            int price, number;
            bool convertPrice = int.TryParse(txt_Price.Text.Replace(",", ""), out price);
            bool convertNumber = int.TryParse(txt_Number.Text.Replace(",", ""), out number);
            UpdateProductInputViewModel productViewModel = new UpdateProductInputViewModel
            {
                CategorieId = (long)cmb_Categorie.SelectedValue!,
                Description = txt_Description.Text,
                Name = txt_Name.Text,
                Price = price,
                ImageProduct = path
                ,
                Number = number
                ,
                SellerId = CurrentUser.SellerId
            };

            if (btn_Add.Text == "ویرایش")
            {
                productViewModel.Id = Product.Id;
                if (productViewModel.IsValid)
                {
                    btn_Add.Text = Messages.pleaseWaitText;
                    var client = HttpClientHelper.Instance;
                    var result = await client
                        .PostAsync<OperationResult, UpdateProductInputViewModel>(ApiRoutes.UpdateProduct, productViewModel);
                    if (!result.Success)
                    {
                        btn_Add.Enabled = true;
                        btn_Add.Text = Messages.TextUpdate;
                        ShowInfoError(result.Message!);
                        return;
                    }
                    btn_Add.Enabled = true;
                    btn_Add.Text = Messages.TextUpdate;
                    ShowInfo(result.Message!);
                    RefreshProduct?.Invoke(this, EventArgs.Empty);
                    return;
                }
                btn_Add.Enabled = true;
                btn_Add.Text = Messages.TextUpdate;
                ShowInfo(productViewModel.ErrorMessage);
                return;
            }

            if (productViewModel.IsValid)
            {
                CreateProductInputViewModel createproductViewModel = new CreateProductInputViewModel
                {
                    CategoryId = (long)cmb_Categorie.SelectedValue!,
                    Description = txt_Description.Text,
                    Name = txt_Name.Text,
                    Price = price,
                    ImageProduct = path
                ,
                    Number = number
                ,
                    SellerId = CurrentUser.SellerId
                };
                btn_Add.Text = Messages.pleaseWaitText;
                var client = HttpClientHelper.Instance;
                var result = await client
                    .PostAsync<OperationResult, CreateProductInputViewModel>(ApiRoutes.CreateProduct, createproductViewModel);
                if (!result.Success)
                {
                    if (!result.Result)
                    {
                        btn_Add.Enabled = true;
                        btn_Add.Text = Messages.TextAdd;
                        ShowInfoError(result.Message!);
                        return;
                    }
                    btn_Add.Enabled = true;
                    btn_Add.Text = Messages.TextAdd;
                    ShowInfo(result.Message!);
                    return;
                }
                btn_Add.Enabled = true;
                btn_Add.Text = Messages.TextAdd;
                Clear();
                ShowInfo(result.Message!);
                RefreshProduct?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                ShowInfo(productViewModel.ErrorMessage);
            }

        }
        void Clear()
        {
            txt_Description.Clear();
            txt_Name.Clear();
            txt_Price.Clear();
            txt_Number.Clear();
            pb_Products.Image = Resources.product;
        }
        private void myTextBox3_TextChanged(object sender, EventArgs e)
        {

            int selectionStart = txt_Price.SelectionStart;

            string plainText = txt_Price.Text.Replace(",", "").Replace(".", "");

            if (!long.TryParse(plainText, out long value))
            { }

            txt_Price.Text = string.Format("{0:N0}", value);

            txt_Price.SelectionStart = txt_Price.Text.Length;
        }

        private void txt_Price_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9) &&
                (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) &&
                (e.KeyCode != Keys.Back))
            {
                e.SuppressKeyPress = true;
            }
        }



        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        string path;
        private void pb_Products_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Title = "انتخاب عکس";
            openFileDialog1.Filter = "Image.JPG|*.jpg|Image.JPEG|*.jpeg|Image.PNG|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                pb_Products.ImageLocation = path;
            }
            else
            {
                if (path == null)
                    ShowInfo(Messages.photoNotSelected);
            }
        }
        public bool IsEdit { get; set; } = false;
        public GetProductOutputViewModel Product { get; set; }
        private async void frm_AddProducts_Load(object sender, EventArgs e)
        {
            var client = HttpClientHelper.Instance;
            var result = await client.GetAsync<OperationResult<List<GetAllCategoriesOutputViewModel>>>(ApiRoutes.GetCategori);
            cmb_Categorie.DataSource = result.Data;
            cmb_Categorie.DisplayMember = "Name";
            cmb_Categorie.ValueMember = "Id";
            if (IsEdit)
            {
                path = Product.ImageProduct!;
                txt_Name.Text = Product.Name;
                txt_Description.Text = Product.Description;
                txt_Number.Text = Product.Number.ToString();
                cmb_Categorie.SelectedValue = Product.CategorieId;
                txt_Price.Text = Product.Price.ToString("N0");
                pb_Products.LoadAsync(Product.ImageProduct);
                btn_Add.Text = "ویرایش";
            }
        }

        private void txt_Number_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9) &&
                (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) &&
                (e.KeyCode != Keys.Back))
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
