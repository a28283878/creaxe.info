using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Class_Blog.Models
{
    public class Context: DbContext
    {
        public DbSet<NewsClassModels> NewsClass { get; set; }
        public DbSet<PostModels> Post { get; set; }
        public DbSet<EmergencyNewsModels> Emergency { get; set; }
        public DbSet<TeacherModels> Teacher { get; set; }
        public DbSet<PictureModels> Picture { get; set; }
        public DbSet<ClassModels> Class { get; set; }
        public Context()
            : base("name=DefaultConnection")
        {

        }
    }
}