using DevExpress.Mvvm;
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
using TextEditingProject.Components;
using TextEditingProject.Interfaces;
using WinForms = System.Windows.Forms;
namespace TextEditingProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region "Cunstactor"
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion
        #region "Instances"
        private string _FolderPath;
        private Boolean _ReplaceText;
        private string _TextToReplace;
        private string _TextToReplaceWith;
        #endregion
        #region "Properties"
        public string FolderPath
        {
            get{return _FolderPath; }
            set {_FolderPath = value;}
        }
        public Boolean ReplaceText
        {
            get{return _ReplaceText; }
            set{ _ReplaceText = value;}
        }
        public string TextToReplace
        {
            get { return _TextToReplace; }
            set { _TextToReplace = value; }
        }
        public string TextToReplaceWith
        {
            get { return _TextToReplaceWith; }
            set { _TextToReplaceWith = value; }
        }
        #endregion
        #region "Command"
        private AsyncCommand StartCommand => new AsyncCommand(() => Task.Factory.StartNew(StartProcess));
        #endregion
        #region "Functions"
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

        /// <summary>
        /// Start A New Thread ,So A WaitCursor Appear Will Processe The Editing
        /// </summary>
        private void StartProcess()
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                using (new WaitCursor())
                {
                    Excute();
                }
            }));
        }
        IEditeFilesHelper editeFilesHelper;
        private void Excute()
        {
            if (FolderPath.Length > 0)
            {
                editeFilesHelper = new EditeFilesHelper(FolderPath, ReplaceText, TextToReplace, TextToReplaceWith);
                editeFilesHelper.StartProcessing();
            }
            else throw new Exception(" Path Is Empty ");
        }
        #endregion
    }
}
