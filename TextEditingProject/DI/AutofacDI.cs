using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using TextEditingProject.Components;
using TextEditingProject.DIInterfaces;
using TextEditingProject.Interfaces;

namespace TextEditingProject.DI
{
    class AutofacDI: IAutofacDI
    {
        private IContainer Container { get; set; }
       public IContainer GetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EditeText>().As<IEditeText>();
            builder.RegisterType<DirctoriesHelper>().As<IDirctoriesHelper>();
            Container = builder.Build();
            return Container;
        }

    }
}
