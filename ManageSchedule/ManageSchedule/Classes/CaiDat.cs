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
        #region Properties
        private static bool startup = true;
        public static bool Startup
        {
            get { return startup; }
            set { startup = value; }
        }

        private static bool firstOpen = false;
        public static bool FirstOpen
        {
            get { return firstOpen; }
            set { firstOpen = value; }
        }

        private static bool eventNotify = false;
        public static bool EventNotify
        {
            get { return eventNotify; }
            set { eventNotify = value; }
        }

        private static string preUsername = string.Empty;
        public static string PreUsername
        {
            get { return preUsername; }
            set { preUsername = value; }
        }
        private static string preHashPassword = string.Empty;
        public static string PreHashPassword
        {
            get { return preHashPassword; }
            set { preHashPassword = value; }
        }

        private static IWshRuntimeLibrary.IWshShortcut shortcut;
        #endregion Properties

        #region Constructor
        public CaiDat(string filePath)
        {
            string[] setting = System.IO.File.ReadAllLines(filePath);

            PreUsername = setting[0];
            PreHashPassword = setting[1];

            if (setting[2] == "Startup: false")
            {
                Startup = false;
            }
            else
            {
                Startup = true;
            }

            if (setting[3] == "First Open: true") 
            {
                FirstOpen = true;
            }
            else
            {
                FirstOpen = false;
            }

            if (setting[4] == "Notify: true")
            {
                EventNotify = true;
            }
            else
            {
                EventNotify = false;
            }
        }
        #endregion Constructor

        

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
        
        public static void SetPreLogin(string username, string password)
        {           
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

        #endregion Set Method

        #region Setting
        //
        // setting method
        //
        
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


        // ghi vào file txt   
        public static void WriteToTxt(string filePath)
        {
            string[] setting = new string[5];

            setting[0] = PreUsername;
            setting[1] = PreHashPassword;

            if (!Startup)
            {
                setting[2] = "Startup: false";
            }
            else
            {
                setting[2] = "Startup: true";
            }

            if (!FirstOpen)
            {
                setting[3] = "First Open: false";
            }
            else
            {
                setting[3] = "First Open: true";
            }

            if (EventNotify)
            {
                setting[4] = "Notify: true";
            }
            else
            {
                setting[4] = "Notify: false";
            }

            System.IO.File.WriteAllLines(filePath, setting);
        }

        #endregion Setting
    }
}
