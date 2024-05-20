using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fazenda_urbana_crud_dll.Context;
using fazenda_urbana_crud_dll.Models.Db;
using fazenda_urbana_crud_dll.Models.Entities;

namespace fazenda_urbana_crud_dll.Controllers
{
    public class TransporteController : IController
    {
        private readonly FazendaContext _context;

        public TransporteController()
        {
            _context = ContextBuilder.GetContext();
        }

        public bool Create(object o)
        {
            Transporte transporte = (Transporte) o;
            _context.transportes.Add(transporte);
            _context.SaveChanges();

            Console.WriteLine(transporte);

            return true;
        }

        public bool GetById(int id)
        {
            var transporte = _context.transportes.Find(id);

            if(transporte == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            Console.WriteLine(transporte);
            return true;
        }

        public bool GetAll()
        {
            var transportes = _context.transportes.ToList();

            if(transportes == null)
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            Console.WriteLine(transportes);
            return true;
        }

        public bool Update(int id, object o)
        {
            Transporte transporte = (Transporte) o;

            var transporteBanco = _context.transportes.Find(id);

            if(transporteBanco == null)
            {
                Console.WriteLine("Registro não encontrado");
                return false;
            }

            transporteBanco.VendaID = transporte.VendaID;
            transporteBanco.DataEnvio = transporte.DataEnvio;
            transporteBanco.DataEntrega = transporte.DataEntrega;
            transporteBanco.Transportadora = transporte.Transportadora;
            transporteBanco.NumeroRastreamento = transporte.NumeroRastreamento;
            transporteBanco.Status = transporte.Status;
            transporteBanco.Venda = transporte.Venda;

            _context.transportes.Update(transporteBanco);
            _context.SaveChanges();

            Console.WriteLine(transporteBanco);
            return true;
        }

        public bool Delete(int id)
        {
            Transporte transporteBanco = _context.transportes.Find(id);

            _context.transportes.Remove(transporteBanco);
            _context.SaveChanges();

            Console.WriteLine(transporteBanco);
            return true;
        }
    }
}