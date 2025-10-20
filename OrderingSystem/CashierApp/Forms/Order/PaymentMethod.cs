using System;
using System.Windows.Forms;

namespace OrderingSystem.CashierApp.Forms.Order
{
    public partial class PaymentMethod : Form
    {
        public event EventHandler<string> PaymentMethodChanged;
        public PaymentMethod()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, System.EventArgs e)
        {
            PaymentMethodChanged?.Invoke(this, "Cash");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            PaymentMethodChanged?.Invoke(this, "Credit-Card");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
