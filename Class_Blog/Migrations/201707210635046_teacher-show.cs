namespace Class_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teachershow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TeacherModels", "Show", c => c.Int(nullable: false,defaultValue:1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TeacherModels", "Show");
        }
    }
}
