using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using OrderingSystem.Model;

namespace OrderingSystem.Receipt
{
    public partial class OrderReceipt : Form
    {
        private Image image = Properties.Resources.bloopandas;
        private string orderId;
        private int y = 200;
        private int x = 10;
        private int page = 1;
        private static int lastRead = 0;
        private List<MenuModel> menus;
        private OrderModel om;
        private string message;
        public OrderReceipt(OrderModel om)
        {
            InitializeComponent();
            this.orderId = om.Order_id;
            this.menus = om.OrderList;
            this.om = om;
        }
        private int baseHeight;
        private int itemHeight;
        private int totalHeight;
        public void d()
        {
            int baseHeight = 700;
            int rowHeight = 40;
            int height = 0;
            if (menus.Count > 1)
            {
                height = Math.Max(rowHeight * menus.Count + baseHeight, baseHeight);
            }
            else
            {
                height = baseHeight;
            }


            PaperSize customSize = new PaperSize("Custom", 400, height);
            printDocument.DefaultPageSettings.PaperSize = customSize;
            printDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);


            printPreviewDialog.Document = printDocument;
            printPreviewDialog.WindowState = FormWindowState.Maximized;
            printPreviewDialog.ShowDialog();
        }

        public void Message(string message)
        {
            this.message = message;
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(image, 235, 20, 140, 140);
            e.Graphics.DrawString("BlooPanda", new Font("Segui UI", 23, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline), Brushes.Black, 15, 25);
            e.Graphics.DrawString("506 J.P. Laurel Ave,", new Font("Segui UI", 9, FontStyle.Regular), Brushes.Black, 15, 65);
            e.Graphics.DrawString("Poblacion District, Davao City", new Font("Segui UI", 9, FontStyle.Regular), Brushes.Black, 15, 80);
            e.Graphics.DrawString("Order No.: ", new Font("Segui UI", 9, FontStyle.Regular), Brushes.Black, 15, y);
            e.Graphics.DrawString(orderId.ToString(), new Font("Segui UI", 9, FontStyle.Regular | FontStyle.Underline), Brushes.Black, 90, y);
            y += 50;

            e.Graphics.DrawLine(Pens.Black, x + 25, y, x + 25, y + 20);
            e.Graphics.DrawString("Qty", new Font("Segui UI", 9, FontStyle.Regular | FontStyle.Underline), Brushes.Black, x, y);
            x += 30;
            e.Graphics.DrawString("Menu Name", new Font("Segui UI", 9, FontStyle.Regular | FontStyle.Underline), Brushes.Black, x, y);
            x += 290;
            e.Graphics.DrawLine(Pens.Black, x - 10, y, x - 10, y + 20);
            e.Graphics.DrawString("Price", new Font("Segui UI", 9, FontStyle.Regular | FontStyle.Underline), Brushes.Black, x, y);
            x = 10;
            y += 20;


            Brush brush = Brushes.Black;
            Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
            Font mainFont = new Font("Segui UI", 9);
            for (int i = lastRead; i < menus.Count; i++)
            {
                MenuModel a = menus[i];
                e.Graphics.DrawString(a.PurchaseQty.ToString(), mainFont, Brushes.Black, x, y);
                e.Graphics.DrawLine(Pens.Black, x + 25, y - 30, x + 25, y + 30);
                e.Graphics.DrawLine(Pens.Black, x + 310, y - 30, x + 310, y + 30);
                x += 30;
                e.Graphics.DrawString(a.MenuName, mainFont, Brushes.Black, x, y);
                y += 15;
                x += 30;
                if (a is MenuModel)
                {
                    string va = a.SizeName?.ToLower().Trim() == a.FlavorName?.ToLower().Trim() ? a.SizeName : a.SizeName + "  " + a.FlavorName;
                    e.Graphics.DrawString(va, mainFont, Brushes.Black, x, y);
                }
                x += 260;
                e.Graphics.DrawString(a.GetTotal().ToString("N2"), mainFont, Brushes.Black, x, y);

                x = 10;
                y += 35;
            }

            y += 20;
            SizeF size1;
            double subtotald = menus.Sum(o => o.GetTotal());
            double couponRated = menus.Sum(o => o.GetTotal() * om.CouponRate);
            double vatd = menus.Sum(o => (o.GetTotal() - om.CouponRate) * 0.12);
            double rated = om.CouponRate * 100;
            double totald = (subtotald - couponRated) + vatd;

            int y1 = y;

            e.Graphics.DrawString("Subtotal", new Font("Segui UI", 9, FontStyle.Regular), Brushes.Black, x, y);
            y += 20;
            e.Graphics.DrawString("Discount Rate", new Font("Segui UI", 9, FontStyle.Regular), Brushes.Black, x, y);
            y += 20;
            e.Graphics.DrawString("VAT", new Font("Segui UI", 9, FontStyle.Regular), Brushes.Black, x, y);
            y += 20;
            e.Graphics.DrawString("Total Amount", new Font("Segui UI", 10, FontStyle.Bold | FontStyle.Regular), Brushes.Black, x, y);


            x += 360;
            size1 = graphics.MeasureString(subtotald.ToString("N2"), mainFont);
            e.Graphics.DrawString(subtotald.ToString("N2"), mainFont, Brushes.Black, x - size1.Width, y1);
            y1 += 20;
            size1 = graphics.MeasureString(couponRated.ToString("N2"), mainFont);
            e.Graphics.DrawString(couponRated.ToString("N2"), mainFont, Brushes.Black, x - size1.Width, y1);
            y1 += 20;
            size1 = graphics.MeasureString(vatd.ToString("N2"), mainFont);
            e.Graphics.DrawString(vatd.ToString("N2"), mainFont, Brushes.Black, x - size1.Width, y1);
            y1 += 20;
            size1 = graphics.MeasureString(totald.ToString("N2"), new Font("Segui UI", 10, FontStyle.Bold | FontStyle.Regular));
            e.Graphics.DrawString(totald.ToString("N2"), new Font("Segui UI", 10, FontStyle.Bold | FontStyle.Regular), Brushes.Black, x - size1.Width, y1);

            int bx = 5;
            for (int b = 0; b < 55; b++)
            {
                e.Graphics.DrawString("-", new Font("Sans-serif", 9), Brushes.Black, bx, y + 40);
                bx += 7;
            }

            e.Graphics.DrawString(message, new Font("Segui UI", 15, FontStyle.Bold), Brushes.Black, 90, y + 80);
        }
    }
}
