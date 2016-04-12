using System;
using System.Collections.Generic;
using System.Text;

namespace Canvas
{

    public class Win32DataType
    {


        public static int SW_HIDE { get { return 0; } }
        public static int SW_SHOWNORMAL { get { return 1; } }
        public static int SW_NORMAL { get { return 1; } }
        public static int SW_SHOWMINIMIZED { get { return 2; } }
        public static int SW_SHOWMAXIMIZED { get { return 3; } }
        public static int SW_MAXIMIZE { get { return 3; } }
        public static int SW_SHOWNOACTIVATE { get { return 4; } }
        public static int SW_SHOW { get { return 5; } }
        public static int SW_MINIMIZE { get { return 6; } }
        public static int SW_SHOWMINNOACTIVE { get { return 7; } }
        public static int SW_SHOWNA { get { return 8; } }
        public static int SW_RESTORE { get { return 9; } }
        public static int SW_SHOWDEFAULT { get { return 10; } }
        public static int SW_FORCEMINIMIZE { get { return 11; } }
        public static int SW_MAX { get { return 11; } }

        public static uint WS_VISIBLE
        {
            get { return 0x10000000; }
        }
        public static uint WS_POPUP
        {
            get { return 0x80000000; }
        }
        public static uint WS_CHILD
        {
            get { return 0x40000000; }
        }
    }
}
