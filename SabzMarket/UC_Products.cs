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
    public partial class UC_Products : UserControl
    {
        public GetProductOutputViewModel Product { get; set; }
        public UC_Products()
        {
            InitializeComponent();
        }

        public event EventHandler<ProductEventArgs> Delete;
        public event EventHandler<ProductEventArgs> Edit;
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            ProductEventArgs product = new ProductEventArgs(Product);
            Delete?.Invoke(sender, product);
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            ProductEventArgs product = new ProductEventArgs(Product);
            Edit?.Invoke(this, product);
        }

        private void UC_Products_Load(object sender, EventArgs e)
        {
            lbl_Name.Text = Product.Name;
            lbl_NumberShow.Text = Product.Number.ToString();
            lbl_priceShow.Text = Product.Price.ToString();
            pb_Image.LoadAsync(Product.ImageProduct);
        }

        private void pb_Image_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                pb_Image.Image = Resources.defultprodect;
            }
        }

    }
}
