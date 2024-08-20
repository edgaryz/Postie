﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Post>> GetPostsByTitleOrContent(string title = null, string content = null)
        {
            using (var context = new MyDbContext())
            {
                var resultList = await context.Posts.Where(p => p.Title.Contains(title) || p.Content.Contains(content)).ToListAsync();
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
