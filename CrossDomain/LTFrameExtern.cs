using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LTFrameNet
{
   [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct POINTL
    {
        public int x;
        public int y;
    }

   public delegate Int32 HandleUserMessageCallBack(IntPtr hwnd, uint uMsg, uint wParam, int lParam);
    

    public delegate void OnFinalMessageCallBack();
    public delegate bool OnDropCallBack(IntPtr pDataObject, uint grfKeyState, POINTL pt, IntPtr pdwEffect);
    public delegate bool OnDragLeaveCallBack();
    public delegate bool OnDragOverCallBack(uint grfKeyState, POINTL pt, IntPtr pdwEffect);
    public delegate bool OnDragEnterCallBack(IntPtr pDataObject, uint grfKeyState, POINTL pt, IntPtr pdwEffect);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate long LTNativeFunction(IntPtr ptr);
    public class LTFrameExtern
    {
        [DllImport("LTFrame.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr CreateLTFrameInstance(string lpWindowName, string lpWindowClassName, IntPtr hWndParent, uint dwStyle, int x, int y, int nWidth, int nHeight, IntPtr icon);        

        [DllImport("LTFrame.dll")]
        public static extern void SetHandleUserMessageCallBackNet(IntPtr c, HandleUserMessageCallBack C2);

        [DllImport("LTFrame.dll")]
        public static extern void SetOnFinalMessageCallBackNet(IntPtr obj, OnFinalMessageCallBack fun);

        [DllImport("LTFrame.dll")]
        public static extern void SetOnDropCallBackNet(IntPtr obj, OnDropCallBack fun);

        [DllImport("LTFrame.dll")]
        public static extern void SetOnDragLeaveCallBackNet(IntPtr obj, OnDragLeaveCallBack fun);

        [DllImport("LTFrame.dll")]
        public static extern void SetOnDragOverCallBackNet(IntPtr obj, OnDragOverCallBack fun);

        [DllImport("LTFrame.dll")]
        public static extern void SetOnDragEnterCallBackNet(IntPtr obj, OnDragEnterCallBack fun);
      
        [DllImport("LTFrame.dll")]
        public static extern Int32 HandleMessageNet(IntPtr c, IntPtr hwnd, uint uMsg, uint wParam, int lParam);

        [DllImport("LTFrame.dll", CharSet = CharSet.Ansi)]
        public static extern void BindUserFunctionNet(IntPtr es, string name, LTNativeFunction fn, int argCount);

        [DllImport("LTFrame.dll")]
        public static extern void MessageLoopNet(IntPtr c);

        [DllImport("LTFrame.dll", CharSet = CharSet.Unicode)]
        public static extern void loadHTMLNet(IntPtr obj,string html);

        [DllImport("LTFrame.dll", CharSet = CharSet.Unicode)]
        public static extern void loadNet(IntPtr obj,string filename);

        [DllImport("LTFrame.dll", CharSet = CharSet.Unicode)]
        public static extern void loadFileNet(IntPtr obj,string filename);

        [DllImport("LTFrame.dll")]
        public static extern void SetViewTransparentNet(IntPtr obj,bool b);

        [DllImport("LTFrame.dll")]
        public static extern void IsAutoGCNet(IntPtr obj,bool b,int maxmemorysize);

        [DllImport("LTFrame.dll")]
        public static extern void CleanMemoryNet(IntPtr obj);

        [DllImport("LTFrame.dll", CharSet = CharSet.Unicode)]
        public static extern void SetWebSqlPathNet(IntPtr obj,string path);

        [DllImport("LTFrame.dll", CharSet = CharSet.Unicode)]
        public static extern void SetLocalStoragePathNet(IntPtr obj,string path);

        [DllImport("LTFrame.dll", CharSet = CharSet.Unicode)]
        public static extern long RunJavaScriptNet(IntPtr obj,string script);

        [DllImport("LTFrame.dll")]
        public static extern IntPtr GetGlobalExecStateNet(IntPtr obj);

        [DllImport("LTFrame.dll")]
        public static extern IntPtr windowHandleNet(IntPtr obj);

        [DllImport("LTFrame.dll")]
        public static extern void CloseWindowNet(IntPtr obj);

        [DllImport("LTFrame.dll")]
        public static extern void QuitAppNet(IntPtr obj);

        [DllImport("LTFrame.dll")]
        public static extern void GaussianBlurImageNet(IntPtr obj, IntPtr hBitmap, int radius);

        [DllImport("LTFrame.dll")]
        public static extern void SetAllowKeyDownAutoScrollNet(IntPtr obj,bool b);

        [DllImport("LTFrame.dll")]
        public static extern void EnableDragFrameChangeSizeNet(IntPtr obj,bool b);

        [DllImport("LTFrame.dll")]
        public static extern long Int2JsValueNet(int n);

        [DllImport("LTFrame.dll")]
        public static extern long Float2JsValueNet(float f);

        [DllImport("LTFrame.dll")]
        public static extern long Double2JsValueNet(double d);

        [DllImport("LTFrame.dll")]
        public static extern long Boolean2JsValueNet(bool b);

        [DllImport("LTFrame.dll")]
        public static extern long JsUndefinedNet();

        [DllImport("LTFrame.dll")]
        public static extern long JsNullNet();

        [DllImport("LTFrame.dll")]
        public static extern long JsTrueNet();

        [DllImport("LTFrame.dll")]
        public static extern long JsFalseNet();

        [DllImport("LTFrame.dll", CharSet = CharSet.Unicode)]
        public static extern long String2JsValueNet(IntPtr es, string str);

        [DllImport("LTFrame.dll")]
        public static extern int JsValue2IntNet(IntPtr es, long v);

        [DllImport("LTFrame.dll")]
        public static extern float JsValue2FloatNet(IntPtr es, long v);

        [DllImport("LTFrame.dll")]
        public static extern double JsValue2DoubleNet(IntPtr es, long v);

        [DllImport("LTFrame.dll")]
        public static extern bool JsValue2BooleanNet(IntPtr es, long v);

        [DllImport("LTFrame.dll", CharSet = CharSet.Unicode)]
        public static extern int JsValue2StringWNet(IntPtr es, long v, StringBuilder result);

        [DllImport("LTFrame.dll", CharSet = CharSet.Ansi)]
        public static extern int JsValue2StringNet(IntPtr es, long v, StringBuilder result);

        [DllImport("LTFrame.dll")]
        public static extern long GetJsParameterNet(IntPtr es, int argIdx);

        [DllImport("LTFrame.dll", CharSet = CharSet.Ansi)]
        public static extern long GetJsObjectParameterNet(IntPtr es, int argIdx, string key);

        [DllImport("LTFrame.dll")]
        public static extern long JsCallNet(IntPtr es, long func, IntPtr args, int argCount);

        [DllImport("LTFrame.dll", CharSet = CharSet.Ansi)]
        public static extern long CreateJsObjectNet(IntPtr es, long o, IntPtr key, long value);

        [DllImport("LTFrame.dll")]
        public static extern long CreateObjectNet(IntPtr es);

        [DllImport("LTFrame.dll", CharSet = CharSet.Ansi)]
        public static extern long GetJsObjectAttributeNet(IntPtr es, long v, string key);

        [DllImport("LTFrame.dll")]
        public static extern bool IsJsNumberNet(long v);

        [DllImport("LTFrame.dll")]
        public static extern bool IsJsStringNet(long v);

        [DllImport("LTFrame.dll")]
        public static extern bool IsJsBooleanNet(long v);

        [DllImport("LTFrame.dll")]
        public static extern bool IsJsObjectNet(long v);

        [DllImport("LTFrame.dll")]
        public static extern bool IsJsFunctionNet(long v);

        [DllImport("LTFrame.dll")]
        public static extern bool IsJsUndefinedNet(long v);

        [DllImport("LTFrame.dll")]
        public static extern bool IsJsNullNet(long v);

        [DllImport("LTFrame.dll")]
        public static extern bool IsJsArrayNet(long v);

        [DllImport("LTFrame.dll")]
        public static extern bool IsJsTrueNet(long v);

        [DllImport("LTFrame.dll")]
        public static extern bool IsJsFalseNet(long v);
    }
}
