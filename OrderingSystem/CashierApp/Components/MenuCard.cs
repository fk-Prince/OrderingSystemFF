using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.Model;

namespace OrderingSystem.CashierApp.Forms.Menu
{
    public partial class MenuCard : Guna2Panel


    {
        private MenuModel menu;
        public MenuCard(MenuModel menu)
        {
            InitializeComponent();
            this.menu = menu;
            cardLayout();
            menuName.Text = menu.MenuName;
            menuDescription.Text = menu.MenuDescription;
            image.Image = menu.MenuImage;

        }

        private void cardLayout()
        {
            BorderRadius = 10;
            BorderThickness = 1;
            BackColor = Color.Transparent;
            FillColor = ColorTranslator.FromHtml("#DBEAFE");
            BorderColor = ColorTranslator.FromHtml("#DBEAFE");
            hoverEffects(this);
            //handleClick(this);
        }

        private void handleClick(Control c)
        {
            c.MouseDown += HandleClickEvent;
            foreach (Control cc in c.Controls)
            {
                handleClick(cc);
            }
        }

        private void HandleClickEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                showoption(e.Location);
            }
        }
        private static Guna2Panel c;
        private void showoption(Point location)
        {
            if (c != null && c.Parent != null)
            {
                c.Parent.Controls.Remove(c);
                c.Dispose();
            }
            c = new Guna2Panel();
            c.Location = location;
            c.Size = new Size(150, 60);
            c.BackColor = Color.FromArgb(34, 34, 34);

            Guna2Button b = new Guna2Button();
            b.Size = new Size(150, 30);
            b.Text = "View";
            b.Click += viewMenuDetail;
            c.Controls.Add(b);

            Guna2Button b1 = new Guna2Button();
            b1.Size = new Size(150, 30);
            b1.Location = new Point(0, b.Bottom);
            b1.Click += updateMenuDetail;
            b1.Text = "Update";
            c.Controls.Add(b1);

            this.Controls.Add(c);
            c.BringToFront();
        }

        private void updateMenuDetail(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void viewMenuDetail(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        private void hoverEffects(Control c)
        {
            c.Cursor = Cursors.Hand;
            //c.MouseEnter += (s, e) =>
            //{
            //    BorderColor = ColorTranslator.FromHtml("#689FF9");
            //    BorderThickness = 2;
            //};

            //c.MouseLeave += (s, e) =>
            //{
            //    BorderColor = ColorTranslator.FromHtml("#DBEAFE");
            //    BorderThickness = 1;
            //};

            foreach (Control cc in c.Controls)
            {
                hoverEffects(cc);
            }
        }

    }
}
