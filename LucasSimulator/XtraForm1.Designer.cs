namespace LucasSimulator
{
    partial class XtraForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraForm1));
            this.xtraUserControl11 = new LucasSimulator.XtraUserControl1();
            this.SuspendLayout();
            // 
            // xtraUserControl11
            // 
            this.xtraUserControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraUserControl11.Location = new System.Drawing.Point(0, 0);
            this.xtraUserControl11.Name = "xtraUserControl11";
            this.xtraUserControl11.Size = new System.Drawing.Size(909, 553);
            this.xtraUserControl11.TabIndex = 0;
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 553);
            this.Controls.Add(this.xtraUserControl11);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("XtraForm1.IconOptions.Image")));
            this.MinimumSize = new System.Drawing.Size(911, 585);
            this.Name = "XtraForm1";
            this.Text = "Lucas Simulator";
            this.ResumeLayout(false);

        }

        #endregion

        private XtraUserControl1 xtraUserControl11;
    }
}