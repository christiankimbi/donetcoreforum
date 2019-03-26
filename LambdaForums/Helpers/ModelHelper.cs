using LambdaForums.Data.Models;
using LambdaForums.Models.Forum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaForums.Helpers
{
    public static class ModelHelper
    {

        public static ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.Forum;
            return BuildForumListing(forum);
        }

        public static ForumListingModel BuildForumListing(Forum forum)
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
