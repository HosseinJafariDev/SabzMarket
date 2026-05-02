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

namespace SabzMarket.UI
{
    public partial class UC_Messege : UserControl
    {
        public UC_Messege()
        {
            InitializeComponent();
        }
        public GetMessageOutputViewModel Messege { get; set; }

        private void UC_Messege_Load(object sender, EventArgs e)
        {
            textBox1.Text = Messege.Message;
        }
    }//75
}
