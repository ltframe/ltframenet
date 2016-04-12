using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LTFrameNet;

namespace Canvas
{
    public class UIClass
    {
        public LTFrameNetClass ltf;
        public void QuitApp()
        {
            ltf.CloseWindow();
        }

        public long DragWindowFun(IntPtr es)
        {
            Lib.ReleaseCapture();
            Point DownPoint =new Point();
            Lib.GetCursorPos(ref DownPoint);
            Lib.SendMessage(ltf.windowHandle(), 0x00A1, 2, (DownPoint.X & 0xFFFF) + (DownPoint.Y & 0xFFFF) * 0x10000);
            return ltf.JsUndefined();
        }

        public long QuitAppFun(IntPtr es)
        {
            ltf.QuitApp();
            return ltf.JsUndefined();
        }
        
        public long MinWindowFun(IntPtr es)
        {
            Lib.ShowWindow(ltf.windowHandle(), Win32DataType.SW_MINIMIZE);
            return ltf.JsUndefined();
        }
        public UIClass()
        {
            int ww = 700, wh = 500;
            Rectangle rect = Lib.CenterWindow(ww, wh);
            ltf = new LTFrameNetClass("LTFrame-Canvas", "Localstorage", IntPtr.Zero, Win32DataType.WS_POPUP | Win32DataType.WS_VISIBLE, rect.Left, rect.Top, ww, wh, IntPtr.Zero);
            ltf.BindUserFunction("DragWindow", DragWindowFun, 1);
            ltf.BindUserFunction("QuitApp", QuitAppFun, 0);
            ltf.BindUserFunction("MinWindow", MinWindowFun, 0);
            ltf.SetLocalStoragePath(null);
            ltf.SetWebSqlPath(null);
            ltf.loadFile(Lib.GetAppPath + @"./template/localstorage.html");
            ltf.EnableDragFrameChangeSize(false);
            ltf.MessageLoop();
        }
    }
}
