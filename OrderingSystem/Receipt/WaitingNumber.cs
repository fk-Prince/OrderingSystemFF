using System.Drawing.Printing;
using System.Windows.Forms;
using OrderingSystem.Model;

namespace OrderingSystem.Receipt
{
    public partial class WaitingNumber : Form
    {
        public WaitingNumber(OrderModel om)
        {
            InitializeComponent();
        }

        public void print()
        {
            PaperSize customSize = new PaperSize("Custom", 300, 300);
            pd.DefaultPageSettings.PaperSize = customSize;
            pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);


            ppd.Document = pd;
            ppd.WindowState = FormWindowState.Maximized;
            ppd.ShowDialog();
        }
        private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


            //e.Graphics()


        }
    }
}
