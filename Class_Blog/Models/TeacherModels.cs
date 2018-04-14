using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class_Blog.Models
{
    public class TeacherModels
    {
        [Key]
        public int ID { get; set; }
        public int School { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string PictureUrl { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Delete { get; set; }
        public int Show { get; set; }
    }
}