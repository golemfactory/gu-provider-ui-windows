using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gu_provider_ui_windows
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
            var mainForm = new MainForm();
            var icon = new NotifyIcon();
            icon.Icon = System.Drawing.SystemIcons.Question;
            icon.Visible = true;
            icon.ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Configure", (sender, args) => { mainForm.Show(); } ),
                new MenuItem("Quit", (sender, args) => { Application.Exit(); } ),
            });
            Application.Run();
        }
    }
}
