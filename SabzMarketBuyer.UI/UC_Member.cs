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

namespace SabzMarketBuyer.UI
{
    public partial class UC_Member : UserControl
    {
        public UC_Member()
        {
            InitializeComponent();
        }
        public findUsersChattedOutputViewModel User { get; set; }

        private void UC_Member_Load(object sender, EventArgs e)
        {
            lblName.Text = User.Firstname;
        }
        public event EventHandler<UserInfoEventArgs> UC_Member_OpenChat;
        private void UC_Member_Click(object sender, EventArgs e)
        {
            UserInfoEventArgs userInfo = new UserInfoEventArgs()
            {
                User = User
            };
            UC_Member_OpenChat?.Invoke(this, userInfo);
        }
    }
}
