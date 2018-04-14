using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class_Blog.Models
{

    public class TABlogViewModels
    {
        public List<NewsClassModels> NewsList { get; set; }
        public List<PostModels> PostList { get; set; }
        public EmergencyNewsModels Emergency { get; set;}
        public List<PictureModels> PictureList { get; set; }

        public int PicturesNum { get; set; }
        public int NewsNum { get; set; }
        public int PostNum { get; set; }

        public TABlogViewModels()
        {
            NewsList = new List<NewsClassModels>();
            PostList = new List<PostModels>();
            PictureList = new List<PictureModels>();
        }
    }
}