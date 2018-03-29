using EcommerceOsorio.Models;
using EcommerceOsorio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceOsorio.DAL
{
    public class ItemVendaDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static void CadastrarItemVenda(Produto produto)
        {
            string carrinhoId = Sessao.RetornarCarrinhoId();

            ItemVenda itemVenda = ctx.ItensVenda.
                FirstOrDefault(x => x.ItemVendaProduto.ProdutoId ==
                produto.ProdutoId &&
                x.ItemVendaCarrinhoId.Equals(carrinhoId));

            if (itemVenda != null)
            {
                itemVenda.ItemVendaQuantidade++;
                ctx.Entry(itemVenda).State =
                    System.Data.Entity.EntityState.Modified;
            }
            else
            {
                itemVenda = new ItemVenda
                {
                    ItemVendaData = DateTime.Now,
                    ItemVendaQuantidade = 1,
                    ItemVendaValor = produto.ProdutoPreco,
                    ItemVendaProduto = produto,
                    ItemVendaCarrinhoId = Sessao.RetornarCarrinhoId()
                };
                ctx.ItensVenda.Add(itemVenda);
            }
            ctx.SaveChanges();
        }

        public static ItemVenda BuscarItemVendaPorId(int? id)
        {
            return ctx.ItensVenda.Find(id);
        }

        public static void RemoverItemVenda(ItemVenda iv)
        {
            ctx.ItensVenda.Remove(iv);
            ctx.SaveChanges();
        }

        public static void AumentarQuantidadeItemVenda(ItemVenda iv)
        {
            iv.ItemVendaQuantidade++;
            ctx.Entry(iv).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void DiminuirQuantidadeItemVenda(ItemVenda iv)
        {
            if (iv.ItemVendaQuantidade == 1)
            {
                RemoverItemVenda(iv);
            }
            else
            {
                iv.ItemVendaQuantidade--;
                ctx.Entry(iv).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
        public static List<ItemVenda> RetonarItensVendaPorSessao()
        {
            string carrinhoId = Sessao.RetornarCarrinhoId();

            return ctx.ItensVenda.
                Include("ItemVendaProduto").
                Where(x => x.ItemVendaCarrinhoId.Equals(carrinhoId)).
                ToList();
        }

        public static int ContarItensCarrinho()
        {
            return RetonarItensVendaPorSessao().Sum(x => x.ItemVendaQuantidade);
        }

        public static double TotalPorCarrinho()
        {
            return RetonarItensVendaPorSessao().Sum(x => x.ItemVendaQuantidade * x.ItemVendaValor);
        }
    }
}