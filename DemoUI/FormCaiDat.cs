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
            SetCbxNotice();
        }

        public void SetCbxNotice()
        {
            if (setting[0] == "StartupShortcut: true") 
            {
                cbxNotice.Checked = true;
            }
            else
                cbxNotice.Checked = false;
        }

        private void cbxNotice_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNotice.Checked)
            {
                try
                {
                    CreateStartupShortcut();
                    setting[0] = "StartupShortcut: true";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    cbxNotice.Checked = false;
                    return;
                }
                setting[2] = "ShowInTaskbar: false";
                System.IO.File.WriteAllLines(SettingFile, setting);
            }
            else
            {
                try
                {
                    CreateStartupShortcut();
                    DeleteStartupShortcuts(GetShortcutTargetFile(shortcut.FullName));
                    setting[0] = "StartupShortcut: false";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    cbxNotice.Checked = true;
                    return;
                }
                setting[2] = "ShowInTaskbar: true";
                System.IO.File.WriteAllLines(SettingFile, setting);
            }
        }

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
    }
}
