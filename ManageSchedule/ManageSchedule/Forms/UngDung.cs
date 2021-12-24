using ManageSchedule.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            this.FormClosing += new FormClosingEventHandler(FormUngDung_Closing);

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
                    childFormLogo.Image = Properties.Resources.lightbulb;
                    break;
            }
        }

        #endregion AnimationOfFeatureButton

        #region FeatureButtonClick

        private void btnBangTin_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(71, 139, 162), "Lịch học");
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
            OpenChildForm(new FormCongViec(), 3);
        }

        private void btnBaoloi_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(71, 139, 162), "Báo lỗi");
            OpenChildForm(new FormBaoLoi(), 4);
        }

        private void btnGoiY_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(71, 139, 162), "Gợi ý lịch học");
            OpenChildForm(new FormGoiY(hedaotao, curUser), 5);
        }

        #endregion FeatureButtonClick

        #region Dang Xuat

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            CaiDat.SetPreLogin(string.Empty, string.Empty);
            CaiDat.FirstOpen = false;
            CaiDat.WriteToTxt(HangSo.txtFilePath);

            this.Close();
            Application.Restart();
        }

        #endregion Dang Xuat

        #region Thoat
        private void btnThoat_Click(object sender, EventArgs e)
        {
            BatDau.isThoat = true;
            CaiDat.FirstOpen = false;
            CaiDat.WriteToTxt(HangSo.txtFilePath);
            //this.Hide();
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            //Application.Exit();
        }

        private void FormUngDung_Closing(object sender, FormClosingEventArgs e)
        {
            //var dr = MessageBox.Show("Close it?", "Notice", MessageBoxButtons.YesNoCancel);
            //if (dr == DialogResult.No)
            //    e.Cancel = true;
            //else
            //    e.Cancel = false;
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            else if (e.CloseReason == CloseReason.TaskManagerClosing || e.CloseReason == CloseReason.WindowsShutDown)
            {
                //if (CaiDat.Startup)
                //    CaiDat.FirstOpen = true;
                //else
                //    CaiDat.FirstOpen = false;
                e.Cancel = false;
            }
            else if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
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
            LoadChartEvent();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #region Context Menu Strip

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            //Visible = true;
            ShowInTaskbar = true;
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn sẽ không tiếp tục nhận thông báo trong hôm nay\nBạn chắc chắn muốn kết thúc?", "Thông báo", MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Yes)
            {
                BatDau.isThoat = true;
                CaiDat.FirstOpen = true;
                CaiDat.WriteToTxt(HangSo.txtFilePath);
                Application.Exit();
            }
        }

        private void tsmiPlan_Click(object sender, EventArgs e)
        {
            new ManageSchedule.Forms.FormThongBao();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tsmiOpen_Click(this, new EventArgs());
        }

        #endregion Context Menu Strip

        #region Show info
        private void FormUngDung_Load(object sender, EventArgs e)
        {
            new TaiKhoan();

            labelFullNameAva.Text = TaiKhoan.FullName;
            labelSUsername.Text = CaiDat.PreUsername;

            labelFullName.Text = TaiKhoan.FullName;
            labelYear.Text = TaiKhoan.Year;
            labelEmail.Text = TaiKhoan.Email;
            labelSpec.Text = TaiKhoan.Spec;
            labelSys.Text = TaiKhoan.Sys;

            if (TaiKhoan.Avatar != string.Empty)
            {
                Image i = ByteToImg(TaiKhoan.Avatar);
                ResizeImage(i, new Size(PictureBoxAvatar.Width, PictureBoxAvatar.Height));
                PictureBoxAvatar.Image = i;
            }

            LoadChartEvent();

            CheckBoxStartUp.Checked = CaiDat.Startup;
            CheckBoxEvent.Checked = CaiDat.EventNotify;

            if (CaiDat.FirstOpen)
            {
                btnThoat_Click(this, new EventArgs());
                CaiDat.FirstOpen = false;
            }

            if (CaiDat.EventNotify)
            {
                new ManageSchedule.Forms.FormThongBao();
                timer.Interval = 60 * 1000;
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormChinhSuaThongTin EditAccount = new FormChinhSuaThongTin();
            EditAccount.ShowDialog();

            labelFullNameAva.Text = TaiKhoan.FullName;
            labelSUsername.Text = CaiDat.PreUsername;

            labelFullName.Text = TaiKhoan.FullName;
            labelYear.Text = TaiKhoan.Year;
            labelEmail.Text = TaiKhoan.Email;
            labelSpec.Text = TaiKhoan.Spec;
            labelSys.Text = TaiKhoan.Sys;

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
            try
            {
                bool isStartUp = CheckBoxStartUp.Checked;
                CaiDat.SetStartup(ref isStartUp);
                if (isStartUp != CheckBoxStartUp.Checked)
                    CheckBoxStartUp.Checked = isStartUp;

                CaiDat.EventNotify = CheckBoxEvent.Checked;

                MessageBox.Show("Thay đổi cài đặt thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            catch
            {
                CheckBoxStartUp.Checked = CaiDat.Startup;
                CheckBoxEvent.Checked = CaiDat.EventNotify;
                MessageBox.Show("Thay đổi cài đặt không thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void LoadChartEvent()
        {
            foreach (var series in chartWeekEvent.Series)
            {
                series.Points.Clear();
            }

            for (int i = 0; i < 7; i++)
            {
                DateTime day = DateTime.Now.AddDays(i);
                OneDay listSK = new OneDay(true, day);
                chartWeekEvent.Series["Event"].Points.AddXY(day.ToString("dd/MM"), listSK.ListOfDay.Count);
            }
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

        #region Avatar

        private void PictureBoxAvatar_Click(object sender, EventArgs e)
        {
            string fileName = UploadPicture();

            if (fileName != string.Empty)
            {
                bool isChange = TaiKhoan.ChangeAvatar(Convert.ToBase64String(converImgToByte(fileName)));

                if (isChange)
                {
                    MessageBox.Show("Thay đổi ảnh đại diện thành công!", "Thông báo", MessageBoxButtons.OK);

                    Image i = ByteToImg(TaiKhoan.Avatar);
                    i = ResizeImage(i, new Size(PictureBoxAvatar.Width, PictureBoxAvatar.Height));
                    PictureBoxAvatar.Image = i;
                }
                else
                {
                    MessageBox.Show("Thay đổi ảnh đại diện không thành công!", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private string UploadPicture()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.png)|*.jpg; *.jpeg; *.jpe; *.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                return openFile.FileName;
            }
            else
            {
                return string.Empty;
            }
        }

        private byte[] converImgToByte(string fileName)
        {
            FileStream fs;
            fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }

        private Image ByteToImg(string byteString)
        {
            byte[] imgBytes = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        public static Image ResizeImage(Image imgToResize, Size destinationSize)
        {
            var originalWidth = imgToResize.Width;
            var originalHeight = imgToResize.Height;

            var hRatio = (float)originalHeight / destinationSize.Height;
            var wRatio = (float)originalWidth / destinationSize.Width;

            var ratio = Math.Min(hRatio, wRatio);

            var hScale = Convert.ToInt32(destinationSize.Height * ratio);
            var wScale = Convert.ToInt32(destinationSize.Width * ratio);

            var startX = (originalWidth - wScale) / 2;
            var startY = (originalHeight - hScale) / 2;

            var sourceRectangle = new Rectangle(startX, startY, wScale, hScale);

            var bitmap = new Bitmap(destinationSize.Width, destinationSize.Height);

            var destinationRectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            using (var g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(imgToResize, destinationRectangle, sourceRectangle, GraphicsUnit.Pixel);
            }

            return bitmap;

        }

        #endregion Avatar

        #region Timer To Notice

        private void timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Second != 0)
            {
                timer.Interval = (60 - DateTime.Now.Second) * 1000;
            }
            else
            {
                timer.Interval = 60 * 1000;
            }

            OneDay listSK = new OneDay(DateTime.Now, true);
            List<OneEvent> eventNow = new List<OneEvent>();
            eventNow.Clear();

            foreach (OneEvent ev in listSK.ListOfDay)
            {
                foreach (ItemThongBao item in ev.ListTB)
                {
                    if (item.ThoiGian.Hour == DateTime.Now.Hour && item.ThoiGian.Minute == DateTime.Now.Minute)
                    {
                        eventNow.Add(ev);
                        break;
                    }
                }
            }

            if (eventNow.Count == 0)
                return;

            //new System.Threading.Thread(() =>
            //{
            //    foreach (OneEvent ev in eventNow)
            //    {
            //        string detail;
            //        if (ev.ToiNgay == new DateTime())
            //            detail = ev.Ngay.ToString("dd-MM-yyyy HH:mm") + "\n" + ev.MoTa;
            //        else
            //            detail = ev.Ngay.ToString("dd-MM-yyyy HH:mm") + " - "
            //                + ev.ToiNgay.ToString("dd-MM-yyyy HH:mm") + "\n" + ev.MoTa;
            //        NotifyIcon ni = new NotifyIcon();
            //        ni.ShowBalloonTip(5000, ev.TieuDe, detail, ToolTipIcon.Info);
            //        System.Threading.Thread.Sleep(5000);
            //    }
            //}).Start();

            foreach (OneEvent ev in eventNow)
            {
                string detail;
                if (ev.ToiNgay == new DateTime())
                    detail = ev.Ngay.ToString("dd-MM-yyyy HH:mm") + "\n" + ev.MoTa;
                else
                    detail = ev.Ngay.ToString("dd-MM-yyyy HH:mm") + " - " + ev.ToiNgay.ToString("dd-MM-yyyy HH:mm")
                        + "\n" + ev.MoTa;
                notifyIcon.ShowBalloonTip(3000, ev.TieuDe, detail, ToolTipIcon.Info);
            }
        }

        #endregion Timer To Notice
    }
}
