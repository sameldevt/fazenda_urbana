using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fazenda_urbana_crud_dll.Context;
using fazenda_urbana_crud_dll.Models.Db;
using fazenda_urbana_crud_dll.Models.Entities;

namespace fazenda_urbana_crud_dll.Controllers
{
    public class ProdutoController : IController
    {
        private readonly FazendaContext _context;

        public ProdutoController()
        {
            _context = ContextBuilder.GetContext();
        }

        public bool Create(object o)
        {
            Produto produto = (Produto) o;
            _context.produtos.Add(produto);
            _context.SaveChanges();

            Console.WriteLine(produto);

            return true;
        }

        public bool GetById(int id)
        {
            var produto = _context.produtos.Find(id);

            if(produto == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            Console.WriteLine(produto);
            return true;
        }

        public bool GetAll()
        {
            var produtos = _context.produtos.ToList();

            if(produtos == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            Console.WriteLine(produtos);
            return true;
        }

        public bool Update(int id, object o)
        {
            Produto produto = (Produto) o;

            var produtoBanco = _context.produtos.Find(id);

            if(produtoBanco == null)
            {
                Console.WriteLine("Registro não encontrado");
                return false;
            }

            produtoBanco.NomeProduto = produto.NomeProduto;
            produtoBanco.CategoriaID = produto.CategoriaID;
            produtoBanco.PrecoUnitario = produto.PrecoUnitario;
            produtoBanco.Categoria = produto.Categoria;

            _context.produtos.Update(produtoBanco);
            _context.SaveChanges();

            Console.WriteLine(produtoBanco);
            return true;
        }

        public bool Delete(int id)
        {
            Produto produtoBanco = _context.produtos.Find(id);

            _context.produtos.Remove(produtoBanco);
            _context.SaveChanges();

            Console.WriteLine(produtoBanco);
            return true;
        }
    }
}