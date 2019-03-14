using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using LambdaForums.Data.Models;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace LambdaForums.Data
{
    public interface IForum
    {
        Forum GetById(int id);
        IEnumerable<Forum> GetAll();
        IEnumerable<ApplicationUser> GetAllActiveUsers();

        Task Create(Forum forum);
        Task Delete(int forumId);
        Task UpdateForumTitle(int forumId, string newDescription);

    }
}
