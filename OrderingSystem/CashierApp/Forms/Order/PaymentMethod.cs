using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OrderingSystem.CashierApp.Payment;
using OrderingSystem.Exceptions;
using OrderingSystem.KioskApplication.Services;
using OrderingSystem.Model;

namespace OrderingSystem.CashierApp.Forms.Order
{
    public partial class PaymentMethod : Form
    {
        private string orderId;
        private OrderServices orderServices;
        private StaffModel staff;

        public PaymentMethod(StaffModel staff, OrderServices orderServices)
        {
            InitializeComponent();
            this.orderServices = orderServices;
            this.staff = staff;

            List<string> x = orderServices.getAvailablePayments();
            x.ForEach(e => cb.Items.Add(e));
            if (x.Count > 0)
                cb.SelectedIndex = 0;

            if (x.Contains("Cash"))
                cb.SelectedIndex = x.IndexOf("Cash");


            cb_SelectedIndexChanged(this, EventArgs.Empty);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cb.SelectedIndex == -1)
                    throw new InvalidPayment("No Payment is Selected");

                IPaymentFactoryType factory = new PaymentFactory(orderServices);
                IPayment payment = factory.paymentType(cb.SelectedItem.ToString());

                double totalD = payment.calculateFee(double.Parse(total.Text));
                bool suc = payment.processPayment(staff, orderId, totalD);
                if (suc)
                    MessageBox.Show("Successfull Payment", "Payment Method", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Failed to Proceed Payment", "Payment Method", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Payment Method", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb.SelectedIndex == -1) return;

            if (cb.SelectedItem.ToString() == "Cash")
            {
                t1.Visible = true;
                l1.Visible = true;
            }
            else
            {
                t1.Visible = false;
                l1.Visible = false;
            }
        }



        public void displayTotal(string text, string orderId)
        {
            total.Text = text;
            this.orderId = orderId;
        }
    }
}
