using log4net;
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
            this.logger.Debug("Entra FicheroBL");
            this.ficheroDao = new FicheroDao();
            this.logger.Debug("Sale FicheroBL");

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
                this.logger.Debug("Entra FiltrarFicheroJsonPorNombre");
                this.logger.Debug("Sale FiltrarFicheroJsonPorNombre");
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
                this.logger.Debug("Entra Leer");
                this.logger.Debug("Sale Leer");
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
