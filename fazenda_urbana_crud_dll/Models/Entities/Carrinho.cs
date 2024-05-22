using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fazenda_urbana_crud_dll.Models.Entities
{
    public class Carrinho
    {
        private long Id {get; set;}
        private string CodigoCarrinho {get; set;}
        private List<Produto> Produtos {get; set;}
        private Cliente Cliente {get; set;}
        
    }
}