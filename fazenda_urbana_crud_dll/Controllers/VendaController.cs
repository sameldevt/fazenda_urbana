using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fazenda_urbana_crud_dll.Context;
using fazenda_urbana_crud_dll.Models.Db;
using fazenda_urbana_crud_dll.Models.Entities;

namespace fazenda_urbana_crud_dll.Controllers
{
    public class VendaController : IController
    {
        private readonly FazendaContext _context;

        public VendaController()
        {
            _context = ContextBuilder.GetContext();
        }

        public bool Create(object o)
        {
            Venda venda = (Venda) o;
            _context.vendas.Add(venda);
            _context.SaveChanges();

            Console.WriteLine(venda);

            return true;
        }

        public bool GetById(int id)
        {
            var venda = _context.vendas.Find(id);

            if(venda == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            Console.WriteLine(venda);
            return true;
        }

        public bool GetAll()
        {
            var vendas = _context.vendas.ToList();

            if(vendas == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            foreach(var v in vendas)
            {
                Console.WriteLine(v);
                Console.WriteLine();
            }
            return true;
        }

        public bool Update(int id, object o)
        {
            Venda venda = (Venda) o;

            var vendaBanco = _context.vendas.Find(id);

            if(vendaBanco == null)
            {
                Console.WriteLine("Registro não encontrado");
                return false;
            }

            vendaBanco.ClienteID = venda.ClienteID;
            vendaBanco.DataVenda = venda.DataVenda;
            vendaBanco.ValorTotal = venda.ValorTotal;
            vendaBanco.MetodoPagamento = venda.MetodoPagamento;
            vendaBanco.Cliente = venda.Cliente;
            vendaBanco.DetalhesVenda = venda.DetalhesVenda;

            _context.vendas.Update(vendaBanco);
            _context.SaveChanges();

            Console.WriteLine(vendaBanco);
            return true;
        }

        public bool Delete(int id)
        {
            Venda vendaBanco = _context.vendas.Find(id);

            _context.vendas.Remove(vendaBanco);
            _context.SaveChanges();

            Console.WriteLine(vendaBanco);
            return true;
        }
    }
}