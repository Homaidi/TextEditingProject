using Autofac;
using Microsoft.Extensions.DependencyInjection;
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
        private Dictionary<string, List<string>> DirctoriesAndFilesList = new Dictionary<string, List<string>>();

        private IContainer Container { get; set; }
        private IAutofacDI autofacDI = new AutofacDI();
        private IServiceProvider ServiceProvider { get; set; }
        private IMSDI MSDI = new MSDI();
        #region "Constructors"
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
                Container = autofacDI.GetAutofacContainer();
                ServiceProvider = MSDI.GetIMSDIServiceProvider();
                if (Input_ReplaceText)
                { ReplaceText(); }

            }
            else throw new Exception(" Directory Not Fund ");
        }
        #endregion
        #region "Replace Text"
        private void ReplaceText()
        {
            FillFilesWithenDirctoriesList();
            var ReverseFilesWithenDirctoriesList = DirctoriesAndFilesList.Reverse();
            //FillDirctoriesList();
            foreach (var Dirctory in ReverseFilesWithenDirctoriesList)
            {
                //FillFilesList(Dirctory);
                foreach (var _File in Dirctory.Value)
                {
                    string _Extension = Path.GetExtension(_File);
                    string _FileName = Path.GetFileNameWithoutExtension(_File);
                    string _Path = Path.GetDirectoryName(_File);
                    _FileName= _FileName.Replace(Input_TextReplace, Input_TextReplaceWith);
                    if (_FileName.Length > 0)
                        try
                        {
                            File.Move(_File, Path.Combine(_Path, _FileName.Trim() + _Extension));
                        }
                        catch { }

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
                DirctoriesAndFilesList = DirctoriesHelper.GetDirctoriesAndFiles(this.Input_FolderPath);
          
            }
            //var serviceScopeFactory = ServiceProvider.GetRequiredService<IServiceScopeFactory>();
            //using (var scope = serviceScopeFactory.CreateScope())
            //{
            //    var DirctoriesHelper2 = ServiceProvider.GetService<IDirctoriesHelper>();
            //    DirctoriesHelper2.GetDirctoriesAndFiles(this.Input_FolderPath);
            //}
             
        }
        #endregion
    }
}
