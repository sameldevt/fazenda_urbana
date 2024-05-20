using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace fazenda_urbana_crud_dll.Models.Entities
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string NomeCliente { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }

        public override string ToString()
        {
            return $"Id: {ClienteID}\nNome: {NomeCliente}\nTelefone: {Telefone}\nEmail: {Email}\nEndereço: {Endereco}";
        }
    }
}