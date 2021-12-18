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
    public partial class MotSuKien : UserControl
    {
        private int type;
        private OneEvent suKien;
        public OneEvent SuKien
        {
            get { return suKien; }
            set { suKien = value; }
        }
        private FlowLayoutPanel flPnlTotal;
        private Size sizeUC;
        public Size SizeUC
        {
            get { return sizeUC; }
            set { sizeUC = value; }
        }
        private event EventHandler deleted;
        public event EventHandler Deleted
        {
            add { deleted += value; }
            remove { deleted -= value; }
        }

        public MotSuKien(OneEvent oneEvent, int width, int i = 0)
        {
            InitializeComponent();
            type = i;
            suKien = oneEvent;
            flPnlTotal = new FlowLayoutPanel();
            flPnlTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            flPnlTotal.FlowDirection = FlowDirection.TopDown;
            this.Controls.Add(flPnlTotal);

            sizeUC = new Size();
            sizeUC.Width = width;
            ShowSuKien();
        }

        private void ShowSuKien()
        {
            this.Width = sizeUC.Width;
            flPnlTotal.Size = this.Size;

            if (type == 1)
            {
                this.Margin = new Padding(0, 0, 0, 0);
            }
            else
            {
                CreatePnlButton();
            }

            CreatePnlEvent();
            flPnlTotal.Height = sizeUC.Height;
            this.Size = flPnlTotal.Size;
        }

        private void Clear()
        {
            sizeUC = new Size(this.Width, 0);
            flPnlTotal.Controls.Clear();
        }

        private void CreatePnlButton()
        {
            FlowLayoutPanel pnlBtn = new FlowLayoutPanel();
            pnlBtn.Width = flPnlTotal.Width;
            pnlBtn.FlowDirection = FlowDirection.RightToLeft;

            Button btnDelete = new Button();
            btnDelete.Text = "Xóa";
            btnDelete.Click += BtnDelete_Click;
            pnlBtn.Controls.Add(btnDelete);

            Button btnEdit = new Button();
            btnEdit.Text = "Chỉnh sửa";
            btnEdit.Click += BtnEdit_Click;
            pnlBtn.Controls.Add(btnEdit);

            pnlBtn.Height = btnEdit.Height + 6;

            flPnlTotal.Controls.Add(pnlBtn);
            sizeUC.Height += pnlBtn.Height + pnlBtn.Margin.Top + pnlBtn.Margin.Bottom;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EditSuKien formEdit = new EditSuKien(SuKien);
            formEdit.Show();
            formEdit.Edited += FormEdit_Edited;
            formEdit.Deleted += FormEdit_Deleted;
        }

        private void FormEdit_Deleted(object sender, EventArgs e)
        {
            if (deleted != null)
                deleted(this, new EventArgs());
        }

        private void FormEdit_Edited(object sender, EventArgs e)
        {
            sizeUC = new Size(this.Width, 0);
            flPnlTotal.Controls.Clear();
            ShowSuKien();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SuKien.Delete();
            if (deleted != null)
                deleted(this, new EventArgs());
        }

        private void CreatePnlEvent()
        {
            AddPanel("Tiêu đề", SuKien.TieuDe);

            string ngay;
            string thu = HangSo.DayofWeek_vn[(int)SuKien.Ngay.DayOfWeek];
            string thang = HangSo.Month_vn[SuKien.Ngay.Month - 1];
            ngay = $"{thu}, {SuKien.Ngay.Day} {thang}  {SuKien.Ngay.ToString("HH:mm")}";
            AddPanel("Thời gian", ngay);

            if (!string.IsNullOrEmpty(SuKien.MonHoc))
            {
                AddPanel("Môn học", SuKien.MonHoc);
            }

            if (!string.IsNullOrEmpty(SuKien.MoTa))
            {
                AddPanel("Mô tả", SuKien.MoTa);
            }

            if (SuKien.ToiNgay != DateTime.MinValue)
            {
                string toingay;
                string _thu = HangSo.DayofWeek_vn[(int)SuKien.ToiNgay.DayOfWeek];
                string _thang = HangSo.Month_vn[SuKien.ToiNgay.Month - 1];
                toingay = $"{_thu}, {SuKien.ToiNgay.Day} {_thang}  {SuKien.ToiNgay.ToString("HH:mm")}";
                AddPanel("Tới", toingay);
            }

            if (SuKien.ListTB.Count != 0)
            {
                AddPanelThongBao(SuKien.ListTB);
            }
        }

        private void AddPanel(string label, string sender)
        {
            string infor = label + ": " + sender;
            //thêm icon thay label
            Panel pnl = new Panel();

            Label lbl = new Label();
            lbl.Font = new System.Drawing.Font("Calibri Light", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbl.AutoSize = false;
            lbl.Width = flPnlTotal.Width;
            using (Graphics g = CreateGraphics())
            {
                SizeF size = g.MeasureString(infor, lbl.Font, lbl.Width);
                lbl.Height = (int)Math.Ceiling(size.Height);
                lbl.Text = infor;
            }
            pnl.Controls.Add(lbl);
            pnl.AutoSize = true;

            flPnlTotal.Controls.Add(pnl);
            sizeUC.Height += pnl.Height + pnl.Margin.Top + pnl.Margin.Bottom;
        }

        private void AddPanelThongBao(List<ItemThongBao> listTB)
        {
            FlowLayoutPanel flowLayout = new FlowLayoutPanel();
            flowLayout.AutoSize = true;
            Label label = new Label() { Text = "Thông báo: " };
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Calibri Light", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            flowLayout.Controls.Add(label);
            if (listTB.Count == 0)
                return;
            FlowLayoutPanel pnl = new FlowLayoutPanel();
            pnl.FlowDirection = FlowDirection.TopDown;
            pnl.AutoSize = true;
            for (int i = 0; i < listTB.Count; i++)
            {
                Label lbl = new Label() { Text = $"{listTB[i].GiaTri} {listTB[i].DonVi}" };
                lbl.Font = new System.Drawing.Font("Calibri Light", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbl.AutoSize = true;
                pnl.Controls.Add(lbl);
            }

            flowLayout.Controls.Add(pnl);
            flPnlTotal.Controls.Add(flowLayout);
            // size.Height += pnl.Height + pnl.Margin.Top + pnl.Margin.Bottom;
            sizeUC.Height += flowLayout.Height + flowLayout.Margin.Top + flowLayout.Margin.Bottom;
        }
    }
}
