
namespace ManageSchedule
{
    partial class FormDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDangNhap));
            this.BoTronDangNhap = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTaiKhoan = new System.Windows.Forms.TextBox();
            this.textBoxMatKhau = new System.Windows.Forms.TextBox();
            this.checkBoxNhoMK = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.btnDangNhap = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnTroVe = new Bunifu.UI.WinForms.BunifuImageButton();
            this.btnShowPass = new Bunifu.UI.WinForms.BunifuImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // BoTronDangNhap
            // 
            this.BoTronDangNhap.ElipseRadius = 10;
            this.BoTronDangNhap.TargetControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tài khoản:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật khẩu:";
            // 
            // textBoxTaiKhoan
            // 
            this.textBoxTaiKhoan.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTaiKhoan.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTaiKhoan.Location = new System.Drawing.Point(137, 276);
            this.textBoxTaiKhoan.Name = "textBoxTaiKhoan";
            this.textBoxTaiKhoan.Size = new System.Drawing.Size(246, 27);
            this.textBoxTaiKhoan.TabIndex = 1;
            // 
            // textBoxMatKhau
            // 
            this.textBoxMatKhau.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxMatKhau.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMatKhau.Location = new System.Drawing.Point(137, 314);
            this.textBoxMatKhau.Name = "textBoxMatKhau";
            this.textBoxMatKhau.PasswordChar = '*';
            this.textBoxMatKhau.Size = new System.Drawing.Size(246, 27);
            this.textBoxMatKhau.TabIndex = 2;
            // 
            // checkBoxNhoMK
            // 
            this.checkBoxNhoMK.AutoSize = true;
            this.checkBoxNhoMK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxNhoMK.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxNhoMK.Location = new System.Drawing.Point(137, 347);
            this.checkBoxNhoMK.Name = "checkBoxNhoMK";
            this.checkBoxNhoMK.Size = new System.Drawing.Size(150, 20);
            this.checkBoxNhoMK.TabIndex = 7;
            this.checkBoxNhoMK.Text = "Ghi nhớ đăng nhập";
            this.checkBoxNhoMK.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(188, 423);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(143, 18);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Quên mật khẩu?";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::ManageSchedule.Properties.Resources.LogoAppNoneBG;
            this.pictureBoxLogo.Location = new System.Drawing.Point(-7, 38);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(436, 270);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.ActiveBorderThickness = 1;
            this.btnDangNhap.ActiveCornerRadius = 20;
            this.btnDangNhap.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(144)))));
            this.btnDangNhap.ActiveForecolor = System.Drawing.Color.Black;
            this.btnDangNhap.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(144)))));
            this.btnDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.btnDangNhap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDangNhap.BackgroundImage")));
            this.btnDangNhap.ButtonText = "Đăng nhập";
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnDangNhap.IdleBorderThickness = 1;
            this.btnDangNhap.IdleCornerRadius = 20;
            this.btnDangNhap.IdleFillColor = System.Drawing.Color.Gainsboro;
            this.btnDangNhap.IdleForecolor = System.Drawing.Color.Black;
            this.btnDangNhap.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(144)))));
            this.btnDangNhap.Location = new System.Drawing.Point(137, 374);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(246, 45);
            this.btnDangNhap.TabIndex = 3;
            this.btnDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnTroVe
            // 
            this.btnTroVe.ActiveImage = null;
            this.btnTroVe.AllowAnimations = true;
            this.btnTroVe.AllowBuffering = false;
            this.btnTroVe.AllowToggling = false;
            this.btnTroVe.AllowZooming = true;
            this.btnTroVe.AllowZoomingOnFocus = false;
            this.btnTroVe.BackColor = System.Drawing.Color.Transparent;
            this.btnTroVe.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnTroVe.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnTroVe.ErrorImage")));
            this.btnTroVe.FadeWhenInactive = false;
            this.btnTroVe.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnTroVe.Image = global::ManageSchedule.Properties.Resources.chevron_circle;
            this.btnTroVe.ActiveImage = null;
            this.btnTroVe.ImageLocation = null;
            this.btnTroVe.ImageMargin = 10;
            this.btnTroVe.ImageSize = new System.Drawing.Size(40, 40);
            this.btnTroVe.ImageZoomSize = new System.Drawing.Size(50, 50);
            this.btnTroVe.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnTroVe.InitialImage")));
            this.btnTroVe.Location = new System.Drawing.Point(12, 12);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Rotation = 0;
            this.btnTroVe.ShowActiveImage = true;
            this.btnTroVe.ShowCursorChanges = true;
            this.btnTroVe.ShowImageBorders = true;
            this.btnTroVe.ShowSizeMarkers = false;
            this.btnTroVe.Size = new System.Drawing.Size(50, 50);
            this.btnTroVe.TabIndex = 12;
            this.btnTroVe.ToolTipText = "";
            this.btnTroVe.WaitOnLoad = false;
            this.btnTroVe.ImageMargin = 10;
            this.btnTroVe.ZoomSpeed = 10;
            this.btnTroVe.Click += new System.EventHandler(this.BtnTroVe_Click);
            // 
            // btnShowPass
            // 
            this.btnShowPass.ActiveImage = null;
            this.btnShowPass.AllowAnimations = true;
            this.btnShowPass.AllowBuffering = false;
            this.btnShowPass.AllowToggling = false;
            this.btnShowPass.AllowZooming = false;
            this.btnShowPass.AllowZoomingOnFocus = false;
            this.btnShowPass.BackColor = System.Drawing.Color.Transparent;
            this.btnShowPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowPass.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnShowPass.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnShowPass.ErrorImage")));
            this.btnShowPass.FadeWhenInactive = false;
            this.btnShowPass.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnShowPass.Image = global::ManageSchedule.Properties.Resources.eye_slash_solid;
            this.btnShowPass.ActiveImage = null;
            this.btnShowPass.ImageLocation = null;
            this.btnShowPass.ImageMargin = 20;
            this.btnShowPass.ImageSize = new System.Drawing.Size(20, 20);
            this.btnShowPass.ImageZoomSize = new System.Drawing.Size(40, 40);
            this.btnShowPass.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnShowPass.InitialImage")));
            this.btnShowPass.Location = new System.Drawing.Point(387, 308);
            this.btnShowPass.Name = "btnShowPass";
            this.btnShowPass.Rotation = 0;
            this.btnShowPass.ShowActiveImage = true;
            this.btnShowPass.ShowCursorChanges = false;
            this.btnShowPass.ShowImageBorders = true;
            this.btnShowPass.ShowSizeMarkers = false;
            this.btnShowPass.Size = new System.Drawing.Size(40, 40);
            this.btnShowPass.TabIndex = 13;
            this.btnShowPass.ToolTipText = "";
            this.btnShowPass.WaitOnLoad = false;
            this.btnShowPass.ImageMargin = 20;
            this.btnShowPass.ZoomSpeed = 10;
            this.btnShowPass.Click += new System.EventHandler(this.btnShowPass_Click);
            // 
            // FormDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(435, 523);
            this.Controls.Add(this.btnShowPass);
            this.Controls.Add(this.btnTroVe);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.checkBoxNhoMK);
            this.Controls.Add(this.textBoxMatKhau);
            this.Controls.Add(this.textBoxTaiKhoan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBoxLogo);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse BoTronDangNhap;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.TextBox textBoxMatKhau;
        private System.Windows.Forms.TextBox textBoxTaiKhoan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxNhoMK;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnDangNhap;
        private Bunifu.UI.WinForms.BunifuImageButton btnTroVe;
        private Bunifu.UI.WinForms.BunifuImageButton btnShowPass;
    }
}

