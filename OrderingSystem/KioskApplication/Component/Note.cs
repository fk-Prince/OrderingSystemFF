using System.Drawing;
using Guna.UI2.WinForms;

namespace OrderingSystem.KioskApplication.Component
{
    public partial class Note : Guna2Panel
    {
        public Note()
        {
            InitializeComponent();
            BorderRadius = 5;
            BorderColor = Color.DarkGray;
            BorderThickness = 1;
            FillColor = Color.FromArgb(244, 244, 244);
            BackColor = Color.Transparent;
        }
    }
}
