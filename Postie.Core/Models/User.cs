using System.ComponentModel.DataAnnotations;

namespace Postie.Core.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User() { }

        public User(int id)
        {
            Id = id;
        }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public User(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}
