﻿using System;
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
    public partial class BatDau : Form
    {
        internal static bool isThoat;
        public BatDau()
        {
            InitializeComponent();
            toolTipBtnThoat.SetToolTip(btnThoat, "Thoát ứng dụng");
            toolTipBtnMini.SetToolTip(btnMini, "Minimize");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            isThoat = false;
            FormDangNhap dangnhap = new FormDangNhap();
            this.Hide();
            dangnhap.ShowDialog();
            if (!isThoat)
                this.Show();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            isThoat = false;
            FormDangKy dangky = new FormDangKy();
            this.Hide();
            dangky.ShowDialog();
            if (!isThoat)
                this.Show();
        }
    }
}