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
        private Button curButton;
        private Panel leftBorderBtn;
        private Form curChildForm;

        private string hedaotao = string.Empty;
        public FormUngDung(string hdt)
        {
            InitializeComponent();
            toolTipThoat.SetToolTip(btnThoat, "Thoát");
            toolTipMini.SetToolTip(btnMini, "Minimize");
            hedaotao = hdt;
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            this.FormClosing += new FormClosingEventHandler(FormUngDung_Closing);
            
            SetupDay();
        }

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

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.FromArgb(71, 139, 162), "Cài đặt");
            OpenChildForm(new FormBaoLoi(), 5);
        }

        #endregion FeatureButtonClick

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            CaiDat.SetPreLogin(string.Empty, string.Empty);
            CaiDat.SetFirstOpen(false);
            CaiDat.WriteToTxt(HangSo.txtFilePath);

            this.Close();
            Application.Restart();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            BatDau.isThoat = true;
            CaiDat.SetFirstOpen(false);
            CaiDat.WriteToTxt(HangSo.txtFilePath);
            //this.Hide();
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
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
                e.Cancel = false;
                CaiDat.SetFirstOpen(true);
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

        //protected override void DestroyHandle()
        //{
        //    System.Diagnostics.Debugger.Break();
        //    base.DestroyHandle();
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

        //#region Time Event

        //private void NumStartHour_ValueChanged(object sender, EventArgs e)
        //{
        //    if (NumStartHour.Value == 24)
        //        NumStartHour.Value = 0;
        //    if (NumStartHour.Value == -1)
        //        NumStartHour.Value = 23;
        //}

        //private void NumStartMin_ValueChanged(object sender, EventArgs e)
        //{
        //    if (NumStartMin.Value == 60)
        //        NumStartMin.Value = 0;
        //    if (NumStartMin.Value == -1)
        //        NumStartMin.Value = 59;
        //}

        //#endregion Time Event

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
                CaiDat.SetFirstOpen(true);
                CaiDat.WriteToTxt(HangSo.txtFilePath);
                Application.Exit();
            }
        }

        //private void tsmiError_Click(object sender, EventArgs e)
        //{
        //    this.Show();
        //    WindowState = FormWindowState.Normal;
        //    //Visible = true;
        //    ShowInTaskbar = true;
        //    btnBaoloi_Click(this, new EventArgs());
        //}

        private void tsmiPlan_Click(object sender, EventArgs e)
        {
            new FormThongBaoTrongNgay();
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

            labelFullNameAva.Text = TaiKhoan.GetFullName();
            labelSUsername.Text = CaiDat.GetPreUsername();

            labelFullName.Text = TaiKhoan.GetFullName();
            labelYear.Text = TaiKhoan.GetYear();
            labelEmail.Text = TaiKhoan.GetEmail();
            labelSpec.Text = TaiKhoan.GetSpec();
            labelSys.Text = TaiKhoan.GetSys();

            if (TaiKhoan.GetAvatar() != string.Empty)
            {
                Image i = ByteToImg(TaiKhoan.GetAvatar());
                PictureBoxAvatar.Image = i;
            }

            CheckBoxStartUp.Checked = CaiDat.GetStartup();
            CheckBoxDeadline.Checked = CaiDat.GetDeadlineNotify();
            CheckBoxEvent.Checked = CaiDat.GetEventNotify();
            CheckBoxOther.Checked = CaiDat.GetOtherNotify();

            //NumDuringTime.Value = CaiDat.GetNoticeTime();
            //NumStartHour.Value = CaiDat.GetNotifyHour();
            //NumStartMin.Value = CaiDat.GetNotifyMinute();

            if (CaiDat.GetFirstOpen())
            {
                btnThoat_Click(this, new EventArgs());
                CaiDat.SetFirstOpen(false);
            }

            if (CaiDat.GetDeadlineNotify() || CaiDat.GetEventNotify() || CaiDat.GetOtherNotify())
            {
                new FormThongBaoTrongNgay();

                timer.Interval = 1000;
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
            try
            {
                bool isStartUp = CheckBoxStartUp.Checked;
                CaiDat.SetStartup(ref isStartUp);
                if (isStartUp != CheckBoxStartUp.Checked)
                    CheckBoxStartUp.Checked = isStartUp;

                CaiDat.SetNotify(CheckBoxDeadline.Checked, CheckBoxEvent.Checked, CheckBoxOther.Checked);

                //CaiDat.SetNoticeTime(int.Parse(NumDuringTime.Value.ToString()), int.Parse(NumStartHour.Value.ToString()), int.Parse(NumStartMin.Value.ToString()));

                MessageBox.Show("Thay đổi cài đặt thành công!", "Thông báo");

                FormUngDung_Load(this, new EventArgs());
            }
            catch
            {
                MessageBox.Show("Thay đổi cài đặt không thành công!", "Thông báo");
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
                TaiKhoan.ChangeAvatar(Convert.ToBase64String(converImgToByte(fileName)));

                if (TaiKhoan.GetAvatar() != string.Empty)
                {
                    Image i = ByteToImg(TaiKhoan.GetAvatar());
                    i = ResizeImage(i, new Size(PictureBoxAvatar.Width, PictureBoxAvatar.Height));
                    PictureBoxAvatar.Image = i;
                }
            }

        }

        /*
            imageList1.Images.Add(ByteToImg(richTextBox1.Text));
            imageList1.ImageSize = new Size(132, 132);
            this.listView1.View = View.LargeIcon;
            for (int counter = 0; counter < imageList1.Images.Count; counter++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = counter;
                this.listView1.Items.Add(item);
            }
            this.listView1.LargeImageList = imageList1;
        */

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
            if (DateTime.Now.Second == 0)
            {
                timer.Interval = 1000 * 60;
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
                notifyIcon.ShowBalloonTip(5000, ev.TieuDe, detail, ToolTipIcon.Info);
            }
            //new FormThongBaoSuKien();
        }
        #endregion Timer To Notice
    }

    public class TimeNUD : NumericUpDown
    {
        protected override void UpdateEditText()
        {
            this.Text = this.Value.ToString().PadLeft(2, '0');
        }
    }
}
