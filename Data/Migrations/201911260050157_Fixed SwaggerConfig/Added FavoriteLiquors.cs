namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedSwaggerConfigAddedFavoriteLiquors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FavoriteLiquors", "IsStarred", c => c.Boolean(nullable: false));
            AddColumn("dbo.Recipes", "IsStarred", c => c.Boolean(nullable: false));
            DropColumn("dbo.Liquors", "AverageRating");
            DropColumn("dbo.Recipes", "AverageRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "AverageRating", c => c.Double(nullable: false));
            AddColumn("dbo.Liquors", "AverageRating", c => c.Double(nullable: false));
            DropColumn("dbo.Recipes", "IsStarred");
            DropColumn("dbo.FavoriteLiquors", "IsStarred");
        }
    }
}
