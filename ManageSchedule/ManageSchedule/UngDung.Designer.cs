﻿
namespace ManageSchedule
{
    partial class FormUngDung
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnBaoloi = new System.Windows.Forms.Button();
            this.btnDeadline = new System.Windows.Forms.Button();
            this.btnXemLich = new System.Windows.Forms.Button();
            this.btnTaoLich = new System.Windows.Forms.Button();
            this.btnBangTin = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.BoTronUngDung = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelBar = new System.Windows.Forms.Panel();
            this.panelUngDung = new System.Windows.Forms.Panel();
            this.btnAccount = new System.Windows.Forms.PictureBox();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnChinhSua = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.panelBar.SuspendLayout();
            this.panelUngDung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccount)).BeginInit();
            this.panelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(227)))), ((int)(((byte)(206)))));
            this.panelMenu.Controls.Add(this.btnBaoloi);
            this.panelMenu.Controls.Add(this.btnDeadline);
            this.panelMenu.Controls.Add(this.btnXemLich);
            this.panelMenu.Controls.Add(this.btnTaoLich);
            this.panelMenu.Controls.Add(this.btnBangTin);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 800);
            this.panelMenu.TabIndex = 0;
            // 
            // btnBaoloi
            // 
            this.btnBaoloi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaoloi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoloi.FlatAppearance.BorderSize = 0;
            this.btnBaoloi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoloi.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaoloi.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnBaoloi.Image = global::ManageSchedule.Properties.Resources.bug;
            this.btnBaoloi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoloi.Location = new System.Drawing.Point(0, 369);
            this.btnBaoloi.Name = "btnBaoloi";
            this.btnBaoloi.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnBaoloi.Size = new System.Drawing.Size(220, 60);
            this.btnBaoloi.TabIndex = 5;
            this.btnBaoloi.Text = "  Báo lỗi";
            this.btnBaoloi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoloi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBaoloi.UseVisualStyleBackColor = true;
            this.btnBaoloi.Click += new System.EventHandler(this.btnBaoloi_Click);
            // 
            // btnDeadline
            // 
            this.btnDeadline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeadline.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDeadline.FlatAppearance.BorderSize = 0;
            this.btnDeadline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeadline.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeadline.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnDeadline.Image = global::ManageSchedule.Properties.Resources.clipboard;
            this.btnDeadline.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeadline.Location = new System.Drawing.Point(0, 309);
            this.btnDeadline.Name = "btnDeadline";
            this.btnDeadline.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnDeadline.Size = new System.Drawing.Size(220, 60);
            this.btnDeadline.TabIndex = 4;
            this.btnDeadline.Text = "  Công việc";
            this.btnDeadline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeadline.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeadline.UseVisualStyleBackColor = true;
            this.btnDeadline.Click += new System.EventHandler(this.btnDeadline_Click);
            // 
            // btnXemLich
            // 
            this.btnXemLich.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemLich.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnXemLich.FlatAppearance.BorderSize = 0;
            this.btnXemLich.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemLich.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemLich.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnXemLich.Image = global::ManageSchedule.Properties.Resources.calendar_check;
            this.btnXemLich.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemLich.Location = new System.Drawing.Point(0, 249);
            this.btnXemLich.Name = "btnXemLich";
            this.btnXemLich.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnXemLich.Size = new System.Drawing.Size(220, 60);
            this.btnXemLich.TabIndex = 3;
            this.btnXemLich.Text = "  Xem lịch học";
            this.btnXemLich.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemLich.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXemLich.UseVisualStyleBackColor = true;
            this.btnXemLich.Click += new System.EventHandler(this.btnXemLich_Click);
            // 
            // btnTaoLich
            // 
            this.btnTaoLich.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoLich.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaoLich.FlatAppearance.BorderSize = 0;
            this.btnTaoLich.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoLich.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoLich.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnTaoLich.Image = global::ManageSchedule.Properties.Resources.calendar;
            this.btnTaoLich.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoLich.Location = new System.Drawing.Point(0, 189);
            this.btnTaoLich.Name = "btnTaoLich";
            this.btnTaoLich.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnTaoLich.Size = new System.Drawing.Size(220, 60);
            this.btnTaoLich.TabIndex = 2;
            this.btnTaoLich.Text = "  Tạo lịch học";
            this.btnTaoLich.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoLich.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaoLich.UseVisualStyleBackColor = true;
            this.btnTaoLich.Click += new System.EventHandler(this.btnTaoLich_Click);
            // 
            // btnBangTin
            // 
            this.btnBangTin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBangTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBangTin.FlatAppearance.BorderSize = 0;
            this.btnBangTin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBangTin.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBangTin.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnBangTin.Image = global::ManageSchedule.Properties.Resources.desktop;
            this.btnBangTin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBangTin.Location = new System.Drawing.Point(0, 129);
            this.btnBangTin.Name = "btnBangTin";
            this.btnBangTin.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnBangTin.Size = new System.Drawing.Size(220, 60);
            this.btnBangTin.TabIndex = 1;
            this.btnBangTin.Text = "  Bảng tin";
            this.btnBangTin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBangTin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBangTin.UseVisualStyleBackColor = true;
            this.btnBangTin.Click += new System.EventHandler(this.btnBangTin_Click);
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.Image = global::ManageSchedule.Properties.Resources.UIT2;
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(220, 129);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            // 
            // BoTronUngDung
            // 
            this.BoTronUngDung.ElipseRadius = 10;
            this.BoTronUngDung.TargetControl = this;
            // 
            // panelBar
            // 
            this.panelBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(157)))), ((int)(((byte)(156)))));
            this.panelBar.Controls.Add(this.btnAccount);
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBar.Location = new System.Drawing.Point(220, 0);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(1180, 73);
            this.panelBar.TabIndex = 1;
            // 
            // panelUngDung
            // 
            this.panelUngDung.Controls.Add(this.panelButton);
            this.panelUngDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUngDung.Location = new System.Drawing.Point(220, 73);
            this.panelUngDung.Name = "panelUngDung";
            this.panelUngDung.Size = new System.Drawing.Size(1180, 727);
            this.panelUngDung.TabIndex = 2;
            // 
            // btnAccount
            // 
            this.btnAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccount.Image = global::ManageSchedule.Properties.Resources.user;
            this.btnAccount.Location = new System.Drawing.Point(1117, 12);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(51, 47);
            this.btnAccount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAccount.TabIndex = 0;
            this.btnAccount.TabStop = false;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnDangXuat);
            this.panelButton.Controls.Add(this.btnChinhSua);
            this.panelButton.Location = new System.Drawing.Point(1021, 2);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(156, 71);
            this.panelButton.TabIndex = 0;
            // 
            // btnChinhSua
            // 
            this.btnChinhSua.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnChinhSua.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChinhSua.FlatAppearance.BorderSize = 0;
            this.btnChinhSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChinhSua.Location = new System.Drawing.Point(0, 0);
            this.btnChinhSua.Name = "btnChinhSua";
            this.btnChinhSua.Size = new System.Drawing.Size(156, 34);
            this.btnChinhSua.TabIndex = 0;
            this.btnChinhSua.Text = "Chỉnh sửa thông tin";
            this.btnChinhSua.UseVisualStyleBackColor = false;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Location = new System.Drawing.Point(0, 38);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(156, 34);
            this.btnDangXuat.TabIndex = 1;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // FormUngDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.panelUngDung);
            this.Controls.Add(this.panelBar);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormUngDung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UngDung";
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.panelBar.ResumeLayout(false);
            this.panelUngDung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAccount)).EndInit();
            this.panelButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox btnHome;
        private Bunifu.Framework.UI.BunifuElipse BoTronUngDung;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Button btnBangTin;
        private System.Windows.Forms.Button btnTaoLich;
        private System.Windows.Forms.Panel panelUngDung;
        private System.Windows.Forms.Button btnBaoloi;
        private System.Windows.Forms.Button btnDeadline;
        private System.Windows.Forms.Button btnXemLich;
        private System.Windows.Forms.PictureBox btnAccount;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnChinhSua;
    }
}