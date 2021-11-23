namespace ManageSchedule
{
    partial class FormCaiDat
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
            this.label1 = new System.Windows.Forms.Label();
            this.tgbBgProcess = new DemoUI.ToggleButton();
            this.tgbDeadline = new DemoUI.ToggleButton();
            this.tgbEvent = new DemoUI.ToggleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Form Cai Dat";
            // 
            // tgbBgProcess
            // 
            this.tgbBgProcess.Location = new System.Drawing.Point(129, 133);
            this.tgbBgProcess.MinimumSize = new System.Drawing.Size(45, 22);
            this.tgbBgProcess.Name = "tgbBgProcess";
            this.tgbBgProcess.OffBackColor = System.Drawing.Color.Gray;
            this.tgbBgProcess.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.tgbBgProcess.OnBackColor = System.Drawing.Color.MediumTurquoise;
            this.tgbBgProcess.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tgbBgProcess.Size = new System.Drawing.Size(50, 22);
            this.tgbBgProcess.TabIndex = 2;
            this.tgbBgProcess.Text = "toggleButton1";
            this.tgbBgProcess.UseVisualStyleBackColor = true;
            this.tgbBgProcess.CheckedChanged += new System.EventHandler(this.tgbBgProcess_CheckedChanged);
            // 
            // tgbDeadline
            // 
            this.tgbDeadline.Location = new System.Drawing.Point(191, 194);
            this.tgbDeadline.MinimumSize = new System.Drawing.Size(45, 22);
            this.tgbDeadline.Name = "tgbDeadline";
            this.tgbDeadline.OffBackColor = System.Drawing.Color.Gray;
            this.tgbDeadline.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.tgbDeadline.OnBackColor = System.Drawing.Color.MediumTurquoise;
            this.tgbDeadline.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tgbDeadline.Size = new System.Drawing.Size(50, 22);
            this.tgbDeadline.TabIndex = 3;
            this.tgbDeadline.Text = "toggleButton2";
            this.tgbDeadline.UseVisualStyleBackColor = true;
            // 
            // tgbEvent
            // 
            this.tgbEvent.Location = new System.Drawing.Point(191, 241);
            this.tgbEvent.MinimumSize = new System.Drawing.Size(45, 22);
            this.tgbEvent.Name = "tgbEvent";
            this.tgbEvent.OffBackColor = System.Drawing.Color.Gray;
            this.tgbEvent.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.tgbEvent.OnBackColor = System.Drawing.Color.MediumTurquoise;
            this.tgbEvent.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tgbEvent.Size = new System.Drawing.Size(50, 22);
            this.tgbEvent.TabIndex = 4;
            this.tgbEvent.Text = "toggleButton3";
            this.tgbEvent.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(185, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cho phép ứng dụng chạy ngầm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(247, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Thông báo deadline";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(247, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Thông báo event";
            // 
            // FormCaiDat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 640);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tgbEvent);
            this.Controls.Add(this.tgbDeadline);
            this.Controls.Add(this.tgbBgProcess);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCaiDat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "FormCaiDat";
            this.Load += new System.EventHandler(this.FormCaiDat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DemoUI.ToggleButton tgbBgProcess;
        private DemoUI.ToggleButton tgbDeadline;
        private DemoUI.ToggleButton tgbEvent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}