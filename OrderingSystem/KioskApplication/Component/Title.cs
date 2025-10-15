using System;
using System.Drawing;
using Guna.UI2.WinForms;

namespace OrderingSystem.KioskApplication.Component
{
    public partial class Title : Guna2Panel
    {
        public Title(string title)
        {
            InitializeComponent();
            tt.Text = title;
            AutoRoundedCorners = true;
            BorderColor = Color.DarkGray;
            BackColor = Color.Transparent;
            FillColor = Color.DarkGray;

            BorderThickness = 1;
        }

        private void tt_Click(object sender, EventArgs e)
        {

        }
    }
}
