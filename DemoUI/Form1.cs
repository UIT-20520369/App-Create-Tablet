﻿using System;
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

            ActiveButton(sender, RGBColors.color5);
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

            Application.Exit();
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

        private void btnMinimize_MouseHover(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.FromArgb(255, 128, 128);
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
        }

        private void tsmiNotice_Click(object sender, EventArgs e)
        {
            if (tsmiNotice.Checked)
            {
                setting[0] = "StartupShortcut: true";
            }
            else
            {
                setting[0] = "StartupShortcut: false";
            }
            Form1_Load(this, new EventArgs());
        }

        private void tsmiNotice_CheckedChanged(object sender, EventArgs e)
        {
            if (setting[0] == "StartupShortcut: true")
                tsmiNotice.Checked = true;
            else
                tsmiNotice.Checked = false;
        }
    }
}
