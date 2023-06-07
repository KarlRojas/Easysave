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

        private void Oneexec_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           
            Save.Visibility = Visibility.Visible;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            Process[] pname = Process.GetProcessesByName("CalculatorApp");
            Process[] pname2 = Process.GetProcessesByName("Calculator");
            if (pname.Length > 0)
            {
                MessageBox.Show("Calculator is running, please close it before saving ");
            }
            else if (pname2.Length > 0)
            {
                MessageBox.Show("Calculator is running, please close it before saving ");
            }
            else
            {
                MessageBox.Show("App is not running");
            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("CalculatorApp");
            Process[] pname2 = Process.GetProcessesByName("Calculator");
            if (pname.Length > 0)
            {
                MessageBox.Show("Calculatrice en cours d'execution, fermez la avant sauvegarde");
            }
            else if (pname2.Length > 0)
            {
                MessageBox.Show("Calculatrice en cours d'execution, fermez la avant sauvegarde");
            }
            else
            {
                MessageBox.Show("App pas executé");
            }
        }
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
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
            }
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


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SwitchLanguage("en");
        }
        private void MenuItem_Click1(object sender, RoutedEventArgs e)
        {
            SwitchLanguage("fr");
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
    }
}
