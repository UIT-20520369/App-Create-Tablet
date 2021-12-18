using ManageSchedule.Classes;
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
    public partial class FormShowSuKien : Form
    {
        private bool isClickButton;
        private MotSuKien suKien;
        public MotSuKien SuKien
        {
            get { return suKien; }
            set { suKien = value; }
        }

        private event EventHandler deleted;
        public event EventHandler Deleted
        {
            add { deleted += value; }
            remove { deleted -= value; }
        }

        private event EventHandler edited;
        public event EventHandler Edited
        {
            add { edited += value; }
            remove { edited -= value; }
        }

        public FormShowSuKien(OneEvent oneEvent)
        {
            InitializeComponent();
            isClickButton = false;
            CreatePnlButton();
            suKien = new MotSuKien(oneEvent, this.Width - 3, 1);


            if (suKien.Height > (this.MaximumSize.Height))
            {
                suKien = new MotSuKien(oneEvent, this.Width - 20, 1);
                pnlSukien.Height = (this.MaximumSize.Height - flPnl1.Height);
            }
            else
            {
                pnlSukien.Height = suKien.Height + 3;
            }
            pnlSukien.Controls.Add(suKien);
            flPnlTotal.Size = new Size(this.Width, flPnl1.Height + pnlSukien.Height);
            this.Size = flPnlTotal.Size;
        }

        private void CreatePnlButton()
        {
            flPnl1.FlowDirection = FlowDirection.RightToLeft;

            Button btnCancel = new Button();
            btnCancel.Size = new Size(30, 30);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Text = "X";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            flPnl1.Controls.Add(btnCancel);

            Button btnDelete = new Button();
            btnDelete.Text = "Xóa";
            btnDelete.Click += BtnDelete_Click;
            flPnl1.Controls.Add(btnDelete);

            Button btnEdit = new Button();
            btnEdit.Text = "Chỉnh sửa";
            btnEdit.Click += BtnEdit_Click;
            flPnl1.Controls.Add(btnEdit);

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            isClickButton = true;
            this.suKien.SuKien.Delete();
            if (deleted != null)
                deleted(this, new EventArgs());
            this.Close();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            isClickButton = true;
            if (edited != null)
                edited(this, new EventArgs());
            this.Close();
        }

        private void FormShowSuKien_Deactivate(object sender, EventArgs e)
        {
            if (!isClickButton)
                this.Close();
            else
                isClickButton = false;
        }

    }
}
