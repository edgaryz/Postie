using Microsoft.EntityFrameworkCore;
using Postie.Core.Contracts;
using Postie.Core.Models;

namespace Postie.Core.Repositories
{
    public class PostDbRepository : IPostDbRepository
    {
        public async Task<List<Post>> GetAllPosts()
        {
            using (var context = new MyDbContext())
            {
                List<Post> allPosts = await context.Posts.ToListAsync();
                //to display User as object in return
                foreach (var post in allPosts)
                {
                    context.Entry(post).Reference(x => x.User).Load();
                }
                return allPosts;
            }
        }

        public async Task<Post> GetPostById(int id)
        {
            using (var context = new MyDbContext())
            {
                //to display User as object in return
                var post = await context.Posts.FindAsync(id);
                context.Entry(post).Reference(x => x.User).Load();
                return post;
            }
        }

        public async Task CreatePost(Post post)
        {
            using (var context = new MyDbContext())
            {
                //AddAsync does not work, so we use Update
                context.Posts.Update(post);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdatePost(Post post)
        {
            using (var context = new MyDbContext())
            {
                try
                {
                    await context.Posts
                        .Where(x => x.Id == post.Id)
                        .ExecuteUpdateAsync(x => x
                            .SetProperty(y => y.Author, post.Author)
                            .SetProperty(y => y.Title, post.Title)
                            .SetProperty(y => y.Content, post.Content)
                            .SetProperty(y => y.CreationDate, post.CreationDate)
                            //.SetProperty(y => y.User, post.User)
                            .SetProperty(y => y.User.Id, post.User.Id)
                            //.SetProperty(y => y.User.Name, post.User.Name)
                            //.SetProperty(y => y.User.Email, post.User.Email)
                            );
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    ex = ex;
                }
            }
        }

        public async Task DeletePost(int id)
        {
            using (var context = new MyDbContext())
            {
                context.Posts.Remove(await context.Posts.FindAsync(id));
                await context.SaveChangesAsync();
            }
        }
    }
}
