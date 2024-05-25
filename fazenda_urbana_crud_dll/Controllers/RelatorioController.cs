using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fazenda_urbana_crud_dll.Context;
using fazenda_urbana_crud_dll.Models.Db;
using fazenda_urbana_crud_dll.Models.Entities;

namespace fazenda_urbana_crud_dll.Controllers
{
    public class RelatorioController : IController
    {
        private readonly FazendaContext _context;

        public RelatorioController()
        {
            _context = ContextBuilder.GetContext();
        }

        public bool Create(object o)
        {
            Relatorio relatorio = (Relatorio) o;
            _context.relatorios.Add(relatorio);
            _context.SaveChanges();

            Console.WriteLine(relatorio);

            return true;
        }

        public bool GetById(int id)
        {
            var relatorio = _context.relatorios.Find(id);

            if(relatorio == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            Console.WriteLine(relatorio);
            return true;
        }

        public bool GetAll()
        {
            var relatorios = _context.relatorios.ToList();

            if(relatorios == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            foreach(var r in relatorios)
            {
                Console.WriteLine(r);
                Console.WriteLine();
            }
            return true;
        }

        public bool Update(int id, object o)
        {
            Relatorio relatorio = (Relatorio) o;

            var relatorioBanco = _context.relatorios.Find(id);

            if(relatorioBanco == null)
            {
                Console.WriteLine("Registro não encontrado");
                return false;
            }

            relatorioBanco.TipoRelatorio = relatorio.TipoRelatorio;
            relatorioBanco.DataGeracao = relatorio.DataGeracao;
            relatorioBanco.DadosRelatorio = relatorio.DadosRelatorio;

            _context.relatorios.Update(relatorioBanco);
            _context.SaveChanges();

            Console.WriteLine(relatorioBanco);
            return true;
        }

        public bool Delete(int id)
        {
            Relatorio relatorioBanco = _context.relatorios.Find(id);

            _context.relatorios.Remove(relatorioBanco);
            _context.SaveChanges();

            Console.WriteLine(relatorioBanco);
            return true;
        }
    }
}