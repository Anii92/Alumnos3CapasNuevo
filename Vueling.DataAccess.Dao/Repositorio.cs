using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Interfaces;

namespace Vueling.DataAccess.Dao
{
    public abstract class Repositorio : ICrud
    {
        public abstract Alumno Add(Alumno alumno);

        public abstract List<Alumno> Read();
        public abstract object ReadByGuid(string guid);

        public virtual Alumno UpdateName(string name, string guid)
        {
            return new Alumno();
        }

        public virtual int DeleteById(int id)
        {
            return 1;
        }

        public virtual int DeleteByGuid(string guid)
        {
            return 1;
        }

        
    }
}
