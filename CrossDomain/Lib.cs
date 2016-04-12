using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;
using System.Runtime.InteropServices;
namespace Canvas
{

    public class Lib
    {

        public static string GetAppPath
        {
            get { return Application.StartupPath; }
        }
        public static Rectangle CenterWindow(int w, int h)
        {
            int scrWidth, scrHeight;
            Rectangle rect =new Rectangle();

            scrWidth = SystemInformation.PrimaryMonitorSize.Width;
            scrHeight = SystemInformation.PrimaryMonitorSize.Height;
            rect.X = scrWidth/2 - w/2;
            rect.Y = scrHeight/2 - h/2;
            return rect;
        }
        [DllImport("User32.dll")]
        public static extern bool ShowWindow(IntPtr es, int nCmdShow);
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern bool GetCursorPos(ref Point lpPoint);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, uint wMsg, uint wParam, int lParam);


    }
}
