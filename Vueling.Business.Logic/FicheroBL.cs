using log4net;
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
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly FicheroDao ficheroDao;

        public FicheroBL()
        {
            Log.Debug("Entra FicheroBL");
            this.ficheroDao = new FicheroDao();
            Log.Debug("Sale FicheroBL");

        }

        public List<Alumno> CargarDatosFichero(TipoFichero tipoFichero)
        {
            Log.Debug("Entra CargarDatosFichero");
            Log.Debug("Sale CargarDatosFichero");
            return this.ficheroDao.CargarDatosFichero(tipoFichero);
        }

        public List<Alumno> FiltrarFicheroJsonPorNombre(string valor)
        {
            Log.Debug("Entra FiltrarFicheroJsonPorNombre");
            Log.Debug("Sale FiltrarFicheroJsonPorNombre");
            return this.ficheroDao.FiltrarFicheroJsonPorNombre(valor);
        }

        public List<Alumno> Leer(TipoFichero tipoFichero)
        {
            Log.Debug("Entra Leer");
            Log.Debug("Sale Leer");
            return this.ficheroDao.Leer(tipoFichero);
        }
    }
}
