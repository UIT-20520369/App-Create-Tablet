using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;

namespace ManageSchedule
{
    public partial class FormGoiY : Form
    {
        #region Declare

        private List<BunifuShapes> listShape = new List<BunifuShapes>();
        private BunifuShapes curShape;
        private Form curForm;
        private int pos = 1;
        private string HeDaoTao;
        private string curUser = string.Empty;

        internal static List<DataRow> DanhSachMaMonDaChon = new List<DataRow>();
        internal static List<DataRow> DanhSachMaLopDaChon = new List<DataRow>();
        internal static bool isConstraint = false;
        internal static bool[,] DanhSachRangBuoc = new bool[3, 8];

        #endregion Declare

        public FormGoiY(string hdt, string x)
        {
            InitializeComponent();

            HeDaoTao = hdt;
            curUser = x;

            listShape.AddRange(new BunifuShapes[] { CircleMaMon, CircleMaLop, CircleRangBuoc, CircleKetQua });

            curShape = listShape[0];
            curShape.FillColor = Color.Pink;

            btnPrevious.Enabled = false;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 8; j++)
                    DanhSachRangBuoc[i, j] = false;

            OpenChildForm(new ItemGoiY.FormChonMaMon(HeDaoTao));
        }

        #region Next Click

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (btnPrevious.Enabled == false)
            {
                btnPrevious.Enabled = true;
                btnPrevious.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
            }

            pos++;
            if (pos > 4)
                pos = 1;

            switch (pos)
            {
                case 1:
                    OpenChildForm(new ItemGoiY.FormChonMaMon(HeDaoTao));
                    break;
                case 2:
                    OpenChildForm(new ItemGoiY.FormChonMaLop(HeDaoTao));
                    break;
                case 3:
                    OpenChildForm(new ItemGoiY.FormChonRangBuoc());
                    break;
                case 4:
                    OpenChildForm(new ItemGoiY.FormKetQua(HeDaoTao, curUser));
                    break;
            }

            curShape.FillColor = Color.Transparent;
            for (int i = 0; i < listShape.Count; i++)
            {
                if (curShape == listShape[i])
                {
                    listShape[i + 1].FillColor = Color.Pink;
                    curShape = listShape[i + 1];
                    if (curShape == listShape[listShape.Count - 1])
                    {
                        btnNext.Enabled = false;
                        return;
                    }
                    return;
                }
            }
            btnNext.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
        }

        #endregion Next Click

        #region Previous Click

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (btnNext.Enabled == false)
            {
                btnNext.Enabled = true;
                btnNext.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
            }

            pos--;
            if (pos == 0)
                pos = 4;
            switch (pos)
            {
                case 1:
                    OpenChildForm(new ItemGoiY.FormChonMaMon(HeDaoTao));
                    break;
                case 2:
                    OpenChildForm(new ItemGoiY.FormChonMaLop(HeDaoTao));
                    break;
                case 3:
                    OpenChildForm(new ItemGoiY.FormChonRangBuoc());
                    break;
                case 4:
                    OpenChildForm(new ItemGoiY.FormKetQua(HeDaoTao, curUser));
                    break;
            }

            curShape.FillColor = Color.Transparent;
            for (int i = 0; i < listShape.Count; i++)
            {
                if (curShape == listShape[i])
                {
                    listShape[i - 1].FillColor = Color.Pink;
                    curShape = listShape[i - 1];
                    if (curShape == listShape[0])
                    {
                        btnPrevious.Enabled = false;
                        return;
                    }
                    return;
                }
            }

            btnPrevious.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
        }

        #endregion Previous Click

        private void OpenChildForm(Form childForm)
        {
            if (curForm != null)
                curForm.Close();

            curForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
