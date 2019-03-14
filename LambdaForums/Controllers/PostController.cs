
using System;
using System.Collections.Generic;
using System.Linq;
using LambdaForums.Data;
using LambdaForums.Data.Models;
using LambdaForums.Models.Post;
using LambdaForums.Models.Reply;
using Microsoft.AspNetCore.Mvc;

namespace LambdaForums.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;

        public PostController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);
            var replies = builPostRepliesModel(post.Replies);

            var model = new PostIndexModel()
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorImageUrl = post.User.ProfileImageUrl,
                AuthorRating = post.User.Rating,
                Created = post.Created,
                PostContent = post.Content,
                Replies = replies


            };
            return View(model);
        }

        private IEnumerable<PostReplyModel> builPostRepliesModel(IEnumerable<PostReply> replies)
        {
            return replies.Select(p => new PostReplyModel() {

                Id = p.Id,
                ReplyContent = p.Content,
                Created = p.Created,
                AuthorId = p.User.Id,
                AuthorName = p.User.UserName,
                AuthorImageUrl = p.User.ProfileImageUrl,
                AuthorRating = p.User.Rating,
                PostId = p.Post.Id
               

            });
        }
    }
}