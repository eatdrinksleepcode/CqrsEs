namespace CqrsEs
{
    public class CreateDraftCommandHandler : CommandHandlerBase<CreateDraftCommand>
    {
        public override void Handle(CreateDraftCommand command)
        {
            var sourceOrganization = Repository.GetOrganization(command.OrganizationId);
            sourceOrganization.CreateDraft();
        }
    }
}
