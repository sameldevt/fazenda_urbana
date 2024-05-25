using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fazenda_urbana_crud_dll.Context;
using fazenda_urbana_crud_dll.Models.Db;
using fazenda_urbana_crud_dll.Models.Entities;

namespace fazenda_urbana_crud_dll.Controllers
{
    public class PagamentoController : IController
    {
        private readonly FazendaContext _context;

        public PagamentoController()
        {
            _context = ContextBuilder.GetContext();
        }

        public bool Create(object o)
        {
            Pagamento pagamento = (Pagamento) o;
            _context.pagamentos.Add(pagamento);
            _context.SaveChanges();

            Console.WriteLine(pagamento);

            return true;
        }

        public bool GetById(int id)
        {
            var pagamento = _context.pagamentos.Find(id);

            if(pagamento == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            Console.WriteLine(pagamento);
            return true;
        }

        public bool GetAll()
        {
            var pagamentos = _context.pagamentos.ToList();

            if(pagamentos == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }
            foreach(var p in pagamentos)
            {
                Console.WriteLine(p);
                Console.WriteLine();
            }
            return true;
        }

        public bool Update(int id, object o)
        {
            Pagamento pagamento = (Pagamento) o;

            var pagamentoBanco = _context.pagamentos.Find(id);

            if(pagamentoBanco == null)
            {
                Console.WriteLine("Registro não encontrado");
                return false;
            }

            pagamentoBanco.VendaID = pagamento.VendaID;
            pagamentoBanco.DataPagamento = pagamento.DataPagamento;
            pagamentoBanco.ValorPagamento = pagamento.ValorPagamento;
            pagamentoBanco.MetodoPagamento = pagamento.MetodoPagamento;
            pagamentoBanco.Venda = pagamento.Venda;

            _context.pagamentos.Update(pagamentoBanco);
            _context.SaveChanges();

            Console.WriteLine(pagamentoBanco);
            return true;
        }

        public bool Delete(int id)
        {
            Pagamento pagamentoBanco = _context.pagamentos.Find(id);

            _context.pagamentos.Remove(pagamentoBanco);
            _context.SaveChanges();

            Console.WriteLine(pagamentoBanco);
            return true;
        }
    }
}