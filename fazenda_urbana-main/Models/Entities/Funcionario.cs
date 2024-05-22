using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fazenda.Models.Entities
{
    public class Funcionario
    {
        public int FuncionarioID { get; set; }
        public string NomeFuncionario { get; set; }
        public string Cargo { get; set; }
        public DateTime DataContratacao { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
    }
}