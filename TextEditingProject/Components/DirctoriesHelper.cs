using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditingProject.Interfaces;

namespace TextEditingProject.Components
{
   public class DirctoriesHelper : IDirctoriesHelper
    {
        Dictionary<string, List<string>> FilesWithenDirctoriesList ;
        public List<String> GetDirctories(string Path)
        {
            List<string> DirctoriesList = new List<string>();           
            DirctoriesList = Directory.GetDirectories(Path).ToList();
            DirctoriesList.Insert(0, Path);
            return DirctoriesList;
        }

        public List<String> GetFiles(string Path)
        {
            List<string> FilesList = new List<string>();
            FilesList = Directory.GetFiles(Path).ToList();
            return FilesList;
        }

        public Dictionary<string, List<string>> GetDirctoriesAndFiles(string Path)
        {
            FilesWithenDirctoriesList = new Dictionary<string, List<string>>();
            //FilesWithenDirctoriesList.Reverse();
            PrapearDirctoriesAndFiles(Path);
            //FilesWithenDirctoriesList.Reverse();
           //var ReverseFilesWithenDirctoriesList = FilesWithenDirctoriesList.Reverse();
            return FilesWithenDirctoriesList;
        }
        private Dictionary<string, List<string>> PrapearDirctoriesAndFiles(string Path)
        {
            //List<List<string>> FilesWithenDirctoriesList = new List<List<string>>();
            List<string> DirctoriesList = new List<string>();
            DirctoriesList = Directory.GetDirectories(Path).ToList();
            if (!FilesWithenDirctoriesList.ContainsKey(Path))
            DirctoriesList.Insert(0, Path);
            //DirctoriesList.Reverse();

            foreach (var _Dirctory in DirctoriesList)
            {

                List<string> FilesList = new List<string>();
                FilesList = Directory.GetFiles(_Dirctory).ToList();
                //FilesWithenDirctoriesList.Add(FilesList);
                if (!FilesWithenDirctoriesList.ContainsKey(_Dirctory))
                FilesWithenDirctoriesList.Add(_Dirctory, FilesList);
                PrapearDirctoriesAndFiles(_Dirctory);
            }
            return FilesWithenDirctoriesList;
        }
    }
}
