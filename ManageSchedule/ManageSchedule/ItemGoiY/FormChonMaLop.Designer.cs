
namespace ManageSchedule.ItemGoiY
{
    partial class FormChonMaLop
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChonMaLop));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.DataGridViewMaLop = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.MaMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewSelected = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxSearch = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btnSelect = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.btnDelete = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewMaLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewSelected)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewMaLop
            // 
            this.DataGridViewMaLop.AllowCustomTheming = false;
            this.DataGridViewMaLop.AllowUserToAddRows = false;
            this.DataGridViewMaLop.AllowUserToDeleteRows = false;
            this.DataGridViewMaLop.AllowUserToResizeColumns = false;
            this.DataGridViewMaLop.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.DataGridViewMaLop.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewMaLop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewMaLop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridViewMaLop.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridViewMaLop.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewMaLop.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewMaLop.ColumnHeadersHeight = 40;
            this.DataGridViewMaLop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaMon,
            this.TenMon,
            this.SoTC,
            this.Thu,
            this.Tiet});
            this.DataGridViewMaLop.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.DataGridViewMaLop.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DataGridViewMaLop.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DataGridViewMaLop.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.DataGridViewMaLop.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DataGridViewMaLop.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.DataGridViewMaLop.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.DataGridViewMaLop.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.DataGridViewMaLop.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.DataGridViewMaLop.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridViewMaLop.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.DataGridViewMaLop.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DataGridViewMaLop.CurrentTheme.Name = null;
            this.DataGridViewMaLop.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridViewMaLop.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DataGridViewMaLop.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DataGridViewMaLop.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.DataGridViewMaLop.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewMaLop.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewMaLop.EnableHeadersVisualStyles = false;
            this.DataGridViewMaLop.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.DataGridViewMaLop.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.DataGridViewMaLop.HeaderBackColor = System.Drawing.Color.Empty;
            this.DataGridViewMaLop.HeaderForeColor = System.Drawing.Color.White;
            this.DataGridViewMaLop.Location = new System.Drawing.Point(1, 55);
            this.DataGridViewMaLop.MultiSelect = false;
            this.DataGridViewMaLop.Name = "DataGridViewMaLop";
            this.DataGridViewMaLop.ReadOnly = true;
            this.DataGridViewMaLop.RowHeadersVisible = false;
            this.DataGridViewMaLop.RowTemplate.Height = 40;
            this.DataGridViewMaLop.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGridViewMaLop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewMaLop.Size = new System.Drawing.Size(682, 528);
            this.DataGridViewMaLop.TabIndex = 1;
            this.DataGridViewMaLop.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // MaMon
            // 
            this.MaMon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MaMon.Frozen = true;
            this.MaMon.HeaderText = "MÃ LỚP";
            this.MaMon.Name = "MaMon";
            this.MaMon.ReadOnly = true;
            this.MaMon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MaMon.Width = 160;
            // 
            // TenMon
            // 
            this.TenMon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TenMon.Frozen = true;
            this.TenMon.HeaderText = "TÊN MÔN";
            this.TenMon.Name = "TenMon";
            this.TenMon.ReadOnly = true;
            this.TenMon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TenMon.Width = 300;
            // 
            // SoTC
            // 
            this.SoTC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SoTC.Frozen = true;
            this.SoTC.HeaderText = "SỐ TC";
            this.SoTC.Name = "SoTC";
            this.SoTC.ReadOnly = true;
            this.SoTC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SoTC.Width = 70;
            // 
            // Thu
            // 
            this.Thu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Thu.Frozen = true;
            this.Thu.HeaderText = "THỨ";
            this.Thu.Name = "Thu";
            this.Thu.ReadOnly = true;
            this.Thu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Thu.Width = 66;
            // 
            // Tiet
            // 
            this.Tiet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Tiet.Frozen = true;
            this.Tiet.HeaderText = "TIẾT";
            this.Tiet.Name = "Tiet";
            this.Tiet.ReadOnly = true;
            this.Tiet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Tiet.Width = 86;
            // 
            // DataGridViewSelected
            // 
            this.DataGridViewSelected.AllowCustomTheming = false;
            this.DataGridViewSelected.AllowUserToAddRows = false;
            this.DataGridViewSelected.AllowUserToDeleteRows = false;
            this.DataGridViewSelected.AllowUserToResizeColumns = false;
            this.DataGridViewSelected.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.DataGridViewSelected.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridViewSelected.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewSelected.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridViewSelected.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridViewSelected.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewSelected.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridViewSelected.ColumnHeadersHeight = 40;
            this.DataGridViewSelected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.DataGridViewSelected.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.DataGridViewSelected.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DataGridViewSelected.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DataGridViewSelected.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.DataGridViewSelected.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DataGridViewSelected.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.DataGridViewSelected.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.DataGridViewSelected.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.DataGridViewSelected.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.DataGridViewSelected.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridViewSelected.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.DataGridViewSelected.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DataGridViewSelected.CurrentTheme.Name = null;
            this.DataGridViewSelected.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridViewSelected.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DataGridViewSelected.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DataGridViewSelected.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.DataGridViewSelected.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewSelected.DefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridViewSelected.EnableHeadersVisualStyles = false;
            this.DataGridViewSelected.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.DataGridViewSelected.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.DataGridViewSelected.HeaderBackColor = System.Drawing.Color.Empty;
            this.DataGridViewSelected.HeaderForeColor = System.Drawing.Color.White;
            this.DataGridViewSelected.Location = new System.Drawing.Point(705, 55);
            this.DataGridViewSelected.MultiSelect = false;
            this.DataGridViewSelected.Name = "DataGridViewSelected";
            this.DataGridViewSelected.ReadOnly = true;
            this.DataGridViewSelected.RowHeadersVisible = false;
            this.DataGridViewSelected.RowTemplate.Height = 40;
            this.DataGridViewSelected.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGridViewSelected.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewSelected.Size = new System.Drawing.Size(428, 528);
            this.DataGridViewSelected.TabIndex = 4;
            this.DataGridViewSelected.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "MÃ LỚP";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "TÊN MÔN";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tìm kiếm theo mã lớp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(702, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Danh sách mã lớp đã chọn";
            // 
            // TextBoxSearch
            // 
            this.TextBoxSearch.AcceptsReturn = false;
            this.TextBoxSearch.AcceptsTab = false;
            this.TextBoxSearch.AnimationSpeed = 200;
            this.TextBoxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.TextBoxSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.TextBoxSearch.AutoSizeHeight = true;
            this.TextBoxSearch.BackColor = System.Drawing.Color.Transparent;
            this.TextBoxSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TextBoxSearch.BackgroundImage")));
            this.TextBoxSearch.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.TextBoxSearch.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.TextBoxSearch.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.TextBoxSearch.BorderColorIdle = System.Drawing.Color.Silver;
            this.TextBoxSearch.BorderRadius = 25;
            this.TextBoxSearch.BorderThickness = 1;
            this.TextBoxSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TextBoxSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxSearch.DefaultFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxSearch.DefaultText = "";
            this.TextBoxSearch.FillColor = System.Drawing.Color.White;
            this.TextBoxSearch.HideSelection = true;
            this.TextBoxSearch.IconLeft = null;
            this.TextBoxSearch.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxSearch.IconPadding = 10;
            this.TextBoxSearch.IconRight = null;
            this.TextBoxSearch.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxSearch.Lines = new string[0];
            this.TextBoxSearch.Location = new System.Drawing.Point(206, 7);
            this.TextBoxSearch.MaxLength = 32767;
            this.TextBoxSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.TextBoxSearch.Modified = false;
            this.TextBoxSearch.Multiline = false;
            this.TextBoxSearch.Name = "TextBoxSearch";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.TextBoxSearch.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.TextBoxSearch.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.TextBoxSearch.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.TextBoxSearch.OnIdleState = stateProperties4;
            this.TextBoxSearch.Padding = new System.Windows.Forms.Padding(3);
            this.TextBoxSearch.PasswordChar = '\0';
            this.TextBoxSearch.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.TextBoxSearch.PlaceholderText = "Nhập mã lớp";
            this.TextBoxSearch.ReadOnly = false;
            this.TextBoxSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxSearch.SelectedText = "";
            this.TextBoxSearch.SelectionLength = 0;
            this.TextBoxSearch.SelectionStart = 0;
            this.TextBoxSearch.ShortcutsEnabled = true;
            this.TextBoxSearch.Size = new System.Drawing.Size(260, 42);
            this.TextBoxSearch.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.TextBoxSearch.TabIndex = 7;
            this.TextBoxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBoxSearch.TextMarginBottom = 0;
            this.TextBoxSearch.TextMarginLeft = 3;
            this.TextBoxSearch.TextMarginTop = 1;
            this.TextBoxSearch.TextPlaceholder = "Nhập mã lớp";
            this.TextBoxSearch.UseSystemPasswordChar = false;
            this.TextBoxSearch.WordWrap = true;
            this.TextBoxSearch.TextChange += new System.EventHandler(this.TextBoxSearch_TextChange);
            // 
            // btnSelect
            // 
            this.btnSelect.AllowAnimations = true;
            this.btnSelect.AllowMouseEffects = true;
            this.btnSelect.AllowToggling = false;
            this.btnSelect.AnimationSpeed = 200;
            this.btnSelect.AutoGenerateColors = false;
            this.btnSelect.AutoRoundBorders = false;
            this.btnSelect.AutoSizeLeftIcon = true;
            this.btnSelect.AutoSizeRightIcon = true;
            this.btnSelect.BackColor = System.Drawing.Color.Transparent;
            this.btnSelect.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btnSelect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelect.BackgroundImage")));
            this.btnSelect.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSelect.ButtonText = "Chọn";
            this.btnSelect.ButtonTextMarginLeft = 0;
            this.btnSelect.ColorContrastOnClick = 45;
            this.btnSelect.ColorContrastOnHover = 45;
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnSelect.CustomizableEdges = borderEdges1;
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSelect.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSelect.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSelect.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSelect.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnSelect.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnSelect.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnSelect.IconMarginLeft = 11;
            this.btnSelect.IconPadding = 10;
            this.btnSelect.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnSelect.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnSelect.IconSize = 25;
            this.btnSelect.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSelect.IdleBorderRadius = 20;
            this.btnSelect.IdleBorderThickness = 1;
            this.btnSelect.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnSelect.IdleIconLeftImage = null;
            this.btnSelect.IdleIconRightImage = null;
            this.btnSelect.IndicateFocus = false;
            this.btnSelect.Location = new System.Drawing.Point(472, 19);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSelect.OnDisabledState.BorderRadius = 20;
            this.btnSelect.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSelect.OnDisabledState.BorderThickness = 1;
            this.btnSelect.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSelect.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSelect.OnDisabledState.IconLeftImage = null;
            this.btnSelect.OnDisabledState.IconRightImage = null;
            this.btnSelect.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnSelect.onHoverState.BorderRadius = 20;
            this.btnSelect.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSelect.onHoverState.BorderThickness = 1;
            this.btnSelect.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnSelect.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnSelect.onHoverState.IconLeftImage = null;
            this.btnSelect.onHoverState.IconRightImage = null;
            this.btnSelect.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSelect.OnIdleState.BorderRadius = 20;
            this.btnSelect.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSelect.OnIdleState.BorderThickness = 1;
            this.btnSelect.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnSelect.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnSelect.OnIdleState.IconLeftImage = null;
            this.btnSelect.OnIdleState.IconRightImage = null;
            this.btnSelect.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnSelect.OnPressedState.BorderRadius = 20;
            this.btnSelect.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnSelect.OnPressedState.BorderThickness = 1;
            this.btnSelect.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnSelect.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnSelect.OnPressedState.IconLeftImage = null;
            this.btnSelect.OnPressedState.IconRightImage = null;
            this.btnSelect.Size = new System.Drawing.Size(125, 30);
            this.btnSelect.TabIndex = 8;
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSelect.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSelect.TextMarginLeft = 0;
            this.btnSelect.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSelect.UseDefaultRadiusAndThickness = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AllowAnimations = true;
            this.btnDelete.AllowMouseEffects = true;
            this.btnDelete.AllowToggling = false;
            this.btnDelete.AnimationSpeed = 200;
            this.btnDelete.AutoGenerateColors = false;
            this.btnDelete.AutoRoundBorders = false;
            this.btnDelete.AutoSizeLeftIcon = true;
            this.btnDelete.AutoSizeRightIcon = true;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnDelete.ButtonText = "Xóa";
            this.btnDelete.ButtonTextMarginLeft = 0;
            this.btnDelete.ColorContrastOnClick = 45;
            this.btnDelete.ColorContrastOnHover = 45;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnDelete.CustomizableEdges = borderEdges2;
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDelete.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDelete.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnDelete.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnDelete.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnDelete.IconMarginLeft = 11;
            this.btnDelete.IconPadding = 10;
            this.btnDelete.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnDelete.IconSize = 25;
            this.btnDelete.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDelete.IdleBorderRadius = 20;
            this.btnDelete.IdleBorderThickness = 1;
            this.btnDelete.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btnDelete.IdleIconLeftImage = null;
            this.btnDelete.IdleIconRightImage = null;
            this.btnDelete.IndicateFocus = false;
            this.btnDelete.Location = new System.Drawing.Point(996, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDelete.OnDisabledState.BorderRadius = 20;
            this.btnDelete.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnDelete.OnDisabledState.BorderThickness = 1;
            this.btnDelete.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnDelete.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnDelete.OnDisabledState.IconLeftImage = null;
            this.btnDelete.OnDisabledState.IconRightImage = null;
            this.btnDelete.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnDelete.onHoverState.BorderRadius = 20;
            this.btnDelete.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnDelete.onHoverState.BorderThickness = 1;
            this.btnDelete.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btnDelete.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnDelete.onHoverState.IconLeftImage = null;
            this.btnDelete.onHoverState.IconRightImage = null;
            this.btnDelete.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDelete.OnIdleState.BorderRadius = 20;
            this.btnDelete.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnDelete.OnIdleState.BorderThickness = 1;
            this.btnDelete.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnDelete.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnDelete.OnIdleState.IconLeftImage = null;
            this.btnDelete.OnIdleState.IconRightImage = null;
            this.btnDelete.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnDelete.OnPressedState.BorderRadius = 20;
            this.btnDelete.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.btnDelete.OnPressedState.BorderThickness = 1;
            this.btnDelete.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btnDelete.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnDelete.OnPressedState.IconLeftImage = null;
            this.btnDelete.OnPressedState.IconRightImage = null;
            this.btnDelete.Size = new System.Drawing.Size(125, 30);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnDelete.TextMarginLeft = 0;
            this.btnDelete.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnDelete.UseDefaultRadiusAndThickness = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FormChonMaLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 582);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.TextBoxSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataGridViewSelected);
            this.Controls.Add(this.DataGridViewMaLop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormChonMaLop";
            this.Text = "FormChonMaLop";
            this.Load += new System.EventHandler(this.FormChonMaLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewMaLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewSelected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuDataGridView DataGridViewMaLop;
        private Bunifu.UI.WinForms.BunifuDataGridView DataGridViewSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Bunifu.UI.WinForms.BunifuTextBox TextBoxSearch;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnSelect;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tiet;
    }
}