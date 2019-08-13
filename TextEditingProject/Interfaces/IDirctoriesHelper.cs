﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditingProject.Interfaces
{
    interface IDirctoriesHelper
    {
        List<String> GetDirctories(string Path);
        List<String> GetFiles(string Path);
        Dictionary<string, List<string>> GetDirctoriesAndFiles(string Path);
    }
}
