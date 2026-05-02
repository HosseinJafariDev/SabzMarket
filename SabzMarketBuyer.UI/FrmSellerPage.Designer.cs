namespace SabzMarketBuyer.UI
{
    partial class FrmSellerPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSellerPage));
            pnlShowProduct = new FlowLayoutPanel();
            pbProfile = new PictureBox();
            lblName = new Label();
            lblUsername = new Label();
            lblAddress = new Label();
            lblTitleWorkHistory = new Label();
            lblWorkHistory = new Label();
            btnMessage = new Button();
            ((System.ComponentModel.ISupportInitialize)pbProfile).BeginInit();
            SuspendLayout();
            // 
            // pnlShowProduct
            // 
            pnlShowProduct.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlShowProduct.AutoScroll = true;
            pnlShowProduct.BackColor = Color.Ivory;
            pnlShowProduct.Location = new Point(0, 188);
            pnlShowProduct.Name = "pnlShowProduct";
            pnlShowProduct.RightToLeft = RightToLeft.Yes;
            pnlShowProduct.Size = new Size(733, 501);
            pnlShowProduct.TabIndex = 0;
            // 
            // pbProfile
            // 
            pbProfile.Image = Properties.Resources.profile;
            pbProfile.Location = new Point(12, 12);
            pbProfile.Name = "pbProfile";
            pbProfile.Size = new Size(124, 117);
            pbProfile.SizeMode = PictureBoxSizeMode.Zoom;
            pbProfile.TabIndex = 1;
            pbProfile.TabStop = false;
            pbProfile.LoadCompleted += pictureBox1_LoadCompleted;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(161, 12);
            lblName.Name = "lblName";
            lblName.Size = new Size(41, 28);
            lblName.TabIndex = 2;
            lblName.Text = "نام ";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(161, 52);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(92, 28);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "نام کاربری";
            // 
            // lblAddress
            // 
            lblAddress.Location = new Point(423, 6);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(306, 176);
            lblAddress.TabIndex = 4;
            lblAddress.Text = "آدرس";
            // 
            // lblTitleWorkHistory
            // 
            lblTitleWorkHistory.AutoSize = true;
            lblTitleWorkHistory.Location = new Point(25, 151);
            lblTitleWorkHistory.Name = "lblTitleWorkHistory";
            lblTitleWorkHistory.Size = new Size(109, 28);
            lblTitleWorkHistory.TabIndex = 5;
            lblTitleWorkHistory.Text = "سابقه ی کار";
            // 
            // lblWorkHistory
            // 
            lblWorkHistory.AutoSize = true;
            lblWorkHistory.Location = new Point(161, 151);
            lblWorkHistory.Name = "lblWorkHistory";
            lblWorkHistory.Size = new Size(23, 28);
            lblWorkHistory.TabIndex = 6;
            lblWorkHistory.Text = "0";
            // 
            // btnMessage
            // 
            btnMessage.BackColor = Color.LightGreen;
            btnMessage.Font = new Font("Segoe UI", 9F);
            btnMessage.Location = new Point(161, 100);
            btnMessage.Name = "btnMessage";
            btnMessage.Size = new Size(94, 48);
            btnMessage.TabIndex = 7;
            btnMessage.Text = "ارتباط با فروشنده ";
            btnMessage.UseVisualStyleBackColor = false;
            btnMessage.Click += btnMessage_Click;
            // 
            // FrmSellerPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(733, 689);
            Controls.Add(btnMessage);
            Controls.Add(lblWorkHistory);
            Controls.Add(lblTitleWorkHistory);
            Controls.Add(lblAddress);
            Controls.Add(lblUsername);
            Controls.Add(lblName);
            Controls.Add(pbProfile);
            Controls.Add(pnlShowProduct);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmSellerPage";
            Text = "صفحه فروشنده";
            FormClosing += FrmSellerPage_FormClosing;
            Load += FrmSellerPage_Load;
            ((System.ComponentModel.ISupportInitialize)pbProfile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel pnlShowProduct;
        private PictureBox pbProfile;
        private Label lblName;
        private Label lblUsername;
        private Label lblAddress;
        private Label lblTitleWorkHistory;
        private Label lblWorkHistory;
        private Button btnMessage;
    }
}