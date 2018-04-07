using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Factories;
using Vueling.DataAccess.Dao.Singletons;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.DataAccess.Dao
{
    public class FicheroDao: IFicheroDao
    {
        Logger logger = new Logger();
        private SingletonJson singletonJson;

        public FicheroDao()
        {
            this.logger.Debug("Entra FicheroDao");
            this.singletonJson = SingletonJson.Instance;
            this.logger.Debug("Sale FicheroDao");
        }

        public List<Alumno> Leer(TipoFichero tipoFichero)
        {
            this.logger.Debug("Entra Leer");
            IFichero fichero = (IFichero)FicheroFactory.CrearFichero(tipoFichero, "ListadoAlumno");
            this.logger.Debug("Sale Leer");
            return fichero.Leer();
        }

        public List<Alumno> CargarDatosFichero(TipoFichero tipoFichero)
        {
            try
            {
                this.logger.Debug("Entra CargarDatosFichero");
                List<Alumno> alumnos = new List<Alumno>();
                switch (tipoFichero)
                {
                    case (TipoFichero.Json):
                        alumnos = SingletonJson.Instance.Leer();
                        break;
                    case (TipoFichero.Xml):
                        alumnos = SingletonXml.Instance.Leer();
                        break;
                    default:
                        alumnos = SingletonJson.Instance.Leer();
                        break;
                }
                this.logger.Debug("Sale CargarDatosFichero");
                return alumnos;
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
                return this.singletonJson.Filtrar(valor);
            }
            catch (NullReferenceException exception)
            {
                this.logger.Error("Referencia nula" + exception.Message);
                throw;
            }
        }

        public List<Alumno> CargarDatosFicheroXml()
        {
            this.logger.Debug("Entra CargarDatosFicheroXml");
            this.logger.Debug("Sale CargarDatosFicheroXml");
            return new List<Alumno>();
        }
    }
}
