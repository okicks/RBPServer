namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class swagger : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "AverageRating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "AverageRating");
        }
    }
}
