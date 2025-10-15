namespace OrderingSystem.KioskApplication.Components
{
    partial class MyRadioButton
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.price = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.name = new System.Windows.Forms.Label();
            this.ooo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // price
            // 
            this.price.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.Location = new System.Drawing.Point(519, 9);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(121, 25);
            this.price.TabIndex = 1;
            this.price.Text = "Price";
            this.price.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(488, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "₱";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioButton
            // 
            this.radioButton.BackColor = System.Drawing.Color.Transparent;
            this.radioButton.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioButton.CheckedState.BorderThickness = 2;
            this.radioButton.CheckedState.FillColor = System.Drawing.Color.White;
            this.radioButton.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioButton.Location = new System.Drawing.Point(21, 11);
            this.radioButton.Name = "radioButton";
            this.radioButton.Size = new System.Drawing.Size(17, 17);
            this.radioButton.TabIndex = 3;
            this.radioButton.Text = "guna2CustomRadioButton1";
            this.radioButton.UncheckedState.BorderColor = System.Drawing.Color.DimGray;
            this.radioButton.UncheckedState.BorderThickness = 2;
            this.radioButton.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radioButton.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(54, 8);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(50, 20);
            this.name.TabIndex = 4;
            this.name.Text = "label2";
            // 
            // ooo
            // 
            this.ooo.AutoSize = true;
            this.ooo.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ooo.ForeColor = System.Drawing.Color.DarkRed;
            this.ooo.Location = new System.Drawing.Point(258, 11);
            this.ooo.Name = "ooo";
            this.ooo.Size = new System.Drawing.Size(118, 20);
            this.ooo.TabIndex = 5;
            this.ooo.Text = "OUT OF ORDER";
            this.ooo.Visible = false;
            // 
            // MyRadioButton
            // 
            this.ClientSize = new System.Drawing.Size(663, 41);
            this.Controls.Add(this.ooo);
            this.Controls.Add(this.name);
            this.Controls.Add(this.radioButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.price);
            this.Name = "MyRadioButton";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CustomRadioButton radioButton;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label ooo;
    }
}