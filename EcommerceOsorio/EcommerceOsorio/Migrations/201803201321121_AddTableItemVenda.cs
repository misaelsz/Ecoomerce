namespace EcommerceOsorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableItemVenda : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItensVenda", "ItemVendaProduto_ProdutoId", "dbo.Produtos");
            DropIndex("dbo.ItensVenda", new[] { "ItemVendaProduto_ProdutoId" });
            DropTable("dbo.ItensVenda");
        }
    }
}
