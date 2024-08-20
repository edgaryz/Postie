using Microsoft.EntityFrameworkCore;
using Postie.Core.Contracts;
using Postie.Core.Enums;
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

        public async Task<List<Post>> GetPagedPosts(int pageNumber, int pageSize)
        {
            using (var context = new MyDbContext())
            {
                var posts = await context.Posts.OrderBy(p => p.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

                foreach (var post in posts)
                {
                    context.Entry(post).Reference(x => x.User).Load();
                }
                return posts;
            }
        }

        public async Task<int> GetTotalPostsCount()
        {
            using (var context = new MyDbContext())
            {
                return await context.Posts.CountAsync();
            }
        }

        public async Task<List<Post>> GetPostsByUser(User user)
        {
            using (var context = new MyDbContext())
            {
                var resultList = await context.Posts.Where(p => p.User.Email == user.Email && p.User.Name == user.Name).ToListAsync();
                //to display User as object in return
                foreach (var post in resultList)
                {
                    context.Entry(post).Reference(x => x.User).Load();
                }
                return resultList;
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

        public async Task UpdatePost(int id, Post updatedPost)
        {
            using (var context = new MyDbContext())
            {
                var existingPost = await context.Posts.FindAsync(id);
                if (existingPost != null)
                {
                    existingPost.Title = updatedPost.Title;
                    existingPost.Content = updatedPost.Content;

                    await context.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("Post not found");
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

        public async Task<List<Post>> GetPostsByTitleOrContent(string searchContent = null)
        {
            using (var context = new MyDbContext())
            {
                var resultList = await context.Posts.Where(p => p.Title.Contains(searchContent) || p.Content.Contains(searchContent)).ToListAsync();
                //to display User as object in return
                foreach (var post in resultList)
                {
                    context.Entry(post).Reference(x => x.User).Load();
                }
                return resultList;
            }
        }

        public async Task<List<Post>> GetPostsByCategory(Category category)
        {
            using (var context = new MyDbContext())
            {
                var resultList = await context.Posts.Where(p => p.Category == category).ToListAsync();
                //to display User as object in return
                foreach (var post in resultList)
                {
                    context.Entry(post).Reference(x => x.User).Load();
                }
                return resultList;
            }
        }
    }
}
