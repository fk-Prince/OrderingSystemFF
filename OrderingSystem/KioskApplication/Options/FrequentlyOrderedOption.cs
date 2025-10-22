using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OrderingSystem.Model;
using OrderingSystem.Repository;


namespace OrderingSystem.KioskApplication.Options
{
    public class FrequentlyOrderedOption : ISelectedFrequentlyOrdered
    {
        private FrequentlyOrderedLayout fot;
        private FlowLayoutPanel flowPanel;
        private IKioskMenuRepository _menuRepository;
        public FrequentlyOrderedOption(IKioskMenuRepository _menuRepository, FlowLayoutPanel flowPanel)
        {
            this.flowPanel = flowPanel;
            this._menuRepository = _menuRepository;
        }

        public void displayFrequentlyOrdered(MenuModel menus)
        {
            try
            {
                List<MenuModel> md = _menuRepository.getFrequentlyOrderedTogether(menus);
                if (flowPanel.Contains(fot))
                {
                    flowPanel.Controls.SetChildIndex(fot, flowPanel.Controls.Count - 1);
                    return;
                }

                if (md.Min(m => m.MaxOrder) <= 20) return;


                fot = new FrequentlyOrderedLayout(md);
                fot.Margin = new Padding(20, 30, 0, 20);
                flowPanel.Controls.Add(fot);
                if (flowPanel.Controls.Contains(fot))
                {
                    flowPanel.Controls.SetChildIndex(fot, flowPanel.Controls.Count - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Internal Server Error." + ex.Message);
            }
        }

        public List<MenuModel> getFrequentlyOrdered()
        {
            if (fot != null)
            {
                return fot.getFrequentlyOrderList();
            }
            return null;
        }
    }
}
