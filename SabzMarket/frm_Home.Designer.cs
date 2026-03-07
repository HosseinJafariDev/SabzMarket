using SabzMarket.UI.Properties;

namespace SabzMarket
{
    partial class frm_Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Home));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btn_Setting = new Guna.UI2.WinForms.Guna2ImageButton();
            pln_Menu1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            pb_Profile = new PictureBox();
            lbl_UserName = new Label();
            lbl_Settings = new Label();
            lbl_Name = new Label();
            pln_Menu2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            btn_Orders = new Guna.UI2.WinForms.Guna2ImageButton();
            btn_Chat = new Guna.UI2.WinForms.Guna2ImageButton();
            btn_AddProduct = new Guna.UI2.WinForms.Guna2ImageButton();
            flp_ShowProduct = new FlowLayoutPanel();
            btn_Menu = new Guna.UI2.WinForms.Guna2Button();
            pln_Menu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Profile).BeginInit();
            pln_Menu2.SuspendLayout();
            guna2CustomGradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_Setting
            // 
            btn_Setting.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_Setting.BackColor = Color.Transparent;
            btn_Setting.CheckedState.ImageSize = new Size(64, 64);
            btn_Setting.HoverState.Image = (Image)resources.GetObject("resource.Image");
            btn_Setting.HoverState.ImageSize = new Size(64, 64);
            btn_Setting.Image = (Image)resources.GetObject("btn_Setting.Image");
            btn_Setting.ImageOffset = new Point(0, 0);
            btn_Setting.ImageRotate = 0F;
            btn_Setting.Location = new Point(2, 654);
            btn_Setting.Margin = new Padding(3, 4, 3, 4);
            btn_Setting.Name = "btn_Setting";
            btn_Setting.PressedState.Image = (Image)resources.GetObject("resource.Image1");
            btn_Setting.PressedState.ImageSize = new Size(64, 64);
            btn_Setting.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btn_Setting.Size = new Size(77, 95);
            btn_Setting.TabIndex = 0;
            btn_Setting.UseTransparentBackground = true;
            btn_Setting.Click += btn_Setting_Click;
            // 
            // pln_Menu1
            // 
            pln_Menu1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pln_Menu1.Controls.Add(pb_Profile);
            pln_Menu1.Controls.Add(lbl_UserName);
            pln_Menu1.Controls.Add(lbl_Settings);
            pln_Menu1.Controls.Add(lbl_Name);
            pln_Menu1.Controls.Add(btn_Setting);
            pln_Menu1.CustomizableEdges = customizableEdges2;
            pln_Menu1.FillColor = Color.MintCream;
            pln_Menu1.FillColor2 = Color.MediumSeaGreen;
            pln_Menu1.FillColor3 = Color.PaleTurquoise;
            pln_Menu1.FillColor4 = Color.LightCyan;
            pln_Menu1.Location = new Point(12, 13);
            pln_Menu1.Margin = new Padding(3, 4, 3, 4);
            pln_Menu1.Name = "pln_Menu1";
            pln_Menu1.ShadowDecoration.CustomizableEdges = customizableEdges3;
            pln_Menu1.Size = new Size(370, 766);
            pln_Menu1.TabIndex = 1;
            // 
            // pb_Profile
            // 
            pb_Profile.Image = Resources.profile;
            pb_Profile.Location = new Point(8, 16);
            pb_Profile.Margin = new Padding(3, 4, 3, 4);
            pb_Profile.Name = "pb_Profile";
            pb_Profile.Size = new Size(84, 94);
            pb_Profile.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Profile.TabIndex = 5;
            pb_Profile.TabStop = false;
            // 
            // lbl_UserName
            // 
            lbl_UserName.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_UserName.Location = new Point(105, 95);
            lbl_UserName.Name = "lbl_UserName";
            lbl_UserName.Size = new Size(154, 48);
            lbl_UserName.TabIndex = 4;
            lbl_UserName.Text = "...........";
            // 
            // lbl_Settings
            // 
            lbl_Settings.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbl_Settings.AutoSize = true;
            lbl_Settings.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Settings.Location = new Point(105, 688);
            lbl_Settings.Name = "lbl_Settings";
            lbl_Settings.Size = new Size(100, 29);
            lbl_Settings.TabIndex = 3;
            lbl_Settings.Text = "Settings";
            // 
            // lbl_Name
            // 
            lbl_Name.AutoSize = true;
            lbl_Name.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Name.Location = new Point(106, 24);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Size = new Size(53, 20);
            lbl_Name.TabIndex = 2;
            lbl_Name.Text = "...........";
            // 
            // pln_Menu2
            // 
            pln_Menu2.BackColor = Color.Transparent;
            pln_Menu2.Controls.Add(pln_Menu1);
            pln_Menu2.Dock = DockStyle.Left;
            pln_Menu2.FillColor = Color.White;
            pln_Menu2.Location = new Point(0, 0);
            pln_Menu2.Margin = new Padding(3, 4, 3, 4);
            pln_Menu2.Name = "pln_Menu2";
            pln_Menu2.ShadowColor = Color.Black;
            pln_Menu2.Size = new Size(393, 792);
            pln_Menu2.TabIndex = 4;
            pln_Menu2.Visible = false;
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.Controls.Add(btn_Orders);
            guna2CustomGradientPanel1.Controls.Add(btn_Chat);
            guna2CustomGradientPanel1.Controls.Add(btn_AddProduct);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges7;
            guna2CustomGradientPanel1.Dock = DockStyle.Right;
            guna2CustomGradientPanel1.FillColor = Color.WhiteSmoke;
            guna2CustomGradientPanel1.FillColor2 = Color.Honeydew;
            guna2CustomGradientPanel1.FillColor3 = Color.Beige;
            guna2CustomGradientPanel1.FillColor4 = Color.LightGreen;
            guna2CustomGradientPanel1.Location = new Point(988, 0);
            guna2CustomGradientPanel1.Margin = new Padding(3, 4, 3, 4);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2CustomGradientPanel1.Size = new Size(109, 792);
            guna2CustomGradientPanel1.TabIndex = 7;
            // 
            // btn_Orders
            // 
            btn_Orders.CheckedState.ImageSize = new Size(64, 64);
            btn_Orders.HoverState.ImageSize = new Size(64, 64);
            btn_Orders.Image = (Image)resources.GetObject("btn_Orders.Image");
            btn_Orders.ImageOffset = new Point(0, 0);
            btn_Orders.ImageRotate = 0F;
            btn_Orders.Location = new Point(14, 110);
            btn_Orders.Margin = new Padding(3, 4, 3, 4);
            btn_Orders.Name = "btn_Orders";
            btn_Orders.PressedState.Image = Resources.shop;
            btn_Orders.PressedState.ImageSize = new Size(64, 64);
            btn_Orders.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_Orders.Size = new Size(83, 94);
            btn_Orders.TabIndex = 10;
            btn_Orders.Click += btn_Orders_Click;
            // 
            // btn_Chat
            // 
            btn_Chat.BackColor = Color.Transparent;
            btn_Chat.CheckedState.ImageSize = new Size(64, 64);
            btn_Chat.HoverState.Image = Resources.Wwalczyszyn_Android_Style_Honeycomb_Messages_48;
            btn_Chat.HoverState.ImageSize = new Size(64, 64);
            btn_Chat.Image = (Image)resources.GetObject("btn_Chat.Image");
            btn_Chat.ImageOffset = new Point(0, 0);
            btn_Chat.ImageRotate = 0F;
            btn_Chat.IndicateFocus = true;
            btn_Chat.Location = new Point(14, 15);
            btn_Chat.Margin = new Padding(3, 4, 3, 4);
            btn_Chat.Name = "btn_Chat";
            btn_Chat.PressedState.Image = (Image)resources.GetObject("resource.Image2");
            btn_Chat.PressedState.ImageSize = new Size(64, 64);
            btn_Chat.ShadowDecoration.CustomizableEdges = customizableEdges5;
            btn_Chat.Size = new Size(83, 88);
            btn_Chat.TabIndex = 9;
            btn_Chat.Click += btn_Chat_Click;
            // 
            // btn_AddProduct
            // 
            btn_AddProduct.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_AddProduct.BackColor = Color.Honeydew;
            btn_AddProduct.CheckedState.ImageSize = new Size(64, 64);
            btn_AddProduct.HoverState.Image = (Image)resources.GetObject("resource.Image3");
            btn_AddProduct.HoverState.ImageSize = new Size(64, 64);
            btn_AddProduct.Image = (Image)resources.GetObject("btn_AddProduct.Image");
            btn_AddProduct.ImageOffset = new Point(0, 0);
            btn_AddProduct.ImageRotate = 0F;
            btn_AddProduct.Location = new Point(14, 679);
            btn_AddProduct.Margin = new Padding(3, 4, 3, 4);
            btn_AddProduct.Name = "btn_AddProduct";
            btn_AddProduct.PressedState.Image = (Image)resources.GetObject("resource.Image4");
            btn_AddProduct.PressedState.ImageSize = new Size(64, 64);
            btn_AddProduct.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btn_AddProduct.Size = new Size(83, 99);
            btn_AddProduct.TabIndex = 8;
            btn_AddProduct.Click += btn_AddProduct_Click;
            // 
            // flp_ShowProduct
            // 
            flp_ShowProduct.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flp_ShowProduct.AutoScroll = true;
            flp_ShowProduct.BackColor = Color.MintCream;
            flp_ShowProduct.FlowDirection = FlowDirection.RightToLeft;
            flp_ShowProduct.Location = new Point(3, 0);
            flp_ShowProduct.Margin = new Padding(3, 4, 3, 4);
            flp_ShowProduct.Name = "flp_ShowProduct";
            flp_ShowProduct.Size = new Size(985, 792);
            flp_ShowProduct.TabIndex = 8;
            // 
            // btn_Menu
            // 
            btn_Menu.CustomizableEdges = customizableEdges9;
            btn_Menu.DisabledState.BorderColor = Color.DarkGray;
            btn_Menu.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Menu.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Menu.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Menu.Font = new Font("Segoe UI", 9F);
            btn_Menu.ForeColor = Color.White;
            btn_Menu.Location = new Point(-2, 0);
            btn_Menu.Margin = new Padding(3, 4, 3, 4);
            btn_Menu.Name = "btn_Menu";
            btn_Menu.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btn_Menu.Size = new Size(41, 36);
            btn_Menu.TabIndex = 5;
            btn_Menu.Text = "☰";
            btn_Menu.Click += guna2Button1_Click;
            // 
            // frm_Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(1097, 792);
            Controls.Add(pln_Menu2);
            Controls.Add(guna2CustomGradientPanel1);
            Controls.Add(btn_Menu);
            Controls.Add(flp_ShowProduct);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1115, 839);
            Name = "frm_Home";
            Text = "سبز مارکت";
            FormClosed += frm_Home_FormClosed;
            Load += frm_Home_Load;
            pln_Menu1.ResumeLayout(false);
            pln_Menu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Profile).EndInit();
            pln_Menu2.ResumeLayout(false);
            guna2CustomGradientPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ImageButton btn_Setting;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pln_Menu1;
        private Guna.UI2.WinForms.Guna2ShadowPanel pln_Menu2;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2ImageButton btn_AddProduct;
        private Guna.UI2.WinForms.Guna2ImageButton btn_Chat;
        private Guna.UI2.WinForms.Guna2ImageButton btn_Orders;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_Settings;
        private System.Windows.Forms.FlowLayoutPanel flp_ShowProduct;
        private Guna.UI2.WinForms.Guna2Button btn_Menu;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.PictureBox pb_Profile;
    }
}