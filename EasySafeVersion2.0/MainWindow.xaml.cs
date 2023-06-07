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
using System.Diagnostics;
using System.ComponentModel;
using System.IO;
namespace EasySafeVersion2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SwitchLanguage("en");
            MenuEN.IsChecked = true;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            Save.Visibility = Visibility.Collapsed;




        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }



        private void Button_Click_3(object sender, RoutedEventArgs e)
        {


            Save.Visibility = Visibility.Visible;


        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            

        }

        private void Execution(object sender, RoutedEventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("CalculatorApp");
            Process[] pname2 = Process.GetProcessesByName("Calculator");

            if (pname.Length > 0 && MenuEN.IsChecked == true)
            {
                MessageBox.Show("Calculator is running, please close it before saving ");
            }
            else if (pname2.Length > 0 && MenuEN.IsChecked == true)
            {
                MessageBox.Show("Calculator is running, please close it before saving ");
            }
            else if (MenuEN.IsChecked == true && pname2.Length == 0 && pname.Length == 0)
            {
                MessageBox.Show("App is not running");
            }

            if (pname.Length > 0 && MenuFR.IsChecked == true)
            {
                MessageBox.Show("Calculatrice en cours d'execution, fermez la avant sauvegarde");
            }
            else if (pname2.Length > 0 && MenuFR.IsChecked == true)
            {
                MessageBox.Show("Calculatrice en cours d'execution, fermez la avant sauvegarde");
            }
            else if(MenuFR.IsChecked == true && pname2.Length == 0 && pname.Length ==0)
            {
                MessageBox.Show("App pas executée");

                if (Encryptbutton.IsChecked == true)
                {

                    string path = @"/K cd ..\Cryptosoft&&Cryptosoft.exe source C:\Users\kemlu\source\repos\EasySafe2\crypt\hello.txt destination C:\Users\kemlu\source\repos\EasySafe2\crypt\decrypt1.txt";
                    Process process = new Process();
                    var startInfo = new ProcessStartInfo("cmd.exe", path);
                    //startInfo.CreateNoWindow = true;
                    //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo = startInfo;

                    process.Start();
                }
            }

            if (RbJson.IsChecked == true)
            {
                Logfile obj = new Logfile();
                obj.createJsonFile();
            }
            else
            {
                Logfile obj = new Logfile();
                obj.createXmlFile();
            }

            



        }
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog folderBrowser = new Microsoft.Win32.OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == true)
            {
                FileNameTextBox.Text = System.IO.Path.GetDirectoryName(folderBrowser.FileName);
                // ...
            }
            //Create OpenFileDialog
            /*Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.InitialDirectory = @"C:";
            openFileDlg.Multiselect = true;
            //openFileDlg.Filter = "All files (.)|.";
            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();

            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                FileNameTextBox.Text = openFileDlg.FileName;
                TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }*/
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BrowseButton_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
       
        private void SwitchLanguage(string languageCode)
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            switch (languageCode)
            {
                case "en":
                    dictionary.Source = new Uri("..\\Anglais.xaml", UriKind.Relative);
                    break;
                case "fr":
                    dictionary.Source = new Uri("..\\Francais.xaml", UriKind.Relative);
                    break;
                default:
                    dictionary.Source = new Uri("..\\Anglais.xaml", UriKind.Relative);
                    break;
            }
            this.Resources.MergedDictionaries.Add(dictionary);
        }

        private void Destinationbutton(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog folderBrowser = new Microsoft.Win32.OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == true)
            {
                Destinationtextbox.Text = System.IO.Path.GetDirectoryName(folderBrowser.FileName);
                // ...
            }
        }


        private void Destinationtextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void selectEnglish(object sender, RoutedEventArgs e)
        {
            MenuFR.IsChecked = false;
            MenuEN.IsChecked = true;
            SwitchLanguage("en");
        }

        private void selectFrench(object sender, RoutedEventArgs e)
        {
            MenuEN.IsChecked = false;
            MenuFR.IsChecked = true;
            SwitchLanguage("fr");
        }
    }
}