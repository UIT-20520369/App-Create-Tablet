using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using System.IO;

namespace ImportExcelFile
{
    public partial class FormImport : Form
    {
        DataSet ds;

        RandomTablet rtLT;
        RandomTablet rtTH;
        public FormImport()
        { 
            InitializeComponent();

            rtLT = new RandomTablet(dgvDisplayLT);
            rtTH = new RandomTablet(dgvDisplayTH);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        IExcelDataReader reader;
                        if (ofd.FilterIndex == 2)
                        {
                            reader = ExcelReaderFactory.CreateBinaryReader(stream);
                        }
                        else
                        {
                            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        }

                        ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });

                        // Thêm các cột vào data grid view
                        for (int i = 0; i < ds.Tables[0].Columns.Count; i++) 
                        {
                            DataGridViewColumn c = new DataGridViewColumn();
                            c.Name = "c" + ds.Tables[0].Rows[6].ItemArray[i].ToString();
                            c.HeaderText = ds.Tables[0].Rows[6].ItemArray[i].ToString();
                            c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            c.CellTemplate = new DataGridViewTextBoxCell();
                            dgvDisplayLT.Columns.Add(c);
                        }
                        dgvDisplayLT.Rows.Clear();
                        for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                        {
                            DataGridViewColumn c = new DataGridViewColumn();
                            c.Name = "c" + ds.Tables[1].Rows[6].ItemArray[i].ToString();
                            c.HeaderText = ds.Tables[1].Rows[6].ItemArray[i].ToString();
                            c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            c.CellTemplate = new DataGridViewTextBoxCell();
                            dgvDisplayTH.Columns.Add(c);
                        }
                        dgvDisplayTH.Rows.Clear();
                   
                        // set hệ mặc định là CQUI
                        cbHeDT.SelectedIndex = 0;

                        reader.Close();
                    }
                }
            }
        }


        private void dgvDisplayLT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thêm môn lí thuyết vào listview
            int add = rtLT.AddLTbyClick(dgvDisplayLT, e.RowIndex);
            if (add != 0)
            {
                ListViewItem classID = new ListViewItem(dgvDisplayLT.Rows[e.RowIndex].Cells[2].Value.ToString());
                ListViewItem.ListViewSubItem subjectName = new ListViewItem.ListViewSubItem(classID, dgvDisplayLT.Rows[e.RowIndex].Cells[3].Value.ToString());
                ListViewItem.ListViewSubItem day = new ListViewItem.ListViewSubItem(classID, dgvDisplayLT.Rows[e.RowIndex].Cells[10].Value.ToString());
                ListViewItem.ListViewSubItem period = new ListViewItem.ListViewSubItem(classID, dgvDisplayLT.Rows[e.RowIndex].Cells[11].Value.ToString());
                classID.SubItems.Add(subjectName);
                classID.SubItems.Add(day);
                classID.SubItems.Add(period);
                lvwSelectedClass.Items.Add(classID);
                // Nếu lớp học 2 buổi/tuần
                if (add == 2)
                {
                    foreach (DataGridViewRow row in dgvDisplayLT.Rows)
                    {
                        if (row.Cells[2].Value.ToString() == classID.Text)
                        {
                            if (row.Cells[10].Value.ToString() != classID.SubItems[2].Text || row.Cells[11].Value.ToString() != classID.SubItems[3].Text)
                            {
                                ListViewItem class2ID = new ListViewItem(row.Cells[2].Value.ToString());
                                ListViewItem.ListViewSubItem subject2Name = new ListViewItem.ListViewSubItem(class2ID, row.Cells[3].Value.ToString());
                                ListViewItem.ListViewSubItem day2 = new ListViewItem.ListViewSubItem(class2ID, row.Cells[10].Value.ToString());
                                ListViewItem.ListViewSubItem period2 = new ListViewItem.ListViewSubItem(class2ID, row.Cells[11].Value.ToString());
                                class2ID.SubItems.Add(subject2Name);
                                class2ID.SubItems.Add(day2);
                                class2ID.SubItems.Add(period2);
                                lvwSelectedClass.Items.Add(class2ID);
                            }
                        }
                    }
                }
            }
        }

        private void dgvDisplayTH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thêm môn thực hành vào listview
            if (rtTH.AddTHbyClick(dgvDisplayTH, e.RowIndex, rtLT.GetDSL()))
            {
                ListViewItem classID = new ListViewItem(dgvDisplayTH.Rows[e.RowIndex].Cells[2].Value.ToString());
                ListViewItem.ListViewSubItem subjectName = new ListViewItem.ListViewSubItem(classID, dgvDisplayTH.Rows[e.RowIndex].Cells[3].Value.ToString());
                ListViewItem.ListViewSubItem day = new ListViewItem.ListViewSubItem(classID, dgvDisplayTH.Rows[e.RowIndex].Cells[10].Value.ToString());
                ListViewItem.ListViewSubItem period = new ListViewItem.ListViewSubItem(classID, dgvDisplayTH.Rows[e.RowIndex].Cells[11].Value.ToString());
                classID.SubItems.Add(subjectName);
                classID.SubItems.Add(day);
                classID.SubItems.Add(period);
                lvwSelectedClass.Items.Add(classID);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvwSelectedClass.SelectedItems)
            {
                for (int i = 0; i < rtLT.GetDSL().Count; i++)
                {
                    if (item.SubItems[0].Text == rtLT.GetDSL()[i].getMaLop())
                    {
                        rtLT.GetDSL().RemoveAt(i);
                        i--;
                    }
                }
                for (int i = 0; i < rtTH.GetDSL().Count; i++)
                {
                    if (item.SubItems[0].Text == rtTH.GetDSL()[i].getMaLop())
                    {
                        rtTH.GetDSL().RemoveAt(i);
                        i--;
                    }
                }
                lvwSelectedClass.Items.Remove(item);              
            }
        }

        private void btnTimLop_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            DataGridView runningDataGrid;
            TextBox search;
            if (btn == btnTimLopLT)
            {
                runningDataGrid = this.dgvDisplayLT;
                search = tbxTimLopLT;
            }
            else
            {
                runningDataGrid = this.dgvDisplayTH;
                search = tbxTimLopTH;
            }
            DataGridView parentDataGrid = runningDataGrid;

            if (parentDataGrid.Rows.Count == 0)
            {
                MessageBox.Show("Chưa mở file!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                if (search.Text == "") return;

                foreach (DataGridViewRow row in parentDataGrid.SelectedRows)
                {
                    row.Selected = false;
                }

                int matches = 0;
                for (int row = parentDataGrid.CurrentRow.Index + 1; row <= runningDataGrid.Rows.Count; row++)
                {
                    if (row == runningDataGrid.Rows.Count)  
                    {
                        DialogResult mb = MessageBox.Show("Không tìm thấy kết quả phù hợp! \nCó muốn tìm lại từ đầu?", "Thông báo", MessageBoxButtons.YesNo);
                        if (mb == DialogResult.Yes)
                        {
                            row = 0;
                            parentDataGrid.Rows[0].Cells[0].Selected = true;
                        }
                        else return;
                    }
                    for (int col = 0; col < parentDataGrid.Columns.Count; col++)
                    {
                        if (runningDataGrid.Rows[row].Cells[col].Value.ToString().ToUpper().Contains(search.Text.ToUpper()))
                        {
                            parentDataGrid.Rows[row].Cells[col].Selected = true;
                            matches++;
                            return;
                        }
                    }
                }
            }
        }

        private void cbHeDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDisplayLT.Rows.Clear();
            dgvDisplayTH.Rows.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DataGridViewRow row = new DataGridViewRow();
                if (dr[17].ToString() != "" && dr[17].ToString() == cbHeDT.Text)
                    dgvDisplayLT.Rows.Add(dr.ItemArray);
            }
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                if (dr[17].ToString() != "" && dr[17].ToString() == cbHeDT.Text)
                    dgvDisplayTH.Rows.Add(dr.ItemArray);
            }
        }

       

        private void tbxTimLop_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                if (tb == tbxTimLopLT)
                    sender = (Button)btnTimLopLT;
                else
                    sender = (Button)btnTimLopTH;
                btnTimLop_Click(sender, e);
            }
        }
    }
}
