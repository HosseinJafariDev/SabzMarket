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
    public partial class UC_Empty : UserControl
    {
        public UC_Empty()
        {
            InitializeComponent();
            this.MouseWheel += UC_Empty_MouseWheel; ;
        }

        private void UC_Empty_MouseWheel(object? sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
    }
}
