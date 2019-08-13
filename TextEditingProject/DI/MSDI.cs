using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TextEditingProject.Components;
using TextEditingProject.DIInterfaces;
using TextEditingProject.Interfaces;

namespace TextEditingProject.DI
{
    class MSDI : IMSDI
    {
    //Transient – Created every time they are requested
    //Scoped – Created once per scope.Most of the time, scope refers to a web request. But this can also be used for any unit of work, such as the execution of an Azure Function.
    //Singleton – Created only for the first request.If a particular instance is specified at registration time, this instance will be provided to all consumers of the registration type.
        private IServiceProvider ServiceProvider { get; set; }
        public IServiceProvider GetIMSDIServiceProvider()
        {
            var Service  = new ServiceCollection();
            Service.AddTransient<IEditeText, EditeText>();
            Service.AddTransient<IDirctoriesHelper, DirctoriesHelper>();
            ServiceProvider = Service.BuildServiceProvider();
            return ServiceProvider;
        }
    }
}
