namespace ManageSchedule
{
    partial class FormThongBaoTrongNgay
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
            this.panelControl = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.labelCancel = new System.Windows.Forms.Label();
            this.panelNotice = new System.Windows.Forms.Panel();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.BackColor = System.Drawing.Color.MediumTurquoise;
            this.panelControl.Controls.Add(this.labelName);
            this.panelControl.Controls.Add(this.labelCancel);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl.Location = new System.Drawing.Point(1, 1);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(350, 40);
            this.panelControl.TabIndex = 0;
            // 
            // labelName
            // 
            this.labelName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelName.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(0, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(265, 40);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "ASSM Schedule";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCancel
            // 
            this.labelCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelCancel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCancel.ForeColor = System.Drawing.Color.White;
            this.labelCancel.Location = new System.Drawing.Point(310, 0);
            this.labelCancel.Name = "labelCancel";
            this.labelCancel.Size = new System.Drawing.Size(40, 40);
            this.labelCancel.TabIndex = 0;
            this.labelCancel.Text = "X";
            this.labelCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelCancel.Click += new System.EventHandler(this.labelCancel_Click);
            this.labelCancel.MouseLeave += new System.EventHandler(this.labelCancel_MouseLeave);
            this.labelCancel.MouseHover += new System.EventHandler(this.labelCancel_MouseHover);
            // 
            // panelNotice
            // 
            this.panelNotice.BackColor = System.Drawing.SystemColors.Control;
            this.panelNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNotice.Location = new System.Drawing.Point(1, 41);
            this.panelNotice.Name = "panelNotice";
            this.panelNotice.Size = new System.Drawing.Size(350, 310);
            this.panelNotice.TabIndex = 1;
            // 
            // FormThongBaoTrongNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(352, 352);
            this.Controls.Add(this.panelNotice);
            this.Controls.Add(this.panelControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormThongBaoTrongNgay";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "FormThongBaoSK";
            this.panelControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Label labelCancel;
        private System.Windows.Forms.Panel panelNotice;
        private System.Windows.Forms.Label labelName;
    }
}