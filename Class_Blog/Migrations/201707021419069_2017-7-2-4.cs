namespace Class_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2017724 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassModels", "ClassTeacher_ID", c => c.Int());
            AddColumn("dbo.ClassModels", "CompanyTeacher_ID", c => c.Int());
            CreateIndex("dbo.ClassModels", "ClassTeacher_ID");
            CreateIndex("dbo.ClassModels", "CompanyTeacher_ID");
            AddForeignKey("dbo.ClassModels", "ClassTeacher_ID", "dbo.TeacherModels", "ID");
            AddForeignKey("dbo.ClassModels", "CompanyTeacher_ID", "dbo.TeacherModels", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassModels", "CompanyTeacher_ID", "dbo.TeacherModels");
            DropForeignKey("dbo.ClassModels", "ClassTeacher_ID", "dbo.TeacherModels");
            DropIndex("dbo.ClassModels", new[] { "CompanyTeacher_ID" });
            DropIndex("dbo.ClassModels", new[] { "ClassTeacher_ID" });
            DropColumn("dbo.ClassModels", "CompanyTeacher_ID");
            DropColumn("dbo.ClassModels", "ClassTeacher_ID");
        }
    }
}
