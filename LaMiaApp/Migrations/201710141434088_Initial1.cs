namespace LaMiaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trattamenti", "Appuntamento_Id", "dbo.Appuntamenti");
            DropIndex("dbo.Trattamenti", new[] { "Appuntamento_Id" });
            CreateTable(
                "dbo.TrattamentoAppuntamentoes",
                c => new
                    {
                        Trattamento_Id = c.Int(nullable: false),
                        Appuntamento_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Trattamento_Id, t.Appuntamento_Id })
                .ForeignKey("dbo.Trattamenti", t => t.Trattamento_Id, cascadeDelete: true)
                .ForeignKey("dbo.Appuntamenti", t => t.Appuntamento_Id, cascadeDelete: true)
                .Index(t => t.Trattamento_Id)
                .Index(t => t.Appuntamento_Id);
            
            DropColumn("dbo.Trattamenti", "Appuntamento_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trattamenti", "Appuntamento_Id", c => c.Int());
            DropForeignKey("dbo.TrattamentoAppuntamentoes", "Appuntamento_Id", "dbo.Appuntamenti");
            DropForeignKey("dbo.TrattamentoAppuntamentoes", "Trattamento_Id", "dbo.Trattamenti");
            DropIndex("dbo.TrattamentoAppuntamentoes", new[] { "Appuntamento_Id" });
            DropIndex("dbo.TrattamentoAppuntamentoes", new[] { "Trattamento_Id" });
            DropTable("dbo.TrattamentoAppuntamentoes");
            CreateIndex("dbo.Trattamenti", "Appuntamento_Id");
            AddForeignKey("dbo.Trattamenti", "Appuntamento_Id", "dbo.Appuntamenti", "Id");
        }
    }
}
