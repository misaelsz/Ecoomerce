using EcommerceOsorio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EcommerceOsorio.DAL
{
    public class ProdutoDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static List<Produto> ListarProdutos()
        {
            return ctx.Produtos.ToList();
        }
        public static List<Produto> ListarProdutosPorCategoria(int? id)
        {
            return ctx.Produtos.Where(x => x.ProdutoCategoria.CategoriaId == id).ToList();
        }
        public static void CadastrarProduto(Produto produto)
        {
            ctx.Produtos.Add(produto);
            ctx.SaveChanges();
        }

        public static Produto BuscarProdutoPorId(int? id)
        {
            return ctx.Produtos.Find(id);
        }

        public static void EditarProduto(Produto produto)
        {
            ctx.Entry(produto).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void RemoverProduto(Produto produto)
        {
            ctx.Produtos.Remove(produto);
            ctx.SaveChanges();
        }

    }
}