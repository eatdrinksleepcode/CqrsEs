using Moq;
using Ninject;
using Ninject.MockingKernel.Moq;
using NUnit.Framework;

namespace CqrsEs
{
    internal class CommandHandlerTestsBase<T>
    {
        protected MoqMockingKernel kernel;
        protected Mock<IDomainRepository> repository;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            kernel = new MoqMockingKernel();
        }

        [SetUp]
        public void Before()
        {
            repository = kernel.GetMock<IDomainRepository>();
        }

        protected T CreateHandler()
        {
            return kernel.Get<T>();
        }
    }
}