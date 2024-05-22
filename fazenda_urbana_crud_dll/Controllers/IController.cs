using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fazenda_urbana_crud_dll.Context;
using fazenda_urbana_crud_dll.Models.Db;

namespace fazenda_urbana_crud_dll.Controllers
{
    public interface IController
    {
        bool Create(object o);

        bool GetById(int id);

        bool GetAll();

        bool Update(int id, object o);

        bool Delete(int id);
    }
}