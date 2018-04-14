using Class_Blog.Migrations;
using Class_Blog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class_Blog.Controllers
{
    public class NtustController : Controller
    {
        private int SchoolID = 1;
        private string SchoolName = "Ntust";
        private int limit_num = 100;
        Context db = new Context();
        // GET: Ntust
        public ActionResult Index()
        {
            BlogViewModels blogs = new BlogViewModels();
            blogs.PostList = db.Post.Where(r => r.School.Equals(SchoolID)).Where(r => r.Delete == 0).Where(r => r.Publish == 1).ToList();
            blogs.NewsList = db.NewsClass.Where(r => r.School.Equals(SchoolID)).Where(r => r.Delete == 0).Where(r => r.Publish == 1).ToList();
            blogs.Emergency = db.Emergency.Where(r => r.School.Equals(SchoolID))
                .Where(r => r.Delete == 0).FirstOrDefault();
            blogs.PostNum = blogs.PostList.Count;
            blogs.NewsNum = blogs.NewsList.Count;
            return View(blogs);
        }

        public ActionResult Info()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.SchoolName = SchoolName;
            var TeacherList = db.Teacher.Where(r => r.School.Equals(SchoolID)).Where(r => r.Delete == 0).Where(r => r.Show == 1).OrderBy(r => r.ID).ToList();
            foreach (var teacher in TeacherList)
            {
                if (!String.IsNullOrEmpty(teacher.Title))
                {
                    teacher.Title = teacher.Title.Replace(',', '\n');
                }
            }
            return View(TeacherList);
        }

        public ActionResult Classes()
        {
            ViewBag.SchoolName = SchoolName;
            List<ClassModels> ClassList = db.Class.Include("ClassTeacher").Include("CompanyTeacher").Where(r => r.School.Equals(SchoolID)).Where(r => r.Delete == 0).OrderBy(r => r.ID).ToList();
            return View(ClassList);
        }

        public ActionResult ClassDetail(int ID)
        {
            ViewBag.SchoolName = SchoolName;
            ClassModels Class = db.Class.Include("ClassTeacher").Include("CompanyTeacher").Where(r => r.ID == ID).Where(r => r.School.Equals(SchoolID)).Where(r => r.Delete == 0).OrderBy(r => r.ID).FirstOrDefault();
            if (Class == null)
            {
                return RedirectToAction("index");
            }
            return View(Class);
        }

        public ActionResult PostPartial(int Pages)
        {
            ViewBag.SchoolName = SchoolName;
            var PostList = db.Post.Where(r => r.School.Equals(SchoolID)).Where(r => r.Delete == 0).Where(r => r.Publish == 1).OrderByDescending(r => r.ID).ToList();
            var Result = new List<PostModels>();
            for (int i = 0; i < limit_num; i++)
            {
                if (Pages * limit_num + i < PostList.Count)
                {
                    Result.Add(PostList[Pages * limit_num + i]);
                }
                else break;
            }
            return PartialView("_PostPartial", Result);
        }

        public ActionResult Post(int ID,int Type)
        {
            var BlogModel = new BlogViewModels();
            if (Type == 0)
            {
                var Emergency = db.Emergency.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).Where(r => r.Delete == 0).FirstOrDefault();
                if (Emergency != null) BlogModel.Emergency = Emergency;
                else
                {
                    return RedirectToAction("index");
                }
                return View(BlogModel);
            }
            else if (Type == 1)
            {
                var News = db.NewsClass.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).Where(r => r.Delete == 0).Where(r => r.Publish == 1).FirstOrDefault();
                if (News != null) BlogModel.NewsList.Add(News);
                else
                {
                    return RedirectToAction("index");
                }
                return View(BlogModel);
            }
            else if (Type == 2)
            {
                var Post = db.Post.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).Where(r => r.Delete == 0).Where(r => r.Publish == 1).FirstOrDefault();
                if (Post != null) BlogModel.PostList.Add(Post);
                else
                {
                    return RedirectToAction("index");
                }
                return View(BlogModel);
            }

            return View();
        }

        [Authorize(Roles = "Admin,NTUST_TA")]
        public ActionResult TAPost(int ID, int Type)
        {
            var BlogModel = new BlogViewModels();
            if (Type == 0)
            {
                var Emergency = db.Emergency.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).Where(r => r.Delete == 0).FirstOrDefault();
                if (Emergency != null) BlogModel.Emergency = Emergency;
                else
                {
                    return RedirectToAction("index");
                }
                return View("Post", BlogModel);
            }
            else if (Type == 1)
            {
                var News = db.NewsClass.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).Where(r => r.Delete == 0).FirstOrDefault();
                if (News != null) BlogModel.NewsList.Add(News);
                else
                {
                    return RedirectToAction("index");
                }
                return View("Post", BlogModel);
            }
            else if (Type == 2)
            {
                var Post = db.Post.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).Where(r => r.Delete == 0).FirstOrDefault();
                if (Post != null) BlogModel.PostList.Add(Post);
                else
                {
                    return RedirectToAction("index");
                }
                return View("Post", BlogModel);
            }

            return View("Post",BlogModel);
        }

        public ActionResult NewsPartial(int Pages)
        {
            ViewBag.SchoolName = SchoolName;
            var NewsList = db.NewsClass.Where(r => r.School.Equals(SchoolID)).Where(r => r.Delete == 0).Where(r => r.Publish == 1).OrderByDescending(r => r.ID).ToList();
            var Result = new List<NewsClassModels>();
            for (int i = 0; i < limit_num; i++)
            {
                if (Pages * limit_num + i < NewsList.Count)
                {
                    Result.Add(NewsList[Pages * limit_num + i]);
                }
                else break;
            }
            return PartialView("_NewsPartial", Result);
        }

        [Authorize(Roles = "Admin,NTUST_TA")]
        public ActionResult TAIndex()
        {
            TABlogViewModels blogs = new TABlogViewModels();
            blogs.PostList = db.Post.Where(r => r.School.Equals(SchoolID)).Where(r => r.Delete == 0).ToList();
            blogs.NewsList = db.NewsClass.Where(r => r.School.Equals(SchoolID)).Where(r => r.Delete == 0).ToList();
            blogs.Emergency = db.Emergency.Where(r => r.School.Equals(SchoolID))
                .Where(r => r.Delete == 0).FirstOrDefault();
            blogs.PictureList = db.Picture.Where(r => r.School.Equals(SchoolID)).Where(r => r.Delete == 0).ToList();
            blogs.PostNum = blogs.PostList.Count;
            blogs.NewsNum = blogs.NewsList.Count;
            blogs.PicturesNum = blogs.PictureList.Count;

            return View(blogs);
        }

        [Authorize(Roles = "Admin,NTUST_TA")]
        public ActionResult TAPostPartial(int Pages)
        {
            ViewBag.SchoolName = SchoolName;
            var PostList = db.Post.Where(r => r.School.Equals(SchoolID)).Where(r => r.Delete == 0).OrderByDescending(r => r.ID).ToList();
            var Result = new List<PostModels>();
            for (int i = 0; i < limit_num; i++)
            {
                if (Pages * limit_num + i < PostList.Count)
                {
                    Result.Add(PostList[Pages * limit_num + i]);
                }
                else break;
            }
            return PartialView("_TAPostPartial", Result);
        }

        [Authorize(Roles = "Admin,NTUST_TA")]
        public ActionResult TANewsPartial(int Pages)
        {
            ViewBag.SchoolName = SchoolName;
            var NewsList = db.NewsClass.Where(r => r.School.Equals(SchoolID)).Where(r => r.Delete == 0).OrderByDescending(r => r.ID).ToList();
            var Result = new List<NewsClassModels>();
            for (int i = 0; i < limit_num; i++)
            {
                if (Pages * limit_num + i < NewsList.Count)
                {
                    Result.Add(NewsList[Pages * limit_num + i]);
                }
                else break;
            }
            return PartialView("_TANewsPartial", Result);
        }

        [Authorize(Roles = "Admin,NTUST_TA")]
        public ActionResult TAPicturesPartial(int Pages)
        {
            ViewBag.SchoolName = SchoolName;
            var NewsList = db.Picture.Where(r => r.School.Equals(SchoolID)).Where(r => r.Delete == 0).OrderByDescending(r => r.ID).ToList();
            var Result = new List<PictureModels>();
            for (int i = 0; i < limit_num; i++)
            {
                if (Pages * limit_num + i < NewsList.Count)
                {
                    Result.Add(NewsList[Pages * limit_num + i]);
                }
                else break;
            }
            return PartialView("_TAPicturesPartial", Result);
        }

        [Authorize(Roles = "Admin,NTUST_TA")]
        public ActionResult Edit(int ID, int Type)
        {
            var BlogModel = new BlogViewModels();
            if (Type == 0)
            {
                var Emergency = db.Emergency.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).FirstOrDefault();
                if (Emergency != null) BlogModel.Emergency = Emergency;
                return View(BlogModel);
            }
            else if (Type == 1)
            {
                var News = db.NewsClass.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).FirstOrDefault();
                if (News != null) BlogModel.NewsList.Add(News);
                return View(BlogModel);
            }
            else if (Type == 2)
            {
                var Post = db.Post.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).FirstOrDefault();
                if (Post != null) BlogModel.PostList.Add(Post);
                return View(BlogModel);
            }

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,NTUST_TA")]
        [ValidateInput(false)]
        public ActionResult Edit(int ID, int Type, String Title, String Tag, String Lead, String Context)
        {
            if(Type == 0)
            {
                var Emergency = db.Emergency.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).FirstOrDefault();
                Emergency.Title = Title;
                Emergency.Tag = Tag;
                Emergency.Lead = Lead;
                Emergency.Context = Context;

                db.SaveChanges();
            }
            else if (Type == 1)
            {
                var New = db.NewsClass.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).FirstOrDefault();
                New.Title = Title;
                New.Tag = Tag;
                New.Lead = Lead;
                New.Context = Context;

                db.SaveChanges();
            }
            else if (Type == 2)
            {
                var Post = db.Post.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).FirstOrDefault();
                Post.Title = Title;
                Post.Tag = Tag;
                Post.Lead = Lead;
                Post.Context = Context;

                db.SaveChanges();
            }

            return RedirectToAction("TAIndex");
        }

        [Authorize(Roles = "Admin,NTUST_TA")]
        public ActionResult Delete(int ID, int Type)
        {
            var BlogModel = new BlogViewModels();
            if (Type == 0)
            {
                var Emergency = db.Emergency.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).FirstOrDefault();
                if (Emergency != null) Emergency.Delete = 1;
            }
            else if (Type == 1)
            {
                var News = db.NewsClass.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).FirstOrDefault();
                if (News != null) News.Delete = 1;
            }
            else if (Type == 2)
            {
                var Post = db.Post.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).FirstOrDefault();
                if (Post != null) Post.Delete = 1;
            }
            db.SaveChanges();
            return RedirectToAction("TAIndex");
        }

        [Authorize(Roles = "Admin,NTUST_TA")]
        public ActionResult DeletePic(int ID)
        {
            var Picture = db.Picture.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).FirstOrDefault();
            if (Picture != null) Picture.Delete = 1;
            db.SaveChanges();
            return RedirectToAction("TAIndex");
        }

        [Authorize(Roles = "Admin,NTUST_TA")]
        public ActionResult Create(int Type)
        {
            ViewBag.Type = Type;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,NTUST_TA")]
        public ActionResult Create(int Type, String Title, String Tag, String Lead, String Context)
        {
            if(Type == 0)
            {
                var Emergency = new EmergencyNewsModels();
                Emergency.Title = Title;
                Emergency.Tag = Tag;
                Emergency.Lead = Lead;
                Emergency.Context = Context;
                Emergency.CreatedDate = DateTime.Now;
                Emergency.School = SchoolID;
                Emergency.Delete = 0;
                Emergency.PostBy = "TA";

                db.Emergency.Add(Emergency);

                db.SaveChanges();
            }
            else if (Type == 1)
            {
                var New = new NewsClassModels();
                New.Title = Title;
                New.Tag = Tag;
                New.Lead = Lead;
                New.Context = Context;
                New.CreatedDate = DateTime.Now;
                New.School = SchoolID;
                New.Delete = 0;
                New.PostBy = "TA";

                db.NewsClass.Add(New);

                db.SaveChanges();
            }
            else if (Type == 2)
            {
                var Post = new PostModels();
                Post.Title = Title;
                Post.Tag = Tag;
                Post.Lead = Lead;
                Post.Context = Context;
                Post.CreatedDate = DateTime.Now;
                Post.School = SchoolID;
                Post.Delete = 0;
                Post.PostBy = "TA";

                db.Post.Add(Post);

                db.SaveChanges();
            }

            return RedirectToAction("TAIndex");
        }

        [HttpPost]
        [Authorize(Roles = "Admin,NTUST_TA")]
        public int UploadPicture(HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (file.ContentLength > 800 * 1024)
                {
                    return 400;
                }
                if (file.ContentLength > 0)
                {
                    Guid name = Guid.NewGuid();
                    var fileName = name + "." + Path.GetFileName(file.ContentType);
                    var path = Path.Combine(Server.MapPath("~/img/" + SchoolName), fileName);
                    file.SaveAs(path);

                    PictureModels Picture = new PictureModels();
                    Picture.Filename = Path.GetFileName(file.FileName);
                    Picture.Name = name;
                    Picture.FullName = string.Format("/img/{0}/",SchoolName) + fileName;
                    Picture.School = SchoolID;
                    Picture.CreatedTime = DateTime.Now;

                    db.Picture.Add(Picture);
                    db.SaveChanges();
                    return 200;
                }
            }
            return 500;
        }

        [Authorize(Roles = "Admin,NTUST_TA")]
        public ActionResult Publish(int ID ,int Type)
        {
            if(Type == 1)
            {
                var New = db.NewsClass.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).FirstOrDefault();
                if (New != null) New.Publish = 1;
                db.SaveChanges();
            }
            else if(Type == 2)
            {
                var Post = db.Post.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).FirstOrDefault();
                if (Post != null) Post.Publish = 1;
                db.SaveChanges();
            }

            return RedirectToAction("TAIndex");
        }

        [Authorize(Roles = "Admin,NTUST_TA")]
        public ActionResult Unpublish(int ID, int Type)
        {
            if (Type == 1)
            {
                var New = db.NewsClass.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).FirstOrDefault();
                if (New != null) New.Publish = 0;
                db.SaveChanges();
                return RedirectToAction("TAIndex");
            }
            else if (Type == 2)
            {
                var Post = db.Post.Where(r => r.School.Equals(SchoolID)).Where(r => r.ID == ID).FirstOrDefault();
                if (Post != null) Post.Publish = 0;
                db.SaveChanges();
                return RedirectToAction("TAIndex");
            }

            return RedirectToAction("TAIndex");
        }
    }
}