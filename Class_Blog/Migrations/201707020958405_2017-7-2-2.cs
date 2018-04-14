namespace Class_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2017722 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        School = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Name = c.String(),
                        Point = c.Int(nullable: false),
                        Class_teacher = c.Int(nullable: false),
                        Company_teacher = c.Int(nullable: false),
                        Detail = c.String(),
                        Delete = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClassModels");
        }
    }
}
