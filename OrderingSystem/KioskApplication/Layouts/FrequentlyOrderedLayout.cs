using System.Collections.Generic;
using System.Drawing;
using Guna.UI2.WinForms;
using OrderingSystem.KioskApplication.Components;
using OrderingSystem.Model;

namespace OrderingSystem.KioskApplication
{
    public partial class FrequentlyOrderedLayout : Guna2Panel
    {

        private List<OrderItemModel> checkList;
        public FrequentlyOrderedLayout(List<MenuModel> menus)
        {
            InitializeComponent();
            checkList = new List<OrderItemModel>();

            BorderRadius = 8;
            BorderColor = Color.LightGray;
            BorderThickness = 1;
            FillColor = Color.FromArgb(244, 244, 244);
            BackColor = Color.Transparent;

            displayFrequentlyOrdered(menus);
        }
        private void displayFrequentlyOrdered(List<MenuModel> menu)
        {
            int y = 30;

            foreach (var m in menu)
            {
                if (m.MaxOrder <= 10) continue;
                FrequentlyOrderedCard fot = new FrequentlyOrderedCard(m);
                fot.Location = new Point(20, title.Bottom + y);
                fot.checkedMenu += (s, e) => { checkList.Add(e); };
                fot.unCheckedMenu += (s, e) => { checkList.Remove(e); };
                this.Controls.Add(fot);
                y += 120;
                this.Height += 110;
            }
        }

        public List<OrderItemModel> getFrequentlyOrderList()
        {
            return checkList;
        }
    }
}
