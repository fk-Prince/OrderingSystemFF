﻿using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OrderingSystem.CashierApp.SessionData;
using OrderingSystem.Services;
using Font = iTextSharp.text.Font;

namespace OrderingSystem.CashierApp.Forms
{
    public partial class Reports : Form
    {
        private DataView view;
        private InventoryServices inventoryServices;
        private string title;
        public Reports(InventoryServices inventoryServices)
        {
            InitializeComponent();
            this.inventoryServices = inventoryServices;
            dtTo.Value = DateTime.Now;
            cb.SelectedIndex = 0;
            cb_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void txt_TextChanged(object sender, System.EventArgs e)
        {
            db.Stop();
            db.Start();
        }


        private void filter()
        {
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string s = cb.Text;
            title = s;
            switch (s)
            {
                case "Track Quantity In/Out":
                    reportTrackQuantity();
                    break;
                case "Expiry Tracking":
                    reportExpirationIngredient();
                    break;
                case "Inventory Reports":
                    reportInventory();
                    break;
                case "Ingredient Usage":
                    reportIngredientUsage();
                    break;
                case "Menu Popular's":
                    reportMenuPopular();
                    break;
                case "Menu Performance":
                    reportMenuPerformance();
                    break;
            }
            ;



            dataGrid.Refresh();
        }
        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb.SelectedIndex == -1) return;
            string s = cb.Text;

            if (s == "Track Quantity In/Out")
            {
                txt.PlaceholderText = "Search Staff, Ingredient";
                view = inventoryServices.getTrackingIngredients();
            }
            else if (s == "Expiry Tracking")
            {
                txt.PlaceholderText = "Search Ingredient";
                view = inventoryServices.getIngredientExpiry();
            }
            else if (s == "Inventory Reports")
            {
                txt.PlaceholderText = "Search Staff, Ingredient";
                view = inventoryServices.getInventorySummaryReports();
            }
            else if (s == "Ingredient Usage")
            {
                txt.PlaceholderText = "Search Ingredient";
                view = inventoryServices.getIngredientsUsage();
            }
            else if (s == "Menu Popular's")
            {
                txt.PlaceholderText = "Search Menu";
                view = inventoryServices.getMenuPopularity();
            }
            else if (s == "Menu Performance")
            {
                txt.PlaceholderText = "Search Menu, Flavor, Size, Price";
                view = inventoryServices.getMenuPerformance();
            }
            dataGrid.DataSource = view;
            dataGrid.Refresh();
            filter();
        }
        private void dtTo_ValueChanged(object sender, System.EventArgs e)
        {
            filter();
        }
        private void dtFrom_ValueChanged(object sender, System.EventArgs e)
        {
            filter();
        }
        private void dt2_ValueChanged(object sender, EventArgs e)
        {
            filter();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            db.Stop();
            filter();
        }
        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            }

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                row.Cells[e.ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#DBEAFE");
            }
        }
        private void dataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            }

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                row.Cells[e.ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#DBEAFE");
            }

        }

        // -- REPORTS
        private void reportTrackQuantity()
        {
            p1.Visible = true;
            p2.Visible = false;
            string staffFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Staff Incharge] LIKE '%{txt.Text}%'";
            string ingredientFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Ingredient Name] LIKE '%{txt.Text}%'";
            string dateFilter = $"[Date-Action] >= #{dtFrom.Value:yyyy-MM-dd}# AND [Date-Action] <= #{dtTo.Value:yyyy-MM-dd}#";
            string staff_ingredient_filter = string.Join(" OR ", new[] { staffFilter, ingredientFilter }.Where(f => !string.IsNullOrEmpty(f)));
            string finalFilter = string.IsNullOrEmpty(staff_ingredient_filter) ? dateFilter : $"({staff_ingredient_filter}) AND {dateFilter}";
            view.RowFilter = finalFilter;
        }
        private void reportExpirationIngredient()
        {
            p1.Visible = true;
            p2.Visible = false;
            string ingredientFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Ingredient Name] LIKE '%{txt.Text}%'";
            string dateFilter = $"[Expiry Date] >= #{dtFrom.Value:yyyy-MM-dd}# AND [Expiry Date] <= #{dtTo.Value:yyyy-MM-dd}#";
            string finalFilter = string.Join(" OR ", new[] { ingredientFilter, dateFilter }.Where(f => !string.IsNullOrEmpty(f)));
            view.RowFilter = finalFilter;
        }
        private void reportInventory()
        {
            p1.Visible = true;
            p2.Visible = false;
            string staffFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Staff Incharge] LIKE '%{txt.Text}%'";
            string ingredientFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Ingredient Name] LIKE '%{txt.Text}%'";
            string dateFilter = $"[IN - Recorded At] >= #{dtFrom.Value:yyyy-MM-dd}# AND [IN - Recorded At] <= #{dtTo.Value:yyyy-MM-dd}#";
            string staff_ingredient_filter = string.Join(" OR ", new[] { staffFilter, ingredientFilter }.Where(f => !string.IsNullOrEmpty(f)));
            string finalFilter = string.IsNullOrEmpty(staff_ingredient_filter) ? dateFilter : $"({staff_ingredient_filter}) AND {dateFilter}";
            view.RowFilter = finalFilter;
        }
        private void reportIngredientUsage()
        {
            dt2.CustomFormat = "yyyy";
            dataGrid.Columns[0].Width = 200;
            dataGrid.Columns[1].Width = 150;
            dt2.Value = DateTime.Now;
            p1.Visible = false;
            p2.Visible = true;
            string ingredientFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Ingredient Name] LIKE '%{txt.Text}%'";
            if (string.IsNullOrEmpty(txt.Text))
            {
                string dateFilter = $"([Year] = '{dt2.Value.Year}' OR [Year] = 'Total' OR [Year] = 'Total per Year')";
                view.RowFilter = dateFilter;
            }
            else
            {
                string dateFilter = $"([Year] = '{dt2.Value.Year}' OR [Year] = 'Total')";
                string finalFilter = $"{ingredientFilter} AND {dateFilter}";
                view.RowFilter = finalFilter;
            }
        }
        private void reportMenuPerformance()
        {
            p1.Visible = true;
            p2.Visible = false;
            string menuFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Menu Name] LIKE '%{txt.Text}%'";
            string sizeFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Size] LIKE '%{txt.Text}%'";
            string flavorFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Flavor] LIKE '%{txt.Text}%'";
            string priceFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Price] LIKE '%{txt.Text}%'";
            string finalFilter = string.Join(" OR ", new[] { menuFilter, sizeFilter, flavorFilter, priceFilter }.Where(f => !string.IsNullOrEmpty(f)));
            view.RowFilter = finalFilter;
        }
        private void reportMenuPopular()
        {
            dt2.CustomFormat = "yyyy-MMMM";
            dt2.Value = DateTime.Now;
            p1.Visible = false;
            p2.Visible = true;
            string dateFilter = $"[Year] = '{dt2.Value.Year}' AND [Month] = '{dt2.Value.ToString("MMMM")}'";
            string menuFilter = string.IsNullOrEmpty(txt.Text) ? "" : $"[Menu Name] LIKE '%{txt.Text}%'";
            string finalFilter = string.Join(" AND ", new[] { menuFilter, dateFilter }.Where(f => !string.IsNullOrEmpty(f)));
            view.RowFilter = finalFilter;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DataTable table = view.ToTable();
            using (var save = new SaveFileDialog { Filter = "PDF File|*.pdf", FileName = $"{title + " - " + DateTime.Now.ToString("yyyy-MM-dd")}" })
            {
                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (var doc = new Document(PageSize.A4, 10f, 10f, 20f, 20f))
                    {
                        PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));
                        doc.Open();

                        Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                        Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                        doc.Add(new Paragraph("Report: " + title, headerFont));
                        doc.Add(new Paragraph("Requested By: " + SessionStaffData.getFullName(), normalFont));
                        doc.Add(new Paragraph("Date: " + DateTime.Now.ToString("yyyy-MM-dd"), normalFont));
                        doc.Add(new Paragraph(" "));
                        doc.Add(new Paragraph(" "));

                        PdfPTable pdfTable = new PdfPTable(table.Columns.Count);
                        pdfTable.WidthPercentage = 100;

                        Font columnHeaderFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                        foreach (DataColumn column in table.Columns)
                        {
                            PdfPCell headerCell = new PdfPCell(new Phrase(column.ColumnName, columnHeaderFont));
                            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            headerCell.Padding = 10;
                            headerCell.MinimumHeight = 30f;
                            headerCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                            pdfTable.AddCell(headerCell);
                        }

                        foreach (DataRow row in table.Rows)
                        {
                            foreach (var cell in row.ItemArray)
                            {
                                PdfPCell dataCell = new PdfPCell(new Phrase(cell?.ToString() ?? ""));
                                dataCell.Padding = 5;
                                pdfTable.AddCell(dataCell);
                            }
                        }

                        doc.Add(pdfTable);
                        doc.Close();
                    }
                    MessageBox.Show("Report saved to PDF", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
