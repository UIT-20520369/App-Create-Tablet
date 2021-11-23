using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ManageSchedule
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string SettingFile = string.Format("{0}\\setting.txt", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
            string[] setting = System.IO.File.ReadAllLines(SettingFile);

            FormDangNhap SignIn = new FormDangNhap();
            if (setting[3] != "" && setting[4] != "")
            {
                if (SignIn.KiemTraDangNhap(setting[3], setting[4]))
                {
                    FormUngDung ungdung = new FormUngDung();
                    ungdung.ShowDialog();
                }
            }
            Application.Run(new BatDau());
        }
    }
}
