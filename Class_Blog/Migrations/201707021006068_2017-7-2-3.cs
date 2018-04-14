namespace Class_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2017723 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassModels", "Semester", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClassModels", "Semester");
        }
    }
}
