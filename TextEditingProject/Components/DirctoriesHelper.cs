using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditingProject.Components
{
    class DirctoriesHelper
    {
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

        public List<List<string>> GetDirctoriesAndFiles(string Path)
        {
            Dictionary<string, List<string>> FilesWithenDirctoriesList2 = new Dictionary<string, List<string>>();
            List<List<string>> FilesWithenDirctoriesList = new List<List<string>>();
            List<string> DirctoriesList = new List<string>();
            DirctoriesList = Directory.GetDirectories(Path).ToList();
            DirctoriesList.Insert(0, Path);
            DirctoriesList.Reverse();

            foreach (var _Dirctory in DirctoriesList)
            {

                List<string> FilesList = new List<string>();
                FilesList = Directory.GetFiles(_Dirctory).ToList();
                FilesWithenDirctoriesList.Add(FilesList);
                FilesWithenDirctoriesList2.Add(_Dirctory, FilesList);
            }
          
            
            return FilesWithenDirctoriesList;
        }
    }
}
