using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fazenda_urbana_crud_dll.Context;
using fazenda_urbana_crud_dll.Models.Db;
using fazenda_urbana_crud_dll.Models.Entities;

namespace fazenda_urbana_crud_dll.Controllers
{
    public class ProducaoController : IController
    {
        private readonly FazendaContext _context;

        public ProducaoController()
        {
            _context = ContextBuilder.GetContext();
        }

        public bool Create(object o)
        {
            Producao producao = (Producao) o;
            _context.producoes.Add(producao);
            _context.SaveChanges();

            Console.WriteLine(producao);

            return true;
        }

        public bool GetById(int id)
        {
            var producao = _context.producoes.Find(id);

            if(producao == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            Console.WriteLine(producao);
            return true;
        }

        public bool GetAll()
        {
            var producoes = _context.producoes.ToList();

            if(producoes == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            Console.WriteLine(producoes);
            return true;
        }

        public bool Update(int id, object o)
        {
            Producao producao = (Producao) o;

            var producaoBanco = _context.producoes.Find(id);

            if(producaoBanco == null)
            {
                Console.WriteLine("Registro não encontrado");
                return false;
            }

            producaoBanco.ProdutoID = producao.ProdutoID;
            producaoBanco.FornecedorID = producao.FornecedorID;
            producaoBanco.Quantidade = producao.Quantidade;
            producaoBanco.DataProducao = producao.DataProducao;
            producaoBanco.DataPrevistaColheita = producao.DataPrevistaColheita;
            producaoBanco.DataColheita = producao.DataColheita;
            producaoBanco.Status = producao.Status;
            producaoBanco.Produto = producao.Produto;
            producaoBanco.Fornecedor = producao.Fornecedor;

            _context.producoes.Update(producaoBanco);
            _context.SaveChanges();

            Console.WriteLine(producaoBanco);
            return true;
        }

        public bool Delete(int id)
        {
            Producao producaoBanco = _context.producoes.Find(id);

            _context.producoes.Remove(producaoBanco);
            _context.SaveChanges();

            Console.WriteLine(producaoBanco);
            return true;
        }
    }
}