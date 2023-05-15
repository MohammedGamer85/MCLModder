using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;
using Newtonsoft;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Windows.Controls;

namespace MCLModder
{
    public class Extra
    {
        Vars Vars = new Vars();
        public bool importMod(string modlocation)
        {
            try
            {   //vars
                var slashM = "\\manifist.json";
                Vars.modFiles = modlocation.Replace(slashM, "");

                dynamic jsonfile = JsonConvert.DeserializeObject(File.ReadAllText(modlocation));

                string ModName = (jsonfile["name"]);

                if (Directory.Exists(Vars.userDocFiles + ModName))//Is used to deal with importing duplicate mods
                {
                    Directory.Delete(Vars.userDocFiles + ModName, true);
                    CopyDirectory(Vars.modFiles, Vars.userDocFiles + ModName, true);
                }
                else
                {
                    CopyDirectory(Vars.modFiles, Vars.userDocFiles + ModName, true);

                    try//this stores all imported mods to the mods.json file in a very non-Profitional way.
                    {
                        if (!File.Exists(Vars.userDocFiles + "mods.json"))
                        {
                            File.Create(Vars.userDocFiles + "mods.json");
                        }

                        dynamic modJsonfile = JsonConvert.DeserializeObject(File.ReadAllText(Vars.userDocFiles + "mods.json"));
                        string[] importedMods;
                        if (modJsonfile == null)
                        {
                            importedMods = new string[1];
                            importedMods[0] = ModName;
                        }
                        else
                        {
                            importedMods = modJsonfile["mods"];
                            importedMods[importedMods.Length + 1] = ModName;
                        }

                        MessageBox.Show(Vars.userDocFiles + "mods.json");

                        StringBuilder sb = new StringBuilder();
                        StringWriter sw = new StringWriter(sb);
                        using (JsonWriter writer = new JsonTextWriter(sw))
                        {
                            writer.Formatting = Formatting.Indented;

                            writer.WriteStartObject();
                            writer.WritePropertyName("mods");
                            writer.WriteStartArray();
                            writer.WriteComment("The code that does this is completly shit and needs remaking");
                            for (int i = 0; i < importedMods.Length;)
                            {
                                writer.WriteValue(importedMods[i]);
                                i++; //remove this unneeded line later.
                            }
                            writer.WriteEnd();
                            writer.WriteEndObject();
                        }
                        MessageBox.Show(sb.ToString());
                        File.WriteAllText(Vars.userDocFiles + "mods.json", sb.ToString());

                    }
                    catch
                    {

                    }
                }

                //I hardly can even remember what this was for
                if (applyMod(ModName, modlocation) == true)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Mod Imported but not applyed to game, please try to reapply the mod or contact mod auther");
                }
                return true;
            }
            catch
            {
                MessageBox.Show("A error happened please close and open the app again or contact mod auther");
                return false;
            }
        }
        public bool applyMod(string ModName, string modlocation)
        {
            Vars vars = new Vars();
            string modfiles = modlocation;
            dynamic jsonfile = JsonConvert.DeserializeObject(File.ReadAllText(modfiles));
            string BPLocation = jsonfile["packs"]["behaviorPack"];
            string RPLocation = jsonfile["packs"]["resourcePack"];
            MessageBox.Show(BPLocation + "=============" + RPLocation);
            string GameISPCBP = vars.userAppDataFiles + "internalStorage\\premium_cache\\behavior_packs\\";
            string GameISPCRP = vars.userAppDataFiles + "internalStorage\\premium_cache\\resource_packs\\";
            if (!Directory.Exists(GameISPCBP))
            {
                Directory.CreateDirectory(GameISPCBP);
            }
            if (!Directory.Exists(GameISPCRP))
            {
                Directory.CreateDirectory(GameISPCRP);
            }
            CopyDirectory(vars.userDocFiles + ModName + BPLocation, vars.userAppDataFiles + "internalStorage\\premium_cache\\behavior_packs\\", true);
            CopyDirectory(vars.userDocFiles + ModName + BPLocation, vars.userAppDataFiles + "internalStorage\\premium_cache\\resource_packs\\", true);
            return false;
        }

        public void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }

        public void setSelectedMod(int offSet)
        {
            if (offSet != 0)//if 0 means to load the list
            {
                if (offSet is -1)
                {

                }
                else if (offSet is 1)
                {

                }
                else
                {

                }
            }
            else 
            {

                    //Sets up everything needed for the imported mods list
                dynamic modJsonfile = JsonConvert.DeserializeObject(File.ReadAllText(Vars.userDocFiles + "mods.json"));
                for (int i = 0; modJsonfile["mods"][i-1] != null; i++)
                {
                    if(modJsonfile["mods"][i-1] == null)
                    {
                        break;
                    }   
                    Vars.importedMods[i - 1] = Convert.ToString(modJsonfile["mods"][i - 1]);
                }

                MainWindow mainWindow = new MainWindow();
                mainWindow.TextBox3.Text = Vars.importedMods[0];
                mainWindow.TextBox4.Text = Vars.importedMods[1];
                mainWindow.TextBox5.Text = Vars.importedMods[2];
                mainWindow.TextBox6.Text = Vars.importedMods[3];
                mainWindow.TextBox7.Text = Vars.importedMods[4];

            }
        }
    }
}
