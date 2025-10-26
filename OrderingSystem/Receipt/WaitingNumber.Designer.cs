namespace OrderingSystem.Receipt
{
    partial class WaitingNumber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitingNumber));
            this.ppd = new System.Windows.Forms.PrintPreviewDialog();
            this.pd = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // ppd
            // 
            this.ppd.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppd.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppd.ClientSize = new System.Drawing.Size(400, 300);
            this.ppd.Enabled = true;
            this.ppd.Icon = ((System.Drawing.Icon)(resources.GetObject("ppd.Icon")));
            this.ppd.Name = "printPreviewDialog1";
            this.ppd.Visible = false;
            // 
            // pd
            // 
            this.pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pd_PrintPage);
            // 
            // WaitingNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "WaitingNumber";
            this.Text = "WaitingNumber";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintPreviewDialog ppd;
        private System.Drawing.Printing.PrintDocument pd;
    }
}