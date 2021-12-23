
namespace ManageSchedule
{
    partial class FormChinhSuaThongTIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChinhSuaThongTIn));
            this.btnTroVe = new Bunifu.UI.WinForms.BunifuImageButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBoxHoTen = new System.Windows.Forms.TextBox();
            this.BoTronForm = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.TextBoxKhoaHoc = new System.Windows.Forms.TextBox();
            this.TextBoxEmail = new System.Windows.Forms.TextBox();
            this.ComboBoxNganh = new System.Windows.Forms.ComboBox();
            this.ComboBoxHeDaoTao = new System.Windows.Forms.ComboBox();
            this.btnEdit = new Bunifu.Framework.UI.BunifuThinButton2();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Họ và tên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Ngành học:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(61, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Khóa học:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(91, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "Hệ đào tạo:";
            // 
            // TextBoxHoTen
            // 
            this.TextBoxHoTen.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxHoTen.Location = new System.Drawing.Point(157, 84);
            this.TextBoxHoTen.Name = "TextBoxHoTen";
            this.TextBoxHoTen.Size = new System.Drawing.Size(320, 27);
            this.TextBoxHoTen.TabIndex = 19;
            // 
            // BoTronForm
            // 
            this.BoTronForm.ElipseRadius = 10;
            this.BoTronForm.TargetControl = this;
            // 
            // TextBoxKhoaHoc
            // 
            this.TextBoxKhoaHoc.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxKhoaHoc.Location = new System.Drawing.Point(157, 200);
            this.TextBoxKhoaHoc.Name = "TextBoxKhoaHoc";
            this.TextBoxKhoaHoc.Size = new System.Drawing.Size(320, 27);
            this.TextBoxKhoaHoc.TabIndex = 20;
            this.TextBoxKhoaHoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKhoaHoc_KeyPress);
            // 
            // TextBoxEmail
            // 
            this.TextBoxEmail.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxEmail.Location = new System.Drawing.Point(157, 241);
            this.TextBoxEmail.Name = "TextBoxEmail";
            this.TextBoxEmail.Size = new System.Drawing.Size(320, 27);
            this.TextBoxEmail.TabIndex = 21;
            // 
            // ComboBoxNganh
            // 
            this.ComboBoxNganh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxNganh.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxNganh.FormattingEnabled = true;
            this.ComboBoxNganh.Location = new System.Drawing.Point(157, 124);
            this.ComboBoxNganh.Name = "ComboBoxNganh";
            this.ComboBoxNganh.Size = new System.Drawing.Size(320, 26);
            this.ComboBoxNganh.TabIndex = 22;
            // 
            // ComboBoxHeDaoTao
            // 
            this.ComboBoxHeDaoTao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxHeDaoTao.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxHeDaoTao.FormattingEnabled = true;
            this.ComboBoxHeDaoTao.Location = new System.Drawing.Point(157, 162);
            this.ComboBoxHeDaoTao.Name = "ComboBoxHeDaoTao";
            this.ComboBoxHeDaoTao.Size = new System.Drawing.Size(320, 26);
            this.ComboBoxHeDaoTao.TabIndex = 23;
            // 
            // btnEdit
            // 
            this.btnEdit.ActiveBorderThickness = 1;
            this.btnEdit.ActiveCornerRadius = 20;
            this.btnEdit.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(144)))));
            this.btnEdit.ActiveForecolor = System.Drawing.Color.Black;
            this.btnEdit.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(144)))));
            this.btnEdit.BackColor = System.Drawing.SystemColors.Control;
            this.btnEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.BackgroundImage")));
            this.btnEdit.ButtonText = "Xác nhận";
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnEdit.IdleBorderThickness = 1;
            this.btnEdit.IdleCornerRadius = 20;
            this.btnEdit.IdleFillColor = System.Drawing.Color.Gainsboro;
            this.btnEdit.IdleForecolor = System.Drawing.Color.Black;
            this.btnEdit.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(144)))));
            this.btnEdit.Location = new System.Drawing.Point(119, 290);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(320, 45);
            this.btnEdit.TabIndex = 24;
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // FormChinhSuaThongTIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 360);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.ComboBoxHeDaoTao);
            this.Controls.Add(this.ComboBoxNganh);
            this.Controls.Add(this.TextBoxEmail);
            this.Controls.Add(this.TextBoxKhoaHoc);
            this.Controls.Add(this.TextBoxHoTen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTroVe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormChinhSuaThongTIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉnh sửa thông tin tài khoản";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuImageButton btnTroVe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextBoxHoTen;
        private Bunifu.Framework.UI.BunifuElipse BoTronForm;
        private System.Windows.Forms.ComboBox ComboBoxHeDaoTao;
        private System.Windows.Forms.ComboBox ComboBoxNganh;
        private System.Windows.Forms.TextBox TextBoxEmail;
        private System.Windows.Forms.TextBox TextBoxKhoaHoc;
        private Bunifu.Framework.UI.BunifuThinButton2 btnEdit;
    }
}