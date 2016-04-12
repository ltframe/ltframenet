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
        OnDropCallBack d1;
        OnDragLeaveCallBack d2;
        OnDragOverCallBack d3;
        OnDragEnterCallBack d4;
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
            d1 = new OnDropCallBack(OnDrop);
            d2 = new OnDragLeaveCallBack(OnDragLeave);
            d3 = new OnDragOverCallBack(OnDragOver);
            d4 = new OnDragEnterCallBack(OnDragEnter);
            int ww = 640, wh = 510;
            Rectangle rect = Lib.CenterWindow(ww, wh);
            ltf = new LTFrameNetClass("LTFrame-Canvas","OLEDragDrop", IntPtr.Zero, Win32DataType.WS_POPUP | Win32DataType.WS_VISIBLE, rect.Left, rect.Top, ww, wh, IntPtr.Zero);
            ltf.BindUserFunction("DragWindow", DragWindowFun, 1);
            ltf.BindUserFunction("QuitApp", QuitAppFun, 0);
            ltf.BindUserFunction("MinWindow", MinWindowFun, 0);

            ltf.SetOnDropCallBack(d1);
            ltf.SetOnDragLeaveCallBack(d2);
            ltf.SetOnDragOverCallBack(d3);
            ltf.SetOnDragEnterCallBack(d4);
            
            
            ltf.loadFile(Lib.GetAppPath + @"./template/Drag2.html");
            ltf.EnableDragFrameChangeSize(false);
            ltf.MessageLoop();
        }
        public bool OnDragLeave()
        {
	        ltf.RunJavaScript("$(\"#div1\").text('动作：DragLeave')");
	        return true;
        }
        public bool OnDragEnter(IntPtr pDataObject, uint grfKeyState, POINTL pt, IntPtr pdwEffect)
        {
	        ltf.RunJavaScript("$(\"#div1\").text('动作：DragEnter')");
	        return true;
        }

        public bool OnDragOver(uint grfKeyState, POINTL pt, IntPtr pdwEffect)
        {
	        ltf.RunJavaScript("$(\"#div1\").text('动作：DragOver')");
	        return true;
        }
        public bool OnDrop(IntPtr pDataObject, uint grfKeyState, POINTL pt, IntPtr pdwEffect)
        {
	        ltf.RunJavaScript("$(\"#div1\").text('动作：Drop')");
	        return true;
}
    }
}
