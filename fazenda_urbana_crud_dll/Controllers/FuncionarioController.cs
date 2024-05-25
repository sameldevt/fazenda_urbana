using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fazenda_urbana_crud_dll.Context;
using fazenda_urbana_crud_dll.Models.Db;
using fazenda_urbana_crud_dll.Models.Entities;

namespace fazenda_urbana_crud_dll.Controllers
{
    public class FuncionarioController : IController
    {
        private readonly FazendaContext _context;

        public FuncionarioController()
        {
            _context = ContextBuilder.GetContext();
        }

        public bool Create(object o)
        {
            Funcionario funcionario = (Funcionario) o;
            _context.funcionarios.Add(funcionario);
            _context.SaveChanges();

            Console.WriteLine(funcionario);

            return true;
        }

        public bool GetById(int id)
        {
            var funcionario = _context.funcionarios.Find(id);

            if(funcionario == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            Console.WriteLine(funcionario);
            return true;
        }

        public bool GetAll()
        {
            var funcionarios = _context.funcionarios.ToList();

            if(funcionarios == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            foreach(var f in funcionarios)
            {
                Console.WriteLine(f);
                Console.WriteLine();
            }
            return true;
        }

        public bool Update(int id, object o)
        {
            Funcionario funcionario = (Funcionario) o;

            var funcionarioBanco = _context.funcionarios.Find(id);

            if(funcionarioBanco == null)
            {
                Console.WriteLine("Registro não encontrado");
                return false;
            }

            funcionarioBanco.NomeFuncionario = funcionario.NomeFuncionario;
            funcionarioBanco.Cargo = funcionario.Cargo;
            funcionarioBanco.DataContratacao = funcionario.DataContratacao;
            funcionarioBanco.Telefone = funcionario.Telefone;
            funcionarioBanco.Email = funcionario.Email;
            funcionarioBanco.Endereco = funcionario.Endereco;

            _context.funcionarios.Update(funcionarioBanco);
            _context.SaveChanges();

            Console.WriteLine(funcionarioBanco);
            return true;
        }

        public bool Delete(int id)
        {
            Funcionario funcionarioBanco = _context.funcionarios.Find(id);

            _context.funcionarios.Remove(funcionarioBanco);
            _context.SaveChanges();

            Console.WriteLine(funcionarioBanco);
            return true;
        }
    }
}