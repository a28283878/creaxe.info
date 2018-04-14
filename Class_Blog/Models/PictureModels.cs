using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Class_Blog.Models
{
    public class PictureModels
    {
        [Key]
        public int ID { get; set; }
        public int School { get; set; }
        public Guid Name { get; set; }
        public String FullName { get; set; }
        public DateTime CreatedTime { get; set; }
        public String Filename { get; set; }
        public int Delete { get; set; }
    }
}