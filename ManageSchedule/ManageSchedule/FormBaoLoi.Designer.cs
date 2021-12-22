
namespace ManageSchedule
{
    partial class FormBaoLoi
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
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBaoLoi));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.BoTronBaoLoi = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelText = new System.Windows.Forms.Panel();
            this.labelText = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textSubject = new System.Windows.Forms.TextBox();
            this.textMail = new System.Windows.Forms.RichTextBox();
            this.txtFile = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpenFile = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnSend = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelText.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // BoTronBaoLoi
            // 
            this.BoTronBaoLoi.ElipseRadius = 10;
            this.BoTronBaoLoi.TargetControl = this;
            // 
            // panelText
            // 
            this.panelText.Controls.Add(this.labelText);
            this.panelText.Location = new System.Drawing.Point(51, 25);
            this.panelText.Name = "panelText";
            this.panelText.Size = new System.Drawing.Size(1035, 121);
            this.panelText.TabIndex = 2;
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelText.Location = new System.Drawing.Point(32, 21);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(619, 36);
            this.labelText.TabIndex = 0;
            this.labelText.Text = "Xin lỗi vì trải nghiệm không tốt của bạn khi dùng sản phẩm của chúng tôi.\r\nHãy bá" +
    "o cho chúng tôi biết những lỗi mà bạn đã gặp phải. Xin cảm ơn.\r\n";
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.btnSend);
            this.panelContent.Controls.Add(this.btnOpenFile);
            this.panelContent.Controls.Add(this.label4);
            this.panelContent.Controls.Add(this.txtFile);
            this.panelContent.Controls.Add(this.textMail);
            this.panelContent.Controls.Add(this.textSubject);
            this.panelContent.Controls.Add(this.label3);
            this.panelContent.Controls.Add(this.label2);
            this.panelContent.Controls.Add(this.label1);
            this.panelContent.Location = new System.Drawing.Point(58, 168);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(853, 437);
            this.panelContent.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mô tả lỗi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nội dung";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tệp đính kèm";
            // 
            // textSubject
            // 
            this.textSubject.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSubject.Location = new System.Drawing.Point(187, 4);
            this.textSubject.Name = "textSubject";
            this.textSubject.Size = new System.Drawing.Size(459, 27);
            this.textSubject.TabIndex = 3;
            // 
            // textMail
            // 
            this.textMail.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMail.Location = new System.Drawing.Point(187, 69);
            this.textMail.Name = "textMail";
            this.textMail.Size = new System.Drawing.Size(457, 183);
            this.textMail.TabIndex = 4;
            this.textMail.Text = "";
            // 
            // txtFile
            // 
            this.txtFile.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFile.Location = new System.Drawing.Point(187, 282);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(459, 39);
            this.txtFile.TabIndex = 5;
            this.txtFile.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(647, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "(*)";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.AllowAnimations = true;
            this.btnOpenFile.AllowMouseEffects = true;
            this.btnOpenFile.AllowToggling = false;
            this.btnOpenFile.AnimationSpeed = 200;
            this.btnOpenFile.AutoGenerateColors = false;
            this.btnOpenFile.AutoRoundBorders = false;
            this.btnOpenFile.AutoSizeLeftIcon = true;
            this.btnOpenFile.AutoSizeRightIcon = true;
            this.btnOpenFile.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenFile.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btnOpenFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpenFile.BackgroundImage")));
            this.btnOpenFile.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnOpenFile.ButtonText = "Chọn tệp";
            this.btnOpenFile.ButtonTextMarginLeft = 0;
            this.btnOpenFile.ColorContrastOnClick = 45;
            this.btnOpenFile.ColorContrastOnHover = 45;
            this.btnOpenFile.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnOpenFile.CustomizableEdges = borderEdges2;
            this.btnOpenFile.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOpenFile.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnOpenFile.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnOpenFile.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnOpenFile.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnOpenFile.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFile.ForeColor = System.Drawing.Color.White;
            this.btnOpenFile.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenFile.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnOpenFile.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnOpenFile.IconMarginLeft = 11;
            this.btnOpenFile.IconPadding = 10;
            this.btnOpenFile.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenFile.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnOpenFile.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnOpenFile.IconSize = 25;
            this.btnOpenFile.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnOpenFile.IdleBorderRadius = 37;
            this.btnOpenFile.IdleBorderThickness = 1;
            this.btnOpenFile.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnOpenFile.IdleIconLeftImage = null;
            this.btnOpenFile.IdleIconRightImage = null;
            this.btnOpenFile.IndicateFocus = false;
            this.btnOpenFile.Location = new System.Drawing.Point(678, 282);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnOpenFile.OnDisabledState.BorderRadius = 37;
            this.btnOpenFile.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnOpenFile.OnDisabledState.BorderThickness = 1;
            this.btnOpenFile.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnOpenFile.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnOpenFile.OnDisabledState.IconLeftImage = null;
            this.btnOpenFile.OnDisabledState.IconRightImage = null;
            this.btnOpenFile.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnOpenFile.onHoverState.BorderRadius = 37;
            this.btnOpenFile.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnOpenFile.onHoverState.BorderThickness = 1;
            this.btnOpenFile.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnOpenFile.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnOpenFile.onHoverState.IconLeftImage = null;
            this.btnOpenFile.onHoverState.IconRightImage = null;
            this.btnOpenFile.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnOpenFile.OnIdleState.BorderRadius = 37;
            this.btnOpenFile.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnOpenFile.OnIdleState.BorderThickness = 1;
            this.btnOpenFile.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnOpenFile.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnOpenFile.OnIdleState.IconLeftImage = null;
            this.btnOpenFile.OnIdleState.IconRightImage = null;
            this.btnOpenFile.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnOpenFile.OnPressedState.BorderRadius = 37;
            this.btnOpenFile.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnOpenFile.OnPressedState.BorderThickness = 1;
            this.btnOpenFile.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnOpenFile.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnOpenFile.OnPressedState.IconLeftImage = null;
            this.btnOpenFile.OnPressedState.IconRightImage = null;
            this.btnOpenFile.Size = new System.Drawing.Size(150, 39);
            this.btnOpenFile.TabIndex = 7;
            this.btnOpenFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOpenFile.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnOpenFile.TextMarginLeft = 0;
            this.btnOpenFile.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnOpenFile.UseDefaultRadiusAndThickness = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnSend
            // 
            this.btnSend.AllowAnimations = true;
            this.btnSend.AllowMouseEffects = true;
            this.btnSend.AllowToggling = false;
            this.btnSend.AnimationSpeed = 200;
            this.btnSend.AutoGenerateColors = false;
            this.btnSend.AutoRoundBorders = false;
            this.btnSend.AutoSizeLeftIcon = true;
            this.btnSend.AutoSizeRightIcon = true;
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btnSend.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSend.BackgroundImage")));
            this.btnSend.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSend.ButtonText = "Gửi";
            this.btnSend.ButtonTextMarginLeft = 0;
            this.btnSend.ColorContrastOnClick = 45;
            this.btnSend.ColorContrastOnHover = 45;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnSend.CustomizableEdges = borderEdges1;
            this.btnSend.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSend.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSend.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSend.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSend.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnSend.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSend.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnSend.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnSend.IconMarginLeft = 11;
            this.btnSend.IconPadding = 10;
            this.btnSend.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSend.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnSend.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnSend.IconSize = 25;
            this.btnSend.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSend.IdleBorderRadius = 37;
            this.btnSend.IdleBorderThickness = 1;
            this.btnSend.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnSend.IdleIconLeftImage = null;
            this.btnSend.IdleIconRightImage = null;
            this.btnSend.IndicateFocus = false;
            this.btnSend.Location = new System.Drawing.Point(496, 377);
            this.btnSend.Name = "btnSend";
            this.btnSend.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSend.OnDisabledState.BorderRadius = 37;
            this.btnSend.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSend.OnDisabledState.BorderThickness = 1;
            this.btnSend.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSend.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSend.OnDisabledState.IconLeftImage = null;
            this.btnSend.OnDisabledState.IconRightImage = null;
            this.btnSend.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnSend.onHoverState.BorderRadius = 37;
            this.btnSend.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSend.onHoverState.BorderThickness = 1;
            this.btnSend.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnSend.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnSend.onHoverState.IconLeftImage = null;
            this.btnSend.onHoverState.IconRightImage = null;
            this.btnSend.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSend.OnIdleState.BorderRadius = 37;
            this.btnSend.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSend.OnIdleState.BorderThickness = 1;
            this.btnSend.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnSend.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnSend.OnIdleState.IconLeftImage = null;
            this.btnSend.OnIdleState.IconRightImage = null;
            this.btnSend.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnSend.OnPressedState.BorderRadius = 37;
            this.btnSend.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSend.OnPressedState.BorderThickness = 1;
            this.btnSend.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnSend.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnSend.OnPressedState.IconLeftImage = null;
            this.btnSend.OnPressedState.IconRightImage = null;
            this.btnSend.Size = new System.Drawing.Size(150, 39);
            this.btnSend.TabIndex = 8;
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSend.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSend.TextMarginLeft = 0;
            this.btnSend.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSend.UseDefaultRadiusAndThickness = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormBaoLoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 679);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBaoLoi";
            this.Text = "Báo lỗi";
            this.panelText.ResumeLayout(false);
            this.panelText.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse BoTronBaoLoi;
        private System.Windows.Forms.Panel panelContent;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnSend;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnOpenFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtFile;
        private System.Windows.Forms.RichTextBox textMail;
        private System.Windows.Forms.TextBox textSubject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelText;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}