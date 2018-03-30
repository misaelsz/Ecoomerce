using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceOsorio.Models;
using EcommerceOsorio.DAL;

namespace EcommerceOsorio.Controllers
{
    public class ProdutosController : Controller
    {

        // GET: Produtos
        public ActionResult Index()
        {
            return View(ProdutoDAO.ListarProdutos());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.Categorias = new SelectList(
                CategoriaDAO.ListarCategorias(),
                "CategoriaId", "CategoriaNome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoId,ProdutoNome,ProdutoDescricao,ProdutoQuantidade,ProdutoPreco")] Produto produto, int Categorias, HttpPostedFileBase fupImagem)
        {
            ViewBag.Categorias = new SelectList(CategoriaDAO.ListarCategorias(), "CategoriaId", "CategoriaNome");
            if (ModelState.IsValid)
            {
                if (fupImagem != null)
                {
                    //Gravar imagem
                    string nomeImagem = fupImagem.FileName;
                    string caminho = System.IO.Path.Combine(
                        Server.MapPath("~/Images/"), nomeImagem);

                    fupImagem.SaveAs(caminho);
                    produto.ProdutoImagem = nomeImagem;


                    produto.ProdutoCategoria =
                        CategoriaDAO.BuscarCategoriaPorId(Categorias);
                    ProdutoDAO.CadastrarProduto(produto);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Favor escolher uma imagem!");
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoId,ProdutoNome,ProdutoDescricao,ProdutoQuantidade,ProdutoPreco")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                ProdutoDAO.EditarProduto(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            ProdutoDAO.RemoverProduto(produto);
            return RedirectToAction("Index");
        }
    }
}
