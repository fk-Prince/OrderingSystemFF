using System;
using System.Drawing;
using System.Windows.Forms;
using OrderingSystem.Model;

namespace OrderingSystem.CashierApp.Forms.Category
{
    public partial class CategoryPopup : Form
    {
        public event EventHandler ButtonClicked;
        private Image cat = null;
        public CategoryPopup(string type)
        {
            InitializeComponent();
            b.Text = type;

        }

        public void displayCategory(CategoryModel cat)
        {
            this.cat = cat.CategoryImage;
            image.Image = cat.CategoryImage;
            name.Text = cat.CategoryName;
        }

        private void image_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Image Files (*.jpg, *.png)|*.jpg;*.png";
            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                string imagePath = ofd.FileName;
                image.ImageLocation = imagePath;
            }
            else
            {
                image.ImageLocation = null;
                image.Image = cat;
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
