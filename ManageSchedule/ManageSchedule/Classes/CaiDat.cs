using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using IWshRuntimeLibrary;
//using Shell32;
using System.Data;
using System.Data.SqlClient;

namespace ManageSchedule
{
    class CaiDat
    {
        #region Param
        private static bool Startup = false;
        private static bool DeadlineNotify = false;
        private static bool EventNotify = false;
        private static bool OtherNotify = false;
        //private static bool DarkMode = false;
        private static int NotifyTime = 60;
        private static int NoticeStartHour = 0;
        private static int NoticeStartMinute = 0;
        private static string PreUsername = string.Empty;
        private static string PreHashPassword = string.Empty;
        private static bool AutoLogin = false;
        private static IWshRuntimeLibrary.IWshShortcut shortcut;
        #endregion Param

        #region Constructor
        public CaiDat(string filePath)
        {
            string[] setting = System.IO.File.ReadAllLines(filePath);

            PreUsername = setting[0];
            PreHashPassword = setting[1];
            NotifyTime = int.Parse(setting[5]);
            NoticeStartHour = int.Parse(setting[6]);
            NoticeStartMinute = int.Parse(setting[7]);

            if (setting[2] == "Startup: false")
            {
                Startup = false;
            }
            else
            {
                Startup = true;
            }

            //if (setting[3] == "Dark Mode: false")
            //{
            //    DarkMode = false;
            //}
            //else
            //{
            //    DarkMode = true;
            //}

            if (setting[4].Contains("Deadline"))
            {
                DeadlineNotify = true;
            }
            else
            {
                DeadlineNotify = false;
            }

            if (setting[4].Contains("Enevt"))
            {
                EventNotify = true;
            }
            else
            {
                EventNotify = false;
            }

            if (setting[4].Contains("Other"))
            {
                OtherNotify = true;
            }
            else
            {
                OtherNotify = false;
            }
        }
        #endregion Constructor

        #region Get Method
        //
        // get method
        //

        public static bool GetStartup()
        {
            return Startup;
        }

        public static bool GetDeadlineNotify()
        {
            return DeadlineNotify;
        }

        public static bool GetEventNotify()
        {
            return EventNotify;
        }

        public static bool GetOtherNotify()
        {
            return OtherNotify;
        }

        //public static bool GetDarkMode()
        //{
        //    return DarkMode;
        //}

        public static int GetNoticeTime()
        {
            return NotifyTime;
        }

        public static int GetNotifyHour()
        {
            return NoticeStartHour;
        }

        public static int GetNotifyMinute()
        {
            return NoticeStartMinute;
        }

        public static string GetPreUsername()
        {
            return PreUsername;
        }

        public static string GetPreHash()
        {
            return PreHashPassword;
        }

        public static bool GetAutoLogin()
        {
            return AutoLogin;
        }

        #endregion Get Method

        #region Set Method

        public static void SetStartup(ref bool isStartup)
        {
            // nếu isStartup = true thì chạy startup, nếu không thì tắt startup
            // sự kiện checkbox Startup
            if (isStartup)
            {
                try
                {
                    CreateStartupShortcut();
                    Startup = isStartup;
                }
                catch
                {
                    isStartup = Startup;
                }
            }
            else
            {
                try
                {
                    CreateStartupShortcut();
                    DeleteStartupShortcuts(GetShortcutTargetFile(shortcut.FullName));
                    Startup = isStartup;
                }
                catch
                {
                    isStartup = Startup;
                }
            }
        }

        //public static void SetDarkMode(bool isDark)
        //{
        //    // nếu isDark = true thì chạy darkmode, nếu không đặt lại bình thường
        //    // sự kiện checkbox darkmode
        //    // thay đổi ngay khi change mode
        //    DarkMode = isDark;
        //    if (DarkMode)
        //    {
        //        DarkApp();
        //    }
        //    else
        //    {
        //        LightApp();
        //    }
        //}

        public static void SetNotify(bool _deadline, bool _event, bool _other)
        {
            // type là deadline, event other, deadline event other, ...
            // sự kiện checkbox deadline/event/other
            // nếu chưa bật startup vẫn có thể lựa chọn
            // nếu không có bất cứ checkbox nào bật vẫn chạy background
            // không xóa khi đăng xuất
            // không xóa khi kết thúc từ notify icon (== application.exit)
            DeadlineNotify = _deadline;
            EventNotify = _event;
            OtherNotify = _other;

            Deadline();
            Event();
            Other();
        }

        public static void SetNoticeTime(int time, int hour, int minute)
        {
            // lấy dữ liệu từ numeric up down
            // time là khoảng cách giữa 2 lần thông báo
            // hour:minute là thời gian bắt đầu thông báo
            // vd hour=7, minute=30 thì bắt đầu thông báo từ 7h30 mỗi ngày
            NotifyTime = time;
            NoticeStartHour = hour;
            NoticeStartMinute = minute;

            Time();
        }

        public static void SetPreLogin(string username, string password)
        {
            // gọi khi đăng nhập
            // xóa khi đăng xuất
            // không xóa khi thoát
            // thay đổi khi đổi mật khẩu
            PreUsername = username;
            PreHashPassword = password;
        }

        public static bool isPreLogin()
        {
            if (PreUsername != string.Empty && PreHashPassword != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SetAutoLogin(bool isAutoLogin)
        {
            AutoLogin = isAutoLogin;
        }

        #endregion Set Method

        #region Setting
        //
        // setting method
        //

        public static bool ChangePassword(string _hash)
        {
            SqlConnection sqlCon = null;
            if (sqlCon == null)
                sqlCon = new SqlConnection(HangSo.strCon);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            try
            {
                SqlCommand sqlCmdUpdate = new SqlCommand();
                sqlCmdUpdate.CommandType = CommandType.Text;
                sqlCmdUpdate.CommandText = "update dbo.Thongtintaikhoan " +
                    "set MatKhau=@MatKhau " +
                    "where TaiKhoan=@TaiKhoan";

                SqlParameter parMK = new SqlParameter("@MatKhau", SqlDbType.VarChar);
                parMK.Value = _hash;

                SqlParameter parTK = new SqlParameter("@TaiKhoan", SqlDbType.VarChar);
                parTK.Value = CaiDat.GetPreUsername();

                sqlCmdUpdate.Parameters.Add(parMK);
                sqlCmdUpdate.Parameters.Add(parTK);

                sqlCmdUpdate.Connection = sqlCon;

                sqlCmdUpdate.ExecuteNonQuery();

                sqlCon.Close();

                PreHashPassword = _hash;

                return true;
            }
            catch
            {
                sqlCon.Close();

                return false;
            }
        }

        #region Startup
        // tạo shortcut startup
        public static void CreateStartupShortcut()
        {
            WshShellClass wshShell = new WshShellClass();
            string startUpPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

            shortcut = (IWshRuntimeLibrary.IWshShortcut)wshShell.CreateShortcut(startUpPath + "\\" + Application.ProductName + ".lnk");

            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.WorkingDirectory = Application.StartupPath;
            shortcut.Description = "App Create Tablet";
            shortcut.Save();
        }

        public static string GetShortcutTargetFile(string shortcutFilename)
        {
            string pathOnly = Path.GetDirectoryName(shortcutFilename);
            string filenameOnly = Path.GetFileName(shortcutFilename);

            Shell32.Shell shell = new Shell32.ShellClass();
            Shell32.Folder folder = shell.NameSpace(pathOnly);
            Shell32.FolderItem folderItem = folder.ParseName(filenameOnly);
            if (folderItem != null)
            {
                Shell32.ShellLinkObject link = (Shell32.ShellLinkObject)folderItem.GetLink;
                return link.Path;
            }

            return String.Empty;
        }

        // xóa shortcut startup
        public static void DeleteStartupShortcuts(string targetExeName)
        {
            string startUpPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

            DirectoryInfo di = new DirectoryInfo(startUpPath);
            FileInfo[] files = di.GetFiles("*.lnk");

            foreach (FileInfo fi in files)
            {
                string shortcutTargetFile = GetShortcutTargetFile(fi.FullName);

                if (shortcutTargetFile.EndsWith(targetExeName, StringComparison.InvariantCultureIgnoreCase))
                {
                    System.IO.File.Delete(fi.FullName);
                }
            }
        }
        #endregion Startup

        //#region Dark Mode

        //public static void LightApp()
        //{

        //}

        //public static void DarkApp()
        //{

        //}

        //#endregion Dark Mode

        #region Notify

        public static void Deadline()
        {

        }

        public static void Event()
        {

        }

        public static void Other()
        {

        }

        public static void Time()
        {

        }

        #endregion Notify

        // ghi vào file txt   
        public static void WriteToTxt(string filePath)
        {
            string[] setting = new string[8];

            setting[0] = PreUsername;
            setting[1] = PreHashPassword;
            setting[5] = NotifyTime.ToString();
            setting[6] = NoticeStartHour.ToString();
            setting[7] = NoticeStartMinute.ToString();

            if (!Startup)
            {
                setting[2] = "Startup: false";
            }
            else
            {
                setting[2] = "Startup: true";
            }

            //if (!DarkMode)
            //{
            //    setting[3] = "Dark Mode: false";
            //}
            //else
            //{
            //    setting[3] = "Dark Mode: true";
            //}

            setting[4] = "Notify:";

            if (DeadlineNotify)
            {
                if (!setting[4].Contains("Deadline"))
                    setting[4] += " Deadline";
            }
            else
            {
                if (setting[4].Contains("Deadline"))
                {
                    setting[4].Remove(setting[4].IndexOf("Deadline"), 9);
                }
            }

            if (EventNotify)
            {
                if (!setting[4].Contains("Event"))
                    setting[4] += " Event";
            }
            else
            {
                if (setting[4].Contains("Event"))
                {
                    setting[4].Remove(setting[4].IndexOf("Event"), 6);
                }
            }

            if (OtherNotify)
            {
                if (!setting[4].Contains("Other"))
                    setting[4] += " Other";
            }
            else
            {
                if (setting[4].Contains("Other"))
                {
                    setting[4].Remove(setting[4].IndexOf("Other"), 6);
                }
            }

            if (!DeadlineNotify && !EventNotify && !OtherNotify)
            {
                setting[4] += " None";
            }

            System.IO.File.WriteAllLines(filePath, setting);
        }

        #endregion Setting
    }
}
