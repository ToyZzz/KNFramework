using System.Diagnostics;
using System.Reflection;

namespace KNFramework
{
    public static class DebugerExtension
    {
        private static Assembly _assembly;

        public static void Log(this object obj, Debuger.DebugColor debugColor, string msg, object context = null)
        {
            string a = GetLogCallerMethod();
            Debuger.Log(debugColor, GetLogTag(obj), GetLogCallerMethod(), msg, context);
        }

        public static void Log(this object obj, string debugColor, string msg, object context = null)
        {
            Debuger.Log(debugColor, GetLogTag(obj), GetLogCallerMethod(), msg, context);
        }

        public static void Log(this object obj, string msg, object context = null)
        {

        }

        private static string GetLogTag(object obj)
        {
            FieldInfo fi = obj.GetType().GetField("LogTag");
            if (fi != null)
            {
                return (string)fi.GetValue(obj);
            }
            return obj.GetType().Name;
        }




        private static string GetLogCallerMethod()
        {
            StackTrace st = new StackTrace(2, false);
            if (st != null)
            {
                if (_assembly == null)
                {
                    _assembly = typeof(Debuger).Assembly;
                }

                int currStackFrameIndex = 0;
                while (currStackFrameIndex < st.FrameCount)
                {
                    StackFrame oneSf = st.GetFrame(currStackFrameIndex);
                    MethodBase oneMethod = oneSf.GetMethod();
                    if (oneMethod.Module.Assembly != _assembly)
                    {
                    return oneMethod.Name;
                    }
                    currStackFrameIndex++;
                }
            }
            return "";
        }
    }
}
