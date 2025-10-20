using System;
using System.Collections.Generic;
using System.Drawing;
using Guna.UI2.WinForms;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApplication.Components
{
    public partial class FlavorLayout : Guna2Panel
    {
        private List<MenuModel> menuDetails;
        public event EventHandler<MenuModel> FlavorSelected;
        private List<MyRadioButton> radioSamples;

        public FlavorLayout(List<MenuModel> menuDetails)
        {
            InitializeComponent();
            this.menuDetails = menuDetails;


            BorderRadius = 8;
            BorderColor = Color.LightGray;
            BorderThickness = 1;
            Width = 730;
            FillColor = Color.FromArgb(244, 244, 244);
            BackColor = Color.Transparent;

            displayFlavor();


        }

        public void setTitle(string text, string x)
        {
            titleOption.Text = text;
            menuName.Text = x;
        }


        public void setSubTitle(string text)
        {
            subTitle.Text = text;
        }

        private void displayFlavor()
        {
            int y = 40;
            bool isFirst = true;
            radioSamples = new List<MyRadioButton>();
            foreach (var m in menuDetails)
            {
                double p = 0;
                string priceText;

                if (m.getPrice() <= menuDetails[0].getPrice())
                {
                    priceText = "Free";
                }
                else
                {
                    p = m.getPrice() - menuDetails[0].getPrice();
                    priceText = p.ToString("N2");
                }

                string displayPrice = isFirst ? "Free" : priceText;

                MyRadioButton rs = new MyRadioButton(m.FlavorName, displayPrice, m);
                rs.Location = new Point(50, titleOption.Bottom + y);
                rs.RadioCheckedChanged += (s, e) =>
                {

                    foreach (var r in radioSamples)
                    {
                        if (r != rs)
                        {
                            r.Radio().Checked = false;
                        }
                    }
                    if (rs.Radio().Checked && m.MaxOrder > 0)
                    {
                        FlavorSelected?.Invoke(this, m);
                    }
                    else if (m.MaxOrder <= 0)
                    {
                        FlavorSelected?.Invoke(this, null);
                    }
                };
                Controls.Add(rs);
                radioSamples.Add(rs);
                y += 50;
                this.Height += 40;
                isFirst = false;
            }
        }

        public void defaultSelection()
        {
            if (menuDetails.Count > 0 && radioSamples.Count > 0)
            {

                int x = 0;
                foreach (var i in menuDetails)
                {
                    if (i.MaxOrder > 0)
                    {

                        radioSamples[x].Radio().Checked = true;
                        FlavorSelected?.Invoke(this, menuDetails[x]);
                        break;
                    }
                    else
                    {
                        x++;
                        FlavorSelected?.Invoke(this, null);
                    }
                }
            }
        }
    }
}
