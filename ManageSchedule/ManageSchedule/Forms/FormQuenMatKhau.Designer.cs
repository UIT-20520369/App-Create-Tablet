
namespace ManageSchedule
{
    partial class FormQuenMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuenMatKhau));
            this.btnTroVe = new Bunifu.UI.WinForms.BunifuImageButton();
            this.labelTaiKhoan = new System.Windows.Forms.Label();
            this.TextBoxTaiKhoan = new System.Windows.Forms.TextBox();
            this.btnGuiMa = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuLoader = new Bunifu.UI.WinForms.BunifuLoader();
            this.BoTronForm = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.labelOTP = new System.Windows.Forms.Label();
            this.TextBoxOTP = new System.Windows.Forms.TextBox();
            this.btnXacNhan = new Bunifu.Framework.UI.BunifuThinButton2();
            this.labelMatKhau = new System.Windows.Forms.Label();
            this.labelNhapLai = new System.Windows.Forms.Label();
            this.TextBoxMatKhau = new System.Windows.Forms.TextBox();
            this.TextBoxNhapLai = new System.Windows.Forms.TextBox();
            this.btnDoiMatKhau = new Bunifu.Framework.UI.BunifuThinButton2();
            this.CircleProgress = new Bunifu.UI.WinForms.BunifuCircleProgress();
            this.btnShowPassMK = new Bunifu.UI.WinForms.BunifuImageButton();
            this.btnShowPassXN = new Bunifu.UI.WinForms.BunifuImageButton();
            this.TimerCountDown = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
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
            this.btnTroVe.TabIndex = 13;
            this.btnTroVe.ToolTipText = "";
            this.btnTroVe.WaitOnLoad = false;
            this.btnTroVe.ImageMargin = 10;
            this.btnTroVe.ZoomSpeed = 10;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // labelTaiKhoan
            // 
            this.labelTaiKhoan.AutoSize = true;
            this.labelTaiKhoan.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTaiKhoan.Location = new System.Drawing.Point(61, 97);
            this.labelTaiKhoan.Name = "labelTaiKhoan";
            this.labelTaiKhoan.Size = new System.Drawing.Size(95, 18);
            this.labelTaiKhoan.TabIndex = 14;
            this.labelTaiKhoan.Text = "Tài khoản:";
            // 
            // TextBoxTaiKhoan
            // 
            this.TextBoxTaiKhoan.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxTaiKhoan.Location = new System.Drawing.Point(162, 94);
            this.TextBoxTaiKhoan.Name = "TextBoxTaiKhoan";
            this.TextBoxTaiKhoan.Size = new System.Drawing.Size(242, 27);
            this.TextBoxTaiKhoan.TabIndex = 15;
            // 
            // btnGuiMa
            // 
            this.btnGuiMa.ActiveBorderThickness = 1;
            this.btnGuiMa.ActiveCornerRadius = 20;
            this.btnGuiMa.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnGuiMa.ActiveForecolor = System.Drawing.Color.White;
            this.btnGuiMa.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnGuiMa.BackColor = System.Drawing.SystemColors.Control;
            this.btnGuiMa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGuiMa.BackgroundImage")));
            this.btnGuiMa.ButtonText = "Nhận mã OTP";
            this.btnGuiMa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuiMa.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiMa.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnGuiMa.IdleBorderThickness = 1;
            this.btnGuiMa.IdleCornerRadius = 20;
            this.btnGuiMa.IdleFillColor = System.Drawing.Color.White;
            this.btnGuiMa.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnGuiMa.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnGuiMa.Location = new System.Drawing.Point(162, 128);
            this.btnGuiMa.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnGuiMa.Name = "btnGuiMa";
            this.btnGuiMa.Size = new System.Drawing.Size(242, 47);
            this.btnGuiMa.TabIndex = 16;
            this.btnGuiMa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGuiMa.Click += new System.EventHandler(this.btnGuiMa_Click);
            // 
            // bunifuLoader
            // 
            this.bunifuLoader.AllowStylePresets = true;
            this.bunifuLoader.BackColor = System.Drawing.Color.Transparent;
            this.bunifuLoader.CapStyle = Bunifu.UI.WinForms.BunifuLoader.CapStyles.Round;
            this.bunifuLoader.Color = System.Drawing.Color.DodgerBlue;
            this.bunifuLoader.Colors = new Bunifu.UI.WinForms.Bloom[0];
            this.bunifuLoader.Customization = "";
            this.bunifuLoader.DashWidth = 0.5F;
            this.bunifuLoader.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuLoader.Image = null;
            this.bunifuLoader.Location = new System.Drawing.Point(255, 182);
            this.bunifuLoader.Name = "bunifuLoader";
            this.bunifuLoader.NoRounding = false;
            this.bunifuLoader.Preset = Bunifu.UI.WinForms.BunifuLoader.StylePresets.Solid;
            this.bunifuLoader.RingStyle = Bunifu.UI.WinForms.BunifuLoader.RingStyles.Solid;
            this.bunifuLoader.ShowText = false;
            this.bunifuLoader.Size = new System.Drawing.Size(40, 40);
            this.bunifuLoader.Speed = 7;
            this.bunifuLoader.TabIndex = 17;
            this.bunifuLoader.Text = "bunifuLoader1";
            this.bunifuLoader.TextPadding = new System.Windows.Forms.Padding(0);
            this.bunifuLoader.Thickness = 6;
            this.bunifuLoader.Transparent = true;
            // 
            // BoTronForm
            // 
            this.BoTronForm.ElipseRadius = 10;
            this.BoTronForm.TargetControl = this;
            // 
            // labelOTP
            // 
            this.labelOTP.AutoSize = true;
            this.labelOTP.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOTP.Location = new System.Drawing.Point(79, 238);
            this.labelOTP.Name = "labelOTP";
            this.labelOTP.Size = new System.Drawing.Size(77, 18);
            this.labelOTP.TabIndex = 18;
            this.labelOTP.Text = "Mã OTP:";
            // 
            // TextBoxOTP
            // 
            this.TextBoxOTP.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxOTP.Location = new System.Drawing.Point(162, 235);
            this.TextBoxOTP.Name = "TextBoxOTP";
            this.TextBoxOTP.Size = new System.Drawing.Size(242, 27);
            this.TextBoxOTP.TabIndex = 19;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.ActiveBorderThickness = 1;
            this.btnXacNhan.ActiveCornerRadius = 20;
            this.btnXacNhan.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnXacNhan.ActiveForecolor = System.Drawing.Color.White;
            this.btnXacNhan.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnXacNhan.BackColor = System.Drawing.SystemColors.Control;
            this.btnXacNhan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXacNhan.BackgroundImage")));
            this.btnXacNhan.ButtonText = "Xác nhận";
            this.btnXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhan.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnXacNhan.IdleBorderThickness = 1;
            this.btnXacNhan.IdleCornerRadius = 20;
            this.btnXacNhan.IdleFillColor = System.Drawing.Color.White;
            this.btnXacNhan.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnXacNhan.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnXacNhan.Location = new System.Drawing.Point(162, 269);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(242, 47);
            this.btnXacNhan.TabIndex = 20;
            this.btnXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // labelMatKhau
            // 
            this.labelMatKhau.AutoSize = true;
            this.labelMatKhau.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMatKhau.Location = new System.Drawing.Point(30, 357);
            this.labelMatKhau.Name = "labelMatKhau";
            this.labelMatKhau.Size = new System.Drawing.Size(126, 18);
            this.labelMatKhau.TabIndex = 21;
            this.labelMatKhau.Text = "Mật khẩu mới:";
            // 
            // labelNhapLai
            // 
            this.labelNhapLai.AutoSize = true;
            this.labelNhapLai.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNhapLai.Location = new System.Drawing.Point(73, 397);
            this.labelNhapLai.Name = "labelNhapLai";
            this.labelNhapLai.Size = new System.Drawing.Size(83, 18);
            this.labelNhapLai.TabIndex = 22;
            this.labelNhapLai.Text = "Nhập lại:";
            // 
            // TextBoxMatKhau
            // 
            this.TextBoxMatKhau.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxMatKhau.Location = new System.Drawing.Point(162, 354);
            this.TextBoxMatKhau.Name = "TextBoxMatKhau";
            this.TextBoxMatKhau.PasswordChar = '*';
            this.TextBoxMatKhau.Size = new System.Drawing.Size(242, 27);
            this.TextBoxMatKhau.TabIndex = 23;
            // 
            // TextBoxNhapLai
            // 
            this.TextBoxNhapLai.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxNhapLai.Location = new System.Drawing.Point(162, 394);
            this.TextBoxNhapLai.Name = "TextBoxNhapLai";
            this.TextBoxNhapLai.PasswordChar = '*';
            this.TextBoxNhapLai.Size = new System.Drawing.Size(242, 27);
            this.TextBoxNhapLai.TabIndex = 24;
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.ActiveBorderThickness = 1;
            this.btnDoiMatKhau.ActiveCornerRadius = 20;
            this.btnDoiMatKhau.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnDoiMatKhau.ActiveForecolor = System.Drawing.Color.White;
            this.btnDoiMatKhau.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnDoiMatKhau.BackColor = System.Drawing.SystemColors.Control;
            this.btnDoiMatKhau.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDoiMatKhau.BackgroundImage")));
            this.btnDoiMatKhau.ButtonText = "Đổi mật khẩu";
            this.btnDoiMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoiMatKhau.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoiMatKhau.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnDoiMatKhau.IdleBorderThickness = 1;
            this.btnDoiMatKhau.IdleCornerRadius = 20;
            this.btnDoiMatKhau.IdleFillColor = System.Drawing.Color.White;
            this.btnDoiMatKhau.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnDoiMatKhau.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnDoiMatKhau.Location = new System.Drawing.Point(162, 439);
            this.btnDoiMatKhau.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(242, 47);
            this.btnDoiMatKhau.TabIndex = 25;
            this.btnDoiMatKhau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // CircleProgress
            // 
            this.CircleProgress.Animated = false;
            this.CircleProgress.AnimationInterval = 1;
            this.CircleProgress.AnimationSpeed = 1;
            this.CircleProgress.BackColor = System.Drawing.Color.Transparent;
            this.CircleProgress.CircleMargin = 10;
            this.CircleProgress.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CircleProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CircleProgress.IsPercentage = false;
            this.CircleProgress.LineProgressThickness = 10;
            this.CircleProgress.LineThickness = 10;
            this.CircleProgress.Location = new System.Drawing.Point(412, 212);
            this.CircleProgress.Maximum = 60;
            this.CircleProgress.Name = "CircleProgress";
            this.CircleProgress.ProgressAnimationSpeed = 200;
            this.CircleProgress.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.CircleProgress.ProgressColor = System.Drawing.Color.DodgerBlue;
            this.CircleProgress.ProgressColor2 = System.Drawing.Color.DodgerBlue;
            this.CircleProgress.ProgressEndCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Round;
            this.CircleProgress.ProgressFillStyle = Bunifu.UI.WinForms.BunifuCircleProgress.FillStyles.Solid;
            this.CircleProgress.ProgressStartCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Round;
            this.CircleProgress.SecondaryFont = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CircleProgress.Size = new System.Drawing.Size(66, 66);
            this.CircleProgress.SubScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.CircleProgress.SubScriptMargin = new System.Windows.Forms.Padding(5, -20, 0, 0);
            this.CircleProgress.SubScriptText = "";
            this.CircleProgress.SuperScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.CircleProgress.SuperScriptMargin = new System.Windows.Forms.Padding(5, 20, 0, 0);
            this.CircleProgress.SuperScriptText = "";
            this.CircleProgress.TabIndex = 16;
            this.CircleProgress.Text = "30";
            this.CircleProgress.TextMargin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.CircleProgress.Value = 30;
            this.CircleProgress.ValueByTransition = 30;
            this.CircleProgress.ValueMargin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            // 
            // btnShowPassMK
            // 
            this.btnShowPassMK.ActiveImage = null;
            this.btnShowPassMK.AllowAnimations = true;
            this.btnShowPassMK.AllowBuffering = false;
            this.btnShowPassMK.AllowToggling = false;
            this.btnShowPassMK.AllowZooming = false;
            this.btnShowPassMK.AllowZoomingOnFocus = false;
            this.btnShowPassMK.BackColor = System.Drawing.Color.Transparent;
            this.btnShowPassMK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowPassMK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnShowPassMK.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnShowPassMK.ErrorImage")));
            this.btnShowPassMK.FadeWhenInactive = false;
            this.btnShowPassMK.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnShowPassMK.Image = global::ManageSchedule.Properties.Resources.eye_slash_solid;
            this.btnShowPassMK.ActiveImage = null;
            this.btnShowPassMK.ImageLocation = null;
            this.btnShowPassMK.ImageMargin = 20;
            this.btnShowPassMK.ImageSize = new System.Drawing.Size(20, 20);
            this.btnShowPassMK.ImageZoomSize = new System.Drawing.Size(40, 40);
            this.btnShowPassMK.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnShowPassMK.InitialImage")));
            this.btnShowPassMK.Location = new System.Drawing.Point(410, 347);
            this.btnShowPassMK.Name = "btnShowPassMK";
            this.btnShowPassMK.Rotation = 0;
            this.btnShowPassMK.ShowActiveImage = true;
            this.btnShowPassMK.ShowCursorChanges = false;
            this.btnShowPassMK.ShowImageBorders = true;
            this.btnShowPassMK.ShowSizeMarkers = false;
            this.btnShowPassMK.Size = new System.Drawing.Size(40, 40);
            this.btnShowPassMK.TabIndex = 26;
            this.btnShowPassMK.ToolTipText = "";
            this.btnShowPassMK.WaitOnLoad = false;
            this.btnShowPassMK.ImageMargin = 20;
            this.btnShowPassMK.ZoomSpeed = 10;
            this.btnShowPassMK.Click += new System.EventHandler(this.btnShowPassMK_Click);
            // 
            // btnShowPassXN
            // 
            this.btnShowPassXN.ActiveImage = null;
            this.btnShowPassXN.AllowAnimations = true;
            this.btnShowPassXN.AllowBuffering = false;
            this.btnShowPassXN.AllowToggling = false;
            this.btnShowPassXN.AllowZooming = false;
            this.btnShowPassXN.AllowZoomingOnFocus = false;
            this.btnShowPassXN.BackColor = System.Drawing.Color.Transparent;
            this.btnShowPassXN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowPassXN.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnShowPassXN.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnShowPassXN.ErrorImage")));
            this.btnShowPassXN.FadeWhenInactive = false;
            this.btnShowPassXN.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnShowPassXN.Image = global::ManageSchedule.Properties.Resources.eye_slash_solid;
            this.btnShowPassXN.ActiveImage = null;
            this.btnShowPassXN.ImageLocation = null;
            this.btnShowPassXN.ImageMargin = 20;
            this.btnShowPassXN.ImageSize = new System.Drawing.Size(20, 20);
            this.btnShowPassXN.ImageZoomSize = new System.Drawing.Size(40, 40);
            this.btnShowPassXN.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnShowPassXN.InitialImage")));
            this.btnShowPassXN.Location = new System.Drawing.Point(412, 386);
            this.btnShowPassXN.Name = "btnShowPassXN";
            this.btnShowPassXN.Rotation = 0;
            this.btnShowPassXN.ShowActiveImage = true;
            this.btnShowPassXN.ShowCursorChanges = false;
            this.btnShowPassXN.ShowImageBorders = true;
            this.btnShowPassXN.ShowSizeMarkers = false;
            this.btnShowPassXN.Size = new System.Drawing.Size(40, 40);
            this.btnShowPassXN.TabIndex = 27;
            this.btnShowPassXN.ToolTipText = "";
            this.btnShowPassXN.WaitOnLoad = false;
            this.btnShowPassXN.ImageMargin = 20;
            this.btnShowPassXN.ZoomSpeed = 10;
            this.btnShowPassXN.Click += new System.EventHandler(this.btnShowPassXN_Click);
            // 
            // TimerCountDown
            // 
            this.TimerCountDown.Interval = 1000;
            this.TimerCountDown.Tick += new System.EventHandler(this.TimerCountDown_Tick);
            // 
            // FormQuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 523);
            this.Controls.Add(this.btnShowPassXN);
            this.Controls.Add(this.btnShowPassMK);
            this.Controls.Add(this.CircleProgress);
            this.Controls.Add(this.btnDoiMatKhau);
            this.Controls.Add(this.TextBoxNhapLai);
            this.Controls.Add(this.TextBoxMatKhau);
            this.Controls.Add(this.labelNhapLai);
            this.Controls.Add(this.labelMatKhau);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.TextBoxOTP);
            this.Controls.Add(this.labelOTP);
            this.Controls.Add(this.bunifuLoader);
            this.Controls.Add(this.btnGuiMa);
            this.Controls.Add(this.TextBoxTaiKhoan);
            this.Controls.Add(this.labelTaiKhoan);
            this.Controls.Add(this.btnTroVe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQuenMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormQuenMatKhau";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuImageButton btnTroVe;
        private System.Windows.Forms.Label labelTaiKhoan;
        private System.Windows.Forms.TextBox TextBoxTaiKhoan;
        private Bunifu.Framework.UI.BunifuThinButton2 btnGuiMa;
        private Bunifu.UI.WinForms.BunifuLoader bunifuLoader;
        private Bunifu.Framework.UI.BunifuElipse BoTronForm;
        private Bunifu.Framework.UI.BunifuThinButton2 btnDoiMatKhau;
        private System.Windows.Forms.TextBox TextBoxNhapLai;
        private System.Windows.Forms.TextBox TextBoxMatKhau;
        private System.Windows.Forms.Label labelNhapLai;
        private System.Windows.Forms.Label labelMatKhau;
        private Bunifu.Framework.UI.BunifuThinButton2 btnXacNhan;
        private System.Windows.Forms.TextBox TextBoxOTP;
        private System.Windows.Forms.Label labelOTP;
        private Bunifu.UI.WinForms.BunifuCircleProgress CircleProgress;
        private Bunifu.UI.WinForms.BunifuImageButton btnShowPassXN;
        private Bunifu.UI.WinForms.BunifuImageButton btnShowPassMK;
        private System.Windows.Forms.Timer TimerCountDown;
    }
}