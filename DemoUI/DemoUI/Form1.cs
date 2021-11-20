using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.IO;

namespace DemoUI
{
    public partial class Form1 : Form
    {
        private IconButton curButton;
        private Panel leftBorderBtn;
        private Form curChildForm;
        string SettingFile;
        string[] setting;
        int borderSize = 2;
        Size formSize;

        public Form1()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(34, 33, 74);
            btnMenu_Click(this, new EventArgs());
        }

        private class RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(24, 161, 251);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(95, 77, 221);
        }

        private void ActiveButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();

                // Button
                curButton = (IconButton)senderBtn;
                curButton.BackColor = Color.FromArgb(37, 36, 81);
                curButton.ForeColor = color;
                curButton.TextAlign = ContentAlignment.MiddleCenter;
                curButton.IconColor = color;
                curButton.TextImageRelation = TextImageRelation.TextBeforeImage;
                curButton.ImageAlign = ContentAlignment.MiddleRight;

                // Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, curButton.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                // Icon current child form
                iconCurChildForm.IconChar = curButton.IconChar;
                iconCurChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (curButton != null)
            {
                curButton.BackColor = Color.FromArgb(31, 30, 68);
                curButton.ForeColor = Color.Gainsboro;
                curButton.TextAlign = ContentAlignment.MiddleLeft;
                curButton.IconColor = Color.Gainsboro;
                curButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                curButton.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (curChildForm != null)
            {
                curChildForm.Close();
            }

            curChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelTitleChildForm.Text = childForm.Text;
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            OpenChildForm(new FormTrangChu());
        }

        private void btnTaoTKB_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color2);
            OpenChildForm(new FormTaoTKB());
        }

        private void btnXemTKB_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color3);
            OpenChildForm(new FormXemTKB());
        }

        private void btnHoTro_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color4);
            OpenChildForm(new FormHuongDan());
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {

            ActiveButton(sender, RGBColors.color6);
            OpenChildForm(new FormCaiDat());
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            btnClose_Click(this, new EventArgs());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (curChildForm == null)
            {
                return;
            }
            curChildForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurChildForm.IconChar = IconChar.Home;
            iconCurChildForm.IconColor = Color.MediumPurple;
            labelTitleChildForm.Text = "Nhà";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            string[] newSetting = System.IO.File.ReadAllLines(SettingFile);

            int count = 0;
            foreach (string row in newSetting)
            {
                if (row != setting[count]) 
                {
                    Form1_Load(this, new EventArgs());
                }
                count++;
            }
            if (setting[0] == "StartupShortcut: false")
                Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                this.Size = formSize;
                btnMaximize.IconChar = IconChar.WindowMaximize;
                WindowState = FormWindowState.Normal;
            }
            else
            {
                formSize = this.ClientSize;
                btnMaximize.IconChar = IconChar.WindowRestore;
                WindowState = FormWindowState.Maximized;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(255, 128, 128);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(26, 25, 62);
        }

        private void btnMaximize_MouseHover(object sender, EventArgs e)
        {
            btnMaximize.BackColor = Color.FromArgb(96, 90, 185);
        }

        private void btnMaximize_MouseLeave(object sender, EventArgs e)
        {
            btnMaximize.BackColor = Color.FromArgb(26, 25, 62);
        }

        private void btnMinimize_MouseHover(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.FromArgb(96, 90, 185);
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.FromArgb(26, 25, 62);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            SettingFile = string.Format("{0}\\notify_setting.txt", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
            setting = System.IO.File.ReadAllLines(SettingFile);

            FormCaiDat settingForm = new FormCaiDat();
            if (setting[1] == "NotifyIcon: true") 
                notifyIcon.Visible = true;
            else
                notifyIcon.Visible = false;

            if (setting[2] == "ShowInTaskbar: true")
            {
                Visible = true;
                ShowInTaskbar = true;
            }
            else
            {
                Visible = false;
                ShowInTaskbar = false;
            }
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            if (setting[2] != "ShowInTaskbar: true")
            {
                setting[2] = "ShowInTaskbar: true";
                System.IO.File.WriteAllLines(SettingFile, setting);
                Form1_Load(this, new EventArgs());
            }
            this.WindowState = FormWindowState.Normal;
            //this.Show();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (this.panelMenu.Width>200)
            {
                panelMenu.Width = 60;
                pbxLogo.Visible = false;
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            {
                panelMenu.Width = 220;
                pbxLogo.Visible = true;
                btnMenu.Dock = DockStyle.None;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020;
            const int SC_RESTORE = 0xF120;
            const int WM_NCHITTEST = 0x0084;
            const int resizeAreaSize = 10;

            #region Form Resize
            const int HTCLIENT = 1;
            const int HTLEFT = 10;
            const int HTRIGHT = 11;
            const int HTTOP = 12;
            const int HTTOPLEFT = 13;
            const int HTTOPRIGHT = 14;
            const int HTBOTTOM = 15;
            const int HTBOTTOMLEFT = 16;
            const int HTBOTTOMRIGHT = 17;

            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)
                {
                    if ((int)m.Result == HTCLIENT)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());                          
                        Point clientPoint = this.PointToClient(screenPoint);                     

                        if (clientPoint.Y <= resizeAreaSize)
                        {
                            if (clientPoint.X <= resizeAreaSize)
                                m.Result = (IntPtr)HTTOPLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))
                                m.Result = (IntPtr)HTTOP;
                            else
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize))
                        {
                            if (clientPoint.X <= resizeAreaSize)
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))
                                m.Result = (IntPtr)HTBOTTOM;
                            else
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion

            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }

            if (m.Msg == WM_SYSCOMMAND)
            {
                int wParam = (m.WParam.ToInt32() & 0xFFF0);

                if (wParam == SC_MINIMIZE) 
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)
                    this.Size = formSize;
            }
            base.WndProc(ref m);
        }
    }
}
