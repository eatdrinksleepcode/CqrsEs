namespace CqrsEs
{
    public class CreateDraftCommand : ICommand
    {
        public OrganizationId SourceId { get; set; }
    }
}
