using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using IWshRuntimeLibrary;
using Shell32;

namespace DemoUI
{
    public partial class FormCaiDat : Form
    {
        IWshRuntimeLibrary.IWshShortcut shortcut;
        string[] setting;
        string SettingFile;

        public FormCaiDat()
        {
            InitializeComponent();
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            SettingFile = string.Format("{0}\\notify_setting.txt", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
            setting = System.IO.File.ReadAllLines(SettingFile);
            SetTgbBgProcess();
        }

        // check cho phép chạy ngầm
        public void SetTgbBgProcess()
        {
            if (setting[0] == "StartupShortcut: true")
            {
                tgbBgProcess.Checked = true;
                tgbDeadline.Enabled = true;
                tgbEvent.Enabled = true;
            }
            else
            {
                tgbBgProcess.Checked = false;
                tgbDeadline.Enabled = false;
                tgbEvent.Enabled = false;
            }
        }

        private void tgbBgProcess_CheckedChanged(object sender, EventArgs e)
        {
            if (tgbBgProcess.Checked)
            {
                try
                {
                    CreateStartupShortcut();
                    setting[0] = "StartupShortcut: true";
                    setting[2] = "ShowInTaskbar: false";
                    tgbDeadline.Enabled = true;
                    tgbEvent.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                if (setting[0] != "StartupShortcut: true")
                    tgbBgProcess.Checked = false;
                System.IO.File.WriteAllLines(SettingFile, setting);
            }
            else
            {
                try
                {
                    CreateStartupShortcut();
                    DeleteStartupShortcuts(GetShortcutTargetFile(shortcut.FullName));
                    setting[0] = "StartupShortcut: false";
                    setting[2] = "ShowInTaskbar: true";
                    tgbDeadline.Enabled = false;
                    tgbEvent.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                if (setting[0] != "StartupShortcut: false")
                    tgbBgProcess.Checked = true;
                System.IO.File.WriteAllLines(SettingFile, setting);
            }
        }

        // tạo shortcut startup
        public void CreateStartupShortcut()
        {
            WshShellClass wshShell = new WshShellClass();
            string startUpPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

            shortcut = (IWshRuntimeLibrary.IWshShortcut)wshShell.CreateShortcut(startUpPath + "\\" + Application.ProductName + ".lnk");

            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.WorkingDirectory = Application.StartupPath;
            shortcut.Description = "App Create Tablet";
            shortcut.Save();
        }

        public string GetShortcutTargetFile(string shortcutFilename)
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
        public void DeleteStartupShortcuts(string targetExeName)
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

        private void FormCaiDat_Load(object sender, EventArgs e)
        {

        }
    }
}
