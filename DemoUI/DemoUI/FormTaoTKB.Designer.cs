
namespace DemoUI
{
    partial class FormTaoTKB
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelImport = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new FontAwesome.Sharp.IconButton();
            this.panelTask = new System.Windows.Forms.Panel();
            this.btnXemTKB = new FontAwesome.Sharp.IconButton();
            this.labelKetQua = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelTinChi = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lvDisplay = new System.Windows.Forms.ListView();
            this.maMonHoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tenMonHoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.soTinChi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnTaoTKB = new FontAwesome.Sharp.IconButton();
            this.btnDelete = new FontAwesome.Sharp.IconButton();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.cbChuongTrinhDaoTao = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelImport.SuspendLayout();
            this.panelTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.panelImport);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1516, 220);
            this.panelHeader.TabIndex = 0;
            // 
            // panelImport
            // 
            this.panelImport.Controls.Add(this.label2);
            this.panelImport.Controls.Add(this.labelFilePath);
            this.panelImport.Controls.Add(this.label1);
            this.panelImport.Controls.Add(this.btnImport);
            this.panelImport.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelImport.Location = new System.Drawing.Point(0, 0);
            this.panelImport.Margin = new System.Windows.Forms.Padding(4);
            this.panelImport.Name = "panelImport";
            this.panelImport.Size = new System.Drawing.Size(1512, 220);
            this.panelImport.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(31, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(371, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chọn tệp (Excel) thông tin các môn học";
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilePath.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelFilePath.Location = new System.Drawing.Point(29, 165);
            this.labelFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(0, 22);
            this.labelFilePath.TabIndex = 2;
            this.labelFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(31, 130);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tệp đã chọn: ";
            // 
            // btnImport
            // 
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnImport.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.btnImport.IconColor = System.Drawing.Color.Gainsboro;
            this.btnImport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImport.IconSize = 32;
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(15, 53);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnImport.Size = new System.Drawing.Size(184, 74);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Chọn tệp";
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // panelTask
            // 
            this.panelTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTask.Controls.Add(this.btnXemTKB);
            this.panelTask.Controls.Add(this.labelKetQua);
            this.panelTask.Controls.Add(this.label7);
            this.panelTask.Controls.Add(this.labelTinChi);
            this.panelTask.Controls.Add(this.label6);
            this.panelTask.Controls.Add(this.label5);
            this.panelTask.Controls.Add(this.lvDisplay);
            this.panelTask.Controls.Add(this.btnTaoTKB);
            this.panelTask.Controls.Add(this.btnDelete);
            this.panelTask.Controls.Add(this.btnAdd);
            this.panelTask.Controls.Add(this.cbChuongTrinhDaoTao);
            this.panelTask.Controls.Add(this.label4);
            this.panelTask.Controls.Add(this.tbInput);
            this.panelTask.Controls.Add(this.label3);
            this.panelTask.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTask.Location = new System.Drawing.Point(0, 220);
            this.panelTask.Margin = new System.Windows.Forms.Padding(4);
            this.panelTask.Name = "panelTask";
            this.panelTask.Size = new System.Drawing.Size(1516, 700);
            this.panelTask.TabIndex = 1;
            // 
            // btnXemTKB
            // 
            this.btnXemTKB.FlatAppearance.BorderSize = 0;
            this.btnXemTKB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemTKB.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemTKB.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnXemTKB.IconChar = FontAwesome.Sharp.IconChar.ListAlt;
            this.btnXemTKB.IconColor = System.Drawing.Color.Gainsboro;
            this.btnXemTKB.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXemTKB.IconSize = 32;
            this.btnXemTKB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemTKB.Location = new System.Drawing.Point(917, 494);
            this.btnXemTKB.Margin = new System.Windows.Forms.Padding(4);
            this.btnXemTKB.Name = "btnXemTKB";
            this.btnXemTKB.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnXemTKB.Size = new System.Drawing.Size(201, 62);
            this.btnXemTKB.TabIndex = 20;
            this.btnXemTKB.Text = "  Xem kết quả";
            this.btnXemTKB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemTKB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXemTKB.UseVisualStyleBackColor = true;
            // 
            // labelKetQua
            // 
            this.labelKetQua.AutoSize = true;
            this.labelKetQua.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKetQua.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelKetQua.Location = new System.Drawing.Point(1197, 433);
            this.labelKetQua.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelKetQua.Name = "labelKetQua";
            this.labelKetQua.Size = new System.Drawing.Size(24, 27);
            this.labelKetQua.TabIndex = 18;
            this.labelKetQua.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(800, 433);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(403, 27);
            this.label7.TabIndex = 17;
            this.label7.Text = "Số kết quả phù hợp với yêu cầu của bạn:\r\n";
            // 
            // labelTinChi
            // 
            this.labelTinChi.AutoSize = true;
            this.labelTinChi.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTinChi.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelTinChi.Location = new System.Drawing.Point(621, 567);
            this.labelTinChi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTinChi.Name = "labelTinChi";
            this.labelTinChi.Size = new System.Drawing.Size(19, 21);
            this.labelTinChi.TabIndex = 16;
            this.labelTinChi.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(643, 567);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 21);
            this.label6.TabIndex = 15;
            this.label6.Text = "tín chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(443, 567);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "Đã đăng ký tổng cộng ";
            // 
            // lvDisplay
            // 
            this.lvDisplay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lvDisplay.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lvDisplay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.maMonHoc,
            this.tenMonHoc,
            this.soTinChi});
            this.lvDisplay.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvDisplay.FullRowSelect = true;
            this.lvDisplay.GridLines = true;
            this.lvDisplay.HideSelection = false;
            this.lvDisplay.Location = new System.Drawing.Point(34, 177);
            this.lvDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.lvDisplay.MultiSelect = false;
            this.lvDisplay.Name = "lvDisplay";
            this.lvDisplay.Size = new System.Drawing.Size(732, 379);
            this.lvDisplay.TabIndex = 12;
            this.lvDisplay.UseCompatibleStateImageBehavior = false;
            this.lvDisplay.View = System.Windows.Forms.View.Details;
            // 
            // maMonHoc
            // 
            this.maMonHoc.Text = "Mã môn học";
            this.maMonHoc.Width = 180;
            // 
            // tenMonHoc
            // 
            this.tenMonHoc.Text = "Tên môn học";
            this.tenMonHoc.Width = 440;
            // 
            // soTinChi
            // 
            this.soTinChi.Text = "Số tín chỉ";
            this.soTinChi.Width = 110;
            // 
            // btnTaoTKB
            // 
            this.btnTaoTKB.FlatAppearance.BorderSize = 0;
            this.btnTaoTKB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoTKB.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoTKB.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTaoTKB.IconChar = FontAwesome.Sharp.IconChar.CaretSquareRight;
            this.btnTaoTKB.IconColor = System.Drawing.Color.Gainsboro;
            this.btnTaoTKB.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTaoTKB.IconSize = 32;
            this.btnTaoTKB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoTKB.Location = new System.Drawing.Point(377, 90);
            this.btnTaoTKB.Margin = new System.Windows.Forms.Padding(4);
            this.btnTaoTKB.Name = "btnTaoTKB";
            this.btnTaoTKB.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnTaoTKB.Size = new System.Drawing.Size(243, 62);
            this.btnTaoTKB.TabIndex = 11;
            this.btnTaoTKB.Text = "  Tạo thời khóa biểu";
            this.btnTaoTKB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoTKB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaoTKB.UseVisualStyleBackColor = true;
            this.btnTaoTKB.Click += new System.EventHandler(this.btnTaoTKB_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnDelete.IconColor = System.Drawing.Color.Gainsboro;
            this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDelete.IconSize = 32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(205, 90);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnDelete.Size = new System.Drawing.Size(164, 62);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "  Xóa";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAdd.IconColor = System.Drawing.Color.Gainsboro;
            this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdd.IconSize = 32;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(33, 90);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnAdd.Size = new System.Drawing.Size(164, 62);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "  Thêm";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbChuongTrinhDaoTao
            // 
            this.cbChuongTrinhDaoTao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChuongTrinhDaoTao.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChuongTrinhDaoTao.ForeColor = System.Drawing.Color.Black;
            this.cbChuongTrinhDaoTao.FormattingEnabled = true;
            this.cbChuongTrinhDaoTao.Location = new System.Drawing.Point(1083, 34);
            this.cbChuongTrinhDaoTao.Margin = new System.Windows.Forms.Padding(4);
            this.cbChuongTrinhDaoTao.Name = "cbChuongTrinhDaoTao";
            this.cbChuongTrinhDaoTao.Size = new System.Drawing.Size(192, 30);
            this.cbChuongTrinhDaoTao.TabIndex = 7;
            this.cbChuongTrinhDaoTao.SelectedIndexChanged += new System.EventHandler(this.cbChuongTrinhDaoTao_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(857, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Chương trình đào tạo";
            // 
            // tbInput
            // 
            this.tbInput.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInput.Location = new System.Drawing.Point(324, 30);
            this.tbInput.Margin = new System.Windows.Forms.Padding(4);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(217, 30);
            this.tbInput.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(31, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nhập mã môn hoặc mã lớp:\r\n";
            // 
            // FormTaoTKB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1516, 828);
            this.Controls.Add(this.panelTask);
            this.Controls.Add(this.panelHeader);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTaoTKB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo thời khóa biểu";
            this.panelHeader.ResumeLayout(false);
            this.panelImport.ResumeLayout(false);
            this.panelImport.PerformLayout();
            this.panelTask.ResumeLayout(false);
            this.panelTask.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnImport;
        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelImport;
        private System.Windows.Forms.Panel panelTask;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbChuongTrinhDaoTao;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btnDelete;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton btnTaoTKB;
        private System.Windows.Forms.ListView lvDisplay;
        private System.Windows.Forms.ColumnHeader maMonHoc;
        private System.Windows.Forms.ColumnHeader tenMonHoc;
        private System.Windows.Forms.ColumnHeader soTinChi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTinChi;
        private System.Windows.Forms.Label labelKetQua;
        private System.Windows.Forms.Label label7;
        private FontAwesome.Sharp.IconButton btnXemTKB;
    }
}