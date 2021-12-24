using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace ManageSchedule
{
    public partial class FormBaoLoi : Form
    {
        public FormBaoLoi()
        {
            InitializeComponent();
            AcceptButton = btnSend;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textMail.Text))
            {
                MessageBox.Show("Hãy điền nội dung trước khi gửi nhé !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textMail.Focus();
                return;
            }

            const string p = "1786045148";
            string Email = "20521010@gm.uit.edu.vn";

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.From = new MailAddress("20520369@gm.uit.edu.vn");

            message.To.Add(new MailAddress(Email));
            message.Subject = textSubject.Text;
            message.Body = textMail.Text;

            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("20520369@gm.uit.edu.vn", p);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            foreach (string names in str2)
            {
                if (names != null)
                {
                    message.Attachments.Add(new Attachment(names));
                }

            }

            smtp.Send(message);

            MessageBox.Show("Cảm ơn bạn đã thông báo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        string[] str2 = new string[30];
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            string fileName = "";
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Multiselect = true;
                open.InitialDirectory = "";
                open.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                open.FilterIndex = 2;
                open.RestoreDirectory = true;

                if (open.ShowDialog() == DialogResult.OK)
                {
                    txtFile.Text = open.FileName;
                    foreach (string file in open.FileNames)
                    //cứ sau mỗi lần lặp ta lại có được 1 file, điều này cho phép ta chọn nhiều file thay vì chỉ 1 cái
                    {
                        //Lấy đường dẫn của file cụ thể
                        //lấy tên của file cụ thể
                        fileName = Path.GetFileName(file);
                    }
                }
                str2 = open.FileNames;
            }

        }
    }
}
