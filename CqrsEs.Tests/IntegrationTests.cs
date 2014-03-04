using System;
using CqrsEs.Config;
using FluentAssertions;
using Ninject;
using Ninject.Parameters;
using NUnit.Framework;

namespace CqrsEs
{
    class IntegrationTests
    {
        private IKernel kernel;
        private EventStore eventStore;
        readonly OrganizationId mainOrganizationId = new OrganizationId();
        private CommandBus bus;

        [SetUp]
        public void Before()
        {
            kernel = new StandardKernel(new Module());

            eventStore = kernel.Get<EventStore>();
            eventStore.Add(mainOrganizationId, new DraftCreatedEvent(mainOrganizationId, null));

            bus = kernel.Get<CommandBus>();
        }

        private TResult HandleCommand<TCommand, TEvent, TResult>(TCommand command, Func<TEvent, TResult> selector)
            where TCommand : ICommand 
            where TEvent : IDomainEvent
        {
            TResult result = default(TResult);
            DomainEvents.Register((TEvent it) => result = selector(it));
            bus.DeliverCommand(command);
            return result;
        }

        private IDomainRepository GetRepository(OrganizationId organizationId)
        {
            return kernel.Get<IDomainRepository>(new Parameter("OrganizationId", organizationId, true));
        }

        [Test]
        public void ShouldTieItAllTogether()
        {
            var structureId = HandleCommand(new CreateStructureCommand
            {
                OrganizationId = mainOrganizationId,
                StructureName = "My Structure"
            }, (StructureCreatedEvent it) => it.EntityId);
            var level1Id = HandleCommand(new CreateLevelCommand
            {
                OrganizationId = mainOrganizationId, 
                StructureId = structureId, 
                LevelName = "Level 1"
            }, (LevelCreatedEvent it) => it.EntityId);
            var draft1Id = HandleCommand(new CreateDraftCommand
            {
                OrganizationId = mainOrganizationId
            }, (DraftCreatedEvent it) => it.EntityId);
            var level2Id = HandleCommand(new CreateLevelCommand
            {
                OrganizationId = mainOrganizationId, 
                StructureId = structureId, 
                LevelName = "Level 2"
            }, (LevelCreatedEvent it) => it.EntityId);
            var level3Id = HandleCommand(new CreateLevelCommand
            {
                OrganizationId = draft1Id, 
                StructureId = structureId, 
                LevelName = "Level 2"
            }, (LevelCreatedEvent it) => it.EntityId);

            var mainRepo = GetRepository(mainOrganizationId);
            mainRepo.Invoking(it => it.GetLevel(level1Id)).ShouldNotThrow<MissingEntityException>();
            mainRepo.Invoking(it => it.GetLevel(level2Id)).ShouldNotThrow<MissingEntityException>();
            mainRepo.Invoking(it => it.GetLevel(level3Id)).ShouldThrow<MissingEntityException>();

            var draftRepo = GetRepository(draft1Id);
            draftRepo.Invoking(it => it.GetLevel(level1Id)).ShouldNotThrow<MissingEntityException>();
            draftRepo.Invoking(it => it.GetLevel(level3Id)).ShouldNotThrow<MissingEntityException>();
            draftRepo.Invoking(it => it.GetLevel(level2Id)).ShouldThrow<MissingEntityException>();
        }
    }
}
