using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OrderingSystem.CashierApp.Components;
using OrderingSystem.CashierApp.Forms.FactoryForm;
using OrderingSystem.Model;
using OrderingSystem.Repository.Staff;

namespace OrderingSystem.CashierApp.Forms.Staffs
{
    public partial class StaffFrm : Form
    {
        private IStaffRepository staffRepository;
        private StaffModel staff;
        private IForms iForms;
        public StaffFrm(StaffModel staff)
        {
            InitializeComponent();
            iForms = new FormFactory();
            staffRepository = new StaffRepository();

            List<StaffModel> staffList = staffRepository.getStaff();

            foreach (var st in staffList)
            {
                StaffCard s = new StaffCard(st, iForms);
                s.staffUpdated += refreshList;
                s.userStaff(staff);
                flowPanel.Controls.Add(s);
            }
        }

        private void refreshList(object sender, EventArgs e)
        {
            flowPanel.Controls.Clear();
            List<StaffModel> staffList = staffRepository.getStaff();
            foreach (var st in staffList)
            {
                StaffCard s = new StaffCard(st, iForms);
                s.staffUpdated += refreshList;
                s.userStaff(staff);
                flowPanel.Controls.Add(s);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            StaffInformation s = new StaffInformation(staff);
            s.staffUpdated += (ss, ee) => refreshList(this, EventArgs.Empty);
            DialogResult rs = iForms.selectForm(s, "add-staff").ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                s.Hide();
            }
        }
    }
}
