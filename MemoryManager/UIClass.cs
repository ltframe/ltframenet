using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LTFrameNet;
using System.Runtime.InteropServices;

namespace Canvas
{
    public class UIClass
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(
             uint processAccess,
             bool bInheritHandle,
             uint processId
        );

        struct PROCESS_MEMORY_COUNTERS
        {
            public uint cb;
            public uint PageFaultCount;
            public uint PeakWorkingSetSize;
            public uint WorkingSetSize;
            public uint QuotaPeakPagedPoolUsage;
            public uint QuotaPagedPoolUsage;
            public uint QuotaPeakNonPagedPoolUsage;
            public uint QuotaNonPagedPoolUsage;
            public uint PagefileUsage;
            public uint PeakPagefileUsage;
        };

        public LTFrameNetClass ltf;
        public static HandleUserMessageCallBack h1;
        private IntPtr hProcess;

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

        [DllImport("user32.dll", ExactSpelling = true)]
        static extern IntPtr SetTimer(IntPtr hWnd, uint nIDEvent, uint uElapse, IntPtr lpTimerFunc);
        delegate void TimerProc(IntPtr hWnd, uint uMsg, IntPtr nIDEvent, uint dwTime);

        public long JobStartFun(IntPtr es)
        {
            SetTimer(ltf.windowHandle(),8888888,1,IntPtr.Zero); 
            return ltf.JsUndefined();
        }
        public long AutoGCFun(IntPtr es)
        {
            bool t = ltf.JsValue2Boolean(es, ltf.GetJsParameter(es, 0));
            ltf.IsAutoGC(t,50);
            return ltf.JsUndefined();
        }

        public long CleanMemoryFun(IntPtr es)
        {
            ltf.CleanMemory();
            return ltf.JsUndefined();
        }
        public static LTNativeFunction fn1, fn2, fn3, fn4, fn5, fn6, fn7;
        public UIClass()
        {
            int ww = 700, wh = 500;
            Rectangle rect = Lib.CenterWindow(ww, wh);
            ltf = new LTFrameNetClass("LTFrame-Canvas","MemoryManager",IntPtr.Zero, Win32DataType.WS_POPUP | Win32DataType.WS_VISIBLE, rect.Left, rect.Top, ww, wh, IntPtr.Zero);
            
            fn1 = new LTNativeFunction(DragWindowFun);
            fn2 = new LTNativeFunction(QuitAppFun);
            fn3 = new LTNativeFunction(MinWindowFun);
            fn4 = new LTNativeFunction(JobStartFun);
            fn5 = new LTNativeFunction(AutoGCFun);
            fn6 = new LTNativeFunction(CleanMemoryFun);

            ltf.BindUserFunction("DragWindow", fn1, 0);
            ltf.BindUserFunction("QuitApp", fn2, 0);
            ltf.BindUserFunction("MinWindow", fn3, 0);
            ltf.BindUserFunction("JobStart", fn4, 0);
            ltf.BindUserFunction("AutoGC", fn5, 1);
            ltf.BindUserFunction("CleanMemory", fn6, 0);

            h1 = new HandleUserMessageCallBack(HandleUserMessage);
            ltf.SetHandleUserMessageCallBack(h1);

            uint dwProcessId;
            GetWindowThreadProcessId(ltf.windowHandle(), out dwProcessId);

            hProcess = OpenProcess(0x0400|0x0010, false, dwProcessId);

            ltf.loadFile(Lib.GetAppPath + @"./template/MemoryManager.html");
            ltf.EnableDragFrameChangeSize(false);
            ltf.MessageLoop();
        }
        [DllImport("psapi.dll", SetLastError = true)]
        static extern bool GetProcessMemoryInfo(IntPtr hProcess, out PROCESS_MEMORY_COUNTERS counters, uint size);

        public Int32 HandleUserMessage(IntPtr hwnd, uint uMsg, uint wParam, int lParam)
        {
             switch(uMsg)
	        {
		        case 0x0113:
		        {
		            switch (wParam)
			        {
			            case 8888888:
				            {
						        PROCESS_MEMORY_COUNTERS pmc;
                                pmc.cb = (uint)Marshal.SizeOf(typeof(PROCESS_MEMORY_COUNTERS));
                                GetProcessMemoryInfo(hProcess,out pmc, pmc.cb);
                                int fCurUse = (int)(pmc.WorkingSetSize / (1024*1024));
                                string ss = string.Format("showmemory('{0}')",fCurUse.ToString());
                                ltf.RunJavaScript(ss);
				            }
			            break ;
			        }
		        }
		        break;
	        }
            return ltf.HandleMessage(hwnd, uMsg, wParam, lParam);
        }
    }
}
