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

namespace DemoUI
{
    public partial class FormTaoTKB : Form
    {
        DataSet ds;
        public FormTaoTKB()
        {
            InitializeComponent();
        }

        private void btnImport_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Workbook|*xlsx|Excel Workbook 97-2003|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
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

                    //reader.IsFirstRowAsColumnNames = true;
                    ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    cbSheet.Items.Clear();
                    foreach (DataTable dt in ds.Tables)
                    {
                        cbSheet.Items.Add(dt.TableName);
                    }

                    reader.Close();
                }
            }
        }

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDisplay.DataSource = ds.Tables[cbSheet.SelectedIndex];
        }
    }
}
