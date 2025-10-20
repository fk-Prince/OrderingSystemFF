using System.Windows.Forms;

namespace OrderingSystem.CashierApp.Forms.Utilities
{
    public class UtilityFormFactory
    {

        public GenerateUtilityForm FactoryForm(Form f, string type)
        {
            if (type.ToLower() == "coupon")
                return null;


            return null;
        }
    }
}
