using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using fazenda_urbana_crud_dll.Context;
using Microsoft.EntityFrameworkCore;

namespace fazenda_urbana_crud_dll.Models.Db
{
    public class ContextBuilder
    {
        private static FazendaContext _context;
        private static string connectionString = "Server=localhost; Initial Catalog=FazendaUrbana; Integrated Security=True; TrustServerCertificate=true";  

        public static FazendaContext GetContext()
        {
            if(_context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<FazendaContext>();
                optionsBuilder.UseSqlServer(connectionString);

                _context = new FazendaContext(optionsBuilder.Options);

                return _context;
            }

            return _context;
        }
    }
}