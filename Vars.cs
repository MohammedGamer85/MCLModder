using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MCLModder
{
    public class Vars
    {
        public string gameFiles;
        public string modFiles;
        public string userDocFiles = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MCLModder\\";
        public string userAppDataFiles = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\";
    }
}