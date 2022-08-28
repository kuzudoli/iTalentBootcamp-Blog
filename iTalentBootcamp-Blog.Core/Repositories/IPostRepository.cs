﻿using iTalentBootcamp_Blog.Core.Dtos;
using iTalentBootcamp_Blog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTalentBootcamp_Blog.Core.Repositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<List<Post>> GetPostsWithCategory();
        Task<Post> GetPostByIdWithCategoryAndComments(int id);
        Task<List<Post>> GetPopularPosts(int count);
    }
}
