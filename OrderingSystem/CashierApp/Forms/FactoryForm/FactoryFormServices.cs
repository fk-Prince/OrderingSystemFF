using System.Windows.Forms;
using OrderingSystem.Services;

namespace OrderingSystem.CashierApp.Forms.FactoryForm
{
    public class FactoryFormServices
    {

        public static bool saveFormData(PopupForm f, string type)
        {
            if (type.ToLower() == "coupon")
            {
                bool suc = new CouponServices().saveAction(f.t1.Text, f.dt1.Value, f.t3.Text, f.t4.Text);
                if (suc) MessageBox.Show("Successfully Generated");
                else MessageBox.Show("Failed Generated");
            }
            return false;
        }
    }
}
