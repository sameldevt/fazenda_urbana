using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fazenda_urbana_crud_dll.Controllers
{
    public interface IController
    {
        public abstract bool Create(object o);

        public abstract bool GetById(int id);

        public abstract bool GetAll();

        public abstract bool Update(int id, object o);

        public abstract bool Delete(int id);
    }
}