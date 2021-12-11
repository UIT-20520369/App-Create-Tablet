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
    public partial class FormUngDung : Form
    {
        private Button curButton;
        private Panel leftBorderBtn;
        private Form curChildForm;

        private string hedaotao = string.Empty;

        //private int DayOfColumn = 6;
        //private int DayOfWeek = 7;
        //private List<List<Button>> matrix;
        //private List<string> dateOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        public FormUngDung(string hdt)
        {
            InitializeComponent();
            toolTipThoat.SetToolTip(btnThoat, "Thoát");
            toolTipMini.SetToolTip(btnMini, "Minimize");
            hedaotao = hdt;
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            //panelButton.Visible = false;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //LoadMatrix();

            cbxStartup.Checked = false;
            cbxDeadline.Checked = false;
            cbxEvent.Checked = false;
            cbxOther.Checked = false;
            cbxDarkMode.Checked = false;
        }

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

                // Icon current child form

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

        private void OpenChildForm(Form childForm, int i)
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
            labelChildFormText.Text = childForm.Text;
            switch (i)
            {
                case 0:
                    childFormLogo.Image = Properties.Resources.desktop;
                    break;
                case 1:
                    childFormLogo.Image = Properties.Resources.calendar;
                    break;
                case 2:
                    childFormLogo.Image = Properties.Resources.calendar_check;
                    break;
                case 3:
                    childFormLogo.Image = Properties.Resources.clipboard;
                    break;
                case 4:
                    childFormLogo.Image = Properties.Resources.bug;
                    break;
            }
        }

        private void btnBangTin_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(71, 139, 162), "Bảng tin");
            OpenChildForm(new FormBangTin(), 0);
        }

        private void btnTaoLich_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(71, 139, 162), "Tạo lịch học");
            OpenChildForm(new FormTaoLich(hedaotao), 1);
        }

        private void btnXemLich_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(71, 139, 162), "Xem lịch học");
            OpenChildForm(new FormXemLich(), 2);
        }

        private void btnDeadline_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(71, 139, 162), "Công việc");
            OpenChildForm(new FormCongViec(panelUngDung), 3);
        }

        private void btnBaoloi_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(71, 139, 162), "Báo lỗi");
            OpenChildForm(new FormBaoLoi(), 4);
        }
        
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            CaiDat.SetPreLogin(string.Empty, string.Empty);
            CaiDat.WriteToTxt(HangSo.txtFilePath);
            this.Close();
            Application.Restart();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            BatDau.isThoat = true;
            CaiDat.WriteToTxt(HangSo.txtFilePath);
            Visible = false;
            ShowInTaskbar = false;
            //Application.Exit();
        }

        //private void LoadMatrix()
        //{
        //    matrix = new List<List<Button>>();

        //    Button oldButton = new Button { Width = 0, Height = 0, Location = new Point(-6, 0) };
        //    for (int i = 0; i < DayOfColumn; i++)
        //    {
        //        matrix.Add(new List<Button>());
        //        for (int j = 0; j < DayOfWeek; j++)
        //        {
        //            Button btn = new Button() { Width = 75, Height = 40 };
        //            btn.Location = new Point(oldButton.Location.X + oldButton.Width + 6, oldButton.Location.Y);

        //            panelMatrix.Controls.Add(btn);
        //            matrix[i].Add(btn);

        //            oldButton = btn;
        //        }
        //        oldButton = new Button() { Width = 0, Height = 0, Location = new Point(-6, oldButton.Location.Y + oldButton.Height) };
        //    }

        //    SetDefaultDate();
        //}

        //private void ClearMatrix()
        //{
        //    for (int i = 0; i < matrix.Count; i++)
        //        for (int j = 0; j < matrix.Count; j++)
        //        {
        //            Button btn = matrix[i][j];
        //            btn.Text = "";
        //            btn.BackColor = Color.WhiteSmoke;
        //        }
        //}

        //private void SetDefaultDate()
        //{
        //    dateTimePickerGetDate.Value = DateTime.Now;
        //}

        //private int DayOfMonth(DateTime date)
        //{
        //    switch (date.Month)
        //    {
        //        case 1:
        //        case 3:
        //        case 5:
        //        case 7:
        //        case 8:
        //        case 10:
        //        case 12:
        //            return 31;
        //        case 2:
        //            if (DateTime.IsLeapYear(date.Year))
        //                return 29;
        //            else
        //                return 28;
        //        default:
        //            return 30; ;
        //    }
        //}

        //private bool isEqualDate(DateTime dateA, DateTime dateB)
        //{
        //    return dateA.Year == dateB.Year && dateA.Month == dateB.Month && dateA.Day == dateB.Day;
        //}

        //private void AddNumberIntoMatrixByDate(DateTime date)
        //{
        //    ClearMatrix();
        //    DateTime useDate = new DateTime(date.Year, date.Month, 1);

        //    int line = 0;

        //    for (int i = 0; i < DayOfMonth(date); i++)
        //    {
        //        int column = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());
        //        Button btn = matrix[line][column];
        //        btn.Text = i.ToString();

        //        if (isEqualDate(useDate, DateTime.Now))
        //        {
        //            btn.BackColor = Color.Yellow;
        //        }

        //        if (isEqualDate(useDate, date))
        //        {
        //            btn.BackColor = Color.Aqua;
        //        }

        //        if (column >= 6)
        //            line++;

        //        useDate = useDate.AddDays(1);
        //    }
        //}

        //private void dateTimePickerGetDate_ValueChanged(object sender, EventArgs e)
        //{
        //    AddNumberIntoMatrixByDate((sender as DateTimePicker).Value);
        //}

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

        private void btnMini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //
        // setting event
        //

        private void cbxStartup_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {            
        }

        private void cbxNotice_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
        }

        private void cbxDarkMode_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
        }

        //
        // time event
        //

        private void tbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void numStartHour_ValueChanged(object sender, EventArgs e)
        {
            if (numStartHour.Value == 24)
                numStartHour.Value = 0;
            if (numStartHour.Value == -1)
                numStartHour.Value = 23;
        }


        private void numStartMin_ValueChanged(object sender, EventArgs e)
        {
            if (numStartMin.Value == 60)
                numStartMin.Value = 0;
            if (numStartMin.Value == -1)
                numStartMin.Value = 59;
        }

        //
        // context menu strip
        //

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            Visible = true;
            ShowInTaskbar = true;
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn sẽ không tiếp tục nhận thông báo trong hôm nay\nBạn chắc chắn muốn kết thúc?", "Thông báo", MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Yes) 
            {
                CaiDat.WriteToTxt(HangSo.txtFilePath);
                Application.Exit();
            }           
        }

        private void tsmiError_Click(object sender, EventArgs e)
        {
            Visible = true;
            ShowInTaskbar = true;
            btnBaoloi_Click(this, new EventArgs());
        }

        private void tsmiPlan_Click(object sender, EventArgs e)
        {

        }

        // Hiển thị thông tin tài khoản
        private void FormUngDung_Load(object sender, EventArgs e)
        {
            new TaiKhoan();

            lblSName.Text = TaiKhoan.GetFullName();
            lblSUsername.Text = CaiDat.GetPreUsername();

            labelFullName.Text = TaiKhoan.GetFullName();
            labelYear.Text = TaiKhoan.GetYear();
            labelEmail.Text = TaiKhoan.GetEmail();
            labelSpec.Text = TaiKhoan.GetSpec();
            labelSys.Text = TaiKhoan.GetSys();
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChildFormChinhSuaThongTin editAcc = new ChildFormChinhSuaThongTin();
            editAcc.ShowDialog();
            FormUngDung_Load(this, new EventArgs());
            this.Show();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChildFormDoiMatKhau changePass = new ChildFormDoiMatKhau();
            changePass.ShowDialog();
            this.Show();
        }

        private void btnChangeSetting_Click(object sender, EventArgs e)
        {
            CaiDat.SetDarkMode(cbxDarkMode.Checked);

            bool isStartup = cbxStartup.Checked;
            CaiDat.SetStartup(ref isStartup);
            if (isStartup != cbxStartup.Checked)
                cbxStartup.Checked = isStartup;

            CaiDat.SetNotify(cbxDeadline.Checked, cbxEvent.Checked, cbxOther.Checked);

            CaiDat.SetNoticeTime(int.Parse(numDuringTime.Value.ToString()), int.Parse(numStartHour.Value.ToString()), int.Parse(numStartMin.Value.ToString()));
        }
    }
}
