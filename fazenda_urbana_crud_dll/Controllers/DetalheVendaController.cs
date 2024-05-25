using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fazenda_urbana_crud_dll.Context;
using fazenda_urbana_crud_dll.Models.Db;
using fazenda_urbana_crud_dll.Models.Entities;

namespace fazenda_urbana_crud_dll.Controllers
{
    public class DetalheVendaController : IController
    {
        private readonly FazendaContext _context;

        public DetalheVendaController()
        {
            _context = ContextBuilder.GetContext();
        }

        public bool Create(object o)
        {
            DetalheVenda detalheVenda = (DetalheVenda) o;
            _context.detalheVendas.Add(detalheVenda);
            _context.SaveChanges();

            Console.WriteLine(detalheVenda);

            return true;
        }

        public bool GetById(int id)
        {
            var detalheVendas = _context.detalheVendas.Find(id);

            if(detalheVendas == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            Console.WriteLine(detalheVendas);
            return true;
        }

        public bool GetAll()
        {
            var detalheVendas = _context.detalheVendas.ToList();

            if(detalheVendas == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            foreach(var dv in detalheVendas)
            {
                Console.WriteLine(dv);
                Console.WriteLine();
            }
            return true;
        }

        public bool Update(int id, object o)
        {
            DetalheVenda detalheVenda = (DetalheVenda) o;

            var detalheVendaBanco = _context.detalheVendas.Find(id);

            if(detalheVendaBanco == null)
            {
                Console.WriteLine("Registro não encontrado");
                return false;
            }

            detalheVendaBanco.VendaID = detalheVenda.VendaID;
            detalheVendaBanco.ProdutoID = detalheVenda.ProdutoID;
            detalheVendaBanco.Quantidade = detalheVenda.Quantidade;
            detalheVendaBanco.PrecoUnitario = detalheVenda.PrecoUnitario;
            detalheVendaBanco.Produto = detalheVenda.Produto;

            _context.detalheVendas.Update(detalheVendaBanco);
            _context.SaveChanges();

            Console.WriteLine(detalheVendaBanco);
            return true;
        }

        public bool Delete(int id)
        {
            DetalheVenda detalheVendaBanco = _context.detalheVendas.Find(id);

            _context.detalheVendas.Remove(detalheVendaBanco);
            _context.SaveChanges();

            Console.WriteLine(detalheVendaBanco);
            return true;
        }
    }
}