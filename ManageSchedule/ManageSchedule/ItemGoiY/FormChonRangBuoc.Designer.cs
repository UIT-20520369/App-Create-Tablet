
namespace ManageSchedule.ItemGoiY
{
    partial class FormChonRangBuoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChonRangBuoc));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.PanelConstraint = new System.Windows.Forms.Panel();
            this.RadioButtonNone = new System.Windows.Forms.RadioButton();
            this.RadioButtonConstaint = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelTKB = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ComboBoxThu2Sang = new System.Windows.Forms.ComboBox();
            this.ComboBoxThu2Chieu = new System.Windows.Forms.ComboBox();
            this.ComboBoxThu3Sang = new System.Windows.Forms.ComboBox();
            this.ComboBoxThu3Chieu = new System.Windows.Forms.ComboBox();
            this.ComboBoxThu4Sang = new System.Windows.Forms.ComboBox();
            this.ComboBoxThu4Chieu = new System.Windows.Forms.ComboBox();
            this.ComboBoxThu5Sang = new System.Windows.Forms.ComboBox();
            this.ComboBoxThu5Chieu = new System.Windows.Forms.ComboBox();
            this.ComboBoxThu6Sang = new System.Windows.Forms.ComboBox();
            this.ComboBoxThu6Chieu = new System.Windows.Forms.ComboBox();
            this.ComboBoxThu7Sang = new System.Windows.Forms.ComboBox();
            this.ComboBoxThu7Chieu = new System.Windows.Forms.ComboBox();
            this.btnConfirm = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.PanelConstraint.SuspendLayout();
            this.PanelTKB.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelConstraint
            // 
            this.PanelConstraint.Controls.Add(this.PanelTKB);
            this.PanelConstraint.Controls.Add(this.label2);
            this.PanelConstraint.Controls.Add(this.label1);
            this.PanelConstraint.Controls.Add(this.RadioButtonConstaint);
            this.PanelConstraint.Controls.Add(this.RadioButtonNone);
            this.PanelConstraint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelConstraint.Location = new System.Drawing.Point(0, 0);
            this.PanelConstraint.Name = "PanelConstraint";
            this.PanelConstraint.Size = new System.Drawing.Size(1133, 582);
            this.PanelConstraint.TabIndex = 0;
            // 
            // RadioButtonNone
            // 
            this.RadioButtonNone.AutoSize = true;
            this.RadioButtonNone.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonNone.Location = new System.Drawing.Point(216, 190);
            this.RadioButtonNone.Name = "RadioButtonNone";
            this.RadioButtonNone.Size = new System.Drawing.Size(163, 22);
            this.RadioButtonNone.TabIndex = 0;
            this.RadioButtonNone.TabStop = true;
            this.RadioButtonNone.Text = "Không ràng buộc";
            this.RadioButtonNone.UseVisualStyleBackColor = true;
            this.RadioButtonNone.CheckedChanged += new System.EventHandler(this.RadioButtonNone_CheckedChanged);
            // 
            // RadioButtonConstaint
            // 
            this.RadioButtonConstaint.AutoSize = true;
            this.RadioButtonConstaint.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonConstaint.Location = new System.Drawing.Point(216, 235);
            this.RadioButtonConstaint.Name = "RadioButtonConstaint";
            this.RadioButtonConstaint.Size = new System.Drawing.Size(133, 22);
            this.RadioButtonConstaint.TabIndex = 1;
            this.RadioButtonConstaint.TabStop = true;
            this.RadioButtonConstaint.Text = "Có ràng buộc";
            this.RadioButtonConstaint.UseVisualStyleBackColor = true;
            this.RadioButtonConstaint.CheckedChanged += new System.EventHandler(this.RadioButtonConstaint_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(213, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn các ràng buộc mà bạn muốn cho thời khóa biểu ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(213, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(411, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Có thể bỏ qua nếu bạn cảm thấy không cần thiết";
            // 
            // PanelTKB
            // 
            this.PanelTKB.Controls.Add(this.btnConfirm);
            this.PanelTKB.Controls.Add(this.ComboBoxThu7Chieu);
            this.PanelTKB.Controls.Add(this.ComboBoxThu7Sang);
            this.PanelTKB.Controls.Add(this.ComboBoxThu6Chieu);
            this.PanelTKB.Controls.Add(this.ComboBoxThu6Sang);
            this.PanelTKB.Controls.Add(this.ComboBoxThu5Chieu);
            this.PanelTKB.Controls.Add(this.ComboBoxThu5Sang);
            this.PanelTKB.Controls.Add(this.ComboBoxThu4Chieu);
            this.PanelTKB.Controls.Add(this.ComboBoxThu4Sang);
            this.PanelTKB.Controls.Add(this.ComboBoxThu3Chieu);
            this.PanelTKB.Controls.Add(this.ComboBoxThu3Sang);
            this.PanelTKB.Controls.Add(this.ComboBoxThu2Chieu);
            this.PanelTKB.Controls.Add(this.ComboBoxThu2Sang);
            this.PanelTKB.Controls.Add(this.label10);
            this.PanelTKB.Controls.Add(this.label9);
            this.PanelTKB.Controls.Add(this.label8);
            this.PanelTKB.Controls.Add(this.label7);
            this.PanelTKB.Controls.Add(this.label6);
            this.PanelTKB.Controls.Add(this.label5);
            this.PanelTKB.Controls.Add(this.label4);
            this.PanelTKB.Controls.Add(this.label3);
            this.PanelTKB.Location = new System.Drawing.Point(84, 285);
            this.PanelTKB.Name = "PanelTKB";
            this.PanelTKB.Size = new System.Drawing.Size(1037, 251);
            this.PanelTKB.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(129, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Thứ 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sáng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Chiều";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(282, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Thứ 3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(440, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "Thứ 4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(594, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 18);
            this.label8.TabIndex = 10;
            this.label8.Text = "Thứ 5";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(751, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 18);
            this.label9.TabIndex = 11;
            this.label9.Text = "Thứ 6";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(907, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 18);
            this.label10.TabIndex = 12;
            this.label10.Text = "Thứ 7";
            // 
            // ComboBoxThu2Sang
            // 
            this.ComboBoxThu2Sang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxThu2Sang.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxThu2Sang.FormattingEnabled = true;
            this.ComboBoxThu2Sang.Location = new System.Drawing.Point(132, 70);
            this.ComboBoxThu2Sang.Name = "ComboBoxThu2Sang";
            this.ComboBoxThu2Sang.Size = new System.Drawing.Size(121, 26);
            this.ComboBoxThu2Sang.TabIndex = 13;
            // 
            // ComboBoxThu2Chieu
            // 
            this.ComboBoxThu2Chieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxThu2Chieu.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxThu2Chieu.FormattingEnabled = true;
            this.ComboBoxThu2Chieu.Location = new System.Drawing.Point(132, 144);
            this.ComboBoxThu2Chieu.Name = "ComboBoxThu2Chieu";
            this.ComboBoxThu2Chieu.Size = new System.Drawing.Size(121, 26);
            this.ComboBoxThu2Chieu.TabIndex = 14;
            // 
            // ComboBoxThu3Sang
            // 
            this.ComboBoxThu3Sang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxThu3Sang.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxThu3Sang.FormattingEnabled = true;
            this.ComboBoxThu3Sang.Location = new System.Drawing.Point(285, 70);
            this.ComboBoxThu3Sang.Name = "ComboBoxThu3Sang";
            this.ComboBoxThu3Sang.Size = new System.Drawing.Size(121, 26);
            this.ComboBoxThu3Sang.TabIndex = 15;
            // 
            // ComboBoxThu3Chieu
            // 
            this.ComboBoxThu3Chieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxThu3Chieu.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxThu3Chieu.FormattingEnabled = true;
            this.ComboBoxThu3Chieu.Location = new System.Drawing.Point(285, 144);
            this.ComboBoxThu3Chieu.Name = "ComboBoxThu3Chieu";
            this.ComboBoxThu3Chieu.Size = new System.Drawing.Size(121, 26);
            this.ComboBoxThu3Chieu.TabIndex = 16;
            // 
            // ComboBoxThu4Sang
            // 
            this.ComboBoxThu4Sang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxThu4Sang.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxThu4Sang.FormattingEnabled = true;
            this.ComboBoxThu4Sang.Location = new System.Drawing.Point(443, 70);
            this.ComboBoxThu4Sang.Name = "ComboBoxThu4Sang";
            this.ComboBoxThu4Sang.Size = new System.Drawing.Size(121, 26);
            this.ComboBoxThu4Sang.TabIndex = 17;
            // 
            // ComboBoxThu4Chieu
            // 
            this.ComboBoxThu4Chieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxThu4Chieu.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxThu4Chieu.FormattingEnabled = true;
            this.ComboBoxThu4Chieu.Location = new System.Drawing.Point(443, 144);
            this.ComboBoxThu4Chieu.Name = "ComboBoxThu4Chieu";
            this.ComboBoxThu4Chieu.Size = new System.Drawing.Size(121, 26);
            this.ComboBoxThu4Chieu.TabIndex = 18;
            // 
            // ComboBoxThu5Sang
            // 
            this.ComboBoxThu5Sang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxThu5Sang.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxThu5Sang.FormattingEnabled = true;
            this.ComboBoxThu5Sang.Location = new System.Drawing.Point(597, 70);
            this.ComboBoxThu5Sang.Name = "ComboBoxThu5Sang";
            this.ComboBoxThu5Sang.Size = new System.Drawing.Size(121, 26);
            this.ComboBoxThu5Sang.TabIndex = 19;
            // 
            // ComboBoxThu5Chieu
            // 
            this.ComboBoxThu5Chieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxThu5Chieu.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxThu5Chieu.FormattingEnabled = true;
            this.ComboBoxThu5Chieu.Location = new System.Drawing.Point(597, 144);
            this.ComboBoxThu5Chieu.Name = "ComboBoxThu5Chieu";
            this.ComboBoxThu5Chieu.Size = new System.Drawing.Size(121, 26);
            this.ComboBoxThu5Chieu.TabIndex = 20;
            // 
            // ComboBoxThu6Sang
            // 
            this.ComboBoxThu6Sang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxThu6Sang.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxThu6Sang.FormattingEnabled = true;
            this.ComboBoxThu6Sang.Location = new System.Drawing.Point(754, 70);
            this.ComboBoxThu6Sang.Name = "ComboBoxThu6Sang";
            this.ComboBoxThu6Sang.Size = new System.Drawing.Size(121, 26);
            this.ComboBoxThu6Sang.TabIndex = 21;
            // 
            // ComboBoxThu6Chieu
            // 
            this.ComboBoxThu6Chieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxThu6Chieu.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxThu6Chieu.FormattingEnabled = true;
            this.ComboBoxThu6Chieu.Location = new System.Drawing.Point(754, 144);
            this.ComboBoxThu6Chieu.Name = "ComboBoxThu6Chieu";
            this.ComboBoxThu6Chieu.Size = new System.Drawing.Size(121, 26);
            this.ComboBoxThu6Chieu.TabIndex = 22;
            // 
            // ComboBoxThu7Sang
            // 
            this.ComboBoxThu7Sang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxThu7Sang.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxThu7Sang.FormattingEnabled = true;
            this.ComboBoxThu7Sang.Location = new System.Drawing.Point(908, 70);
            this.ComboBoxThu7Sang.Name = "ComboBoxThu7Sang";
            this.ComboBoxThu7Sang.Size = new System.Drawing.Size(121, 26);
            this.ComboBoxThu7Sang.TabIndex = 23;
            // 
            // ComboBoxThu7Chieu
            // 
            this.ComboBoxThu7Chieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxThu7Chieu.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxThu7Chieu.FormattingEnabled = true;
            this.ComboBoxThu7Chieu.Location = new System.Drawing.Point(908, 144);
            this.ComboBoxThu7Chieu.Name = "ComboBoxThu7Chieu";
            this.ComboBoxThu7Chieu.Size = new System.Drawing.Size(121, 26);
            this.ComboBoxThu7Chieu.TabIndex = 24;
            // 
            // btnConfirm
            // 
            this.btnConfirm.AllowAnimations = true;
            this.btnConfirm.AllowMouseEffects = true;
            this.btnConfirm.AllowToggling = false;
            this.btnConfirm.AnimationSpeed = 200;
            this.btnConfirm.AutoGenerateColors = false;
            this.btnConfirm.AutoRoundBorders = false;
            this.btnConfirm.AutoSizeLeftIcon = true;
            this.btnConfirm.AutoSizeRightIcon = true;
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btnConfirm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfirm.BackgroundImage")));
            this.btnConfirm.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnConfirm.ButtonText = "Xác nhận";
            this.btnConfirm.ButtonTextMarginLeft = 0;
            this.btnConfirm.ColorContrastOnClick = 45;
            this.btnConfirm.ColorContrastOnHover = 45;
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnConfirm.CustomizableEdges = borderEdges1;
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnConfirm.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnConfirm.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnConfirm.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnConfirm.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnConfirm.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnConfirm.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnConfirm.IconMarginLeft = 11;
            this.btnConfirm.IconPadding = 10;
            this.btnConfirm.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirm.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnConfirm.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnConfirm.IconSize = 25;
            this.btnConfirm.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnConfirm.IdleBorderRadius = 15;
            this.btnConfirm.IdleBorderThickness = 1;
            this.btnConfirm.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnConfirm.IdleIconLeftImage = null;
            this.btnConfirm.IdleIconRightImage = null;
            this.btnConfirm.IndicateFocus = false;
            this.btnConfirm.Location = new System.Drawing.Point(903, 191);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnConfirm.OnDisabledState.BorderRadius = 15;
            this.btnConfirm.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnConfirm.OnDisabledState.BorderThickness = 1;
            this.btnConfirm.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnConfirm.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnConfirm.OnDisabledState.IconLeftImage = null;
            this.btnConfirm.OnDisabledState.IconRightImage = null;
            this.btnConfirm.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnConfirm.onHoverState.BorderRadius = 15;
            this.btnConfirm.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnConfirm.onHoverState.BorderThickness = 1;
            this.btnConfirm.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnConfirm.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.onHoverState.IconLeftImage = null;
            this.btnConfirm.onHoverState.IconRightImage = null;
            this.btnConfirm.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnConfirm.OnIdleState.BorderRadius = 15;
            this.btnConfirm.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnConfirm.OnIdleState.BorderThickness = 1;
            this.btnConfirm.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnConfirm.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.OnIdleState.IconLeftImage = null;
            this.btnConfirm.OnIdleState.IconRightImage = null;
            this.btnConfirm.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnConfirm.OnPressedState.BorderRadius = 15;
            this.btnConfirm.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnConfirm.OnPressedState.BorderThickness = 1;
            this.btnConfirm.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnConfirm.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.OnPressedState.IconLeftImage = null;
            this.btnConfirm.OnPressedState.IconRightImage = null;
            this.btnConfirm.Size = new System.Drawing.Size(126, 33);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConfirm.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnConfirm.TextMarginLeft = 0;
            this.btnConfirm.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnConfirm.UseDefaultRadiusAndThickness = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // FormChonRangBuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 582);
            this.Controls.Add(this.PanelConstraint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormChonRangBuoc";
            this.Text = "FormChonRangBuoc";
            this.PanelConstraint.ResumeLayout(false);
            this.PanelConstraint.PerformLayout();
            this.PanelTKB.ResumeLayout(false);
            this.PanelTKB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelConstraint;
        private System.Windows.Forms.RadioButton RadioButtonConstaint;
        private System.Windows.Forms.RadioButton RadioButtonNone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PanelTKB;
        private System.Windows.Forms.ComboBox ComboBoxThu7Chieu;
        private System.Windows.Forms.ComboBox ComboBoxThu7Sang;
        private System.Windows.Forms.ComboBox ComboBoxThu6Chieu;
        private System.Windows.Forms.ComboBox ComboBoxThu6Sang;
        private System.Windows.Forms.ComboBox ComboBoxThu5Chieu;
        private System.Windows.Forms.ComboBox ComboBoxThu5Sang;
        private System.Windows.Forms.ComboBox ComboBoxThu4Chieu;
        private System.Windows.Forms.ComboBox ComboBoxThu4Sang;
        private System.Windows.Forms.ComboBox ComboBoxThu3Chieu;
        private System.Windows.Forms.ComboBox ComboBoxThu3Sang;
        private System.Windows.Forms.ComboBox ComboBoxThu2Chieu;
        private System.Windows.Forms.ComboBox ComboBoxThu2Sang;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnConfirm;
    }
}