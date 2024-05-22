using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fazenda.Models.Entities
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string NomeProduto { get; set; }
        public int CategoriaID { get; set; }
        public decimal PrecoUnitario { get; set; }
        public string Categoria { get; set; }
    }
}