using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class_Blog.Models
{
    public class ClassModels
    {
        [Key]
        public int ID { get; set; }
        public int School { get; set; }
        public int Type { get; set; }//選修必修
        public string Name { get; set; }
        public int Point { get; set; }
        public string Semester { get; set; }
        public int Class_teacher { get; set; }
        public int Company_teacher { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        public TeacherModels ClassTeacher { get; set; }
        public TeacherModels CompanyTeacher { get; set; }
        public int Delete { get; set; }
    }
}