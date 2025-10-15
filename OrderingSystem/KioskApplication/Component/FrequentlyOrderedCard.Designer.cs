namespace OrderingSystem.KioskApplication.Components
{
    partial class FrequentlyOrderedCard
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
            this.menuName = new System.Windows.Forms.Label();
            this.detail = new System.Windows.Forms.Label();
            this.image = new Guna.UI2.WinForms.Guna2PictureBox();
            this.price = new System.Windows.Forms.Label();
            this.checkBox = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // menuName
            // 
            this.menuName.AutoEllipsis = true;
            this.menuName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuName.Location = new System.Drawing.Point(135, 13);
            this.menuName.Name = "menuName";
            this.menuName.Size = new System.Drawing.Size(422, 34);
            this.menuName.TabIndex = 0;
            this.menuName.Text = "label1";
            // 
            // detail
            // 
            this.detail.AutoSize = true;
            this.detail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detail.Location = new System.Drawing.Point(189, 47);
            this.detail.Name = "detail";
            this.detail.Size = new System.Drawing.Size(43, 17);
            this.detail.TabIndex = 1;
            this.detail.Text = "label1";
            // 
            // image
            // 
            this.image.BorderRadius = 3;
            this.image.ImageRotate = 0F;
            this.image.Location = new System.Drawing.Point(53, 13);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(76, 76);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image.TabIndex = 2;
            this.image.TabStop = false;
            // 
            // price
            // 
            this.price.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.Location = new System.Drawing.Point(561, 38);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(109, 22);
            this.price.TabIndex = 3;
            this.price.Text = "label1";
            this.price.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.price.Click += new System.EventHandler(this.price_Click);
            // 
            // checkBox
            // 
            this.checkBox.Checked = true;
            this.checkBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.checkBox.CheckedState.BorderRadius = 2;
            this.checkBox.CheckedState.BorderThickness = 1;
            this.checkBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkBox.CheckMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.checkBox.Location = new System.Drawing.Point(13, 38);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(23, 26);
            this.checkBox.TabIndex = 4;
            this.checkBox.Text = "guna2CustomCheckBox1";
            this.checkBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.checkBox.UncheckedState.BorderRadius = 2;
            this.checkBox.UncheckedState.BorderThickness = 1;
            this.checkBox.UncheckedState.FillColor = System.Drawing.Color.White;
            this.checkBox.Click += new System.EventHandler(this.checkBoxChanged);
            // 
            // FrequentlyOrderedCard
            // 
            this.ClientSize = new System.Drawing.Size(693, 101);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.price);
            this.Controls.Add(this.image);
            this.Controls.Add(this.detail);
            this.Controls.Add(this.menuName);
            this.Name = "FrequentlyOrderedCard";
            this.Text = "FotCard";
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label menuName;
        private System.Windows.Forms.Label detail;
        private Guna.UI2.WinForms.Guna2PictureBox image;
        private System.Windows.Forms.Label price;
        private Guna.UI2.WinForms.Guna2CustomCheckBox checkBox;
    }
}