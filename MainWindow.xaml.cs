using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using System.Xaml;
using System.Xml;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MCLModder
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Vars Vars = new Vars();
            if (Directory.Exists(Vars.userDocFiles))
            { }
            else
            {
                Directory.CreateDirectory(Vars.userDocFiles);
            }
        }

        Vars Vars = new Vars();
        Extra Extra = new Extra();

        string ModFile;
        bool ModC;
        string GameFile;
        bool GameC;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Mod manifist|*.json";
            object FDR = OpenFileDialog.ShowDialog();
            TextBox1.Text = OpenFileDialog.FileName;
            ModFile = OpenFileDialog.FileName;
            ModC = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (GameC == true && ModC == true)
            {
                try
                {
                    var slashM = "\\manifist.json";
                    Vars.modFiles = ModFile.Replace(slashM, "");

                    dynamic jsonfile = JsonConvert.DeserializeObject(File.ReadAllText("C:\\Users\\emanm\\Downloads\\SML\\manifist.json"));

                    string ModName = (jsonfile["Name"]);

                    Directory.Move(Vars.modFiles, Vars.userDocFiles + ModName);

                }
                catch
                {
                    MessageBox.Show("A error happened please close and open the app again");
                }
            }   
        }
    }
}
