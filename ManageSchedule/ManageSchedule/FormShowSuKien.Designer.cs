
namespace ManageSchedule
{
    partial class FormShowSuKien
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
            this.flPnl1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flPnlTotal = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSukien = new System.Windows.Forms.Panel();
            this.flPnlTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // flPnl1
            // 
            this.flPnl1.Location = new System.Drawing.Point(0, 0);
            this.flPnl1.Margin = new System.Windows.Forms.Padding(0);
            this.flPnl1.Name = "flPnl1";
            this.flPnl1.Size = new System.Drawing.Size(421, 30);
            this.flPnl1.TabIndex = 0;
            // 
            // flPnlTotal
            // 
            this.flPnlTotal.Controls.Add(this.flPnl1);
            this.flPnlTotal.Controls.Add(this.pnlSukien);
            this.flPnlTotal.Location = new System.Drawing.Point(0, 0);
            this.flPnlTotal.Name = "flPnlTotal";
            this.flPnlTotal.Size = new System.Drawing.Size(421, 536);
            this.flPnlTotal.TabIndex = 1;
            // 
            // pnlSukien
            // 
            this.pnlSukien.AutoScroll = true;
            this.pnlSukien.AutoScrollMargin = new System.Drawing.Size(3, 3);
            this.pnlSukien.AutoScrollMinSize = new System.Drawing.Size(3, 3);
            this.pnlSukien.Location = new System.Drawing.Point(0, 30);
            this.pnlSukien.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSukien.Name = "pnlSukien";
            this.pnlSukien.Size = new System.Drawing.Size(421, 506);
            this.pnlSukien.TabIndex = 1;
            // 
            // FormShowSuKien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 536);
            this.Controls.Add(this.flPnlTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(421, 536);
            this.Name = "FormShowSuKien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormShowSuKien";
            this.Deactivate += new System.EventHandler(this.FormShowSuKien_Deactivate);
            this.flPnlTotal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flPnl1;
        private System.Windows.Forms.FlowLayoutPanel flPnlTotal;
        private System.Windows.Forms.Panel pnlSukien;
    }
}