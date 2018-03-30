namespace EcommerceOsorio.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EcommerceOsorio.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
            if (context.Categorias.Count() == 0 && context.Produtos.Count() == 0)
            {
                GetCategorias().ForEach(c => context.Categorias.Add(c));
                GetProdutos().ForEach(p => context.Produtos.Add(p));
            }
        }

        private static List<Categoria> GetCategorias()
        {
            var categorias = new List<Categoria> {
                new Categoria
                {
                    CategoriaId = 1,
                    CategoriaNome = "Carros",
                    CategoriaDescricao = "Descrição"
                },
                new Categoria
                {
                    CategoriaId = 2,
                    CategoriaNome = "Aviões",
                    CategoriaDescricao = "Descrição"
                },
                new Categoria
                {
                    CategoriaId = 3,
                    CategoriaNome = "Caminhões",
                    CategoriaDescricao = "Descrição"
                },
                new Categoria
                {
                    CategoriaId = 4,
                    CategoriaNome = "Barcos",
                    CategoriaDescricao = "Descrição"
                },
                new Categoria
                {
                    CategoriaId = 5,
                    CategoriaNome = "Foguetes",
                    CategoriaDescricao = "Descrição"
                },
            };

            return categorias;
        }

        private static List<Produto> GetProdutos()
        {
            var Produtos = new List<Produto> {
                new Produto
                {
                    ProdutoId = 1,
                    ProdutoNome = "Convertible Car",
                    ProdutoDescricao = "This convertible car is fast! The engine is powered by a neutrino based battery (not included)." +
                                  "Power it up and let it go!",
                    ProdutoImagem="carconvert.png",
                    ProdutoPreco = 22.50,
                    ProdutoQuantidade = 15
               },
                new Produto
                {
                    ProdutoId = 2,
                    ProdutoNome = "Old-time Car",
                    ProdutoDescricao = "There's nothing old about this toy car, except it's looks. Compatible with other old toy cars.",
                    ProdutoImagem="carearly.png",
                    ProdutoPreco = 15.95,
                    ProdutoQuantidade = 15
               },
                new Produto
                {
                    ProdutoId = 3,
                    ProdutoNome = "Fast Car",
                    ProdutoDescricao = "Yes this car is fast, but it also floats in water.",
                    ProdutoImagem="carfast.png",
                    ProdutoPreco = 32.99,
                    ProdutoQuantidade = 15
                },
                new Produto
                {
                    ProdutoId = 4,
                    ProdutoNome = "Super Fast Car",
                    ProdutoDescricao = "Use this super fast car to entertain guests. Lights and doors work!",
                    ProdutoImagem="carfaster.png",
                    ProdutoPreco = 8.95,
                    ProdutoQuantidade = 15
                },
                new Produto
                {
                    ProdutoId = 5,
                    ProdutoNome = "Old Style Racer",
                    ProdutoDescricao = "This old style racer can fly (with user assistance). Gravity controls flight duration." +
                                  "No batteries required.",
                    ProdutoImagem="carracer.png",
                    ProdutoPreco = 34.95,
                    ProdutoQuantidade = 15
                },
                new Produto
                {
                    ProdutoId = 6,
                    ProdutoNome = "Ace Plane",
                    ProdutoDescricao = "Authentic airplane toy. Features realistic color and details.",
                    ProdutoImagem="planeace.png",
                    ProdutoPreco = 95.00,
                    ProdutoQuantidade = 15
                },
                new Produto
                {
                    ProdutoId = 7,
                    ProdutoNome = "Glider",
                    ProdutoDescricao = "This fun glider is made from real balsa wood. Some assembly required.",
                    ProdutoImagem="planeglider.png",
                    ProdutoPreco = 4.95,
                    ProdutoQuantidade = 15
                },
                new Produto
                {
                    ProdutoId = 8,
                    ProdutoNome = "Paper Plane",
                    ProdutoDescricao = "This paper plane is like no other paper plane. Some folding required.",
                    ProdutoImagem="planepaper.png",
                    ProdutoPreco = 2.95,
                    ProdutoQuantidade = 15
                },
                new Produto
                {
                    ProdutoId = 9,
                    ProdutoNome = "Propeller Plane",
                    ProdutoDescricao = "Rubber band powered plane features two wheels.",
                    ProdutoImagem="planeprop.png",
                    ProdutoPreco = 32.95,
                    ProdutoQuantidade = 15
                },
                new Produto
                {
                    ProdutoId = 10,
                    ProdutoNome = "Early Truck",
                    ProdutoDescricao = "This toy truck has a real gas powered engine. Requires regular tune ups.",
                    ProdutoImagem="truckearly.png",
                    ProdutoPreco = 15.00,
                    ProdutoQuantidade = 15
                },
                new Produto
                {
                    ProdutoId = 11,
                    ProdutoNome = "Fire Truck",
                    ProdutoDescricao = "You will have endless fun with this one quarter sized fire truck.",
                    ProdutoImagem="truckfire.png",
                    ProdutoPreco = 26.00,
                    ProdutoQuantidade = 15
                },
                new Produto
                {
                    ProdutoId = 12,
                    ProdutoNome = "Big Truck",
                    ProdutoDescricao = "This fun toy truck can be used to tow other trucks that are not as big.",
                    ProdutoImagem="truckbig.png",
                    ProdutoPreco = 29.00,
                    ProdutoQuantidade = 15
                },
                new Produto
                {
                    ProdutoId = 13,
                    ProdutoNome = "Big Ship",
                    ProdutoDescricao = "Is it a boat or a ship. Let this floating vehicle decide by using its " +
                                  "artifically intelligent computer brain!",
                    ProdutoImagem="boatbig.png",
                    ProdutoPreco = 95.00,
                    ProdutoQuantidade = 15
                },
                new Produto
                {
                    ProdutoId = 14,
                    ProdutoNome = "Paper Boat",
                    ProdutoDescricao = "Floating fun for all! This toy boat can be assembled in seconds. Floats for minutes!" +
                                  "Some folding required.",
                    ProdutoImagem="boatpaper.png",
                    ProdutoPreco = 4.95,
                    ProdutoQuantidade = 15
                },
                new Produto
                {
                    ProdutoId = 15,
                    ProdutoNome = "Sail Boat",
                    ProdutoDescricao = "Put this fun toy sail boat in the water and let it go!",
                    ProdutoImagem="boatsail.png",
                    ProdutoPreco = 42.95,
                    ProdutoQuantidade = 15
                },
                new Produto
                {
                    ProdutoId = 16,
                    ProdutoNome = "Rocket",
                    ProdutoDescricao = "This fun rocket will travel up to a height of 200 feet.",
                    ProdutoImagem="rocket.png",
                    ProdutoPreco = 122.95,
                    ProdutoQuantidade = 15
                }
            };

            return Produtos;
        }
    }
}
