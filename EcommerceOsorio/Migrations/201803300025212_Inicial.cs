namespace EcommerceOsorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
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
                "dbo.ItensVenda",
                c => new
                    {
                        ItemVendaId = c.Int(nullable: false, identity: true),
                        ItemVendaData = c.DateTime(nullable: false),
                        ItemVendaQuantidade = c.Int(nullable: false),
                        ItemVendaValor = c.Double(nullable: false),
                        ItemVendaCarrinhoId = c.String(),
                        ItemVendaProduto_ProdutoId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemVendaId)
                .ForeignKey("dbo.Produtos", t => t.ItemVendaProduto_ProdutoId)
                .Index(t => t.ItemVendaProduto_ProdutoId);
            
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
            DropForeignKey("dbo.ItensVenda", "ItemVendaProduto_ProdutoId", "dbo.Produtos");
            DropForeignKey("dbo.Produtos", "ProdutoCategoria_CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtos", new[] { "ProdutoCategoria_CategoriaId" });
            DropIndex("dbo.ItensVenda", new[] { "ItemVendaProduto_ProdutoId" });
            DropTable("dbo.Produtos");
            DropTable("dbo.ItensVenda");
            DropTable("dbo.Categorias");
        }
    }
}
