namespace SabzMarketBuyer.UI
{
    public partial class FormStyle : Form
    {
        public FormStyle()
        {
            InitializeComponent();
            ApplyStyle();
        }


        protected void ApplyStyle()
        {
            this.BackColor = Color.Honeydew;
        }
        public DialogResult ShowInfo(string massage)
        {
            return MessageBox.Show(massage);
        }
        public DialogResult ShowInfoError(string massage)
        {
            return MessageBox.Show(massage, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public DialogResult ShowInfoWarning(string massage)
        {
            return MessageBox.Show(massage, "هشدار", MessageBoxButtons.YesNo);
        }
    }
}
