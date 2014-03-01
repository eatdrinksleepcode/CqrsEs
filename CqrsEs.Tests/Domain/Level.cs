namespace CqrsEs
{
    public class Level : ILevel
    {
        private readonly string name;

        public Level(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
    }
}