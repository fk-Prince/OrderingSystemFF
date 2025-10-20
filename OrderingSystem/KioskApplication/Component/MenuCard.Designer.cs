namespace OrderingSystem.KioskApplication.Cards
{
    partial class MenuCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuCard));
            this.menuName = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.image = new Guna.UI2.WinForms.Guna2PictureBox();
            this.price = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // menuName
            // 
            this.menuName.AutoSize = true;
            this.menuName.BackColor = System.Drawing.Color.Transparent;
            this.menuName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuName.Location = new System.Drawing.Point(12, 9);
            this.menuName.Name = "menuName";
            this.menuName.Size = new System.Drawing.Size(121, 25);
            this.menuName.TabIndex = 0;
            this.menuName.Text = "Menu Name";
            // 
            // description
            // 
            this.description.BackColor = System.Drawing.Color.Transparent;
            this.description.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(34, 147);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(202, 59);
            this.description.TabIndex = 2;
            this.description.Text = "Descirption";
            this.description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // image
            // 
            this.image.BackColor = System.Drawing.Color.Transparent;
            this.image.FillColor = System.Drawing.Color.Transparent;
            this.image.Image = ((System.Drawing.Image)(resources.GetObject("image.Image")));
            this.image.ImageRotate = 0F;
            this.image.Location = new System.Drawing.Point(152, 9);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(122, 100);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image.TabIndex = 3;
            this.image.TabStop = false;
            this.image.UseTransparentBackground = true;
            // 
            // price
            // 
            this.price.BackColor = System.Drawing.Color.Transparent;
            this.price.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.Location = new System.Drawing.Point(13, 77);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(78, 21);
            this.price.TabIndex = 1;
            this.price.Text = "Price";
            this.price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.price.Click += new System.EventHandler(this.price_Click);
            // 
            // MenuCard
            // 
            this.ClientSize = new System.Drawing.Size(282, 230);
            this.Controls.Add(this.image);
            this.Controls.Add(this.description);
            this.Controls.Add(this.price);
            this.Controls.Add(this.menuName);
            this.Name = "MenuCard";
            this.Text = "MenuCard";
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label menuName;
        private System.Windows.Forms.Label description;
        private Guna.UI2.WinForms.Guna2PictureBox image;
        private System.Windows.Forms.Label price;
    }
}