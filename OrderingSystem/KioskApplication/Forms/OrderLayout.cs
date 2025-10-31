using System;
using System.Linq;
using System.Windows.Forms;
using OrderingSystem.KioskApplication.Component;
using OrderingSystem.KioskApplication.Services;
using OrderingSystem.Model;
using OrderingSystem.Receipt;

namespace OrderingSystem.KioskApplication.Forms
{
    public partial class OrderLayout : Form
    {
        private OrderModel om;
        private OrderServices orderServices;
        public event EventHandler successfulPayment;
        public event EventHandler<OrderItemModel> AddQuantity;
        public event EventHandler<OrderItemModel> DeductQuantity;
        public OrderLayout(OrderModel om, OrderServices orderServices)
        {
            InitializeComponent();
            this.om = om;
            this.orderServices = orderServices;

            foreach (var i in om.OrderItemList)
            {
                OrderCard oc = new OrderCard(i);
                oc.Margin = new Padding(50, 0, 0, 10);
                oc.AddQuantity += (s, e) => { AddQuantity?.Invoke(this, i); };
                oc.DeductQuantity += (s, e) => { DeductQuantity?.Invoke(this, i); };
                flow.Controls.Add(oc);
            }
        }
        public void refersh()
        {
            foreach (var cc in flow.Controls.OfType<OrderCard>())
            {
                cc.refreshDetail();
            }
        }
        private void guna2Button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                bool suc = orderServices.confirmOrder(om);
                if (suc)
                {
                    OrderReceipt or = new OrderReceipt(om);
                    or.Message("Proceed to the cashier \n    Within 30 minutes", DateTime.Now.AddMinutes(30).ToString("hh:mm:ss tt"), "");
                    or.print();
                    successfulPayment?.Invoke(this, EventArgs.Empty);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal Server Error." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
