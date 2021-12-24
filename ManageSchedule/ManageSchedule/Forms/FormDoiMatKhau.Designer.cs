
namespace ManageSchedule
{
    partial class FormDoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDoiMatKhau));
            this.BoTronForm = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnTroVe = new Bunifu.UI.WinForms.BunifuImageButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxMatKhauHienTai = new System.Windows.Forms.TextBox();
            this.TextBoxMatKhauMoi = new System.Windows.Forms.TextBox();
            this.TextBoxXacNhanMatKhau = new System.Windows.Forms.TextBox();
            this.btnShowPassHienTai = new Bunifu.UI.WinForms.BunifuImageButton();
            this.btnShowPassMoi = new Bunifu.UI.WinForms.BunifuImageButton();
            this.btnShowPassXacNhan = new Bunifu.UI.WinForms.BunifuImageButton();
            this.btnChange = new Bunifu.Framework.UI.BunifuThinButton2();
            this.SuspendLayout();
            // 
            // BoTronForm
            // 
            this.BoTronForm.ElipseRadius = 10;
            this.BoTronForm.TargetControl = this;
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
            this.btnTroVe.ImageSize = new System.Drawing.Size(57, 52);
            this.btnTroVe.ImageZoomSize = new System.Drawing.Size(67, 62);
            this.btnTroVe.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnTroVe.InitialImage")));
            this.btnTroVe.Location = new System.Drawing.Point(16, 15);
            this.btnTroVe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Rotation = 0;
            this.btnTroVe.ShowActiveImage = true;
            this.btnTroVe.ShowCursorChanges = true;
            this.btnTroVe.ShowImageBorders = true;
            this.btnTroVe.ShowSizeMarkers = false;
            this.btnTroVe.Size = new System.Drawing.Size(67, 62);
            this.btnTroVe.TabIndex = 14;
            this.btnTroVe.ToolTipText = "";
            this.btnTroVe.WaitOnLoad = false;
            this.btnTroVe.ImageMargin = 10;
            this.btnTroVe.ZoomSpeed = 10;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 139);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mật khẩu hiện tại:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 192);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Mật khẩu mới:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 245);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Xác nhận mật khẩu:";
            // 
            // TextBoxMatKhauHienTai
            // 
            this.TextBoxMatKhauHienTai.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxMatKhauHienTai.Location = new System.Drawing.Point(252, 135);
            this.TextBoxMatKhauHienTai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextBoxMatKhauHienTai.Name = "TextBoxMatKhauHienTai";
            this.TextBoxMatKhauHienTai.PasswordChar = '*';
            this.TextBoxMatKhauHienTai.Size = new System.Drawing.Size(425, 32);
            this.TextBoxMatKhauHienTai.TabIndex = 20;
            // 
            // TextBoxMatKhauMoi
            // 
            this.TextBoxMatKhauMoi.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxMatKhauMoi.Location = new System.Drawing.Point(252, 188);
            this.TextBoxMatKhauMoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextBoxMatKhauMoi.Name = "TextBoxMatKhauMoi";
            this.TextBoxMatKhauMoi.PasswordChar = '*';
            this.TextBoxMatKhauMoi.Size = new System.Drawing.Size(425, 32);
            this.TextBoxMatKhauMoi.TabIndex = 21;
            // 
            // TextBoxXacNhanMatKhau
            // 
            this.TextBoxXacNhanMatKhau.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxXacNhanMatKhau.Location = new System.Drawing.Point(252, 241);
            this.TextBoxXacNhanMatKhau.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextBoxXacNhanMatKhau.Name = "TextBoxXacNhanMatKhau";
            this.TextBoxXacNhanMatKhau.PasswordChar = '*';
            this.TextBoxXacNhanMatKhau.Size = new System.Drawing.Size(425, 32);
            this.TextBoxXacNhanMatKhau.TabIndex = 22;
            // 
            // btnShowPassHienTai
            // 
            this.btnShowPassHienTai.ActiveImage = null;
            this.btnShowPassHienTai.AllowAnimations = true;
            this.btnShowPassHienTai.AllowBuffering = false;
            this.btnShowPassHienTai.AllowToggling = false;
            this.btnShowPassHienTai.AllowZooming = false;
            this.btnShowPassHienTai.AllowZoomingOnFocus = false;
            this.btnShowPassHienTai.BackColor = System.Drawing.Color.Transparent;
            this.btnShowPassHienTai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowPassHienTai.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnShowPassHienTai.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnShowPassHienTai.ErrorImage")));
            this.btnShowPassHienTai.FadeWhenInactive = false;
            this.btnShowPassHienTai.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnShowPassHienTai.Image = global::ManageSchedule.Properties.Resources.eye_slash_solid;
            this.btnShowPassHienTai.ActiveImage = null;
            this.btnShowPassHienTai.ImageLocation = null;
            this.btnShowPassHienTai.ImageMargin = 20;
            this.btnShowPassHienTai.ImageSize = new System.Drawing.Size(33, 29);
            this.btnShowPassHienTai.ImageZoomSize = new System.Drawing.Size(53, 49);
            this.btnShowPassHienTai.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnShowPassHienTai.InitialImage")));
            this.btnShowPassHienTai.Location = new System.Drawing.Point(687, 128);
            this.btnShowPassHienTai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShowPassHienTai.Name = "btnShowPassHienTai";
            this.btnShowPassHienTai.Rotation = 0;
            this.btnShowPassHienTai.ShowActiveImage = true;
            this.btnShowPassHienTai.ShowCursorChanges = false;
            this.btnShowPassHienTai.ShowImageBorders = true;
            this.btnShowPassHienTai.ShowSizeMarkers = false;
            this.btnShowPassHienTai.Size = new System.Drawing.Size(53, 49);
            this.btnShowPassHienTai.TabIndex = 23;
            this.btnShowPassHienTai.ToolTipText = "";
            this.btnShowPassHienTai.WaitOnLoad = false;
            this.btnShowPassHienTai.ImageMargin = 20;
            this.btnShowPassHienTai.ZoomSpeed = 10;
            this.btnShowPassHienTai.Click += new System.EventHandler(this.ShowPass_Click);
            // 
            // btnShowPassMoi
            // 
            this.btnShowPassMoi.ActiveImage = null;
            this.btnShowPassMoi.AllowAnimations = true;
            this.btnShowPassMoi.AllowBuffering = false;
            this.btnShowPassMoi.AllowToggling = false;
            this.btnShowPassMoi.AllowZooming = false;
            this.btnShowPassMoi.AllowZoomingOnFocus = false;
            this.btnShowPassMoi.BackColor = System.Drawing.Color.Transparent;
            this.btnShowPassMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowPassMoi.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnShowPassMoi.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnShowPassMoi.ErrorImage")));
            this.btnShowPassMoi.FadeWhenInactive = false;
            this.btnShowPassMoi.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnShowPassMoi.Image = global::ManageSchedule.Properties.Resources.eye_slash_solid;
            this.btnShowPassMoi.ActiveImage = null;
            this.btnShowPassMoi.ImageLocation = null;
            this.btnShowPassMoi.ImageMargin = 20;
            this.btnShowPassMoi.ImageSize = new System.Drawing.Size(33, 29);
            this.btnShowPassMoi.ImageZoomSize = new System.Drawing.Size(53, 49);
            this.btnShowPassMoi.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnShowPassMoi.InitialImage")));
            this.btnShowPassMoi.Location = new System.Drawing.Point(687, 180);
            this.btnShowPassMoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShowPassMoi.Name = "btnShowPassMoi";
            this.btnShowPassMoi.Rotation = 0;
            this.btnShowPassMoi.ShowActiveImage = true;
            this.btnShowPassMoi.ShowCursorChanges = false;
            this.btnShowPassMoi.ShowImageBorders = true;
            this.btnShowPassMoi.ShowSizeMarkers = false;
            this.btnShowPassMoi.Size = new System.Drawing.Size(53, 49);
            this.btnShowPassMoi.TabIndex = 24;
            this.btnShowPassMoi.ToolTipText = "";
            this.btnShowPassMoi.WaitOnLoad = false;
            this.btnShowPassMoi.ImageMargin = 20;
            this.btnShowPassMoi.ZoomSpeed = 10;
            this.btnShowPassMoi.Click += new System.EventHandler(this.ShowPass_Click);
            // 
            // btnShowPassXacNhan
            // 
            this.btnShowPassXacNhan.ActiveImage = null;
            this.btnShowPassXacNhan.AllowAnimations = true;
            this.btnShowPassXacNhan.AllowBuffering = false;
            this.btnShowPassXacNhan.AllowToggling = false;
            this.btnShowPassXacNhan.AllowZooming = false;
            this.btnShowPassXacNhan.AllowZoomingOnFocus = false;
            this.btnShowPassXacNhan.BackColor = System.Drawing.Color.Transparent;
            this.btnShowPassXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowPassXacNhan.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnShowPassXacNhan.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnShowPassXacNhan.ErrorImage")));
            this.btnShowPassXacNhan.FadeWhenInactive = false;
            this.btnShowPassXacNhan.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnShowPassXacNhan.Image = global::ManageSchedule.Properties.Resources.eye_slash_solid;
            this.btnShowPassXacNhan.ActiveImage = null;
            this.btnShowPassXacNhan.ImageLocation = null;
            this.btnShowPassXacNhan.ImageMargin = 20;
            this.btnShowPassXacNhan.ImageSize = new System.Drawing.Size(33, 29);
            this.btnShowPassXacNhan.ImageZoomSize = new System.Drawing.Size(53, 49);
            this.btnShowPassXacNhan.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnShowPassXacNhan.InitialImage")));
            this.btnShowPassXacNhan.Location = new System.Drawing.Point(687, 233);
            this.btnShowPassXacNhan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShowPassXacNhan.Name = "btnShowPassXacNhan";
            this.btnShowPassXacNhan.Rotation = 0;
            this.btnShowPassXacNhan.ShowActiveImage = true;
            this.btnShowPassXacNhan.ShowCursorChanges = false;
            this.btnShowPassXacNhan.ShowImageBorders = true;
            this.btnShowPassXacNhan.ShowSizeMarkers = false;
            this.btnShowPassXacNhan.Size = new System.Drawing.Size(53, 49);
            this.btnShowPassXacNhan.TabIndex = 25;
            this.btnShowPassXacNhan.ToolTipText = "";
            this.btnShowPassXacNhan.WaitOnLoad = false;
            this.btnShowPassXacNhan.ImageMargin = 20;
            this.btnShowPassXacNhan.ZoomSpeed = 10;
            this.btnShowPassXacNhan.Click += new System.EventHandler(this.ShowPass_Click);
            // 
            // btnChange
            // 
            this.btnChange.ActiveBorderThickness = 1;
            this.btnChange.ActiveCornerRadius = 20;
            this.btnChange.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(144)))));
            this.btnChange.ActiveForecolor = System.Drawing.Color.Black;
            this.btnChange.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(144)))));
            this.btnChange.BackColor = System.Drawing.SystemColors.Control;
            this.btnChange.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChange.BackgroundImage")));
            this.btnChange.ButtonText = "Xác nhận";
            this.btnChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChange.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnChange.IdleBorderThickness = 1;
            this.btnChange.IdleCornerRadius = 20;
            this.btnChange.IdleFillColor = System.Drawing.Color.Gainsboro;
            this.btnChange.IdleForecolor = System.Drawing.Color.Black;
            this.btnChange.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(144)))));
            this.btnChange.Location = new System.Drawing.Point(159, 327);
            this.btnChange.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(427, 55);
            this.btnChange.TabIndex = 26;
            this.btnChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // FormDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 443);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnShowPassXacNhan);
            this.Controls.Add(this.btnShowPassMoi);
            this.Controls.Add(this.btnShowPassHienTai);
            this.Controls.Add(this.TextBoxXacNhanMatKhau);
            this.Controls.Add(this.TextBoxMatKhauMoi);
            this.Controls.Add(this.TextBoxMatKhauHienTai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTroVe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse BoTronForm;
        private Bunifu.UI.WinForms.BunifuImageButton btnTroVe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxXacNhanMatKhau;
        private System.Windows.Forms.TextBox TextBoxMatKhauMoi;
        private System.Windows.Forms.TextBox TextBoxMatKhauHienTai;
        private Bunifu.UI.WinForms.BunifuImageButton btnShowPassXacNhan;
        private Bunifu.UI.WinForms.BunifuImageButton btnShowPassMoi;
        private Bunifu.UI.WinForms.BunifuImageButton btnShowPassHienTai;
        private Bunifu.Framework.UI.BunifuThinButton2 btnChange;
    }
}