namespace CqrsEs
{
    public class OrganizationCommandBase : ICommand
    {
        public OrganizationId OrganizationId { get; set; }
    }
}
