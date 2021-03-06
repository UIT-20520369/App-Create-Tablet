
namespace ManageSchedule
{
    partial class FormDayView
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
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lbDay = new System.Windows.Forms.Label();
            this.flPnlListDay = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlTotal.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTotal
            // 
            this.pnlTotal.Controls.Add(this.flPnlListDay);
            this.pnlTotal.Controls.Add(this.pnlTitle);
            this.pnlTotal.Location = new System.Drawing.Point(0, 0);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(1124, 621);
            this.pnlTotal.TabIndex = 0;
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.btnNext);
            this.pnlTitle.Controls.Add(this.btnPre);
            this.pnlTitle.Controls.Add(this.lbDay);
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1124, 50);
            this.pnlTitle.TabIndex = 0;
            // 
            // lbDay
            // 
            this.lbDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDay.Font = new System.Drawing.Font("Calibri Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDay.Location = new System.Drawing.Point(0, 0);
            this.lbDay.Name = "lbDay";
            this.lbDay.Size = new System.Drawing.Size(1124, 50);
            this.lbDay.TabIndex = 0;
            this.lbDay.Text = "Tháng mười hai";
            this.lbDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flPnlListDay
            // 
            this.flPnlListDay.AutoScroll = true;
            this.flPnlListDay.Location = new System.Drawing.Point(0, 53);
            this.flPnlListDay.Name = "flPnlListDay";
            this.flPnlListDay.Size = new System.Drawing.Size(1123, 568);
            this.flPnlListDay.TabIndex = 1;
            // 
            // btnPre
            // 
            this.btnPre.FlatAppearance.BorderSize = 0;
            this.btnPre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPre.Image = global::ManageSchedule.Properties.Resources.chevron_circle;
            this.btnPre.Location = new System.Drawing.Point(12, 3);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(50, 50);
            this.btnPre.TabIndex = 0;
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnNext
            // 
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Image = global::ManageSchedule.Properties.Resources.chevron_circle_right;
            this.btnNext.Location = new System.Drawing.Point(1071, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 50);
            this.btnNext.TabIndex = 1;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // FormDayView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 621);
            this.Controls.Add(this.pnlTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDayView";
            this.Text = "FormDayView";
            this.pnlTotal.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.FlowLayoutPanel flPnlListDay;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lbDay;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
    }
}