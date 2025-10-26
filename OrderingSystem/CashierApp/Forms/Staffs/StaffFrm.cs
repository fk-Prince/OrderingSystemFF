using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OrderingSystem.CashierApp.Components;
using OrderingSystem.CashierApp.Forms.FactoryForm;
using OrderingSystem.Model;
using OrderingSystem.Services;

namespace OrderingSystem.CashierApp.Forms.Staffs
{
    public partial class StaffFrm : Form
    {
        private readonly StaffServices staffServices;
        private readonly IForms iForms;
        public StaffFrm()
        {
            InitializeComponent();

            iForms = new FormFactory();
            staffServices = new StaffServices();

            refreshList(null, EventArgs.Empty);
        }

        private void refreshList(object sender, EventArgs e)
        {
            try
            {
                flowPanel.Controls.Clear();
                List<StaffModel> staffList = staffServices.getStaffs();
                foreach (var st in staffList)
                {
                    StaffCard s = new StaffCard(st, iForms, staffServices);
                    s.staffUpdated += refreshList;

                    flowPanel.Controls.Add(s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Staff", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            StaffInformation s = new StaffInformation(staffServices);
            s.staffUpdated += (ss, ee) => refreshList(this, EventArgs.Empty);
            DialogResult rs = iForms.selectForm(s, "add-staff").ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                s.Hide();
            }
        }
    }
}
