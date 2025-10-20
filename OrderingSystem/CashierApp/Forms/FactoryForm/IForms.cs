using System.Windows.Forms;

namespace OrderingSystem.CashierApp.Forms.FactoryForm
{
    public interface IForms
    {
        Form selectForm(string type);
    }
}
