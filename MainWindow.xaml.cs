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
using System.Windows.Shapes;
using System.IO;
using System.Xaml;
using System.Xml;
using System.Security;

namespace MCLModder
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string ModFile;
        string GameFile;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Mod manifist|*.json";
            object FDR = OpenFileDialog.ShowDialog();
            TextBox1.Text = OpenFileDialog.FileName;
            ModFile = OpenFileDialog.FileName;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {   
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "gamelaunchhelper|*.exe";
            object FDR = OpenFileDialog.ShowDialog();
            TextBox2.Text = OpenFileDialog.FileName;
            GameFile = OpenFileDialog.FileName;
        }
    }
}
