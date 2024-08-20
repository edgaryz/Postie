using Postie.Core.Enums;
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
        public Category Category { get; set; }

        public Post() { }

        public Post(string title, string content, DateOnly creationDate, Category category)
        {
            Title = title;
            Content = content;
            CreationDate = creationDate;
            Category = category;
        }

        public Post(int id, string title, string content, DateOnly creationDate, Category category)
        {
            Id = id;
            Title = title;
            Content = content;
            CreationDate = creationDate;
            Category = category;
        }
    }
}
