namespace ManageSchedule.UserControls
{
    partial class MotThongBao
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSubj = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoEllipsis = true;
            this.labelTitle.BackColor = System.Drawing.SystemColors.Control;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(325, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Tiêu đề";
            this.labelTitle.Click += new System.EventHandler(this.Form_Click);
            // 
            // labelSubj
            // 
            this.labelSubj.AutoEllipsis = true;
            this.labelSubj.BackColor = System.Drawing.SystemColors.Control;
            this.labelSubj.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSubj.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubj.Location = new System.Drawing.Point(0, 25);
            this.labelSubj.Name = "labelSubj";
            this.labelSubj.Size = new System.Drawing.Size(325, 24);
            this.labelSubj.TabIndex = 1;
            this.labelSubj.Text = "Môn học";
            this.labelSubj.Click += new System.EventHandler(this.Form_Click);
            // 
            // labelTime
            // 
            this.labelTime.AutoEllipsis = true;
            this.labelTime.BackColor = System.Drawing.SystemColors.Control;
            this.labelTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTime.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(0, 49);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(325, 25);
            this.labelTime.TabIndex = 2;
            this.labelTime.Text = "Thời gian";
            this.labelTime.Click += new System.EventHandler(this.Form_Click);
            // 
            // MotThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelSubj);
            this.Controls.Add(this.labelTitle);
            this.Name = "MotThongBao";
            this.Size = new System.Drawing.Size(325, 75);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubj;
        private System.Windows.Forms.Label labelTime;
    }
}
