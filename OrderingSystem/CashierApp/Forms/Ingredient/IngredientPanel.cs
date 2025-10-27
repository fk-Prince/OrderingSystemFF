using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OrderingSystem.CashierApp.Forms.FactoryForm;
using OrderingSystem.Exceptions;
using OrderingSystem.Model;
using OrderingSystem.Repository.Ingredients;
using OrderingSystem.Services;

namespace OrderingSystem.CashierApp.Forms.Ingredient
{
    public class IngredientPanel
    {
        private readonly IForms iForms;
        private readonly IngredientServices ingredientServices;
        public event EventHandler ingredientUpdated;
        public IngredientPanel(IForms iForms)
        {
            this.iForms = iForms;
            ingredientServices = new IngredientServices(new IngredientRepository());
        }
        public void popupAddIngredient(Form parentForm)
        {
            PopupForm p = new PopupForm();
            p.c3.Items.Add("Piece");
            p.c3.Items.Add("Kg");
            p.c3.SelectedIndex = 0;
            p.buttonClicked += (s, e) =>
            {
                try
                {
                    bool suc = ingredientServices.validateAddIngredients(p.t1.Text.Trim(), p.t2.Text.Trim(), p.c3.Text, p.dt4.Value);
                    if (suc)
                    {
                        MessageBox.Show("Successful Added", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ingredientUpdated.Invoke(this, EventArgs.Empty);
                        p.Hide();
                    }
                    else
                        MessageBox.Show("Failed to add ingredient", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (InvalidInput ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Internal Server Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            DialogResult rs = iForms.selectForm(p, "add-ingredients").ShowDialog(parentForm);
            if (rs == DialogResult.OK)
            {
                p.Hide();
            }
        }
        public void popupDeductIngredient(Form parentForm)
        {
            PopupForm p = new PopupForm();

            var stocks = ingredientServices.getIngredientStock();
            stocks.ForEach(i => p.c1.Items.Add(i.IngredientStockId));
            var reasons = ingredientServices.getReasons("deduct");
            p.c4.Items.AddRange(reasons.ToArray());
            p.buttonClicked += (ss, ee) =>
            {
                try
                {
                    var selected = stocks.FirstOrDefault(i => i.IngredientStockId == (int)p.c1.SelectedItem);
                    bool suc = ingredientServices.validateDeductionIngredientStock((int)p.c1.SelectedItem, int.Parse(p.t3.Text.Trim()), p.c4.Text.Trim(), selected);
                    if (suc)
                    {
                        MessageBox.Show("Successful", "Deduct", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ingredientUpdated.Invoke(this, EventArgs.Empty);

                        p.Hide();
                    }
                    else
                        MessageBox.Show("Failed to deduct ingredient stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (InvalidInput ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Internal Server Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            p.comboChanged1 += (ss, ee) =>
            {
                if (ss is ComboBox cb && cb.SelectedIndex >= 0)
                {
                    p.t2.Text = stocks.FirstOrDefault(i => i.IngredientStockId == (int)cb.SelectedItem).IngredientName;
                }
            };
            DialogResult rs = iForms.selectForm(p, "deduct-ingredients").ShowDialog(parentForm);
            if (rs == DialogResult.OK)
            {
                p.Hide();
            }
        }
        public void popupRestockIngredient(Form parentForm)
        {
            int id = 0;
            PopupForm p = new PopupForm();
            p.buttonClicked += (ss, ee) =>
            {
                try
                {
                    bool suc = ingredientServices.validateRestockIngredient(id, p.t2.Text.Trim(), p.dt3.Value, p.c4.Text);
                    if (suc)
                    {
                        MessageBox.Show("Successful", "Restock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ingredientUpdated.Invoke(this, EventArgs.Empty);
                        p.Hide();
                    }
                    else
                        MessageBox.Show("Failed to Restock ingredient", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                catch (InvalidInput ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show("Internal Server Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }; List<IngredientModel> ingredients = ingredientServices.getIngredients();
            p.c1.Items.AddRange(ingredients.Select(i => i.IngredientName).ToArray());
            List<string> reas = ingredientServices.getReasons("Add");
            p.c4.Items.AddRange(reas.ToArray());
            p.comboChanged1 += (ss, ee) =>
            {
                if (ss is ComboBox cb && cb.SelectedIndex >= 0)
                {
                    p.l2.Text = $"Quantity  ( {ingredients.FirstOrDefault(i => i.IngredientName.Equals(cb.SelectedItem.ToString())).IngredientUnit} )";
                    id = ingredients.FirstOrDefault(i => i.IngredientName.Equals(cb.SelectedItem.ToString())).Ingredient_id;
                }
            };

            DialogResult rs = iForms.selectForm(p, "restock-ingredients").ShowDialog(parentForm);
            if (rs == DialogResult.OK)
            {
                p.Hide();
            }
        }
    }
}
