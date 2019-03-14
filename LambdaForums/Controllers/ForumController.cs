﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LambdaForums.Data;
using LambdaForums.Data.Models;
using LambdaForums.Models.Forum;
using LambdaForums.Models.Post;
using Microsoft.AspNetCore.Mvc;

namespace LambdaForums.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;

        public ForumController(IForum forumService)
        {
            _forumService = forumService;

        }

        public IActionResult Index()
        {
         var forums = _forumService.GetAll()
               .Select(f => new ForumListingModel()
           {
               Id = f.Id,
               Name = f.Title,
               Description = f.Description

           });

         var model = new ForumIndexModel()
         {
             ForumList =  forums
         };

         return View(model);
        }

        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetById(id);
            var posts = forum.Posts;

            var postListings = posts.Select(p => new PostListingModel()
            {
                Id = p.Id,
                AuthorId = p.User.Id,
                AuthorRating = p.User.Rating,
                Title = p.Title,
                DatePosted = p.Created.ToString(),
                RepliesCount = p.Replies.Count(),
                Forum = BuildForumListing(p)
                
            });

            var model = new ForumTopicModel()
            {
                Posts = postListings,
                Forum = BuildForumListing(forum)
            };

            return View(model);
        }



        private ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.Forum;
            return BuildForumListing(forum);
        }


        private ForumListingModel BuildForumListing(Forum forum)
        {
            
            return new ForumListingModel()
            {
                Id = forum.Id,
                Name = forum.Title,
                Description = forum.Description,
                ImageUrl = forum.ImageUrl
            };
        }

    }
}