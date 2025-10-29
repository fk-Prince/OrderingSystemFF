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
using OrderingSystem.Receipt;
using OrderingSystem.Repository;
using OrderingSystem.Repository.Order;

namespace OrderingSystem.CashierApp.Forms
{
    public partial class OrderFrm : Form
    {
        private DataTable table;
        private OrderModel om;
        string orderId;
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
            table.Columns.Add("Note");
            table.Columns.Add("Note Approval", typeof(bool));
            table.Columns.Add("Price");
            table.Columns.Add("Quantity");
            table.Columns.Add("Total Amount", typeof(string));
            dataGrid.DataSource = table;
            dataGrid.Columns["Note Approval"].Width = 70;
            DataGridViewCheckBoxColumn fx = new DataGridViewCheckBoxColumn();
            fx.DataPropertyName = "Note Approval";
            fx.HeaderText = "Note Approval";
            dataGrid.CellValueChanged += (s, e) =>
            {
                if (e.ColumnIndex == dataGrid.Columns["Note Approval"].Index && e.RowIndex >= 0)
                {
                    bool approved = (bool)dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    om.OrderItemList[e.RowIndex].NoteApproved = approved;
                }
            };
        }

        private void displayOrders()
        {
            try
            {
                orderId = txt.Text.Trim();
                om = orderServices.getAllOrders(orderId);




                if (om.OrderItemList.Count > 0)
                {
                    foreach (var order in om.OrderItemList)
                    {
                        table.Rows.Add(om.OrderId, order.MenuName, order.Note, order.NoteApproved, order.Price, order.PurchaseQty, order.getTotal());
                    }
                }

                double subtotald = om.OrderItemList.Sum(o => o.getTotal());
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
            p.setOrder(om);
            DialogResult rs = p.ShowDialog(this);

            if (rs == DialogResult.OK)
            {
                Tuple<TimeSpan, string> xd = orderServices.getTimeInvoiceWaiting(om.OrderId);
                OrderReceipt or = new OrderReceipt(om);
                or.Message("Wait for your Order", xd.Item1.ToString(@"hh\:mm\:ss"), xd.Item2);
                or.print();
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
