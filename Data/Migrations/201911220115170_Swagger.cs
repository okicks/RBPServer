namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Swagger : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Liquors", "AverageRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Liquors", "AverageRating", c => c.Double(nullable: false));
        }
    }
}
