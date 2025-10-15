using System;
using System.Collections.Generic;
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
        private int staff_id = 1;
        private string order_id;
        private readonly OrderServices orderServices;

        public OrderFrm(IOrderRepository orderRepository)
        {
            InitializeComponent();
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

            table.Rows.Add("ORD-000001", "Cheese", 900.00, 2, 1800);
            table.Rows.Add("ORD-000001", "Cheese", 900.00, 2, 1800);
            table.Rows.Add("ORD-000001", "Cheese", 900.00, 2, 1800);
            table.Rows.Add("ORD-000001", "Cheese", 900.00, 2, 1800);
            table.Rows.Add("ORD-000001", "Cheese", 900.00, 2, 1800);
            table.Rows.Add("ORD-000001", "Cheese", 900.00, 2, 1800);
            table.Rows.Add("ORD-000001", "Cheese", 900.00, 2, 1800);
        }
        public static OrderFrm orderFactory()
        {
            IOrderRepository orderRepository = new OrderRepository();
            return new OrderFrm(orderRepository);
        }
        private void displayOrders()
        {
            try
            {
                string orderId = txt.Text.Trim();
                List<OrderModel> om = orderServices.getAllOrders(orderId);
                DialogResult = DialogResult.OK;
                if (om.Count > 0)
                {
                    order_id = om[0].Order_id;
                    foreach (var order in om)
                    {
                        DataRow row = table.NewRow();
                        row["Order-ID"] = order.Order_id;
                        row["Name"] = order.Menu_name;
                        row["Price"] = order.PricePerQuantity;
                        row["Quantity"] = order.Quantity;
                        row["Total Amount"] = order.TotalPrice;
                        table.Rows.Add(row);
                    }
                    double subtotald = om.Sum(o => o.TotalPrice);
                    double couponRated = om.Sum(o => o.TotalPrice * o.CouponRate);
                    double vatd = om.Sum(o => (o.TotalPrice - o.CouponRate) * 0.12);
                    double rated = om[0].CouponRate * 100;
                    double totald = (subtotald - couponRated) + vatd;
                    subtotal.Text = subtotald.ToString("N2");
                    coupon.Text = couponRated.ToString("N2");
                    rate.Text = rated != 0 ? rated.ToString() + "%" : "";
                    vat.Text = vatd.ToString("N2");
                    total.Text = totald.ToString("N2");
                }
            }
            catch (Exception ex) when (ex is OrderInvalid || ex is OrderNotFound)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Server Error");
            }
        }
        private void reset(object sender, System.EventArgs e)
        {
            table.Clear();
            subtotal.Text = "0.00";
            order_id = "";
            coupon.Text = "0.00";
            vat.Text = "0.00";
            total.Text = "0.00";
        }
        private void cashPayment(object sender, System.EventArgs e)
        {
            PaymentMethod p = new PaymentMethod();
            p.ShowDialog(this);
            p.PaymentMethodChanged += (s, ee) => payment(ee);
        }

        private void payment(string payment_method)
        {
            try
            {
                if (string.IsNullOrEmpty(order_id))
                {
                    MessageBox.Show("No Orders");
                    return;
                }
                bool result = orderServices.payOrder(order_id, staff_id, payment_method);
                if (result) MessageBox.Show("Payment Success");
                else MessageBox.Show("Payment Failed");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal Server Error." + ex.Message);
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

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
