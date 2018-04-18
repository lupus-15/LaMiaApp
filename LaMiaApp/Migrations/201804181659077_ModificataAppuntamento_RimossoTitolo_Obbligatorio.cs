namespace LaMiaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificataAppuntamento_RimossoTitolo_Obbligatorio : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appuntamenti", "Titolo", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appuntamenti", "Titolo", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
