using EcommerceOsorio.DAL;
using EcommerceOsorio.Models;
using EcommerceOsorio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceOsorio.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? id)
        {
            ViewBag.Categorias = CategoriaDAO.ListarCategorias();
            if (id == 0 || id == null)
            {
                return View(ProdutoDAO.ListarProdutos());
            }
            return View(ProdutoDAO.ListarProdutosPorCategoria(id));
        }

        public ActionResult AdicionarAoCarrinho(int? id)
        {
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);            
            ItemVendaDAO.CadastrarItemVenda(produto);
            return RedirectToAction("CarrinhoDeCompras", "Home");
        }

        public ActionResult CarrinhoDeCompras()
        {
            ViewBag.Total = ItemVendaDAO.TotalPorCarrinho().ToString("C2");
            Sessao.AtualizarQuantidadeItens();
            return View(ItemVendaDAO.RetonarItensVendaPorSessao());
        }

        public ActionResult RemoverItemCarrinho(int? id)
        {
            ItemVenda iv = ItemVendaDAO.BuscarItemVendaPorId(id);
            ItemVendaDAO.RemoverItemVenda(iv);
            return RedirectToAction("CarrinhoDeCompras", "Home");
        }

        public ActionResult AumentarQuantidadeItemVenda(int? id)
        {
            ItemVenda iv = ItemVendaDAO.BuscarItemVendaPorId(id);
            ItemVendaDAO.AumentarQuantidadeItemVenda(iv);
            return RedirectToAction("CarrinhoDeCompras", "Home");
        }

        public ActionResult DiminuirQuantidadeItemVenda(int? id)
        {
            ItemVenda iv = ItemVendaDAO.BuscarItemVendaPorId(id);
            ItemVendaDAO.DiminuirQuantidadeItemVenda(iv);
            return RedirectToAction("CarrinhoDeCompras", "Home");
        }

        public ActionResult DetalheProduto(int? id)
        {
            return View(ProdutoDAO.BuscarProdutoPorId(id));
        }
    }
}