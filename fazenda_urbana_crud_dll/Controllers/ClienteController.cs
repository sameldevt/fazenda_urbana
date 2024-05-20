using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fazenda_urbana_crud_dll.Context;
using fazenda_urbana_crud_dll.Models.Db;
using fazenda_urbana_crud_dll.Models.Entities;

namespace fazenda_urbana_crud_dll.Controllers
{
    public class ClienteController : IController
    {
        private readonly FazendaContext _context;

        public ClienteController()
        {
            _context = ContextBuilder.GetContext();
        }

        public bool Create(object o)
        {
            Cliente cliente = (Cliente) o;
            _context.clientes.Add(cliente);
            _context.SaveChanges();

            Console.WriteLine(cliente);

            return true;
        }

        public bool GetById(int id)
        {
            var cliente = _context.clientes.Find(id);

            if(cliente == null)
            {
                Console.WriteLine("Registro não encontrado");
                return false;
            }

            Console.WriteLine(cliente);
            return true;
        }

        public bool GetAll()
        {
            var clientes = _context.clientes.ToList();

            if(clientes == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            Console.WriteLine(clientes);
            return true;
        }

        public bool Update(int id, object o)
        {
            Cliente cliente = (Cliente) o;

            var clienteBanco = _context.clientes.Find(id);

            if(clienteBanco == null)
            {
                Console.WriteLine("Registro não encontrado");
                return false;
            }

            clienteBanco.NomeCliente = cliente.NomeCliente;
            clienteBanco.Telefone = cliente.Telefone;
            clienteBanco.Email = cliente.Email;
            clienteBanco.Endereco = cliente.Endereco;

            _context.clientes.Update(clienteBanco);
            _context.SaveChanges();

            Console.WriteLine(clienteBanco);
            return true;
        }

        public bool Delete(int id)
        {
            Cliente clienteBanco = _context.clientes.Find(id);

            _context.clientes.Remove(clienteBanco);
            _context.SaveChanges();

            Console.WriteLine(clienteBanco);
            return true;
        }
    }
}