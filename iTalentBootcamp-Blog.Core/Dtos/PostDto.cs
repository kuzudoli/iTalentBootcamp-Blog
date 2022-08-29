﻿using iTalentBootcamp_Blog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTalentBootcamp_Blog.Core.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int LikeCount { get; set; }
        public string CreatedAtShortString
        {
            get
            {
                return CreatedAt.ToShortDateString();
            }
            set
            {
                CreatedAtShortString = value;
            }
        }
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
    }
}