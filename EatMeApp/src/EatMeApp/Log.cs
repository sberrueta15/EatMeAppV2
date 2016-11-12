using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EatMeApp
{
    public class Log
    {

        #region Singleton
        static Log instance;
        Log() { }
        internal static Log GetInstance()
        {
            if (instance == null) instance = new Log();
            return instance;
        }
        #endregion

        private string path { get; set; }

        internal void Init(string logPath) { path = logPath; }

        internal void DoLog(string log)
        {
            try
            {
                using (StreamWriter tw1 = File.AppendText(path))
                {
                    tw1.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + log);
                }
            }
            catch (Exception ex)
            {
            }//*/

        }

    }
}
