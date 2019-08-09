using System;
using System.Collections.Generic;
using System.IO;
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
using WinForms = System.Windows.Forms;
namespace TextEditingProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string _FolderPath;
        public string FolderPath
        {
            get
            {
                return _FolderPath;
            }
            set
            {
                _FolderPath = value;
            }
        }
        private void btOpenExplorer_Click(object sender, RoutedEventArgs e)
        {
            WinForms.FolderBrowserDialog fd = new WinForms.FolderBrowserDialog();
            if (Directory.Exists(FolderDirctory.Text))
                fd.SelectedPath = FolderDirctory.Text;
            if (fd.ShowDialog() == WinForms.DialogResult.OK)
            {
                FolderDirctory.Text = fd.SelectedPath;
            }
        }
    }
}
