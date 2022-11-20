using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassHold_WF
{
    internal class GetFilePath
    {
        public static string GetFP(string FileName)
        {
            string exepath = Environment.CurrentDirectory;
            string Filepath = exepath + "\\" + FileName;
            return Filepath;
        }
    }
}
