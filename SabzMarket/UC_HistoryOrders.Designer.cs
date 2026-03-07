using SabzMarket.UI.Properties;

namespace SabzMarket
{
    partial class UC_HistoryOrders
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lbl_Status = new Label();
            lbl_Number = new Label();
            lbl_Product = new Label();
            lbl_Name = new Label();
            btn_Details = new MyButton();
            pb_Image = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb_Image).BeginInit();
            SuspendLayout();
            // 
            // lbl_Status
            // 
            lbl_Status.AutoSize = true;
            lbl_Status.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Status.ForeColor = Color.Red;
            lbl_Status.Location = new Point(325, 210);
            lbl_Status.Name = "lbl_Status";
            lbl_Status.Size = new Size(64, 25);
            lbl_Status.TabIndex = 1;
            lbl_Status.Text = "وضعیت";
            // 
            // lbl_Number
            // 
            lbl_Number.AutoSize = true;
            lbl_Number.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Number.Location = new Point(325, 142);
            lbl_Number.Name = "lbl_Number";
            lbl_Number.Size = new Size(43, 25);
            lbl_Number.TabIndex = 2;
            lbl_Number.Text = "تعداد";
            // 
            // lbl_Product
            // 
            lbl_Product.AutoSize = true;
            lbl_Product.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Product.Location = new Point(325, 78);
            lbl_Product.Name = "lbl_Product";
            lbl_Product.Size = new Size(93, 25);
            lbl_Product.TabIndex = 3;
            lbl_Product.Text = "اسم محصول";
            // 
            // lbl_Name
            // 
            lbl_Name.AutoSize = true;
            lbl_Name.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Name.Location = new Point(325, 21);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Size = new Size(29, 25);
            lbl_Name.TabIndex = 4;
            lbl_Name.Text = "نام";
            // 
            // btn_Details
            // 
            btn_Details.BorderRadius = 8;
            btn_Details.CustomizableEdges = customizableEdges1;
            btn_Details.DisabledState.BorderColor = Color.DarkGray;
            btn_Details.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Details.DisabledState.FillColor = Color.LightGray;
            btn_Details.DisabledState.ForeColor = Color.DarkGray;
            btn_Details.FillColor = Color.SeaGreen;
            btn_Details.Font = new Font("Segoe UI", 11F);
            btn_Details.ForeColor = Color.White;
            btn_Details.HoverState.FillColor = Color.MediumSeaGreen;
            btn_Details.Location = new Point(12, 11);
            btn_Details.Margin = new Padding(3, 4, 3, 4);
            btn_Details.Name = "btn_Details";
            btn_Details.PressedColor = Color.DarkGreen;
            btn_Details.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_Details.Size = new Size(161, 52);
            btn_Details.TabIndex = 5;
            btn_Details.Text = "جزئیات خریدار ";
            btn_Details.Click += btn_Details_Click;
            // 
            // pb_Image
            // 
            pb_Image.Image = Resources.profile;
            pb_Image.Location = new Point(31, 78);
            pb_Image.Margin = new Padding(3, 4, 3, 4);
            pb_Image.Name = "pb_Image";
            pb_Image.Size = new Size(123, 135);
            pb_Image.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Image.TabIndex = 6;
            pb_Image.TabStop = false;
            pb_Image.LoadCompleted += pb_Image_LoadCompleted;
            // 
            // UC_HistoryOrders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            Controls.Add(pb_Image);
            Controls.Add(btn_Details);
            Controls.Add(lbl_Status);
            Controls.Add(lbl_Number);
            Controls.Add(lbl_Product);
            Controls.Add(lbl_Name);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_HistoryOrders";
            Size = new Size(502, 261);
            Load += UC_HistoryOrders_Load;
            ((System.ComponentModel.ISupportInitialize)pb_Image).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Label lbl_Number;
        private System.Windows.Forms.Label lbl_Product;
        private System.Windows.Forms.Label lbl_Name;
        private MyButton btn_Details;
        private System.Windows.Forms.PictureBox pb_Image;
    }
}
