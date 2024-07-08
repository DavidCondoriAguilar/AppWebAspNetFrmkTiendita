namespace AppWebAspNetFrmkTiendita.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Categoria",
                c => new
                    {
                        codcat = c.Int(nullable: false, identity: true),
                        nomcat = c.String(nullable: false, maxLength: 60),
                        estcat = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.codcat);
            
            CreateTable(
                "dbo.T_Producto",
                c => new
                    {
                        codpro = c.Int(nullable: false, identity: true),
                        nompro = c.String(nullable: false, maxLength: 60),
                        despro = c.String(nullable: false, maxLength: 500),
                        prepro = c.Decimal(nullable: false, precision: 18, scale: 2),
                        canpro = c.Decimal(nullable: false, precision: 18, scale: 2),
                        estpro = c.Boolean(nullable: false),
                        codcat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.codpro)
                .ForeignKey("dbo.T_Categoria", t => t.codcat, cascadeDelete: true)
                .Index(t => t.codcat);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Producto", "codcat", "dbo.T_Categoria");
            DropIndex("dbo.T_Producto", new[] { "codcat" });
            DropTable("dbo.T_Producto");
            DropTable("dbo.T_Categoria");
        }
    }
}
