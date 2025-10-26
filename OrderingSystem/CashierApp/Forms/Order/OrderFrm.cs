using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.CashierApp.Forms.Order;
using OrderingSystem.Exceptions;
using OrderingSystem.KioskApplication.Services;
using OrderingSystem.Model;
using OrderingSystem.Repository;
using OrderingSystem.Repository.Order;

namespace OrderingSystem.CashierApp.Forms
{
    public partial class OrderFrm : Form
    {
        private DataTable table;
        private OrderModel om;
        private readonly OrderServices orderServices;
        private readonly IOrderRepository orderRepository;

        public OrderFrm()
        {
            InitializeComponent();
            orderRepository = new OrderRepository();
            orderServices = new OrderServices(orderRepository);
            initTable();
        }
        private void initTable()
        {
            table = new DataTable();
            table.Columns.Add("Order-ID");
            table.Columns.Add("Name");
            table.Columns.Add("Price");
            table.Columns.Add("Quantity");
            table.Columns.Add("Total Amount", typeof(string));
            dataGrid.DataSource = table;
        }

        private void displayOrders()
        {
            try
            {
                string orderId = txt.Text.Trim();
                om = orderServices.getAllOrders(orderId);

                DialogResult = DialogResult.OK;
                if (om.OrderList.Count > 0)
                {

                    foreach (var order in om.OrderList)
                    {
                        DataRow row = table.NewRow();
                        row["Order-ID"] = om.Order_id;
                        row["Name"] = order.MenuName;
                        row["Price"] = order.MenuPrice;
                        row["Quantity"] = order.PurchaseQty;
                        row["Total Amount"] = order.GetTotal();
                        table.Rows.Add(row);
                    }
                    double subtotald = om.OrderList.Sum(o => o.MenuPrice * o.PurchaseQty);
                    double couponRated = subtotald * om.CouponRate;
                    double vatd = (subtotald - couponRated) * 0.12;
                    double totald = (subtotald - couponRated) + vatd;

                    double rated = om.CouponRate * 100;
                    subtotal.Text = subtotald.ToString("N2");
                    coupon.Text = couponRated.ToString("N2");
                    rate.Text = rated != 0 ? rated.ToString() + "%" : "";
                    vat.Text = vatd.ToString("N2");
                    total.Text = totald.ToString("N2");
                }
            }
            catch (Exception ex) when (ex is OrderInvalid || ex is OrderNotFound)
            {
                MessageBox.Show(ex.Message, "Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal Server Error" + ex.Message, "Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void reset(object sender, System.EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            table.Clear();
            txt.Text = "";
            subtotal.Text = "0.00";
            coupon.Text = "0.00";
            vat.Text = "0.00";
            total.Text = "0.00";

        }
        private void cashPayment(object sender, System.EventArgs e)
        {
            PaymentMethod p = new PaymentMethod(orderServices);
            p.displayTotal(total.Text, txt.Text.Trim());
            DialogResult rs = p.ShowDialog(this);

            if (rs == DialogResult.OK)
            {
                p.Hide();
                clear();
            }
        }

        private void txt_MouseDown(object sender, MouseEventArgs e)
        {
            var txt = sender as Guna2TextBox;
            Rectangle iconBounds = new Rectangle(13, 19, 35, 35);

            if (iconBounds.Contains(e.Location))
            {
                displayOrders();
            }
        }
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                displayOrders();
                e.Handled = true;
            }
        }
    }
}
