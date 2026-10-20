namespace BrandNewDayHeroesMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        HeroeId = c.Int(nullable: false, identity: true),
                        NombreHeroe = c.String(nullable: false),
                        Alias = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HeroeId);
            
            CreateTable(
                "dbo.Trajes",
                c => new
                    {
                        TrajeId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TrajeId);
            
            CreateTable(
                "dbo.TrajeHeroes",
                c => new
                    {
                        Traje_TrajeId = c.Int(nullable: false),
                        Heroe_HeroeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Traje_TrajeId, t.Heroe_HeroeId })
                .ForeignKey("dbo.Trajes", t => t.Traje_TrajeId, cascadeDelete: true)
                .ForeignKey("dbo.Heroes", t => t.Heroe_HeroeId, cascadeDelete: true)
                .Index(t => t.Traje_TrajeId)
                .Index(t => t.Heroe_HeroeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrajeHeroes", "Heroe_HeroeId", "dbo.Heroes");
            DropForeignKey("dbo.TrajeHeroes", "Traje_TrajeId", "dbo.Trajes");
            DropIndex("dbo.TrajeHeroes", new[] { "Heroe_HeroeId" });
            DropIndex("dbo.TrajeHeroes", new[] { "Traje_TrajeId" });
            DropTable("dbo.TrajeHeroes");
            DropTable("dbo.Trajes");
            DropTable("dbo.Heroes");
        }
    }
}
