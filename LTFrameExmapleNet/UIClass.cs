using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LTFrameNet;
using LTFrameExmapleNet;
using System.Diagnostics;

namespace Canvas
{
    public class UIClass
    {
        public static LTFrameNetClass ltf;

        public static LTNativeFunction fn1, fn2, fn3, fn4, fn5, fn6, fn7;
        public static HandleUserMessageCallBack h1;
        SubWindow w = new SubWindow();
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
        public long OpenSubWindowFun(IntPtr es)
        {
            this.aaaaaaaa();
            return ltf.JsUndefined();
        }


        public long OpenApplactionFun(IntPtr es)
        {
            string p = ltf.JsValue2StringW(es, ltf.GetJsParameter(es, 0));
            Process.Start(p);
            return ltf.JsUndefined();
        }

        public long OpenTransparentWindowFun(IntPtr es)
        {
            string p = ltf.JsValue2StringW(es, ltf.GetJsParameter(es, 0));
            Process.Start("Transparent.exe", p);
            return ltf.JsUndefined();
        }
        public long OpenCrossDomain(IntPtr es)
        {
            string p = ltf.JsValue2StringW(es, ltf.GetJsParameter(es, 0));
            Process.Start("CrossDomain.exe",p);
            return ltf.JsUndefined();
        }

        public void aaaaaaaa()
        {        
            w.CreateSubWindow(ltf);
        }
        public UIClass()
        {
            int ww = 700, wh = 550;

            Rectangle rect = Lib.CenterWindow(ww, wh);
            ltf = new LTFrameNetClass("LTFrame-transparent", "LTFrameExmaple", IntPtr.Zero, Win32DataType.WS_POPUP | Win32DataType.WS_VISIBLE, rect.Left, rect.Top, ww, wh, IntPtr.Zero);
            fn1 = new LTNativeFunction(DragWindowFun);
            fn2 = new LTNativeFunction(QuitAppFun);
            fn3 = new LTNativeFunction(MinWindowFun);
            fn4 = new LTNativeFunction(OpenSubWindowFun);
            fn5 = new LTNativeFunction(OpenApplactionFun);
            fn6 = new LTNativeFunction(OpenTransparentWindowFun);
            fn7 = new LTNativeFunction(OpenCrossDomain);

            h1 = new HandleUserMessageCallBack(HandleUserMessage);
            ltf.SetHandleUserMessageCallBack(h1);
            ltf.BindUserFunction("DragWindow", fn1, 1);
            ltf.BindUserFunction("QuitApp", fn2, 0);
            ltf.BindUserFunction("MinWindow", fn3, 0);
            ltf.BindUserFunction("OpenSubWindow", fn4, 0);
            ltf.BindUserFunction("OpenApplaction", fn5, 0);
            ltf.BindUserFunction("OpenTransparentWindow", fn6, 1);
            ltf.BindUserFunction("OpenCrossDomain", fn7, 1);
            ltf.loadFile(Lib.GetAppPath + @"./template/Index.html");
            ltf.EnableDragFrameChangeSize(false);
            ltf.MessageLoop();
        }

        public Int32 HandleUserMessage(IntPtr hwnd, uint uMsg, uint wParam, int lParam)
        {
            return ltf.HandleMessage(hwnd, uMsg, wParam, lParam);
        }
    }
}
