using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using MCLModder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace MCLModder
{
        public class PvPhotbarGUI
        {
            public string SelectedPreset { get; set; }
            public string PresetName { get; set; }
            public string[] resourcingHotbar { get; set; }
            public string[] mobsHotbar { get; set; }
            public string[] utilityHotbar { get; set; }
            public string[] villageHotbar { get; set; }
            public string Path { get; set; }

            public PvPhotbarGUI(string SelectedPreset, string PresetName, string hotbar, string data, int slot)
            {
                this.SelectedPreset = SelectedPreset;
                this.PresetName = PresetName;
                publicVars publicVars = new publicVars();
                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);
                this.Path = publicVars.gameFilesPath + "/content/data/game_mode/behavior_packs/pvp/services/in_game_ui_pvp";
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartObject();
                    writer.WritePropertyName("SelectedPreset");
                    writer.WriteValue(SelectedPreset);
                    writer.WritePropertyName("PresetName");
                    writer.WriteValue(PresetName);
                    writer.WriteStartArray();
                    writer.WriteValue("resourcing");
                    writer.WriteStartArray();
                    for(int i = 0; i <= resourcingHotbar.Length;) { writer.WriteValue(resourcingHotbar[i]); }
                    writer.WriteEndArray();
                    writer.WriteValue("mobs");
                    writer.WriteStartArray();
                    for(int i = 0; i <= mobsHotbar.Length;) { writer.WriteValue(mobsHotbar[i]); }
                    writer.WriteEndArray();
                    writer.WriteValue("utility");
                    writer.WriteStartArray();
                    for (int i = 0; i <= utilityHotbar.Length;) { writer.WriteValue(utilityHotbar[i]); }
                    writer.WriteEndArray();
                    writer.WriteValue("village");
                    writer.WriteStartArray();
                    for (int i = 0; i <= villageHotbar.Length;) { writer.WriteValue(villageHotbar[i]); }
                    writer.WriteEndArray();
                    writer.WriteEndArray();
                    writer.WriteEndObject();
                }
            }
        }
}

