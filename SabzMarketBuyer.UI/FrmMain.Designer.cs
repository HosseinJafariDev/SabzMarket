namespace SabzMarketBuyer.UI
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            pnlHamburgerMenu = new Panel();
            pnlSetting = new Panel();
            btnSeting = new MyButon();
            lblSetting = new Label();
            lblUserName = new Label();
            lblName = new Label();
            pbProfile = new PictureBox();
            btnShowMenu = new Button();
            pnlShowProduct = new FlowLayoutPanel();
            pnlMenu = new Panel();
            btnShoppingCart = new MyButon();
            btnChat = new MyButon();
            btnSearch = new MyButon();
            txtSearch = new TextBox();
            panel1 = new Panel();
            rbtSearchProduct = new RadioButton();
            rbtSearchSeller = new RadioButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pnlHamburgerMenu.SuspendLayout();
            pnlSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbProfile).BeginInit();
            pnlMenu.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHamburgerMenu
            // 
            pnlHamburgerMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlHamburgerMenu.BackColor = Color.PaleGreen;
            pnlHamburgerMenu.Controls.Add(pnlSetting);
            pnlHamburgerMenu.Controls.Add(lblUserName);
            pnlHamburgerMenu.Controls.Add(lblName);
            pnlHamburgerMenu.Controls.Add(pbProfile);
            pnlHamburgerMenu.Location = new Point(-1, 0);
            pnlHamburgerMenu.Name = "pnlHamburgerMenu";
            pnlHamburgerMenu.Size = new Size(307, 764);
            pnlHamburgerMenu.TabIndex = 0;
            pnlHamburgerMenu.Visible = false;
            // 
            // pnlSetting
            // 
            pnlSetting.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pnlSetting.BackColor = Color.PaleGreen;
            pnlSetting.Controls.Add(btnSeting);
            pnlSetting.Controls.Add(lblSetting);
            pnlSetting.Location = new Point(3, 669);
            pnlSetting.Name = "pnlSetting";
            pnlSetting.Size = new Size(301, 52);
            pnlSetting.TabIndex = 4;
            pnlSetting.Click += plSetting_Click;
            pnlSetting.MouseDown += plSetting_MouseDown;
            pnlSetting.MouseUp += plSetting_MouseUp;
            // 
            // btnSeting
            // 
            btnSeting.Image = Properties.Resources.Pinion;
            btnSeting.Location = new Point(10, 8);
            btnSeting.Name = "btnSeting";
            btnSeting.Size = new Size(36, 37);
            btnSeting.TabIndex = 2;
            btnSeting.UseVisualStyleBackColor = true;
            btnSeting.Click += btnSeting_Click;
            btnSeting.MouseDown += btnSeting_MouseDown;
            btnSeting.MouseUp += btnSeting_MouseUp;
            // 
            // lblSetting
            // 
            lblSetting.AutoSize = true;
            lblSetting.Font = new Font("Segoe UI", 11F);
            lblSetting.Location = new Point(71, 15);
            lblSetting.Name = "lblSetting";
            lblSetting.Size = new Size(71, 25);
            lblSetting.TabIndex = 1;
            lblSetting.Text = "Setting";
            lblSetting.Click += lblSetting_Click;
            lblSetting.MouseDown += lblSetting_MouseDown;
            lblSetting.MouseUp += lblSetting_MouseUp;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(128, 72);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(36, 28);
            lblUserName.TabIndex = 3;
            lblUserName.Text = "......";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(128, 22);
            lblName.Name = "lblName";
            lblName.Size = new Size(36, 28);
            lblName.TabIndex = 2;
            lblName.Text = "......";
            // 
            // pbProfile
            // 
            pbProfile.Image = Properties.Resources.profile;
            pbProfile.Location = new Point(21, 22);
            pbProfile.Name = "pbProfile";
            pbProfile.Size = new Size(85, 81);
            pbProfile.SizeMode = PictureBoxSizeMode.Zoom;
            pbProfile.TabIndex = 0;
            pbProfile.TabStop = false;
            pbProfile.LoadCompleted += pbProfile_LoadCompleted;
            // 
            // btnShowMenu
            // 
            btnShowMenu.Location = new Point(-1, -1);
            btnShowMenu.Name = "btnShowMenu";
            btnShowMenu.Size = new Size(28, 31);
            btnShowMenu.TabIndex = 1;
            btnShowMenu.Text = "☰";
            btnShowMenu.UseVisualStyleBackColor = true;
            btnShowMenu.Click += btnShowUser_Click;
            // 
            // pnlShowProduct
            // 
            pnlShowProduct.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlShowProduct.BackColor = Color.Ivory;
            pnlShowProduct.FlowDirection = FlowDirection.RightToLeft;
            pnlShowProduct.Location = new Point(0, 72);
            pnlShowProduct.Name = "pnlShowProduct";
            pnlShowProduct.Size = new Size(1201, 661);
            pnlShowProduct.TabIndex = 2;
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(btnShoppingCart);
            pnlMenu.Controls.Add(btnChat);
            pnlMenu.Dock = DockStyle.Right;
            pnlMenu.Location = new Point(1202, 74);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(69, 653);
            pnlMenu.TabIndex = 3;
            // 
            // btnShoppingCart
            // 
            btnShoppingCart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnShoppingCart.BackColor = Color.Honeydew;
            btnShoppingCart.Image = Properties.Resources.basket;
            btnShoppingCart.Location = new Point(7, 585);
            btnShoppingCart.Name = "btnShoppingCart";
            btnShoppingCart.Size = new Size(53, 55);
            btnShoppingCart.TabIndex = 1;
            btnShoppingCart.UseVisualStyleBackColor = false;
            btnShoppingCart.Click += btnShoppingCart_Click;
            // 
            // btnChat
            // 
            btnChat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChat.BackColor = Color.Honeydew;
            btnChat.Image = Properties.Resources.message_dots_1_;
            btnChat.Location = new Point(5, 5);
            btnChat.Name = "btnChat";
            btnChat.Size = new Size(59, 53);
            btnChat.TabIndex = 0;
            btnChat.UseVisualStyleBackColor = false;
            btnChat.Click += btnChat_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Honeydew;
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.Location = new Point(312, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 50);
            btnSearch.TabIndex = 1;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += myButon2_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(424, 21);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(359, 34);
            txtSearch.TabIndex = 0;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // panel1
            // 
            panel1.Controls.Add(rbtSearchProduct);
            panel1.Controls.Add(rbtSearchSeller);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btnSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1271, 74);
            panel1.TabIndex = 4;
            // 
            // rbtSearchProduct
            // 
            rbtSearchProduct.AutoSize = true;
            rbtSearchProduct.Font = new Font("Segoe UI", 11F);
            rbtSearchProduct.Location = new Point(839, 42);
            rbtSearchProduct.Name = "rbtSearchProduct";
            rbtSearchProduct.Size = new Size(185, 29);
            rbtSearchProduct.TabIndex = 3;
            rbtSearchProduct.TabStop = true;
            rbtSearchProduct.Text = "جستوجوی مجصول ";
            rbtSearchProduct.UseVisualStyleBackColor = true;
            // 
            // rbtSearchSeller
            // 
            rbtSearchSeller.AutoSize = true;
            rbtSearchSeller.Checked = true;
            rbtSearchSeller.Font = new Font("Segoe UI", 11F);
            rbtSearchSeller.Location = new Point(839, 7);
            rbtSearchSeller.Name = "rbtSearchSeller";
            rbtSearchSeller.Size = new Size(293, 29);
            rbtSearchSeller.TabIndex = 2;
            rbtSearchSeller.TabStop = true;
            rbtSearchSeller.Text = "جستوجوی فروشنده با شماره تلفن";
            rbtSearchSeller.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 727);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1271, 37);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 764);
            Controls.Add(pnlHamburgerMenu);
            Controls.Add(pnlMenu);
            Controls.Add(btnShowMenu);
            Controls.Add(pnlShowProduct);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1289, 811);
            Name = "FrmMain";
            Text = "سبزمارکت";
            FormClosed += FrmMain_FormClosed;
            Load += FrmMain_Load;
            pnlHamburgerMenu.ResumeLayout(false);
            pnlHamburgerMenu.PerformLayout();
            pnlSetting.ResumeLayout(false);
            pnlSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbProfile).EndInit();
            pnlMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHamburgerMenu;
        private PictureBox pbProfile;
        private Button btnShowMenu;
        private Label lblName;
        private Panel pnlSetting;
        private Label lblSetting;
        private Button btnSetting;
        private Label lblUserName;
        private MyButon btnSeting;
        private FlowLayoutPanel pnlShowProduct;
        private Panel pnlMenu;
        private MyButon btnChat;
        private MyButon btnShoppingCart;
        private MyButon btnSearch;
        private TextBox txtSearch;
        private Panel panel1;
        private RadioButton rbtSearchProduct;
        private RadioButton rbtSearchSeller;
        private FlowLayoutPanel flowLayoutPanel1;
        // private MyButon btnSetting;
    }
}