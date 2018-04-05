using System;
using System.Collections.Generic;
using System.IO;
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
        Logger logger = new Logger();
        private readonly FicheroDao ficheroDao;

        public FicheroBL()
        {
            this.ficheroDao = new FicheroDao();
        }

        public List<Alumno> CargarDatosFichero(TipoFichero tipoFichero)
        {
            try
            {
                return this.ficheroDao.CargarDatosFichero(tipoFichero);
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error("No se ha podido cargar el fichero" + exception.Message);
                throw;
            }
        }

        public List<Alumno> FiltrarFicheroJsonPorNombre(string valor)
        {
            try
            {
                return this.ficheroDao.FiltrarFicheroJsonPorNombre(valor);
            }
            catch (NullReferenceException exception)
            {
                this.logger.Error("Referencia nula" + exception.Message);
                throw;
            }
        }

        public List<Alumno> Leer(TipoFichero tipoFichero)
        {
            try
            {
                return this.ficheroDao.Leer(tipoFichero);
            }
            catch (ArgumentException exception)
            {
                this.logger.Error(exception.Message);
                throw;
            }
        }
    }
}
