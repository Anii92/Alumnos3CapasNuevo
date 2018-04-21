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
        protected ICreate create;
        protected IRead read;
        protected IUpdate update;
        protected IDelete delete;

        public Repositorio(IRead read)
        {
            //this.create = create;
            this.read = read;
            //this.update = update;
            //this.delete = delete;
        }

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
