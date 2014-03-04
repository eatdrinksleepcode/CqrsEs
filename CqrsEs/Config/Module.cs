using System.Linq;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace CqrsEs.Config
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            Bind<EventStore>().ToSelf().InSingletonScope();
            Bind<IDomainRepository>().ToMethod(
                    c => new DomainRepository(
                        ((OrganizationId)c.Parameters.Single(p => p.Name == "OrganizationId").GetValue(c, null)), c.Kernel.Get<EventStore>()));
            this.Bind(x =>
                x.FromAssemblyContaining(typeof(ICommand))
                .Select(t => typeof(IHandleCommand).IsAssignableFrom(t))
                .BindAllInterfaces());
        }
    }
}
