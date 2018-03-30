using EcommerceOsorio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EcommerceOsorio.DAL
{
    public class CategoriaDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static List<Categoria> ListarCategorias()
        {
            return ctx.Categorias.ToList();
        }

        public static void CadastrarCategoria(Categoria categoria)
        {
            ctx.Categorias.Add(categoria);
            ctx.SaveChanges();
        }

        public static Categoria BuscarCategoriaPorId(int? id)
        {
            return ctx.Categorias.Find(id);
        }

        public static void EditarCategoria(Categoria categoria)
        {
            ctx.Entry(categoria).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void RemoverCategoria(Categoria categoria)
        {
            ctx.Categorias.Remove(categoria);
            ctx.SaveChanges();
        }

    }
}