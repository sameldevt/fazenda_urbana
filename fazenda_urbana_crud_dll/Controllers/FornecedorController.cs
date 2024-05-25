using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fazenda_urbana_crud_dll.Context;
using fazenda_urbana_crud_dll.Models.Db;
using fazenda_urbana_crud_dll.Models.Entities;

namespace fazenda_urbana_crud_dll.Controllers
{
    public class FornecedorController : IController
    {
        private readonly FazendaContext _context;

        public FornecedorController()
        {
            _context = ContextBuilder.GetContext();
        }

        public bool Create(object o)
        {
            Fornecedor fornecedor = (Fornecedor) o;
            _context.fornecedores.Add(fornecedor);
            _context.SaveChanges();

            Console.WriteLine(fornecedor);

            return true;
        }

        public bool GetById(int id)
        {
            var fornecedor = _context.fornecedores.Find(id);

            if(fornecedor == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            Console.WriteLine(fornecedor);
            return true;
        }

        public bool GetAll()
        {
            var fornecedores = _context.fornecedores.ToList();

            if(fornecedores == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            foreach(var f in fornecedores)
            {
                Console.WriteLine(f);
                Console.WriteLine();
            }

            return true;
        }

        public bool Update(int id, object o)
        {
            Fornecedor fornecedor = (Fornecedor) o;

            var fornecedorBanco = _context.fornecedores.Find(id);

            if(fornecedorBanco == null)
            {
                Console.WriteLine("Registro não encontrado");
                return false;
            }

            fornecedorBanco.NomeFornecedor = fornecedor.NomeFornecedor;
            fornecedorBanco.Telefone = fornecedor.Telefone;
            fornecedorBanco.Email = fornecedor.Email;
            fornecedorBanco.Endereco = fornecedor.Endereco;

            _context.fornecedores.Update(fornecedorBanco);
            _context.SaveChanges();

            Console.WriteLine(fornecedorBanco);
            return true;
        }

        public bool Delete(int id)
        {
            Fornecedor fornecedorBanco = _context.fornecedores.Find(id);

            _context.fornecedores.Remove(fornecedorBanco);
            _context.SaveChanges();

            Console.WriteLine(fornecedorBanco);
            return true;
        }
    }
}