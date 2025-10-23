namespace OrderingSystem.CashierApp.Forms.Coupon
{
    partial class CouponFrm
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
            this.mm = new Guna.UI2.WinForms.Guna2Panel();
            this.SuspendLayout();
            // 
            // mm
            // 
            this.mm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mm.Location = new System.Drawing.Point(0, 0);
            this.mm.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.mm.MinimumSize = new System.Drawing.Size(1017, 636);
            this.mm.Name = "mm";
            this.mm.Size = new System.Drawing.Size(1121, 660);
            this.mm.TabIndex = 0;
            // 
            // CouponFrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1121, 660);
            this.Controls.Add(this.mm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1121, 660);
            this.Name = "CouponFrm";
            this.Text = "CouponFrm";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel mm;
    }
}