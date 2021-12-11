using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageSchedule
{
    public partial class FormCongViec : Form
    {
        Panel contentPanel;
        public FormCongViec(Panel panel)
        {
            InitializeComponent();
            contentPanel = panel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChildFormCongViec childForm = new ChildFormCongViec();
            childForm.ShowDialog();
            this.Show();
        }
    }
}
