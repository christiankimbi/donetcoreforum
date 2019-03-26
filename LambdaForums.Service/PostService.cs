using LambdaForums.Data;
using LambdaForums.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaForums.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Post post)
        {
            _context.Posts.Add(post);
           await  _context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id, string content)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts
                 .Include(p => p.User)
                .Include(p => p.Forum)
                .Include(p => p.Replies)
                    .ThenInclude(r => r.User);
        }


        public Post GetById(int id)
        {
            return _context.Posts
                .Where(p => p.Id == id)
                .Include(p => p.User)
                .Include(p=>p.Forum)
                .Include(p => p.Replies)
                    .ThenInclude(r=>r.User)
                .FirstOrDefault();
        }

        public IEnumerable<Post> GetFilteredPosts(Forum forum, string searchQuery)
        {
            return string.IsNullOrEmpty(searchQuery) ? forum.Posts :
                forum.Posts
                .Where(p => 
                p.Title.ToLower().Contains(searchQuery.ToLower()) 
                || p.Content.ToLower().Contains(searchQuery.ToLower()));
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            var posts = GetAll().ToList()
            .Where(p =>
              p.Title.ToLower().Contains(searchQuery.ToLower())
              || p.Content.ToLower().Contains(searchQuery.ToLower()));

            return posts;
        }

        public IEnumerable<Post> GetPostsByForum(int id)
        {
            var posts = _context.Forums.
                Where(f => f.Id == id)
                .First()
                .Posts;
            return posts;
        }

        public string GetForumImageUrl(int id)
        {
            var post = GetById(id);
            return post.Forum.ImageUrl;
        }


        public IEnumerable<Post> GetLatestPosts(int count)
        {
            var allPosts = GetAll().OrderByDescending(post => post.Created);
            return allPosts.Take(count);
        }

        public int GetReplyCount(int id)
        {
            return GetById(id).Replies.Count();
        }
    }
}
