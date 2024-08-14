namespace Postie.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public User() { }

        public User(string name)
        {
            Name = name;
        }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
