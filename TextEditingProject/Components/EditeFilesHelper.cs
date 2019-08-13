using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TextEditingProject.Interfaces;
using Autofac;
using TextEditingProject.DI;
using TextEditingProject.DIInterfaces;

namespace TextEditingProject.Components
{
    class EditeFilesHelper: IEditeFilesHelper
    {
        object[] args;
        private IContainer Container { get; set; }
        private IAutofacDI autofacDI = new AutofacDI();
        public EditeFilesHelper(params object[] args)
        {Container = autofacDI.GetAutofacContainer();
            this.args = args;
            Container = autofacDI.GetAutofacContainer();
        }
        public void StartProcessing()
        {
            using (var Scope = Container.BeginLifetimeScope())
            {
                var editeText = Scope.Resolve<IEditeText>(new NamedParameter("args", args));
                editeText.StartProcessing();
            }
        }
        public void StartProcessing(params object[] args)
        {

        }
    }
}
