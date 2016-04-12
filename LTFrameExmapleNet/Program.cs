using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Canvas
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Threading.Mutex Run;
            bool noRun = false;
            Run = new System.Threading.Mutex(true, "{8F62734D-534D-41EA-9EB7-FDE85EA32325}", out noRun);
            //检测是否已经运行
            if (!noRun)
            {
                MessageBox.Show("具有相同实例的一个窗口已在运行,请关闭后重试");
                return;
            }

            Version ver = System.Environment.OSVersion.Version;
            if (ver.Major < 5)
            {
                MessageBox.Show("纵系统版本过低,运行此程序需要windows2000以上的操作系统", "警告");
                return;
            }
            UIClass uiclass = new UIClass();
        }
    }
}
