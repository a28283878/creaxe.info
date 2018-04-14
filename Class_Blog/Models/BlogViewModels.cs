using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class_Blog.Models
{

    public class BlogViewModels
    {
        [AllowHtml]
        public List<NewsClassModels> NewsList { get; set; }
        [AllowHtml]
        public List<PostModels> PostList { get; set; }
        public EmergencyNewsModels Emergency { get; set;}
        public int NewsNum { get; set; }
        public int PostNum { get; set; }

        public BlogViewModels()
        {
            NewsList = new List<NewsClassModels>();
            PostList = new List<PostModels>();
        }
    }
}