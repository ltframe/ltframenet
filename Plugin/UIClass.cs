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
        LTNativeFunction fn1, fn2, fn3;


        public long DragWindowFun(IntPtr es)
        {
            Lib.ReleaseCapture();
            Point DownPoint = new Point();
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
            ltf = new LTFrameNetClass("LTFrame-Plugin","Plugin", IntPtr.Zero, Win32DataType.WS_POPUP | Win32DataType.WS_VISIBLE, rect.Left, rect.Top, ww, wh, IntPtr.Zero);
            fn1 = new LTNativeFunction(DragWindowFun);
            fn2 = new LTNativeFunction(QuitAppFun);
            fn3 = new LTNativeFunction(MinWindowFun);
            ltf.BindUserFunction("DragWindow", fn1, 1);
            ltf.BindUserFunction("QuitApp", fn2, 0);
            ltf.BindUserFunction("MinWindow", fn3, 0);
            ltf.loadFile(Lib.GetAppPath + @"./template/plugin.html");
            ltf.EnableDragFrameChangeSize(false);
            ltf.MessageLoop();
        }
    }
}
