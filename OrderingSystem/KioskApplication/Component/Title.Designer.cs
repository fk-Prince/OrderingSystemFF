﻿namespace OrderingSystem.KioskApplication.Component
{
    partial class Title
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
            this.tt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tt
            // 
            this.tt.AutoSize = true;
            this.tt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tt.ForeColor = System.Drawing.Color.White;
            this.tt.Location = new System.Drawing.Point(24, 7);
            this.tt.Name = "tt";
            this.tt.Size = new System.Drawing.Size(52, 21);
            this.tt.TabIndex = 0;
            this.tt.Text = "label1";
            this.tt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Title
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(236, 35);
            this.Controls.Add(this.tt);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Title";
            this.Text = "Title";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label tt;
    }
}