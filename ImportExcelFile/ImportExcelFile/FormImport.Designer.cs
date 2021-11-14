
namespace ImportExcelFile
{
    partial class FormImport
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
            this.dgvDisplayLT = new System.Windows.Forms.DataGridView();
            this.btnImport = new System.Windows.Forms.Button();
            this.dgvDisplayTH = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxTimLopLT = new System.Windows.Forms.TextBox();
            this.tbxTimLopTH = new System.Windows.Forms.TextBox();
            this.lvwSelectedClass = new System.Windows.Forms.ListView();
            this.cClassID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cSubjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cThu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cTiet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDel = new System.Windows.Forms.Button();
            this.btnTimLopLT = new System.Windows.Forms.Button();
            this.btnTimLopTH = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbHeDT = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplayLT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplayTH)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDisplayLT
            // 
            this.dgvDisplayLT.AllowUserToAddRows = false;
            this.dgvDisplayLT.AllowUserToDeleteRows = false;
            this.dgvDisplayLT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisplayLT.Location = new System.Drawing.Point(13, 117);
            this.dgvDisplayLT.MultiSelect = false;
            this.dgvDisplayLT.Name = "dgvDisplayLT";
            this.dgvDisplayLT.ReadOnly = true;
            this.dgvDisplayLT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDisplayLT.Size = new System.Drawing.Size(662, 221);
            this.dgvDisplayLT.TabIndex = 0;
            this.dgvDisplayLT.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDisplayLT_CellDoubleClick);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(956, 12);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(93, 27);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Import excel";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dgvDisplayTH
            // 
            this.dgvDisplayTH.AllowUserToAddRows = false;
            this.dgvDisplayTH.AllowUserToDeleteRows = false;
            this.dgvDisplayTH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisplayTH.Location = new System.Drawing.Point(12, 371);
            this.dgvDisplayTH.MultiSelect = false;
            this.dgvDisplayTH.Name = "dgvDisplayTH";
            this.dgvDisplayTH.ReadOnly = true;
            this.dgvDisplayTH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDisplayTH.Size = new System.Drawing.Size(662, 228);
            this.dgvDisplayTH.TabIndex = 4;
            this.dgvDisplayTH.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDisplayTH_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Lớp TH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lớp LT";
            // 
            // tbxTimLopLT
            // 
            this.tbxTimLopLT.Location = new System.Drawing.Point(75, 90);
            this.tbxTimLopLT.Name = "tbxTimLopLT";
            this.tbxTimLopLT.Size = new System.Drawing.Size(177, 20);
            this.tbxTimLopLT.TabIndex = 6;
            this.tbxTimLopLT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxTimLop_KeyDown);
            // 
            // tbxTimLopTH
            // 
            this.tbxTimLopTH.Location = new System.Drawing.Point(77, 344);
            this.tbxTimLopTH.Name = "tbxTimLopTH";
            this.tbxTimLopTH.Size = new System.Drawing.Size(175, 20);
            this.tbxTimLopTH.TabIndex = 7;
            this.tbxTimLopTH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxTimLop_KeyDown);
            // 
            // lvwSelectedClass
            // 
            this.lvwSelectedClass.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cClassID,
            this.cSubjectName,
            this.cThu,
            this.cTiet});
            this.lvwSelectedClass.FullRowSelect = true;
            this.lvwSelectedClass.HideSelection = false;
            this.lvwSelectedClass.Location = new System.Drawing.Point(681, 117);
            this.lvwSelectedClass.Name = "lvwSelectedClass";
            this.lvwSelectedClass.Size = new System.Drawing.Size(368, 453);
            this.lvwSelectedClass.TabIndex = 10;
            this.lvwSelectedClass.UseCompatibleStateImageBehavior = false;
            this.lvwSelectedClass.View = System.Windows.Forms.View.Details;
            // 
            // cClassID
            // 
            this.cClassID.Text = "Mã Lớp";
            this.cClassID.Width = 80;
            // 
            // cSubjectName
            // 
            this.cSubjectName.Text = "Tên Môn Học";
            this.cSubjectName.Width = 196;
            // 
            // cThu
            // 
            this.cThu.Text = "Thứ";
            this.cThu.Width = 42;
            // 
            // cTiet
            // 
            this.cTiet.Text = "Tiết";
            this.cTiet.Width = 67;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(974, 576);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "Xóa";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnTimLopLT
            // 
            this.btnTimLopLT.Location = new System.Drawing.Point(258, 88);
            this.btnTimLopLT.Name = "btnTimLopLT";
            this.btnTimLopLT.Size = new System.Drawing.Size(75, 23);
            this.btnTimLopLT.TabIndex = 11;
            this.btnTimLopLT.Text = "Tìm";
            this.btnTimLopLT.UseVisualStyleBackColor = true;
            this.btnTimLopLT.Click += new System.EventHandler(this.btnTimLop_Click);
            // 
            // btnTimLopTH
            // 
            this.btnTimLopTH.Location = new System.Drawing.Point(258, 342);
            this.btnTimLopTH.Name = "btnTimLopTH";
            this.btnTimLopTH.Size = new System.Drawing.Size(75, 23);
            this.btnTimLopTH.TabIndex = 11;
            this.btnTimLopTH.Text = "Tìm";
            this.btnTimLopTH.UseVisualStyleBackColor = true;
            this.btnTimLopTH.Click += new System.EventHandler(this.btnTimLop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Hệ đào tạo";
            // 
            // cbHeDT
            // 
            this.cbHeDT.FormattingEnabled = true;
            this.cbHeDT.Items.AddRange(new object[] {
            "CQUI",
            "CNTN",
            "KSTN",
            "CLC",
            "CTTT",
            "BCU",
            "VB2CQ"});
            this.cbHeDT.Location = new System.Drawing.Point(95, 32);
            this.cbHeDT.Name = "cbHeDT";
            this.cbHeDT.Size = new System.Drawing.Size(95, 21);
            this.cbHeDT.TabIndex = 13;
            this.cbHeDT.SelectedIndexChanged += new System.EventHandler(this.cbHeDT_SelectedIndexChanged);
            // 
            // FormImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 611);
            this.Controls.Add(this.cbHeDT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTimLopTH);
            this.Controls.Add(this.btnTimLopLT);
            this.Controls.Add(this.lvwSelectedClass);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.tbxTimLopTH);
            this.Controls.Add(this.tbxTimLopLT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDisplayTH);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dgvDisplayLT);
            this.Name = "FormImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplayLT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplayTH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDisplayLT;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridView dgvDisplayTH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxTimLopLT;
        private System.Windows.Forms.TextBox tbxTimLopTH;
        private System.Windows.Forms.ListView lvwSelectedClass;
        private System.Windows.Forms.ColumnHeader cClassID;
        private System.Windows.Forms.ColumnHeader cSubjectName;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnTimLopLT;
        private System.Windows.Forms.Button btnTimLopTH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbHeDT;
        private System.Windows.Forms.ColumnHeader cThu;
        private System.Windows.Forms.ColumnHeader cTiet;
    }
}

