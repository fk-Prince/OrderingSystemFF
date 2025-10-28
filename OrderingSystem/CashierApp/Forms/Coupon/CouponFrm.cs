using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using OrderingSystem.CashierApp.Forms.FactoryForm;
using OrderingSystem.CashierApp.SessionData;
using OrderingSystem.Model;
using OrderingSystem.Services;

namespace OrderingSystem.CashierApp.Forms.Coupon
{
    public partial class CouponFrm : Form
    {
        private readonly CouponServices couponServices;
        private readonly TableLayout tableLayout;
        private DataView view;
        private readonly IForms f;

        public CouponFrm(IForms f, CouponServices couponServices)
        {
            InitializeComponent();
            this.f = f;
            this.couponServices = couponServices;

            loadForm(f.selectForm(tableLayout = new TableLayout(), "view-coupon"));
            tableLayout.FilterChanged += checkedChanged;
            tableLayout.ButtonClicked += addCouponPopup;
            displayCoupons();
        }

        private void addCouponPopup(object sender, EventArgs e)
        {

            PopupForm p = new PopupForm();
            p.buttonClicked += (ss, ee) =>
            {
                try
                {
                    bool suc = couponServices.saveAction(p.t1.Text, p.dt2.Value, p.t3.Text, p.t4.Text);
                    if (suc)
                    {
                        displayCoupons();
                        MessageBox.Show("Successfully generate coupons.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        p.Hide();
                    }
                    else
                        MessageBox.Show("Failed to generate coupons.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            DialogResult rs = f.selectForm(p, "coupon").ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                p.Hide();
            }
        }
        private void displayCoupons()
        {

            List<CouponModel> couponList = couponServices.getCoupons();
            DataTable table = new DataTable();
            table.Columns.Add("Coupon Code");
            table.Columns.Add("Description");
            table.Columns.Add("Rate %");
            table.Columns.Add("Until");
            table.Columns.Add("Status");

            couponList.ForEach(c =>
                table.Rows.Add(c.CouponCode, c.Description, c.CouponRate * 100,
                c.ExpiryDate.ToString("yyyy/MM/dd"), c.Status)
            );

            view = new DataView(table);
            tableLayout.dataGrid.DataSource = view;


            if (SessionStaffData.Role.ToLower() == "cashier")
                tableLayout.b1.Visible = false;
        }
        private void checkedChanged(object sender, bool e)
        {
            if (tableLayout.title.Text.ToLower() == "coupon")
            {
                if (tableLayout.cb.Checked)
                    view.RowFilter = "[Status] = 'Used'";
                else
                    view.RowFilter = "[Status] = 'Not-Used'";
            }
        }
        private void loadForm(Form f)
        {
            if (mm.Controls.Count > 0) mm.Controls.Clear();
            if (SessionStaffData.Role.ToLower() == "cashier" && f is TableLayout t) t.b1.Visible = false;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;

            mm.Controls.Add(f);
            mm.Tag = f;
            f.Show();
        }

    }
}
