using System.IO;
using System.Reflection.Metadata.Ecma335;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MCLModder;

namespace MCLModder
{
    public class Vars
    {
        public string winUsername = System.Environment.UserName;
        public string AppDirectory = Environment.CurrentDirectory;
        public string DocFileDirecotry = "C:\\Users\\" + System.Environment.UserName + "\\Documents\\MCLModder\\";
        public string SMPUuid;
        public string SMPName;
        public string SMPVersion;
        public string SMPType;
    }
} 