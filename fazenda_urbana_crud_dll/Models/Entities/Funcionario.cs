using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fazenda_urbana_crud_dll.Models.Entities
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

        public override string ToString()
        {
            return $"Id: {FuncionarioID}\nNomeFuncionario: {NomeFuncionario}\nCargo: {Cargo}\nDataContratacao: {DataContratacao}\nEmail: {Email}\nEndereco: {Endereco}";
        }
    }
}