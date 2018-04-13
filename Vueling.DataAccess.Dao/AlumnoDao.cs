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
using Vueling.DataAccess.Dao.Resources;
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
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public Alumno Add(Alumno alumno, TipoFichero tipoFichero)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                IFichero fichero = (IFichero)FicheroFactory.CrearFichero(tipoFichero, "ListadoAlumno");
                Alumno alumnoInsertado = fichero.Guardar(alumno);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumnoInsertado;
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (ArgumentNullException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public List<Alumno> Leer(TipoFichero tipoFichero)
        {
            try
            {
                List<Alumno> alumnos;
                switch (tipoFichero)
                {
                    case (TipoFichero.Texto):
                        this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + tipoFichero.ToString());
                        IFichero fichero = (IFichero)FicheroFactory.CrearFichero(tipoFichero, "ListadoAlumno");
                        alumnos = fichero.Leer();
                        this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + tipoFichero.ToString());
                        return alumnos;
                    case (TipoFichero.Json):
                        this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + tipoFichero.ToString());
                        alumnos = SingletonJson.Instance.Leer();
                        this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + tipoFichero.ToString());
                        return alumnos;
                    case (TipoFichero.Xml):
                        this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + tipoFichero.ToString());
                        alumnos = SingletonXml.Instance.Leer();
                        this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + tipoFichero.ToString());
                        return alumnos;
                    default:
                        this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + tipoFichero.ToString());
                        alumnos = SingletonJson.Instance.Leer();
                        this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + tipoFichero.ToString());
                        return alumnos;
                }
            }
            catch (NullReferenceException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }
    }
}
