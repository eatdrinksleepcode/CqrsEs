using Ninject;

namespace CqrsEs
{
    public class CommandHandlerBase
    {
        [Inject]
        public IDomainRepository Repository { get; set; }
    }
}