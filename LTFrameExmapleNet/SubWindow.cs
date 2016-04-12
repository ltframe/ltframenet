using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using LTFrameNet;
using Canvas;

namespace LTFrameExmapleNet
{
    public class SubWindow
    {
        public LTFrameNetClass subltf;
        LTNativeFunction fn1, fn2;
        Dictionary<IntPtr, LTFrameNetClass> subwindowlist = new Dictionary<IntPtr, LTFrameNetClass>();
        public static HandleUserMessageCallBack h1;

        public long DragWindowFun(IntPtr es)
        {
            Lib.ReleaseCapture();
            Point DownPoint = new Point();
            Lib.GetCursorPos(ref DownPoint);
            Lib.SendMessage(subltf.windowHandle(), 0x00A1, 2, (DownPoint.X & 0xFFFF) + (DownPoint.Y & 0xFFFF) * 0x10000);
            return subltf.JsUndefined();
        }
        public long CloseWindowFun(IntPtr es)
        {
           
            subltf.CloseWindow();

            return subltf.JsUndefined();
        }

        public void CreateSubWindow(LTFrameNetClass dddddd)
        {
            int ww = 640, wh = 510;
            Rectangle rect = Lib.CenterWindow(ww,wh);
            LTFrameNetClass ltf = new LTFrameNetClass("LTFrame-transparent", "SubWindow", dddddd.windowHandle(), Win32DataType.WS_POPUP | Win32DataType.WS_VISIBLE, 0, 0, ww, wh, IntPtr.Zero);
            ltf.loadFile(Lib.GetAppPath + @"./template/SubWindow.html");
            ltf.EnableDragFrameChangeSize(false);

            subwindowlist.Add(ltf.windowHandle(), ltf);
            fn1 = new LTNativeFunction(DragWindowFun);
            fn2 = new LTNativeFunction(CloseWindowFun);
            ltf.BindUserFunction("DragWindow", fn1, 1);
            ltf.BindUserFunction("CloseWindow", fn2, 0);
            h1 = new HandleUserMessageCallBack(HandleUserMessage);
            ltf.SetHandleUserMessageCallBack(h1);
        }

        public Int32 HandleUserMessage(IntPtr hwnd, uint uMsg, uint wParam, int lParam)
        {
            subltf = subwindowlist[hwnd];
            return subltf.HandleMessage(hwnd, uMsg, wParam, lParam);
        }
       

    }
}
