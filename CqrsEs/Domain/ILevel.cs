namespace CqrsEs
{
    public interface ILevel
    {
        LevelId Id { get; }
        string Name { get; }
    }
}
