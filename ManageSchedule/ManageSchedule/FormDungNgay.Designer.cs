
namespace ManageSchedule
{
    partial class FormDungNgay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDungNgay));
            this.BoTronForm = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnCLC = new System.Windows.Forms.Button();
            this.btnChinhQuy = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.panelBar = new System.Windows.Forms.Panel();
            this.btnTroVe = new System.Windows.Forms.Button();
            this.btnMini = new System.Windows.Forms.Button();
            this.childFormLogo = new System.Windows.Forms.PictureBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.labelChildFormText = new System.Windows.Forms.Label();
            this.panelUngDung = new System.Windows.Forms.Panel();
            this.BoTronBtnThoat = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.BoTronBtnMini = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.BoTronTroVe = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.panelBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.childFormLogo)).BeginInit();
            this.panelUngDung.SuspendLayout();
            this.SuspendLayout();
            // 
            // BoTronForm
            // 
            this.BoTronForm.ElipseRadius = 10;
            this.BoTronForm.TargetControl = this;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(227)))), ((int)(((byte)(206)))));
            this.panelMenu.Controls.Add(this.btnCLC);
            this.panelMenu.Controls.Add(this.btnChinhQuy);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 752);
            this.panelMenu.TabIndex = 1;
            // 
            // btnCLC
            // 
            this.btnCLC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCLC.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCLC.FlatAppearance.BorderSize = 0;
            this.btnCLC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCLC.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCLC.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCLC.Image = global::ManageSchedule.Properties.Resources.calendar;
            this.btnCLC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCLC.Location = new System.Drawing.Point(0, 189);
            this.btnCLC.Name = "btnCLC";
            this.btnCLC.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnCLC.Size = new System.Drawing.Size(220, 60);
            this.btnCLC.TabIndex = 3;
            this.btnCLC.Text = "  Chất lượng cao";
            this.btnCLC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCLC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCLC.UseVisualStyleBackColor = true;
            this.btnCLC.Click += new System.EventHandler(this.btnCLC_Click);
            // 
            // btnChinhQuy
            // 
            this.btnChinhQuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChinhQuy.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChinhQuy.FlatAppearance.BorderSize = 0;
            this.btnChinhQuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChinhQuy.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChinhQuy.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnChinhQuy.Image = global::ManageSchedule.Properties.Resources.calendar;
            this.btnChinhQuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChinhQuy.Location = new System.Drawing.Point(0, 129);
            this.btnChinhQuy.Name = "btnChinhQuy";
            this.btnChinhQuy.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnChinhQuy.Size = new System.Drawing.Size(220, 60);
            this.btnChinhQuy.TabIndex = 2;
            this.btnChinhQuy.Text = "  Chính quy";
            this.btnChinhQuy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChinhQuy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChinhQuy.UseVisualStyleBackColor = true;
            this.btnChinhQuy.Click += new System.EventHandler(this.btnChinhQuy_Click);
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
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panelBar
            // 
            this.panelBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(157)))), ((int)(((byte)(156)))));
            this.panelBar.Controls.Add(this.btnTroVe);
            this.panelBar.Controls.Add(this.btnMini);
            this.panelBar.Controls.Add(this.childFormLogo);
            this.panelBar.Controls.Add(this.btnThoat);
            this.panelBar.Controls.Add(this.labelChildFormText);
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBar.Location = new System.Drawing.Point(220, 0);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(1133, 73);
            this.panelBar.TabIndex = 2;
            // 
            // btnTroVe
            // 
            this.btnTroVe.BackColor = System.Drawing.Color.SpringGreen;
            this.btnTroVe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTroVe.FlatAppearance.BorderColor = System.Drawing.Color.SpringGreen;
            this.btnTroVe.FlatAppearance.BorderSize = 0;
            this.btnTroVe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SpringGreen;
            this.btnTroVe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTroVe.Location = new System.Drawing.Point(1070, 3);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(15, 15);
            this.btnTroVe.TabIndex = 19;
            this.btnTroVe.UseVisualStyleBackColor = false;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // btnMini
            // 
            this.btnMini.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnMini.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMini.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnMini.FlatAppearance.BorderSize = 0;
            this.btnMini.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMini.Location = new System.Drawing.Point(1091, 3);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(15, 15);
            this.btnMini.TabIndex = 18;
            this.btnMini.UseVisualStyleBackColor = false;
            this.btnMini.Click += new System.EventHandler(this.btnMini_Click);
            // 
            // childFormLogo
            // 
            this.childFormLogo.Location = new System.Drawing.Point(8, 21);
            this.childFormLogo.Name = "childFormLogo";
            this.childFormLogo.Size = new System.Drawing.Size(32, 32);
            this.childFormLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.childFormLogo.TabIndex = 2;
            this.childFormLogo.TabStop = false;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Location = new System.Drawing.Point(1111, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(15, 15);
            this.btnThoat.TabIndex = 17;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // labelChildFormText
            // 
            this.labelChildFormText.AutoSize = true;
            this.labelChildFormText.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChildFormText.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelChildFormText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelChildFormText.Location = new System.Drawing.Point(50, 30);
            this.labelChildFormText.Name = "labelChildFormText";
            this.labelChildFormText.Size = new System.Drawing.Size(0, 18);
            this.labelChildFormText.TabIndex = 1;
            this.labelChildFormText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelUngDung
            // 
            this.panelUngDung.Controls.Add(this.bunifuLabel1);
            this.panelUngDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUngDung.Location = new System.Drawing.Point(220, 73);
            this.panelUngDung.Name = "panelUngDung";
            this.panelUngDung.Size = new System.Drawing.Size(1133, 679);
            this.panelUngDung.TabIndex = 3;
            // 
            // BoTronBtnThoat
            // 
            this.BoTronBtnThoat.ElipseRadius = 7;
            this.BoTronBtnThoat.TargetControl = this.btnThoat;
            // 
            // BoTronBtnMini
            // 
            this.BoTronBtnMini.ElipseRadius = 7;
            this.BoTronBtnMini.TargetControl = this.btnMini;
            // 
            // BoTronTroVe
            // 
            this.BoTronTroVe.ElipseRadius = 7;
            this.BoTronTroVe.TargetControl = this.btnTroVe;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Verdana", 18F);
            this.bunifuLabel1.Location = new System.Drawing.Point(199, 259);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(770, 58);
            this.bunifuLabel1.TabIndex = 0;
            this.bunifuLabel1.Text = "Bạn đang sử dụng ứng dụng ở chế độ không đăng ký tài khoản. \r\nĐể sử dụng đầy đủ c" +
    "ác tính năng xin vui lòng đăng ký tài khoản.\r\n";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // FormDungNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 752);
            this.Controls.Add(this.panelUngDung);
            this.Controls.Add(this.panelBar);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDungNgay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormXemTKB";
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.panelBar.ResumeLayout(false);
            this.panelBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.childFormLogo)).EndInit();
            this.panelUngDung.ResumeLayout(false);
            this.panelUngDung.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse BoTronForm;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnChinhQuy;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Button btnMini;
        private System.Windows.Forms.PictureBox childFormLogo;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label labelChildFormText;
        private System.Windows.Forms.Panel panelUngDung;
        private Bunifu.Framework.UI.BunifuElipse BoTronBtnThoat;
        private Bunifu.Framework.UI.BunifuElipse BoTronBtnMini;
        private System.Windows.Forms.Button btnCLC;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Button btnTroVe;
        private Bunifu.Framework.UI.BunifuElipse BoTronTroVe;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
    }
}