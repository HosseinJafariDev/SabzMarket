namespace SabzMarketBuyer.UI
{
    partial class FrmSingUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSingUp));
            txtFirstname = new TextBox();
            txtLastname = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtPasswordRepeat = new TextBox();
            lblFirstname = new Label();
            lblLastname = new Label();
            lblPhone = new Label();
            lblEmail = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            btnSingUp = new Button();
            txtOtp = new TextBox();
            lblPasswordRepeat = new Label();
            lblOtp = new Label();
            btnSendOtp = new Button();
            SuspendLayout();
            // 
            // txtFirstname
            // 
            txtFirstname.Font = new Font("Segoe UI", 11F);
            txtFirstname.Location = new Point(12, 37);
            txtFirstname.Name = "txtFirstname";
            txtFirstname.Size = new Size(208, 32);
            txtFirstname.TabIndex = 0;
            // 
            // txtLastname
            // 
            txtLastname.Font = new Font("Segoe UI", 11F);
            txtLastname.Location = new Point(12, 75);
            txtLastname.Name = "txtLastname";
            txtLastname.Size = new Size(208, 32);
            txtLastname.TabIndex = 1;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 11F);
            txtPhone.Location = new Point(12, 113);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(208, 32);
            txtPhone.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.Location = new Point(12, 151);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(208, 32);
            txtEmail.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(12, 189);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(208, 32);
            txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(12, 227);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(208, 32);
            txtPassword.TabIndex = 5;
            // 
            // txtPasswordRepeat
            // 
            txtPasswordRepeat.Font = new Font("Segoe UI", 11F);
            txtPasswordRepeat.Location = new Point(12, 265);
            txtPasswordRepeat.Name = "txtPasswordRepeat";
            txtPasswordRepeat.Size = new Size(208, 32);
            txtPasswordRepeat.TabIndex = 6;
            // 
            // lblFirstname
            // 
            lblFirstname.AutoSize = true;
            lblFirstname.Font = new Font("Segoe UI", 11F);
            lblFirstname.Location = new Point(226, 40);
            lblFirstname.Name = "lblFirstname";
            lblFirstname.Size = new Size(34, 25);
            lblFirstname.TabIndex = 7;
            lblFirstname.Text = "نام";
            // 
            // lblLastname
            // 
            lblLastname.AutoSize = true;
            lblLastname.Font = new Font("Segoe UI", 11F);
            lblLastname.Location = new Point(226, 78);
            lblLastname.Name = "lblLastname";
            lblLastname.Size = new Size(112, 25);
            lblLastname.TabIndex = 8;
            lblLastname.Text = "نام خانوادگی";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 11F);
            lblPhone.Location = new Point(226, 116);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(100, 25);
            lblPhone.TabIndex = 9;
            lblPhone.Text = "شماره تلفن";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 11F);
            lblEmail.Location = new Point(226, 154);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(53, 25);
            lblEmail.TabIndex = 10;
            lblEmail.Text = "ایمیل";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 11F);
            lblUsername.Location = new Point(226, 192);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(88, 25);
            lblUsername.TabIndex = 11;
            lblUsername.Text = "نام کاربری";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 11F);
            lblPassword.Location = new Point(226, 230);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(77, 25);
            lblPassword.TabIndex = 12;
            lblPassword.Text = "رمز عبور";
            // 
            // btnSingUp
            // 
            btnSingUp.Font = new Font("Segoe UI", 11F);
            btnSingUp.ForeColor = SystemColors.ControlText;
            btnSingUp.Location = new Point(119, 372);
            btnSingUp.Name = "btnSingUp";
            btnSingUp.Size = new Size(131, 61);
            btnSingUp.TabIndex = 7;
            btnSingUp.Text = "ثبت نام";
            btnSingUp.UseVisualStyleBackColor = true;
            btnSingUp.Click += btnSingUp_Click;
            // 
            // txtOtp
            // 
            txtOtp.Font = new Font("Segoe UI", 11F);
            txtOtp.Location = new Point(12, 303);
            txtOtp.Name = "txtOtp";
            txtOtp.Size = new Size(208, 32);
            txtOtp.TabIndex = 14;
            txtOtp.Text = "0";
            // 
            // lblPasswordRepeat
            // 
            lblPasswordRepeat.AutoSize = true;
            lblPasswordRepeat.Font = new Font("Segoe UI", 11F);
            lblPasswordRepeat.Location = new Point(226, 268);
            lblPasswordRepeat.Name = "lblPasswordRepeat";
            lblPasswordRepeat.Size = new Size(117, 25);
            lblPasswordRepeat.TabIndex = 13;
            lblPasswordRepeat.Text = "تکرار رمز عبور";
            // 
            // lblOtp
            // 
            lblOtp.AutoSize = true;
            lblOtp.Font = new Font("Segoe UI", 11F);
            lblOtp.Location = new Point(232, 306);
            lblOtp.Name = "lblOtp";
            lblOtp.Size = new Size(73, 25);
            lblOtp.TabIndex = 15;
            lblOtp.Text = "کد ورود";
            // 
            // btnSendOtp
            // 
            btnSendOtp.Font = new Font("Segoe UI", 8F);
            btnSendOtp.ForeColor = SystemColors.ControlText;
            btnSendOtp.Location = new Point(12, 341);
            btnSendOtp.Name = "btnSendOtp";
            btnSendOtp.Size = new Size(75, 29);
            btnSendOtp.TabIndex = 16;
            btnSendOtp.Text = "ارسال کد";
            btnSendOtp.UseVisualStyleBackColor = true;
            btnSendOtp.Click += btnSendOtp_Click;
            // 
            // FrmSingUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(361, 445);
            Controls.Add(btnSendOtp);
            Controls.Add(lblOtp);
            Controls.Add(txtOtp);
            Controls.Add(btnSingUp);
            Controls.Add(lblPasswordRepeat);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblEmail);
            Controls.Add(lblPhone);
            Controls.Add(lblLastname);
            Controls.Add(lblFirstname);
            Controls.Add(txtPasswordRepeat);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtEmail);
            Controls.Add(txtPhone);
            Controls.Add(txtLastname);
            Controls.Add(txtFirstname);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(379, 492);
            MinimumSize = new Size(379, 492);
            Name = "FrmSingUp";
            Text = "ثبت نام";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFirstname;
        private TextBox txtLastname;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtPasswordRepeat;
        private Label lblFirstname;
        private Label lblLastname;
        private Label lblPhone;
        private Label lblEmail;
        private Label lblUsername;
        private Label lblPassword;
        private Button btnSingUp;
        private TextBox txtOtp;
        private Label lblPasswordRepeat;
        private Label lblOtp;
        private Button btnSendOtp;
    }
}