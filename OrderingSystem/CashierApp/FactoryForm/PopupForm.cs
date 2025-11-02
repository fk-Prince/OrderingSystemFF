using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace OrderingSystem.CashierApp.Forms.FactoryForm
{
    public partial class PopupForm : Form
    {

        public event EventHandler buttonClicked;
        public event EventHandler comboChanged1;
        public PopupForm()
        {
            InitializeComponent();
        }
        private void guna2Button1_Click(object sender, System.EventArgs e)
        {
            foreach (var c in Controls)
            {
                if (c is Guna2TextBox t && isRequired(t) && (string.IsNullOrEmpty(t.Text) && t.Visible))
                {
                    MessageBox.Show("Empty Input Fill all fields");
                    return;
                }

                if (c is ComboBox b && isRequired(b) && (string.IsNullOrEmpty(b.Text) && b.Visible))
                {
                    MessageBox.Show("Empty Input Fill all fields");
                    return;
                }
            }


            buttonClicked?.Invoke(this, EventArgs.Empty);
        }
        private void guna2PictureBox1_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        private void c1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboChanged1?.Invoke(c1, EventArgs.Empty);
        }

        private bool isRequired(Control b)
        {
            return !(b.Tag?.ToString().Equals("Optional", StringComparison.OrdinalIgnoreCase) ?? false);
        }
    }
}
