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
    public class AlumnoDao : IAlumnoDao
    {
        Logger logger = new Logger();
        public AlumnoDao()
        {
        }

        public void CargarDatosDeLosAlumnos(TipoFichero tipoFichero)
        {
            try
            {
                this.logger.Debug("Entra CargarDatosFichero");
                switch (tipoFichero)
                {
                    case (TipoFichero.Json):
                        SingletonJson.Instance.Cargar();
                        break;
                    case (TipoFichero.Xml):
                        SingletonXml.Instance.Cargar();
                        break;
                    default:
                        SingletonJson.Instance.Cargar();
                        break;
                }
                this.logger.Debug("Sale CargarDatosFichero");
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error("No se ha podido cargar el fichero" + exception.Message);
                throw;
            }
        }

        public Alumno Add(Alumno alumno, TipoFichero tipoFichero)
        {
            try
            {
                this.logger.Debug("Entra Add");
                IFichero fichero = (IFichero)FicheroFactory.CrearFichero(tipoFichero, "ListadoAlumno");
                Alumno alumnoInsertado = fichero.Guardar(alumno);
                this.logger.Debug("Sale Add");
                return alumnoInsertado;
            }
            catch (FileNotFoundException exception)
            {
                logger.Error(exception.Message);
                throw;
            }
            catch (ArgumentNullException exception)
            {
                this.logger.Error(exception.Message);
                throw;
            }
        }

        public List<Alumno> Leer(TipoFichero tipoFichero)
        {
            try
            {
                switch (tipoFichero)
                {
                    case (TipoFichero.Texto):
                        this.logger.Debug("Entra leer alumnos json");
                        IFichero fichero = (IFichero)FicheroFactory.CrearFichero(tipoFichero, "ListadoAlumno");
                        return fichero.Leer();
                    case (TipoFichero.Json):
                        this.logger.Debug("Entra leer alumnos json");
                        return SingletonJson.Instance.Leer();
                    case (TipoFichero.Xml):
                        this.logger.Debug("Entra leer alumnos xml");
                        return SingletonXml.Instance.Leer();
                    default:
                        this.logger.Debug("Entra leer alumnos json");
                        return SingletonJson.Instance.Leer();
                }
            }
            catch (NullReferenceException exception)
            {
                this.logger.Error("No se han cargado datos del fichero" + exception.Message);
                throw;
            }
        }
    }
}
