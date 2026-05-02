namespace SabzMarketBuyer.UI
{
    partial class FrmChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChat));
            pnlUser = new FlowLayoutPanel();
            pnlTitle = new Panel();
            lblStatus = new Label();
            lblName = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlSent = new FlowLayoutPanel();
            pnlReceived = new FlowLayoutPanel();
            pnlMessage = new Panel();
            btnSend = new Button();
            txtMessage = new TextBox();
            pnlTitle.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlMessage.SuspendLayout();
            SuspendLayout();
            // 
            // pnlUser
            // 
            pnlUser.BackColor = Color.WhiteSmoke;
            pnlUser.Dock = DockStyle.Left;
            pnlUser.Location = new Point(0, 0);
            pnlUser.Name = "pnlUser";
            pnlUser.Size = new Size(334, 731);
            pnlUser.TabIndex = 0;
            // 
            // pnlTitle
            // 
            pnlTitle.BackColor = Color.CadetBlue;
            pnlTitle.Controls.Add(lblStatus);
            pnlTitle.Controls.Add(lblName);
            pnlTitle.Dock = DockStyle.Top;
            pnlTitle.Location = new Point(334, 0);
            pnlTitle.Name = "pnlTitle";
            pnlTitle.Size = new Size(900, 56);
            pnlTitle.TabIndex = 1;
            pnlTitle.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.Location = new Point(40, 31);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(83, 20);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "اخرین بازدید";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F);
            lblName.Location = new Point(41, 8);
            lblName.Name = "lblName";
            lblName.Size = new Size(30, 23);
            lblName.TabIndex = 0;
            lblName.Text = "نام";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(pnlSent, 1, 0);
            tableLayoutPanel1.Controls.Add(pnlReceived, 0, 0);
            tableLayoutPanel1.Location = new Point(334, 56);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(900, 622);
            tableLayoutPanel1.TabIndex = 2;
            tableLayoutPanel1.Visible = false;
            // 
            // pnlSent
            // 
            pnlSent.AutoScroll = true;
            pnlSent.BackColor = Color.LightGoldenrodYellow;
            pnlSent.Dock = DockStyle.Fill;
            pnlSent.Location = new Point(453, 3);
            pnlSent.Name = "pnlSent";
            pnlSent.Size = new Size(444, 616);
            pnlSent.TabIndex = 1;
            pnlSent.Scroll += pnlSent_Scroll;
            // 
            // pnlReceived
            // 
            pnlReceived.AutoScroll = true;
            pnlReceived.BackColor = Color.LightGoldenrodYellow;
            pnlReceived.Dock = DockStyle.Fill;
            pnlReceived.Location = new Point(3, 3);
            pnlReceived.Name = "pnlReceived";
            pnlReceived.Size = new Size(444, 616);
            pnlReceived.TabIndex = 0;
            pnlReceived.Scroll += pnlReceived_Scroll;
            // 
            // pnlMessage
            // 
            pnlMessage.Controls.Add(btnSend);
            pnlMessage.Controls.Add(txtMessage);
            pnlMessage.Dock = DockStyle.Bottom;
            pnlMessage.Location = new Point(334, 678);
            pnlMessage.Name = "pnlMessage";
            pnlMessage.Size = new Size(900, 53);
            pnlMessage.TabIndex = 3;
            pnlMessage.Visible = false;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.PaleGreen;
            btnSend.Font = new Font("Segoe UI", 11F);
            btnSend.Location = new Point(834, 11);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(49, 30);
            btnSend.TabIndex = 1;
            btnSend.Text = "=>";
            btnSend.UseCompatibleTextRendering = true;
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // txtMessage
            // 
            txtMessage.Font = new Font("Segoe UI", 12F);
            txtMessage.Location = new Point(6, 9);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(803, 34);
            txtMessage.TabIndex = 0;
            txtMessage.KeyDown += txtMessage_KeyDown;
            // 
            // FrmChat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(1234, 731);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pnlMessage);
            Controls.Add(pnlTitle);
            Controls.Add(pnlUser);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(1252, 778);
            MinimumSize = new Size(1252, 0);
            Name = "FrmChat";
            Text = "پیام رسان ";
            FormClosed += frm_Chat_FormClosed;
            Load += frm_Chat_Load;
            pnlTitle.ResumeLayout(false);
            pnlTitle.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            pnlMessage.ResumeLayout(false);
            pnlMessage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel pnlUser;
        private Panel pnlTitle;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlMessage;
        private Button btnSend;
        private TextBox txtMessage;
        private FlowLayoutPanel pnlReceived;
        private FlowLayoutPanel pnlSent;
        private Label lblName;
        private Label lblStatus;
    }
}