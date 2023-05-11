﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MCLModder
{
    public class Extra
    {
        Vars Vars = new Vars();
        public bool importMod(string modlocation)
        {
            try
            {
                var slashM = "\\manifist.json";
                Vars.modFiles = modlocation.Replace(slashM, "");

                dynamic jsonfile = JsonConvert.DeserializeObject(File.ReadAllText("C:\\Users\\emanm\\Downloads\\SML\\manifist.json"));

                string ModName = (jsonfile["Name"]);

                Directory.Move(Vars.modFiles, Vars.userDocFiles + ModName);
                return true;
            }
            catch
            {
                MessageBox.Show("A error happened please close and open the app again");
                return false;
            }
        }
    }
}
