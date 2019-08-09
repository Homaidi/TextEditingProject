using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditingProject.Interfaces
{
    interface IEditeFilesHelper
    {
        void StartProcessing(params Object[] args);
        void StartProcessing();
    }
}
