namespace EcommerceOsorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        CategoriaNome = c.String(nullable: false, maxLength: 50),
                        CategoriaDescricao = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        ProdutoNome = c.String(nullable: false, maxLength: 50),
                        ProdutoDescricao = c.String(nullable: false, maxLength: 200),
                        ProdutoQuantidade = c.Int(nullable: false),
                        ProdutoPreco = c.Double(nullable: false),
                        ProdutoImagem = c.String(),
                        ProdutoCategoria_CategoriaId = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Categorias", t => t.ProdutoCategoria_CategoriaId)
                .Index(t => t.ProdutoCategoria_CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "ProdutoCategoria_CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtos", new[] { "ProdutoCategoria_CategoriaId" });
            DropTable("dbo.Produtos");
            DropTable("dbo.Categorias");
        }
    }
}
