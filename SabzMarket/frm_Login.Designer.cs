namespace SabzMarket
{
    partial class frm_Login
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Login));
            btn_Login = new MyButton();
            txt_UserName = new MyTextBox();
            txt_Password = new MyTextBox();
            lbl_UserName = new Label();
            lbl_password = new Label();
            btn_SignUp = new MyButton();
            SuspendLayout();
            // 
            // btn_Login
            // 
            btn_Login.Animated = true;
            btn_Login.BorderRadius = 8;
            btn_Login.CustomizableEdges = customizableEdges1;
            btn_Login.DisabledState.BorderColor = Color.DarkGray;
            btn_Login.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Login.DisabledState.FillColor = Color.LightGray;
            btn_Login.DisabledState.ForeColor = Color.DarkGray;
            btn_Login.FillColor = Color.SeaGreen;
            btn_Login.Font = new Font("Segoe UI", 11F);
            btn_Login.ForeColor = Color.White;
            btn_Login.HoverState.FillColor = Color.MediumSeaGreen;
            btn_Login.Location = new Point(117, 350);
            btn_Login.Margin = new Padding(3, 4, 3, 4);
            btn_Login.Name = "btn_Login";
            btn_Login.PressedColor = Color.DarkGreen;
            btn_Login.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_Login.Size = new Size(150, 72);
            btn_Login.TabIndex = 3;
            btn_Login.Text = "ورود";
            btn_Login.Click += btn_Login_Click;
            // 
            // txt_UserName
            // 
            txt_UserName.Cursor = Cursors.IBeam;
            txt_UserName.CustomizableEdges = customizableEdges3;
            txt_UserName.DefaultText = "";
            txt_UserName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_UserName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_UserName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_UserName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_UserName.FillColor = Color.PaleGreen;
            txt_UserName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_UserName.Font = new Font("Segoe UI", 11F);
            txt_UserName.ForeColor = Color.DarkGreen;
            txt_UserName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_UserName.Location = new Point(89, 143);
            txt_UserName.Margin = new Padding(4, 6, 4, 6);
            txt_UserName.Name = "txt_UserName";
            txt_UserName.PlaceholderText = "";
            txt_UserName.SelectedText = "";
            txt_UserName.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txt_UserName.Size = new Size(178, 55);
            txt_UserName.TabIndex = 1;
            // 
            // txt_Password
            // 
            txt_Password.Cursor = Cursors.IBeam;
            txt_Password.CustomizableEdges = customizableEdges5;
            txt_Password.DefaultText = "";
            txt_Password.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txt_Password.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txt_Password.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txt_Password.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txt_Password.FillColor = Color.PaleGreen;
            txt_Password.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_Password.Font = new Font("Segoe UI", 11F);
            txt_Password.ForeColor = Color.DarkGreen;
            txt_Password.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txt_Password.Location = new Point(89, 222);
            txt_Password.Margin = new Padding(4, 6, 4, 6);
            txt_Password.Name = "txt_Password";
            txt_Password.PlaceholderText = "";
            txt_Password.SelectedText = "";
            txt_Password.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txt_Password.Size = new Size(178, 55);
            txt_Password.TabIndex = 2;
            txt_Password.KeyDown += txt_Password_KeyDown;
            // 
            // lbl_UserName
            // 
            lbl_UserName.AutoSize = true;
            lbl_UserName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_UserName.Location = new Point(274, 143);
            lbl_UserName.Name = "lbl_UserName";
            lbl_UserName.Size = new Size(75, 25);
            lbl_UserName.TabIndex = 3;
            lbl_UserName.Text = "نام کابری";
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_password.Location = new Point(274, 222);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(79, 25);
            lbl_password.TabIndex = 3;
            lbl_password.Text = "رمز عبور";
            // 
            // btn_SignUp
            // 
            btn_SignUp.Animated = true;
            btn_SignUp.BorderRadius = 8;
            btn_SignUp.CustomizableEdges = customizableEdges7;
            btn_SignUp.DisabledState.BorderColor = Color.DarkGray;
            btn_SignUp.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_SignUp.DisabledState.FillColor = Color.LightGray;
            btn_SignUp.DisabledState.ForeColor = Color.DarkGray;
            btn_SignUp.FillColor = Color.SeaGreen;
            btn_SignUp.Font = new Font("Segoe UI", 9F);
            btn_SignUp.ForeColor = Color.White;
            btn_SignUp.HoverState.FillColor = Color.MediumSeaGreen;
            btn_SignUp.Location = new Point(4, 5);
            btn_SignUp.Margin = new Padding(3, 4, 3, 4);
            btn_SignUp.Name = "btn_SignUp";
            btn_SignUp.PressedColor = Color.DarkGreen;
            btn_SignUp.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btn_SignUp.Size = new Size(88, 49);
            btn_SignUp.TabIndex = 4;
            btn_SignUp.Text = "ثبت نام ";
            btn_SignUp.Click += btn_SignUp_Click;
            // 
            // frm_Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 522);
            Controls.Add(btn_SignUp);
            Controls.Add(lbl_password);
            Controls.Add(lbl_UserName);
            Controls.Add(txt_Password);
            Controls.Add(txt_UserName);
            Controls.Add(btn_Login);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(420, 569);
            MinimumSize = new Size(420, 569);
            Name = "frm_Login";
            Text = "صفحه ورود";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private MyButton btn_Login;
        private MyTextBox txt_UserName;
        private MyTextBox txt_Password;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.Label lbl_password;
        private MyButton btn_SignUp;
    }
}