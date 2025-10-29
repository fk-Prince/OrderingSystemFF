using System;
using System.Drawing;
using Guna.UI2.WinForms;

namespace OrderingSystem.KioskApplication.Component
{
    public partial class Title : Guna2Panel
    {
        public Title(string title, Image img)
        {
            InitializeComponent();
            tt.Text = title;
            AutoRoundedCorners = true;
            //BorderColor = ColorTranslator.FromHtml("#EFF6FF");
            BorderColor = Color.FromArgb(9, 119, 206);
            BackColor = Color.Transparent;
            FillColor = ColorTranslator.FromHtml("#689FF9");
            im.Image = img;
            BorderThickness = 1;
        }

        private void tt_Click(object sender, EventArgs e)
        {

        }
    }
}
