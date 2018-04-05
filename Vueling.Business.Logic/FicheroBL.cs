using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.Business.Logic
{
    public class FicheroBL : IFicheroBL
    {
        private readonly FicheroDao ficheroDao;

        public FicheroBL()
        {
            this.ficheroDao = new FicheroDao();
        }

        public List<Alumno> CargarDatosFichero(TipoFichero tipoFichero)
        {
            return this.ficheroDao.CargarDatosFichero(tipoFichero);
        }

        public List<Alumno> FiltrarFicheroJsonPorNombre(string valor)
        {
            return this.ficheroDao.FiltrarFicheroJsonPorNombre(valor);
        }

        public List<Alumno> Leer(TipoFichero tipoFichero)
        {
            return this.ficheroDao.Leer(tipoFichero);
        }
    }
}
