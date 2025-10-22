using System.Windows.Forms;
using OrderingSystem.CashierApp.Forms.Staffs;

namespace OrderingSystem.CashierApp.Forms.FactoryForm
{
    public class FormFactory : IForms
    {
        public Form selectForm(Form fx, string type)
        {
            if (fx is PopupForm f && type.ToLower() == "coupon")
            {
                f.dt1.Visible = true;
                f.t2.Visible = false;
                f.l1.Text = "Rate %";
                f.l2.Text = "Expiry Date";
                f.l3.Text = "Number of Times";
                f.l4.Text = "Description";
                f.b1.Text = "Submit";
                f.title.Text = "Generate Coupon";
            }
            else if (fx is PopupForm f2 && type.ToLower() == "add-ingredients")
            {
                f2.l1.Text = "Ingredient Name";
                f2.l2.Text = "Initial-Stock";
                f2.l3.Text = "Expiry-Date";
                f2.l4.Text = "Unit";
                f2.b1.Text = "Submit";
                f2.title.Text = "Add Ingredients";
            }
            else if (fx is PopupForm f3 && type.ToLower() == "restock-ingredients")
            {
                f3.l1.Text = "Ingredient Id";
                f3.l2.Text = "Quantity";
                f3.l3.Text = "Expiry-Date";
                f3.t4.Visible = false;
                f3.l4.Visible = false;
                f3.b1.Text = "Submit";
                f3.title.Text = "Restock Ingredients";
            }
            else if (fx is StaffInformation z && type.ToLower() == "add-staff")
            {
                z.fb.Visible = false;
                z.b1.Text = "Add Staff";
                z.cRolePanel.Visible = false;
                z.cRole.Visible = true;
                z.ll.Visible = true;
                z.fn.Visible = true;
                z.firstName.Visible = true;
                z.lastName.Visible = true;
                z.fName.Visible = false;
                z.ffn.Visible = false;
                z.dt.Visible = true;
                z.rr.Visible = true;
                z.hired.Visible = false;
            }
            else if (fx is StaffInformation x && type.ToLower() == "view-staff")
            {
                x.b1.Text = "Update";
            }
            return fx;
        }
    }
}
