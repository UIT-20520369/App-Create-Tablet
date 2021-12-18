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
        #region Declare

        private Button curButton;
        private Panel leftBorderBtn;
        private Form curChildForm;

        private string hedaotao = string.Empty;
        private string curUser = string.Empty;

        #endregion Declare

        #region Constructor

        public FormUngDung(string hdt, string us)
        {
            InitializeComponent();

            curUser = us;
            toolTipThoat.SetToolTip(btnThoat, "Thoát");
            toolTipMini.SetToolTip(btnMini, "Minimize");
            hedaotao = hdt;
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            CheckBoxStartUp.Checked = false;
            CheckBoxDeadline.Checked = false;
            CheckBoxEvent.Checked = false;
            CheckBoxOther.Checked = false;
            SetupDay();
        }

        #endregion Constructor

        #region AnimationOfFeatureButton

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
                case 5:
                    childFormLogo.Image = Properties.Resources.cog;
                    break;
            }
        }

        #endregion AnimationOfFeatureButton

        #region FeatureButtonClick

        private void btnBangTin_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(71, 139, 162), "Bảng tin");
            OpenChildForm(new FormBangTin(curUser), 0);
        }

        private void btnTaoLich_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(71, 139, 162), "Tạo lịch học");
            OpenChildForm(new FormTaoLich(hedaotao, curUser), 1);
        }

        private void btnXemLich_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(71, 139, 162), "Xem lịch học");
            OpenChildForm(new FormXemLich(curUser), 2);
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

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(71, 139, 162), "Cài đặt");
            OpenChildForm(new FormBaoLoi(), 5);
        }

        #endregion FeatureButtonClick

        #region Dang Xuat

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            CaiDat.SetPreLogin(string.Empty, string.Empty);
            CaiDat.WriteToTxt(HangSo.txtFilePath);
            this.Close();
            Application.Restart();
        }

        #endregion Dang Xuat

        #region Thoat
        private void btnThoat_Click(object sender, EventArgs e)
        {
            BatDau.isThoat = true;
            CaiDat.WriteToTxt(HangSo.txtFilePath);
            Visible = false;
            ShowInTaskbar = false;
            //Application.Exit();
        }

        #endregion Thoat

        #region Home

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

        #endregion Home

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

        #region Setting Event

        private void CheckBoxStartUp_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
        }

        private void CheckBoxNotice_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
        }

        #endregion Setting Event

        #region Time Event

        private void NumStartHour_ValueChanged(object sender, EventArgs e)
        {
            if (NumStartHour.Value == 24)
                NumStartHour.Value = 0;
            if (NumStartHour.Value == -1)
                NumStartHour.Value = 23;
        }

        private void NumStartMin_ValueChanged(object sender, EventArgs e)
        {
            if (NumStartMin.Value == 60)
                NumStartMin.Value = 0;
            if (NumStartMin.Value == -1)
                NumStartMin.Value = 59;
        }

        #endregion Time Event

        #region Context Menu Strip

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
                BatDau.isThoat = true;
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

        #endregion Context Menu Strip

        #region Show info
        private void FormUngDung_Load(object sender, EventArgs e)
        {
            new TaiKhoan();

            labelFullNameAva.Text = TaiKhoan.GetFullName();
            labelSUsername.Text = CaiDat.GetPreUsername();

            labelFullName.Text = TaiKhoan.GetFullName();
            labelYear.Text = TaiKhoan.GetYear();
            labelEmail.Text = TaiKhoan.GetEmail();
            labelSpec.Text = TaiKhoan.GetSpec();
            labelSys.Text = TaiKhoan.GetSys();
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormChinhSuaThongTIn EditAccount = new FormChinhSuaThongTIn();
            EditAccount.ShowDialog();
            FormUngDung_Load(this, new EventArgs());
            this.Show();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDoiMatKhau ChangePass = new FormDoiMatKhau();
            ChangePass.ShowDialog();
            this.Show();
        }

        private void btnChangeSetting_Click(object sender, EventArgs e)
        {
            bool isStartUp = CheckBoxStartUp.Checked;
            CaiDat.SetStartup(ref isStartUp);
            if (isStartUp != CheckBoxStartUp.Checked)
                CheckBoxStartUp.Checked = isStartUp;

            CaiDat.SetNotify(CheckBoxDeadline.Checked, CheckBoxEvent.Checked, CheckBoxOther.Checked);

            CaiDat.SetNoticeTime(int.Parse(NumDuringTime.Value.ToString()), int.Parse(NumStartHour.Value.ToString()), int.Parse(NumStartMin.Value.ToString()));
        }

        #endregion Show info

        #region SetupDay

        private void SetupDay()
        {
            DateTime datetime = DateTime.Now;
            switch (datetime.DayOfWeek.ToString())
            {
                case "Monday":
                    labelDay.Text = "Thứ hai, ";
                    break;
                case "Tuesday":
                    labelDay.Text = "Thứ ba, ";
                    break;
                case "Wednesday":
                    labelDay.Text = "Thứ tư, ";
                    break;
                case "Thursday":
                    labelDay.Text = "Thứ năm, ";
                    break;
                case "Friday":
                    labelDay.Text = "Thứ sáu, ";
                    break;
                case "Saturday":
                    labelDay.Text = "Thứ bảy, ";
                    break;
                case "Sunday":
                    labelDay.Text = "Chủ nhật, ";
                    break;
            }

            labelDay.Text += "ngày " + datetime.Day + " tháng " + datetime.Month + " năm " + datetime.Year;
        }

        #endregion SetupDay

    }
}
