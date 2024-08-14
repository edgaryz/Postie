using Microsoft.EntityFrameworkCore;
using Postie.Core.Contracts;
using Postie.Core.Models;

namespace Postie.Core.Repositories
{
    public class PostDbRepository : IPostDbRepository
    {
        public async Task<List<Post>> GetAllPosts()
        {
            using (var context = new PostDbContext())
            {
                List<Post> allPosts = await context.Posts.ToListAsync();
                return allPosts;
            }
        }

        public async Task<Post> GetPostById(int id)
        {
            using (var context = new PostDbContext())
            {
                return await context.Posts.FindAsync(id);
            }
        }

        public async Task CreatePost(Post post)
        {
            using (var context = new PostDbContext())
            {
                await context.Posts.AddAsync(post);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdatePost(Post post)
        {
            using (var context = new PostDbContext())
            {
                await context.Posts
                    .Where(x => x.Id == post.Id)
                    .ExecuteUpdateAsync(x => x
                        .SetProperty(y => y.Author, post.Author)
                        .SetProperty(y => y.Title, post.Title)
                        .SetProperty(y => y.Content, post.Content)
                        .SetProperty(y => y.CreationDate, post.CreationDate)
                        );
                await context.SaveChangesAsync();
            }
        }

        public async Task DeletePost(int id)
        {
            using (var context = new PostDbContext())
            {
                context.Posts.Remove(await context.Posts.FindAsync(id));
                await context.SaveChangesAsync();
            }
        }
    }
}
