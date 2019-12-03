namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ratings : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RecipeRatings", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RecipeRatings", "Rating", c => c.Double(nullable: false));
        }
    }
}
