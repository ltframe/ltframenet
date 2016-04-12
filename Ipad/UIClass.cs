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
        public UIClass()
        {
            int ww = 864, wh = 662;
            Rectangle rect = Lib.CenterWindow(ww, wh);
            ltf = new LTFrameNetClass("LTFrame-Ipad","Ipad", IntPtr.Zero, Win32DataType.WS_POPUP | Win32DataType.WS_VISIBLE, rect.Left, rect.Top, ww, wh, IntPtr.Zero);
            ltf.SetViewTransparent(true);
            ltf.SetAllowKeyDownAutoScroll(false);
            ltf.loadFile(Lib.GetAppPath + @"./template/ipad/ipad.html");
            ltf.EnableDragFrameChangeSize(false);
            ltf.MessageLoop();
        }
    }
}
