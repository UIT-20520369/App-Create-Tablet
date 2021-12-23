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
    public partial class FormDungNgay : Form
    {
        private Button curButton;
        private Panel leftBorderBtn;
        private Form curChildForm;

        public FormDungNgay()
        {
            InitializeComponent();

            // ToolTip
            ToolTip.SetToolTip(btnThoat, "Thoát");
            ToolTip.SetToolTip(btnMini, "Minimize");
            ToolTip.SetToolTip(btnTroVe, "Quay về bắt đầu");

            // Animation button
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
        }

        #region Help Button Click

        private void btnThoat_Click(object sender, EventArgs e)
        {
            BatDau.isThoat = true;
            Application.Exit();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Help Button Click

        #region Animation Button Click
        private void ActiveButton(object senderBtn, Color color, string s)
        {
            if (senderBtn != null)
            {
                DisableButton();

                // Button
                curButton = (Button)senderBtn;
                curButton.BackColor = Color.FromArgb(207, 244, 210);
                curButton.ForeColor = color;
                curButton.TextAlign = ContentAlignment.MiddleCenter;
                curButton.TextImageRelation = TextImageRelation.TextBeforeImage;
                curButton.ImageAlign = ContentAlignment.MiddleRight;
                curButton.Text = s;

                // Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, curButton.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (curButton != null)
            {
                curButton.Text = "  " + curButton.Text;
                curButton.BackColor = Color.FromArgb(134, 227, 206);
                curButton.ForeColor = Color.MidnightBlue;
                curButton.TextAlign = ContentAlignment.MiddleLeft;
                curButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                curButton.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm, int i, int j)
        {
            if (curChildForm != null)
            {
                curChildForm.Close();
            }

            curChildForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panelUngDung.Controls.Add(childForm);
            panelUngDung.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            switch (i)
            {
                case 0:
                    labelChildFormText.Text = "Chính quy";
                    break;
                case 1:
                    labelChildFormText.Text = "Chất lượng cao";
                    break;
                case 2:
                    labelChildFormText.Text = "Báo lỗi";
                    break;
            }
            switch (j)
            {
                case 0:
                    childFormLogo.Image = Properties.Resources.calendar;
                    break;
                case 1:
                    childFormLogo.Image = Properties.Resources.lightbulb;
                    break;
                case 2:
                    childFormLogo.Image = Properties.Resources.bug;
                    break;
            }
            
        }

        #endregion Animation Button Click

        private void btnChinhQuy_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(71, 139, 162), "Chính quy");
            OpenChildForm(new FormTaoLich("CQUI", ""), 0, 0);
        }

        private void btnCLC_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(71, 139, 162), "Chất lượng cao");
            OpenChildForm(new FormTaoLich("CLC", ""), 1, 0);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (curChildForm == null)
            {
                return;
            }
            curChildForm.Close();
            curChildForm = null;
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            labelChildFormText.Text = "";
            childFormLogo.Image = null;
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Restart();
        }

        private void btnHintCQUI_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(71, 139, 162), "Chính quy");
            OpenChildForm(new FormGoiY("CQUI", ""), 0, 1);
        }

        private void btnHintCLC_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(71, 139, 162), "Chất lượng cao");
            OpenChildForm(new FormGoiY("CLC", ""), 1, 1);
        }

        private void btnBaoLoi_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(71, 139, 162), "Báo lỗi");
            OpenChildForm(new FormBaoLoi(), 2, 2);
        }
    }
}
