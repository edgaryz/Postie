using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Postie.Core.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateOnly CreationDate { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public Post() { }

        public Post(string title, string content, DateOnly creationDate)
        {
            Title = title;
            Content = content;
            CreationDate = creationDate;
        }

        public Post(int id, string title, string content, DateOnly creationDate)
        {
            Id = id;
            Title = title;
            Content = content;
            CreationDate = creationDate;
        }
    }
}
