using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
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
            ltf = new LTFrameNetClass("LTFrame-Canvas","JavaScript", IntPtr.Zero, Win32DataType.WS_POPUP | Win32DataType.WS_VISIBLE, rect.Left, rect.Top, ww, wh, IntPtr.Zero);
            ltf.BindUserFunction("DragWindow", DragWindowFun, 1);
            ltf.BindUserFunction("QuitApp", QuitAppFun, 0);
            ltf.BindUserFunction("MinWindow", MinWindowFun, 0);
            ltf.BindUserFunction("f1", f1Fun, 0);
            ltf.BindUserFunction("f2", f2Fun, 0);
            ltf.BindUserFunction("f3", f3Fun, 0);
            ltf.BindUserFunction("f4", f4Fun, 0);
            ltf.BindUserFunction("f5", f5Fun, 1);
            ltf.loadFile(Lib.GetAppPath + @"./template/javascript.html");
            ltf.EnableDragFrameChangeSize(false);
            ltf.MessageLoop();
        }

        public long f1Fun(IntPtr es)
        {
            ltf.RunJavaScript("alert('C#执行了JS')");
            return ltf.JsUndefined();
        }
        public long f2Fun(IntPtr es)
        {
            return ltf.String2JsValue(es, "JS 调用C# 返回了值");
        }
        public long f3Fun(IntPtr es)
        {
            long t = ltf.CreateObject(es);

            IntPtr str1 = Marshal.StringToHGlobalAnsi("avalue");
            ltf.CreateJsObject(es, t, str1,ltf.Int2JsValue(12));
            IntPtr str2 = Marshal.StringToHGlobalAnsi("bvalue");
            ltf.CreateJsObject(es, t, str2,  ltf.Int2JsValue(22));
            return t;
        }
        public long f4Fun(IntPtr es)
        {
	        long fun = ltf.GetJsParameter(es,0);
	        long arg =ltf.String2JsValue(es,"C#执行了回掉函数");
	        long[] ptarg = {arg};
            IntPtr arrayStore = Marshal.AllocHGlobal(ptarg.Length * sizeof(long));
            Marshal.Copy(ptarg, 0, arrayStore, ptarg.Length);
            ltf.JsCall(es, fun, arrayStore, 1); 
	        return ltf.JsUndefined();
        }
        public long f5Fun(IntPtr es)
        {
            long obj = ltf.GetJsParameter(es,0);
	        IntPtr exec = ltf.GetGlobalExecState();
            long v = ltf.GetJsObjectAttribute(exec, obj, "a");
            long xc = ltf.GetJsObjectAttribute(exec, obj, "b");
	        int i1 = ltf.JsValue2Int(exec,v);
	        int i2 = ltf.JsValue2Int(exec,xc);
	        string str = string.Format("alert('a:{0},b:{1}')",i1,i2);
	        ltf.RunJavaScript(str);
            return ltf.JsUndefined();
        }
 
    }
}
