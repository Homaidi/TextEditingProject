using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditingProject.DI;
using TextEditingProject.DIInterfaces;
using TextEditingProject.Interfaces;

namespace TextEditingProject.Components
{
    class EditeText : IEditeText
    {
        private string Input_FolderPath;
        //Replacing Instance
        private Boolean Input_ReplaceText;
        private string Input_TextReplace;
        private string Input_TextReplaceWith;



        private List<string> DirctoriesList = new List<string>();
        private List<string> FilesList = new List<string>();

        private IContainer Container { get; set; }
        private IAutofacDI autofacDI = new AutofacDI();
        #region "Construct"
        public EditeText(params object[] args)
        {
            Input_FolderPath = args[0].ToString();
            Input_ReplaceText = bool.Parse(args[1].ToString());
            Input_TextReplace = args[2].ToString();
            Input_TextReplaceWith = args[3].ToString();
        }
        #endregion

        #region "Start Function"
        public void StartProcessing()
        {
            if (Directory.Exists(Input_FolderPath))
            {
                if(Input_ReplaceText)
                { ReplaceText(); }

            }
            else throw new Exception(" Directory Not Fund ");
        }
        #endregion
        #region "Replace Text"
        private void ReplaceText()
        {
            FillFilesWithenDirctoriesList();
            FillDirctoriesList();
            foreach (var Dirctory in DirctoriesList)
            {
                FillFilesList(Dirctory);
                foreach (var _File in FilesList)
                {
                    string _Extension = Path.GetExtension(_File);
                    string _FileName = Path.GetFileNameWithoutExtension(_File);
                    string _Path = Path.GetDirectoryName(_File);
                    _FileName.Replace(Input_TextReplace, Input_TextReplaceWith);
                    if(_FileName.Length > 0)
                    File.Move(_File, Path.Combine(_Path, _FileName.Trim() + _Extension));
                }
            }
        }
        #endregion
        #region "Fill Lists With Dirctories And Files"
        public void FillDirctoriesList()
        {
            using (var Scope = Container.BeginLifetimeScope())
            {
                var DirctoriesHelper = Scope.Resolve<IDirctoriesHelper>();
                DirctoriesList = DirctoriesHelper.GetDirctories(this.Input_FolderPath);
                DirctoriesList.Reverse();
            }
        }
        public void FillFilesList(string DirctoryPath)
        {
            using (var Scope = Container.BeginLifetimeScope())
            {
                var DirctoriesHelper = Scope.Resolve<IDirctoriesHelper>();
                FilesList = DirctoriesHelper.GetFiles(DirctoryPath);
            }
        }

        public void FillFilesWithenDirctoriesList()
        {
            using (var Scope = Container.BeginLifetimeScope())
            {
                var DirctoriesHelper = Scope.Resolve<IDirctoriesHelper>();
                DirctoriesList = DirctoriesHelper.GetDirctoriesAndFiles(this.Input_FolderPath);
          
            }
        }
        #endregion
    }
}
