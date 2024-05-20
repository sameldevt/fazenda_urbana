using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fazenda_urbana_crud_dll.Context;
using fazenda_urbana_crud_dll.Models.Db;
using fazenda_urbana_crud_dll.Models.Entities;

namespace fazenda_urbana_crud_dll.Controllers
{
    public class InventarioController : IController
    {
        private readonly FazendaContext _context;

        public InventarioController()
        {
            _context = ContextBuilder.GetContext();
        }

        public bool Create(object o)
        {
            Inventario inventario = (Inventario) o;
            _context.inventarios.Add(inventario);
            _context.SaveChanges();

            Console.WriteLine(inventario);

            return true;
        }

        public bool GetById(int id)
        {
            var inventario = _context.inventarios.Find(id);

            if(inventario == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            Console.WriteLine(inventario);
            return true;
        }

        public bool GetAll()
        {
            var inventarios = _context.inventarios.ToList();

            if(inventarios == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            Console.WriteLine(inventarios);
            return true;
        }

        public bool Update(int id, object o)
        {
            Inventario inventario = (Inventario) o;

            var inventarioBanco = _context.inventarios.Find(id);

            if(inventarioBanco == null)
            {
                Console.WriteLine("Registro não encontrado");
                return false;
            }

            inventarioBanco.ProdutoID = inventario.ProdutoID;
            inventarioBanco.Quantidade = inventario.Quantidade;
            inventarioBanco.DataUltimaAtualizacao = inventario.DataUltimaAtualizacao;
            inventarioBanco.Produto = inventario.Produto;
        
            _context.inventarios.Update(inventarioBanco);
            _context.SaveChanges();

            Console.WriteLine(inventarioBanco);
            return true;
        }

        public bool Delete(int id)
        {
            Inventario inventarioBanco = _context.inventarios.Find(id);

            _context.inventarios.Remove(inventarioBanco);
            _context.SaveChanges();

            Console.WriteLine(inventarioBanco);
            return true;
        }
    }
}