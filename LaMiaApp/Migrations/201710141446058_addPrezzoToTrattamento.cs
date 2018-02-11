namespace LaMiaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPrezzoToTrattamento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trattamenti", "Prezzo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trattamenti", "Prezzo");
        }
    }
}
