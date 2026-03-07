using SabzMarket.UI.Properties;

namespace SabzMarket
{
    partial class UC_Orders
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lbl_Name = new Label();
            lbl_ProductName = new Label();
            lbl_Number = new Label();
            lbl_Status = new Label();
            btn_Sent = new MyButton();
            pb_Image = new PictureBox();
            btn_Details = new MyButton();
            btn_Reject = new MyButton();
            lbl_NumberTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)pb_Image).BeginInit();
            SuspendLayout();
            // 
            // lbl_Name
            // 
            lbl_Name.AutoSize = true;
            lbl_Name.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Name.Location = new Point(377, 12);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Size = new Size(29, 25);
            lbl_Name.TabIndex = 0;
            lbl_Name.Text = "نام";
            // 
            // lbl_ProductName
            // 
            lbl_ProductName.AutoSize = true;
            lbl_ProductName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_ProductName.Location = new Point(377, 81);
            lbl_ProductName.Name = "lbl_ProductName";
            lbl_ProductName.Size = new Size(93, 25);
            lbl_ProductName.TabIndex = 0;
            lbl_ProductName.Text = "اسم محصول";
            // 
            // lbl_Number
            // 
            lbl_Number.AutoSize = true;
            lbl_Number.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Number.Location = new Point(377, 151);
            lbl_Number.Name = "lbl_Number";
            lbl_Number.Size = new Size(43, 25);
            lbl_Number.TabIndex = 0;
            lbl_Number.Text = "تعداد";
            // 
            // lbl_Status
            // 
            lbl_Status.AutoSize = true;
            lbl_Status.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Status.ForeColor = Color.DarkOrange;
            lbl_Status.Location = new Point(460, 242);
            lbl_Status.Name = "lbl_Status";
            lbl_Status.Size = new Size(91, 25);
            lbl_Status.TabIndex = 0;
            lbl_Status.Text = "ارسال  نشده";
            // 
            // btn_Sent
            // 
            btn_Sent.BorderRadius = 8;
            btn_Sent.CustomizableEdges = customizableEdges7;
            btn_Sent.DisabledState.BorderColor = Color.DarkGray;
            btn_Sent.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Sent.DisabledState.FillColor = Color.LightGray;
            btn_Sent.DisabledState.ForeColor = Color.DarkGray;
            btn_Sent.FillColor = Color.SeaGreen;
            btn_Sent.Font = new Font("Segoe UI", 11F);
            btn_Sent.ForeColor = Color.White;
            btn_Sent.HoverState.FillColor = Color.MediumSeaGreen;
            btn_Sent.Location = new Point(12, 230);
            btn_Sent.Margin = new Padding(3, 4, 3, 4);
            btn_Sent.Name = "btn_Sent";
            btn_Sent.PressedColor = Color.DarkGreen;
            btn_Sent.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btn_Sent.Size = new Size(161, 51);
            btn_Sent.TabIndex = 1;
            btn_Sent.Text = "ارسال کردن";
            btn_Sent.Click += btn_Sent_Click;
            // 
            // pb_Image
            // 
            pb_Image.Image = Resources.profile;
            pb_Image.Location = new Point(29, 81);
            pb_Image.Margin = new Padding(3, 4, 3, 4);
            pb_Image.Name = "pb_Image";
            pb_Image.Size = new Size(123, 135);
            pb_Image.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Image.TabIndex = 2;
            pb_Image.TabStop = false;
            pb_Image.LoadCompleted += pb_Image_LoadCompleted;
            // 
            // btn_Details
            // 
            btn_Details.BorderRadius = 8;
            btn_Details.CustomizableEdges = customizableEdges9;
            btn_Details.DisabledState.BorderColor = Color.DarkGray;
            btn_Details.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Details.DisabledState.FillColor = Color.LightGray;
            btn_Details.DisabledState.ForeColor = Color.DarkGray;
            btn_Details.FillColor = Color.SeaGreen;
            btn_Details.Font = new Font("Segoe UI", 11F);
            btn_Details.ForeColor = Color.White;
            btn_Details.HoverState.FillColor = Color.MediumSeaGreen;
            btn_Details.Location = new Point(12, 12);
            btn_Details.Margin = new Padding(3, 4, 3, 4);
            btn_Details.Name = "btn_Details";
            btn_Details.PressedColor = Color.DarkGreen;
            btn_Details.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btn_Details.Size = new Size(161, 52);
            btn_Details.TabIndex = 3;
            btn_Details.Text = "جزئیات خریدار ";
            btn_Details.Click += btn_Details_Click;
            // 
            // btn_Reject
            // 
            btn_Reject.BorderRadius = 8;
            btn_Reject.CustomizableEdges = customizableEdges11;
            btn_Reject.DisabledState.BorderColor = Color.DarkGray;
            btn_Reject.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Reject.DisabledState.FillColor = Color.LightGray;
            btn_Reject.DisabledState.ForeColor = Color.DarkGray;
            btn_Reject.FillColor = Color.SeaGreen;
            btn_Reject.Font = new Font("Segoe UI", 11F);
            btn_Reject.ForeColor = Color.Red;
            btn_Reject.HoverState.FillColor = Color.MediumSeaGreen;
            btn_Reject.Location = new Point(193, 230);
            btn_Reject.Margin = new Padding(3, 4, 3, 4);
            btn_Reject.Name = "btn_Reject";
            btn_Reject.PressedColor = Color.DarkGreen;
            btn_Reject.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btn_Reject.Size = new Size(161, 51);
            btn_Reject.TabIndex = 4;
            btn_Reject.Text = "رد کردن";
            btn_Reject.Click += btn_Reject_Click;
            // 
            // lbl_NumberTitle
            // 
            lbl_NumberTitle.AutoSize = true;
            lbl_NumberTitle.BackColor = Color.LightCyan;
            lbl_NumberTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_NumberTitle.ForeColor = Color.CornflowerBlue;
            lbl_NumberTitle.Location = new Point(334, 151);
            lbl_NumberTitle.Name = "lbl_NumberTitle";
            lbl_NumberTitle.Size = new Size(37, 25);
            lbl_NumberTitle.TabIndex = 5;
            lbl_NumberTitle.Text = "عدد";
            // 
            // UC_Orders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            Controls.Add(lbl_NumberTitle);
            Controls.Add(btn_Reject);
            Controls.Add(btn_Details);
            Controls.Add(pb_Image);
            Controls.Add(btn_Sent);
            Controls.Add(lbl_Status);
            Controls.Add(lbl_Number);
            Controls.Add(lbl_ProductName);
            Controls.Add(lbl_Name);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_Orders";
            Size = new Size(641, 291);
            Load += UC_Orders_Load;
            ((System.ComponentModel.ISupportInitialize)pb_Image).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_ProductName;
        private System.Windows.Forms.Label lbl_Number;
        private System.Windows.Forms.Label lbl_Status;
        private MyButton btn_Sent;
        private System.Windows.Forms.PictureBox pb_Image;
        private MyButton btn_Details;
        private MyButton btn_Reject;
        private Label lbl_NumberTitle;
    }
}
