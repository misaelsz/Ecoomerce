using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceOsorio.Models
{

    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = "No mínimo 5 caracteres!")]
        [MaxLength(50, ErrorMessage = "No máximo 50 caracteres!")]
        [Display(Name = "Nome do Produto")]
        public string ProdutoNome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = "No mínimo 5 caracteres!")]
        [MaxLength(200, ErrorMessage = "No máximo 200 caracteres!")]
        [Display(Name = "Descrição do Produto")]
        [DataType(DataType.MultilineText)]
        public string ProdutoDescricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Quantidade do Produto")]
        [DataType(DataType.Text)]
        [Range(1, 500, ErrorMessage = "Quantidade apenas entre 1 e 500")]
        public int ProdutoQuantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Preço do Produto")]
        public double ProdutoPreco { get; set; }

        [Display(Name = "Imagem do Produto")]
        public string ProdutoImagem { get; set; }

        public Categoria ProdutoCategoria { get; set; }
    }
}