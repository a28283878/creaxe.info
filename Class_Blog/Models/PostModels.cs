using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class_Blog.Models
{
    public class PostModels
    {   
        [Key]
        public int ID { get; set; }
        public int School { get; set; }
        public string Tag { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Lead { get; set; }
        [AllowHtml]
        public string Context { get; set; }
        public string PostBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Delete { get; set; }
        public int Publish { get; set; }
    }
}