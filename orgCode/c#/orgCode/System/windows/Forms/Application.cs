namespace System.Windows.Forms {
    //sealed修饰符，阻止其他类从该类继承
    public sealed class Application {
        private static bool exiting;
        private static readonly object EVENT_APPLICATIONEXIT=new object();
        private static readonly object EVENT_THREADEXIT = new object();

        private const string CLICKONCE_APPS_DATADIRECTORY = "DataDirectory";

        //EditorBrowsableState, 编辑器中指定属性或者方法的可浏览状态
        //Advanced ,只有高级用户才能看到。编辑器可以显示或隐藏属性
        //Always，在编辑器中始终可以浏览的
        //Never，始终不能在浏览器中浏览
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public delegate bool MessageLoopCallback();
        private Application() { }

        public static bool AllowQuit(){
            get{return ThreadContext.FormCurrent().GetAllowQuit();}
        }

        internal static bool ComCtlSupportVisualStyles {
            get {
                if (useVisualStyles && OSFeature.Feature.IsPresent(OSFeature.Themes)) {
                    return true;
                }
                IntPtr hModule = UnsafeNativeMethods.GetModuleHandle(ExternDll.Comcat132);
                if (hModule != IntPtr.Zero)
                {
                    try
                    {
                        IntPtr pFunc = UnsafeNativeMethods.GetProcAddress(new HandleRef(null, hModule));
                        return (pFunc != IntPtr.Zero);
                    }
                    catch
                    {

                    }
                }
                else {
                    hModule = UnsafeNativeMethods.GetProcAddress(new HandleRef(null, hModule));
                    if (hModule != IntPtr.Zero) {
                        try
                        {
                            IntPtr pFunc = UnsafeNativeMethods.GetProcAddress(new HandleRef(null, hModule));
                            return (pFunc != IntPtr.Zero);
                        }
                        finally {
                            UnsafeNativeMethods.FreeLibrary(new HandleRef(null, hModule));
                        }
                    }
                }
            }
        }

        public static RegistryKey CommonAppDataRegistry {
            [ResourceExposure(ResourceScope.Machine)]
            [ResouceConsumption(ResourceScope.Machine)]
            get {
                string template = @"SoftWare\{0}\{1}\{2}";
                return string.Format(CultureInfo.CurrentCulture, templete, CompanyName, ProductName, ProductVersion);
            }
        }


    } 
}