using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceOsorio.Models
{
    [Table("ItensVenda")]
    public class ItemVenda
    {
        [Key]
        public int ItemVendaId { get; set; }
        public Produto ItemVendaProduto { get; set; }
        public DateTime ItemVendaData { get; set; }
        public int ItemVendaQuantidade { get; set; }
        public double ItemVendaValor { get; set; }
        public string ItemVendaCarrinhoId { get; set; }

    }
}