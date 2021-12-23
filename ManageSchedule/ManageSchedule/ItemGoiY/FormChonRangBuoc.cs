using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageSchedule.ItemGoiY
{
    public partial class FormChonRangBuoc : Form
    {
        public FormChonRangBuoc()
        {
            InitializeComponent();

            Setting();
            Setup();
        }

        #region Set up

        private void Setup()
        {
            if (FormGoiY.isConstraint == true)
            {
                RadioButtonConstaint.Checked = true;
                PanelConstraint.Visible = true;

                #region Set combobox

                // Sáng
                if (FormGoiY.DanhSachRangBuoc[1, 2])
                    ComboBoxThu2Sang.SelectedIndex = 1;
                else
                    ComboBoxThu2Sang.SelectedIndex = 0;
                if (FormGoiY.DanhSachRangBuoc[1, 3])
                    ComboBoxThu3Sang.SelectedIndex = 1;
                else
                    ComboBoxThu3Sang.SelectedIndex = 0;
                if (FormGoiY.DanhSachRangBuoc[1, 4])
                    ComboBoxThu4Sang.SelectedIndex = 1;
                else
                    ComboBoxThu4Sang.SelectedIndex = 0;
                if (FormGoiY.DanhSachRangBuoc[1, 5])
                    ComboBoxThu5Sang.SelectedIndex = 1;
                else
                    ComboBoxThu5Sang.SelectedIndex = 0;
                if (FormGoiY.DanhSachRangBuoc[1, 6])
                    ComboBoxThu6Sang.SelectedIndex = 1;
                else
                    ComboBoxThu6Sang.SelectedIndex = 0;
                if (FormGoiY.DanhSachRangBuoc[1, 7])
                    ComboBoxThu7Sang.SelectedIndex = 1;
                else
                    ComboBoxThu7Sang.SelectedIndex = 0;

                // Chiều
                if (FormGoiY.DanhSachRangBuoc[2, 2])
                    ComboBoxThu2Chieu.SelectedIndex = 1;
                else
                    ComboBoxThu2Chieu.SelectedIndex = 0;
                if (FormGoiY.DanhSachRangBuoc[2, 3])
                    ComboBoxThu3Chieu.SelectedIndex = 1;
                else
                    ComboBoxThu3Chieu.SelectedIndex = 0;
                if (FormGoiY.DanhSachRangBuoc[2, 4])
                    ComboBoxThu4Chieu.SelectedIndex = 1;
                else
                    ComboBoxThu4Chieu.SelectedIndex = 0;
                if (FormGoiY.DanhSachRangBuoc[2, 5])
                    ComboBoxThu5Chieu.SelectedIndex = 1;
                else
                    ComboBoxThu5Chieu.SelectedIndex = 0;
                if (FormGoiY.DanhSachRangBuoc[2, 6])
                    ComboBoxThu6Chieu.SelectedIndex = 1;
                else
                    ComboBoxThu6Chieu.SelectedIndex = 0;
                if (FormGoiY.DanhSachRangBuoc[2, 7])
                    ComboBoxThu7Chieu.SelectedIndex = 1;
                else
                    ComboBoxThu7Chieu.SelectedIndex = 0;

                #endregion Set combobox
            }
            else
            {
                RadioButtonNone.Checked = true;
                PanelTKB.Visible = false;
            }
        }

        #endregion Set up

        #region Setting

        private void Setting()
        {
            string[] constraint = new string[] { "Tự động", "Trống tiết" };

            #region ComboBox

            ComboBoxThu2Sang.Items.AddRange(constraint);
            ComboBoxThu2Sang.SelectedIndex = 0;
            ComboBoxThu3Sang.Items.AddRange(constraint);
            ComboBoxThu3Sang.SelectedIndex = 0;
            ComboBoxThu4Sang.Items.AddRange(constraint);
            ComboBoxThu4Sang.SelectedIndex = 0;
            ComboBoxThu5Sang.Items.AddRange(constraint);
            ComboBoxThu5Sang.SelectedIndex = 0;
            ComboBoxThu6Sang.Items.AddRange(constraint);
            ComboBoxThu6Sang.SelectedIndex = 0;
            ComboBoxThu7Sang.Items.AddRange(constraint);
            ComboBoxThu7Sang.SelectedIndex = 0;
            ComboBoxThu2Chieu.Items.AddRange(constraint);
            ComboBoxThu2Chieu.SelectedIndex = 0;
            ComboBoxThu3Chieu.Items.AddRange(constraint);
            ComboBoxThu3Chieu.SelectedIndex = 0;
            ComboBoxThu4Chieu.Items.AddRange(constraint);
            ComboBoxThu4Chieu.SelectedIndex = 0;
            ComboBoxThu5Chieu.Items.AddRange(constraint);
            ComboBoxThu5Chieu.SelectedIndex = 0;
            ComboBoxThu6Chieu.Items.AddRange(constraint);
            ComboBoxThu6Chieu.SelectedIndex = 0;
            ComboBoxThu7Chieu.Items.AddRange(constraint);
            ComboBoxThu7Chieu.SelectedIndex = 0;

            #endregion ComboBox
        }

        #endregion Setting

        #region Checked

        private void RadioButtonNone_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonNone.Checked == true)
            {
                PanelTKB.Visible = false;
                FormGoiY.isConstraint = false;
            }
        }

        private void RadioButtonConstaint_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonConstaint.Checked == true)
            {
                PanelTKB.Visible = true;
            }
        }

        #endregion Checked

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (RadioButtonConstaint.Checked == true)
                FormGoiY.isConstraint = true;
            else
                FormGoiY.isConstraint = false;

            #region Check

            // Sáng
            if (ComboBoxThu2Sang.Text == "Trống tiết")
                FormGoiY.DanhSachRangBuoc[1, 2] = true;
            else
                FormGoiY.DanhSachRangBuoc[1, 2] = false;
            if (ComboBoxThu3Sang.Text == "Trống tiết")
                FormGoiY.DanhSachRangBuoc[1, 3] = true;
            else
                FormGoiY.DanhSachRangBuoc[1, 3] = false;
            if (ComboBoxThu4Sang.Text == "Trống tiết")
                FormGoiY.DanhSachRangBuoc[1, 4] = true;
            else
                FormGoiY.DanhSachRangBuoc[1, 4] = false;
            if (ComboBoxThu5Sang.Text == "Trống tiết")
                FormGoiY.DanhSachRangBuoc[1, 5] = true;
            else
                FormGoiY.DanhSachRangBuoc[1, 5] = false;
            if (ComboBoxThu6Sang.Text == "Trống tiết")
                FormGoiY.DanhSachRangBuoc[1, 6] = true;
            else
                FormGoiY.DanhSachRangBuoc[1, 6] = false;
            if (ComboBoxThu7Sang.Text == "Trống tiết")
                FormGoiY.DanhSachRangBuoc[1, 7] = true;
            else
                FormGoiY.DanhSachRangBuoc[1, 7] = false;

            // Chiều
            if (ComboBoxThu2Chieu.Text == "Trống tiết")
                FormGoiY.DanhSachRangBuoc[2, 2] = true;
            else
                FormGoiY.DanhSachRangBuoc[2, 2] = false;
            if (ComboBoxThu3Chieu.Text == "Trống tiết")
                FormGoiY.DanhSachRangBuoc[2, 3] = true;
            else
                FormGoiY.DanhSachRangBuoc[2, 3] = false;
            if (ComboBoxThu4Chieu.Text == "Trống tiết")
                FormGoiY.DanhSachRangBuoc[2, 4] = true;
            else
                FormGoiY.DanhSachRangBuoc[2, 4] = false;
            if (ComboBoxThu5Chieu.Text == "Trống tiết")
                FormGoiY.DanhSachRangBuoc[2, 5] = true;
            else
                FormGoiY.DanhSachRangBuoc[2, 5] = false;
            if (ComboBoxThu6Chieu.Text == "Trống tiết")
                FormGoiY.DanhSachRangBuoc[2, 6] = true;
            else
                FormGoiY.DanhSachRangBuoc[2, 6] = false;
            if (ComboBoxThu7Chieu.Text == "Trống tiết")
                FormGoiY.DanhSachRangBuoc[2, 7] = true;
            else
                FormGoiY.DanhSachRangBuoc[2, 7] = false;

            #endregion Check

            MessageBox.Show("Xác nhận thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnConfirm.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
        }
    }
}
