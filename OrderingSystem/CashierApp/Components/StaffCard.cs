using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.CashierApp.Forms.FactoryForm;
using OrderingSystem.CashierApp.Forms.Staffs;
using OrderingSystem.Model;

namespace OrderingSystem.CashierApp.Components
{
    public partial class StaffCard : Guna2Panel
    {
        private StaffModel staff;
        private StaffModel user;
        public event EventHandler staffUpdated;
        private IForms iForms;
        public StaffCard(StaffModel staff, IForms iForms)
        {
            InitializeComponent();
            this.staff = staff;
            BorderRadius = 3;
            id.Text = staff.StaffId.ToString();
            image.Image = staff.Image;
            name.Text = staff.FirstName.Substring(0, 1).ToUpper() + staff.FirstName.Substring(1).ToLower() + "  " + staff.LastName.Substring(0, 1).ToUpper() + staff.LastName.Substring(1).ToLower();
            role.Text = staff.Role.Substring(0, 1).ToUpper() + staff.Role.Substring(1);

            effects(this);
            this.iForms = iForms;
        }

        public void userStaff(StaffModel user)
        {
            this.user = user;
        }

        private void effects(Control c)
        {
            c.Click += xd;

            foreach (Control cc in c.Controls)
            {
                effects(cc);
            }
        }

        private void xd(object sender, EventArgs e)
        {
            StaffInformation s = new StaffInformation(user);
            s.staffUpdated += (ss, ee) => staffUpdated.Invoke(this, EventArgs.Empty);
            s.displayStaff(staff);
            DialogResult rs = iForms.selectForm(s, "view-staff").ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                s.Hide();
            }
        }
    }
}
