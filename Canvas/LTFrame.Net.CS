using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using HBITMAP = System.IntPtr;
using HWND = System.IntPtr;
using LTExecState = System.IntPtr;
namespace LTFrameNet
{
    public class LTFrameNetClass
    {
        private IntPtr _inst;
        private HandleUserMessageCallBack _handleusermessagecallback;
        

        public LTFrameNetClass(string lpWindowName, string lpWindowClassName, IntPtr hWndParent, uint dwStyle,
                                                   int x, int y, int nWidth, int nHeight, IntPtr icon)
        {
            _inst = LTFrameExtern.CreateLTFrameInstance(lpWindowName,lpWindowClassName, hWndParent, dwStyle, x, y, nWidth, nHeight, icon);
        }

        public void SetHandleUserMessageCallBack(HandleUserMessageCallBack fun)
        {
            LTFrameExtern.SetHandleUserMessageCallBackNet(_inst, fun);
            _handleusermessagecallback = fun;
        }



        public void SetOnFinalMessageCallBack(OnFinalMessageCallBack fun)
        {
            LTFrameExtern.SetOnFinalMessageCallBackNet(_inst, fun);
        }

        public void SetOnDropCallBack(OnDropCallBack fun)
        {
            LTFrameExtern.SetOnDropCallBackNet(_inst, fun);
        }

        public void SetOnDragLeaveCallBack(OnDragLeaveCallBack fun)
        {
            LTFrameExtern.SetOnDragLeaveCallBackNet(_inst, fun);
        }

        public void SetOnDragOverCallBack(OnDragOverCallBack fun)
        {
            LTFrameExtern.SetOnDragOverCallBackNet(_inst, fun);
        }

        public void SetOnDragEnterCallBack(OnDragEnterCallBack fun)
        {
            LTFrameExtern.SetOnDragEnterCallBackNet(_inst, fun);
        }

        public int HandleMessage(IntPtr hwnd, uint uMsg, uint wParam, int lParam)
        {
            return  LTFrameExtern.HandleMessageNet(_inst, hwnd, uMsg, wParam, lParam);
        }

        public void BindUserFunction(string name, LTNativeFunction fn, int argCount)
        {
            LTFrameExtern.BindUserFunctionNet(_inst, name, fn, argCount);
        }
        
        public void  MessageLoop()
        {
            LTFrameExtern.MessageLoopNet(_inst);  
        }

        public void loadHTML(string html)
        {
            LTFrameExtern.loadHTMLNet(_inst,html);  
        }

        public void load(string filename)
        {
            LTFrameExtern.loadNet(_inst, filename);  
        }
        public void loadFile(string path)
        {
            LTFrameExtern.loadFileNet(_inst, path);
        }

        public void SetViewTransparent(bool b)
        {
            LTFrameExtern.SetViewTransparentNet(_inst, b);
        }


        public void IsAutoGC(bool b, int maxmemorysize)
        {
            LTFrameExtern.IsAutoGCNet(_inst, b,maxmemorysize);
        }

        public void CleanMemory()
        {
            LTFrameExtern.CleanMemoryNet(_inst);
        }

        public void SetWebSqlPath(string path)
        {
            LTFrameExtern.SetWebSqlPathNet(_inst, path);
        }
        public void SetLocalStoragePath(string path)
        {
            LTFrameExtern.SetLocalStoragePathNet(_inst, path);
        }
        public long RunJavaScript(string script)
        {
            return LTFrameExtern.RunJavaScriptNet(_inst, script);
        }
        public LTExecState GetGlobalExecState()
        {
            return LTFrameExtern.GetGlobalExecStateNet(_inst);
        }
        public HWND windowHandle()
        {
            return LTFrameExtern.windowHandleNet(_inst);
        }
        public void CloseWindow()
        {
            LTFrameExtern.CloseWindowNet(_inst);
        }
        public void QuitApp()
        {
            LTFrameExtern.QuitAppNet(_inst);
        }
        public void GaussianBlurImage(HBITMAP hBitmap, int radius)
        {
            LTFrameExtern.GaussianBlurImageNet(_inst, hBitmap, radius);
        }
        public void SetAllowKeyDownAutoScroll(bool b)
        {
            LTFrameExtern.SetAllowKeyDownAutoScrollNet(_inst,b);
        }
        public void EnableDragFrameChangeSize(bool b)
        {
            LTFrameExtern.EnableDragFrameChangeSizeNet(_inst, b);
        }

        public long Int2JsValue(int n)
        {
            return LTFrameExtern.Int2JsValueNet(n);
        }
        public long Float2JsValue(float f)
        {
            return LTFrameExtern.Float2JsValueNet(f);
        }
        public long Double2JsValue(double d)
        {
            return LTFrameExtern.Double2JsValueNet(d);
        }
        public long Boolean2JsValue(bool b)
        {
            return LTFrameExtern.Boolean2JsValueNet(b);
        }
        public long JsUndefined()
        {
            return LTFrameExtern.JsUndefinedNet();
        }
        public long JsNull()
        {
            return LTFrameExtern.JsNullNet();
        }
        public long JsTrue()
        {
            return LTFrameExtern.JsTrueNet();
        }
        public long JsFalse()
        {
            return LTFrameExtern.JsFalseNet();
        }
        public long String2JsValue(LTExecState es, string str)
        {
            return LTFrameExtern.String2JsValueNet(es, str);
        }
        public int JsValue2Int(LTExecState es, long v)
        {
            return LTFrameExtern.JsValue2IntNet(es, v);
        }
        public float JsValue2Float(LTExecState es, long v)
        {
            return LTFrameExtern.JsValue2FloatNet(es, v);
        }
        public double JsValue2Double(LTExecState es, long v)
        {
            return LTFrameExtern.JsValue2DoubleNet(es, v);
        }
        public bool JsValue2Boolean(LTExecState es, long v)
        {
            return LTFrameExtern.JsValue2BooleanNet(es, v);
        }
        public string JsValue2StringW(LTExecState es, long v) {

            StringBuilder sb = new StringBuilder();
            LTFrameExtern.JsValue2StringWNet(es, v, sb);
            return sb.ToString();
        }
        public string JsValue2String(LTExecState es, long v)
        {          
             StringBuilder sb = new StringBuilder();
             LTFrameExtern.JsValue2StringNet(es, v, sb);
             return sb.ToString();
        }
        public long GetJsParameter(LTExecState es, int argIdx)
        {
            return LTFrameExtern.GetJsParameterNet(es, argIdx);
        }
        public long GetJsObjectParameter(LTExecState es, int argIdx, string key)
        {
            return LTFrameExtern.GetJsObjectParameterNet(es, argIdx, key);
        }
        public long JsCall(LTExecState es, long func, IntPtr args, int argCount) {
            return LTFrameExtern.JsCallNet(es, func, args, argCount);       
        }
        public long CreateJsObject(LTExecState es, long o, IntPtr key, long value)
        {
             return LTFrameExtern.CreateJsObjectNet(es, o, key, value);       
        }
        public long CreateObject(LTExecState es)
        {
            return LTFrameExtern.CreateObjectNet(es);
        }
        public long GetJsObjectAttribute(LTExecState es, long v, string key)
        {
            return LTFrameExtern.GetJsObjectAttributeNet(es, v, key);
        }
        public bool IsJsNumber(long v) {
            return LTFrameExtern.IsJsNumberNet(v);
        }
        public bool IsJsString(long v)
        {
            return LTFrameExtern.IsJsStringNet(v);
        }
        public bool IsJsBoolean(long v)
        {
            return LTFrameExtern.IsJsBooleanNet(v);
        }
        public bool IsJsObject(long v)
        {
            return LTFrameExtern.IsJsObjectNet(v);
        }
        public bool IsJsFunction(long v)
        {
            return LTFrameExtern.IsJsFunctionNet(v);
        }
        public bool IsJsUndefined(long v)
        {
            return LTFrameExtern.IsJsUndefinedNet(v);
        }
        public bool IsJsNull(long v)
        {
            return LTFrameExtern.IsJsNullNet(v);
        }
        public bool IsJsArray(long v)
        {
            return LTFrameExtern.IsJsArrayNet(v);
        }

        public bool IsJsTrue(long v)
        {
            return LTFrameExtern.IsJsTrueNet(v);
        }
        public bool IsJsFalse(long v)
        {
            return LTFrameExtern.IsJsFalseNet(v);
        }


    }
}
