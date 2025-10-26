using System;
using System.Windows.Forms;
using OrderingSystem.CashierApp.Forms.Staffs;

namespace OrderingSystem.CashierApp.Forms.FactoryForm
{
    public class FormFactory : IForms
    {
        public Form selectForm(Form fx, string type)
        {
            if (fx is PopupForm f1 && type.ToLower() == "coupon")
            {
                f1.dt1.MinDate = DateTime.Now;
                f1.dt1.Visible = true;
                f1.t2.Visible = false;
                f1.l1.Text = "Rate %";
                f1.l2.Text = "Expiry Date";
                f1.l3.Text = "Number of Times";
                f1.l4.Text = "Description";
                f1.b1.Text = "Submit";
                f1.title.Text = "Generate Coupon";
                f1.dt1.MinDate = DateTime.Now;
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
                f3.t1.Visible = false;
                f3.t3.Visible = false;
                f3.t4.Visible = false;
                f3.l1.Text = "Ingredient Name";
                f3.l2.Text = "Quantity";
                f3.l4.Text = "Reason";
                f3.l3.Text = "Expiry-Date";
                f3.c1.Visible = true;
                f3.dt2.Visible = true;
                f3.dt2.MinDate = DateTime.Now.AddDays(1);
                f3.c4.Visible = true;
                f3.b1.Text = "Submit";
                f3.title.Text = "Restock Ingredients";
            }
            else if (fx is PopupForm f4 && type.ToLower() == "deduct-ingredients")
            {
                f4.t2.Enabled = false;
                f4.t4.Visible = false;
                f4.c1.Visible = true;
                f4.t1.Visible = false;
                f4.c4.Visible = true;
                f4.l1.Text = "Ingredient Stock Id";
                f4.l2.Text = "Ingredient Name";
                f4.l3.Text = "Quantity to remove";
                f4.l4.Text = "Reason";
                f4.b1.Text = "Submit";
                f4.title.Text = "Deduct Ingredients";
            }
            else if (fx is StaffInformation f5 && type.ToLower() == "add-staff")
            {
                f5.fb.Visible = false;
                f5.b1.Text = "Add Staff";
                f5.cRolePanel.Visible = false;
                f5.cRole.Visible = true;
                f5.ll.Visible = true;
                f5.fn.Visible = true;
                f5.firstName.Visible = true;
                f5.lastName.Visible = true;
                f5.fName.Visible = false;
                f5.ffn.Visible = false;
                f5.dt.Visible = true;
                f5.rr.Visible = true;
                f5.hired.Visible = false;
            }
            else if (fx is StaffInformation f6 && type.ToLower() == "view-staff")
            {
                f6.b1.Text = "Update";
            }
            else if (fx is TableLayout f7 && type.ToLower() == "category")
            {
                f7.cb.Visible = false;
                f7.title.Text = "Category";
            }
            else if (fx is TableLayout f8 && type.ToLower() == "view-coupon")
            {
                f8.b1.Text = "Add Coupon";
                f8.cb.Text = "View Used Coupon";
                f8.title.Text = "Coupon";
                f8.search.Visible = false;
            }

            return fx;
        }
    }
}
