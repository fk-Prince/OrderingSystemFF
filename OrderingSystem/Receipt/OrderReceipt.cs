﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using OrderingSystem.CashierApp.SessionData;
using OrderingSystem.Model;

namespace OrderingSystem.Receipt
{
    public partial class OrderReceipt : Form
    {
        private Image image = Properties.Resources.bloopandas;
        private readonly string orderId;
        private readonly List<OrderItemModel> menus;
        private readonly OrderModel om;

        private int y = 170;
        private int x = 10;
        private string message;
        private double cash;
        private string invoice_id;
        private string estimated_date;

        public OrderReceipt(OrderModel om)
        {
            InitializeComponent();
            this.orderId = om.OrderId;
            this.menus = om.OrderItemList;
            this.om = om;
        }

        public void print()
        {
            int baseHeight = 700;
            int rowHeight = 40;
            int height = menus.Count > 1 ? Math.Max(rowHeight * menus.Count + baseHeight, baseHeight) : baseHeight;

            PaperSize customSize = new PaperSize("Custom", 400, height);
            printDocument.DefaultPageSettings.PaperSize = customSize;
            printDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

            printPreviewDialog.Document = printDocument;
            printPreviewDialog.WindowState = FormWindowState.Maximized;
            printPreviewDialog.ShowDialog();
        }

        public void Message(string message, string estimated_date, string invoice_id)
        {
            this.message = message;
            this.estimated_date = estimated_date;
            this.invoice_id = invoice_id;
        }

        public void Cash(double cash)
        {
            this.cash = cash;
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(image, 235, 20, 140, 140);
            e.Graphics.DrawString("BlooPanda", new Font("Segui UI", 23, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline), Brushes.Black, 15, 25);
            e.Graphics.DrawString("506 J.P. Laurel Ave,", new Font("Segui UI", 9, FontStyle.Regular), Brushes.Black, 15, 65);
            e.Graphics.DrawString("Poblacion District, Davao City", new Font("Segui UI", 9, FontStyle.Regular), Brushes.Black, 15, 80);
            if (!string.IsNullOrWhiteSpace(invoice_id))
            {
                e.Graphics.DrawString("Cashier Name.: ", new Font("Segui UI", 9, FontStyle.Regular), Brushes.Black, 15, y);
                e.Graphics.DrawString(SessionStaffData.getFullName(), new Font("Segui UI", 9, FontStyle.Regular | FontStyle.Underline), Brushes.Black, 110, y);
                y += 20;
                e.Graphics.DrawString("Invoice ID.: ", new Font("Segui UI", 9, FontStyle.Regular), Brushes.Black, 15, y);
                e.Graphics.DrawString(invoice_id.ToString(), new Font("Segui UI", 9, FontStyle.Regular | FontStyle.Underline), Brushes.Black, 90, y);
            }
            y += 20;
            e.Graphics.DrawString("Order No.: ", new Font("Segui UI", 9, FontStyle.Regular), Brushes.Black, 15, y);
            e.Graphics.DrawString(orderId.ToString(), new Font("Segui UI", 9, FontStyle.Regular | FontStyle.Underline | FontStyle.Bold), Brushes.Black, 90, y);
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
            int line = y + 30;
            for (int i = 0; i < menus.Count; i++)
            {
                OrderItemModel a = menus[i];
                e.Graphics.DrawString(a.PurchaseQty.ToString(), mainFont, Brushes.Black, x, y);
                e.Graphics.DrawLine(Pens.Black, x + 25, y - 30, x + 25, line);
                e.Graphics.DrawLine(Pens.Black, x + 310, y - 30, x + 310, line);
                x += 30;
                e.Graphics.DrawString(a.PurchaseMenu.MenuName, mainFont, Brushes.Black, x, y);
                y += 15;
                x += 30;
                string va = a.PurchaseMenu.SizeName?.ToLower().Trim() == a.PurchaseMenu.FlavorName?.ToLower().Trim() ? "( " + a.PurchaseMenu.SizeName + " )" : "( " + a.PurchaseMenu.SizeName + " - " + a.PurchaseMenu.FlavorName + " )";
                e.Graphics.DrawString(va, mainFont, Brushes.Black, x, y);
                x += 260;
                e.Graphics.DrawString(a.getSubtotal().ToString("N2"), mainFont, Brushes.Black, x, y);
                x = 10;
                y += 35;
                line = y + 50;

            }

            y += 20;
            SizeF size1;
            double subtotald = menus.Sum(o => o.getSubtotal());
            double couponRated = subtotald * (om.Coupon == null ? 0 : om.Coupon.CouponRate);
            double vatd = menus.Sum(o => (subtotald - couponRated) * 0.12);
            double withoutVat = menus.Sum(o => o.PurchaseMenu.MenuPrice * o.PurchaseQty);
            double totald = (subtotald - couponRated);

            int y1 = y;

            e.Graphics.DrawString("Subtotal", new Font("Segui UI", 9, FontStyle.Regular), Brushes.Black, x, y);
            y += 20;
            e.Graphics.DrawString("Coupon Rate", new Font("Segui UI", 9, FontStyle.Regular), Brushes.Black, x, y);
            y += 20;
            e.Graphics.DrawString("Less 12% VAT", new Font("Segui UI", 9, FontStyle.Regular), Brushes.Black, x, y);
            y += 20;
            e.Graphics.DrawString("Sales without VAT", new Font("Segui UI", 9, FontStyle.Regular), Brushes.Black, x, y);
            y += 20;
            e.Graphics.DrawString("Total Amount Due", new Font("Segui UI", 10, FontStyle.Bold | FontStyle.Regular), Brushes.Black, x, y);
            if (cash != 0)
            {
                y += 20;
                e.Graphics.DrawString("Cash", new Font("Segui UI", 10, FontStyle.Bold | FontStyle.Regular), Brushes.Black, x, y);
                y += 20;
                e.Graphics.DrawString("Change", new Font("Segui UI", 10, FontStyle.Bold | FontStyle.Regular), Brushes.Black, x, y);
            }


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
            size1 = graphics.MeasureString(withoutVat.ToString("N2"), mainFont);
            e.Graphics.DrawString(withoutVat.ToString("N2"), mainFont, Brushes.Black, x - size1.Width, y1);

            y1 += 20;
            size1 = graphics.MeasureString(totald.ToString("N2"), new Font("Segui UI", 10, FontStyle.Bold | FontStyle.Regular));
            e.Graphics.DrawString(totald.ToString("N2"), new Font("Segui UI", 10, FontStyle.Bold | FontStyle.Regular), Brushes.Black, x - size1.Width, y1);

            if (cash != 0)
            {
                y1 += 20;
                size1 = graphics.MeasureString(cash.ToString("N2"), new Font("Segui UI", 10, FontStyle.Bold | FontStyle.Regular));
                e.Graphics.DrawString(cash.ToString("N2"), new Font("Segui UI", 10, FontStyle.Bold | FontStyle.Regular), Brushes.Black, x - size1.Width, y1);

                y1 += 20;
                size1 = graphics.MeasureString((cash - totald).ToString("N2"), new Font("Segui UI", 10, FontStyle.Bold | FontStyle.Regular));
                e.Graphics.DrawString((cash - totald).ToString("N2"), new Font("Segui UI", 10, FontStyle.Bold | FontStyle.Regular), Brushes.Black, x - size1.Width, y1);
            }

            int bx = 5;
            for (int b = 0; b < 55; b++)
            {
                e.Graphics.DrawString("-", new Font("Sans-serif", 9), Brushes.Black, bx, y + 40);
                bx += 7;
            }

            y += 100;


            e.Graphics.DrawString(message, new Font("Segui UI", 15, FontStyle.Bold), Brushes.Black, 95, y);

            if (!string.IsNullOrWhiteSpace(estimated_date))
            {
                y += 80;
                size1 = e.Graphics.MeasureString(estimated_date, new Font("Segoe UI", 15, FontStyle.Regular));
                float x = (400 - size1.Width) / 2;
                e.Graphics.DrawString(estimated_date, new Font("Segui UI", 15, FontStyle.Regular), Brushes.Black, x, y);
            }

        }
    }
}
