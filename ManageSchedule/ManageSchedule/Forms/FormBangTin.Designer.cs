
namespace ManageSchedule
{
    partial class FormBangTin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBangTin));
            this.BoTronBangTin = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.PictureBoxTKB = new System.Windows.Forms.PictureBox();
            this.btnXuat = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnHuy = new Bunifu.Framework.UI.BunifuThinButton2();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTKB)).BeginInit();
            this.SuspendLayout();
            // 
            // BoTronBangTin
            // 
            this.BoTronBangTin.ElipseRadius = 10;
            this.BoTronBangTin.TargetControl = this;
            // 
            // PictureBoxTKB
            // 
            this.PictureBoxTKB.Location = new System.Drawing.Point(-8, -23);
            this.PictureBoxTKB.Name = "PictureBoxTKB";
            this.PictureBoxTKB.Size = new System.Drawing.Size(1155, 690);
            this.PictureBoxTKB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBoxTKB.TabIndex = 0;
            this.PictureBoxTKB.TabStop = false;
            // 
            // btnXuat
            // 
            this.btnXuat.ActiveBorderThickness = 1;
            this.btnXuat.ActiveCornerRadius = 20;
            this.btnXuat.ActiveFillColor = System.Drawing.Color.Gainsboro;
            this.btnXuat.ActiveForecolor = System.Drawing.Color.Black;
            this.btnXuat.ActiveLineColor = System.Drawing.Color.Black;
            this.btnXuat.BackColor = System.Drawing.Color.White;
            this.btnXuat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXuat.BackgroundImage")));
            this.btnXuat.ButtonText = "Xuất file excel";
            this.btnXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuat.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.ForeColor = System.Drawing.Color.Black;
            this.btnXuat.IdleBorderThickness = 1;
            this.btnXuat.IdleCornerRadius = 20;
            this.btnXuat.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(144)))));
            this.btnXuat.IdleForecolor = System.Drawing.Color.Black;
            this.btnXuat.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(144)))));
            this.btnXuat.Location = new System.Drawing.Point(330, 594);
            this.btnXuat.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(210, 45);
            this.btnXuat.TabIndex = 7;
            this.btnXuat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.ActiveBorderThickness = 1;
            this.btnHuy.ActiveCornerRadius = 20;
            this.btnHuy.ActiveFillColor = System.Drawing.Color.Gainsboro;
            this.btnHuy.ActiveForecolor = System.Drawing.Color.Black;
            this.btnHuy.ActiveLineColor = System.Drawing.Color.Black;
            this.btnHuy.BackColor = System.Drawing.Color.White;
            this.btnHuy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHuy.BackgroundImage")));
            this.btnHuy.ButtonText = "Hủy đặt mặc định";
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.Black;
            this.btnHuy.IdleBorderThickness = 1;
            this.btnHuy.IdleCornerRadius = 20;
            this.btnHuy.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(144)))));
            this.btnHuy.IdleForecolor = System.Drawing.Color.Black;
            this.btnHuy.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(144)))));
            this.btnHuy.Location = new System.Drawing.Point(594, 594);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(210, 45);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // FormBangTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1133, 679);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.PictureBoxTKB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBangTin";
            this.Text = "Bảng tin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBangTin_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTKB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse BoTronBangTin;
        private System.Windows.Forms.PictureBox PictureBoxTKB;
        private Bunifu.Framework.UI.BunifuThinButton2 btnHuy;
        private Bunifu.Framework.UI.BunifuThinButton2 btnXuat;
    }
}