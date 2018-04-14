namespace Class_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201772 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmergencyNewsModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        School = c.Int(nullable: false),
                        Tag = c.String(),
                        Title = c.String(),
                        Lead = c.String(),
                        Context = c.String(),
                        PostBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false, defaultValue: DateTime.Now),
                        Delete = c.Int(nullable: false, defaultValue: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NewsClassModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        School = c.Int(nullable: false),
                        Tag = c.String(),
                        Title = c.String(),
                        Lead = c.String(),
                        Context = c.String(),
                        PostBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false, defaultValue: DateTime.Now),
                        Delete = c.Int(nullable: false, defaultValue: 0),
                        Publish = c.Int(nullable: false,defaultValue: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PictureModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        School = c.Int(nullable: false),
                        Name = c.Guid(nullable: false),
                        FullName = c.String(),
                        CreatedTime = c.DateTime(nullable: false, defaultValue: DateTime.Now),
                        Filename = c.String(),
                        Delete = c.Int(nullable: false, defaultValue: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PostModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        School = c.Int(nullable: false),
                        Tag = c.String(),
                        Title = c.String(),
                        Lead = c.String(),
                        Context = c.String(),
                        PostBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false, defaultValue: DateTime.Now),
                        Delete = c.Int(nullable: false, defaultValue: 0),
                        Publish = c.Int(nullable: false, defaultValue: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TeacherModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        School = c.Int(nullable: false),
                        Name = c.String(),
                        Title = c.String(),
                        Company = c.String(),
                        PictureUrl = c.String(),
                        Detail = c.String(),
                        CreatedDate = c.DateTime(nullable: false, defaultValue: DateTime.Now),
                        Delete = c.Int(nullable: false, defaultValue: 0),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TeacherModels");
            DropTable("dbo.PostModels");
            DropTable("dbo.PictureModels");
            DropTable("dbo.NewsClassModels");
            DropTable("dbo.EmergencyNewsModels");
        }
    }
}
