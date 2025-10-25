﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.CashierApp.Forms.Category;
using OrderingSystem.Exceptions;
using OrderingSystem.Model;
using OrderingSystem.Services;

namespace OrderingSystem.CashierApp.Components
{
    public partial class CategoryCard : Guna2Panel
    {
        private CategoryModel c;
        private CategoryServices categoryServices;
        public event EventHandler SuccessAction;
        public CategoryCard(CategoryServices categoryServices, CategoryModel c)
        {
            InitializeComponent();
            this.categoryServices = categoryServices;
            this.c = c;
            display();
            layout();
        }

        private void layout()
        {
            BackColor = Color.Transparent;
            FillColor = Color.FromArgb(242, 242, 242);
            BorderRadius = 8;
            ShadowDecoration.Enabled = true;


        }

        private void click(Control c)
        {
            c.Click += update;

            foreach (Control cc in c.Controls)
            {
                click(cc);
            }
        }

        private void display()
        {
            name.Text = c.CategoryName;
            image.Image = c.CategoryImage;
        }

        private void update(object sender, EventArgs be)
        {
            CategoryPopup cat = new CategoryPopup("Update Category");
            cat.displayCategory(c);
            cat.ButtonClicked += (s, e) =>
            {
                CategoryPopup cc = s as CategoryPopup;
                try
                {
                    bool succ = categoryServices.updateCateogry(c.CategoryId, cc.name.Text, cc.image.Image);
                    if (succ)
                    {
                        MessageBox.Show("Category Successfully Updated", "Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cat.DialogResult = DialogResult.OK;
                        SuccessAction?.Invoke(this, EventArgs.Empty);
                    }
                    else MessageBox.Show("Category Failed to Updated", "Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DuplicateException ex)
                {
                    MessageBox.Show(ex.Message, "Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Internal Server Error", "Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            DialogResult rs = cat.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                cat.Hide();
            }
        }

        public void isAuthorized()
        {
            click(this);
        }
    }
}
