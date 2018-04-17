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
using static Vueling.Common.Logic.Enums.Formatos;
using Vueling.Common.Logic.Utils;
using Vueling.Common.Logic.Enums;
using Vueling.Common.Logic.Interfaces;
using System.Reflection;
using Vueling.DataAccess.Dao.Interfaces;

namespace Vueling.DataAccess.Dao
{
    public class AlumnoFicheroDao : ICreate
    {
        private ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        public AlumnoFicheroDao()
        {
        }

        public void CargarDatosDeLosAlumnos(Formato Formato)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                switch (Formato)
                {
                    case (Formato.Json):
                        SingletonJson.Instance.Cargar();
                        break;
                    case (Formato.Xml):
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

        public Alumno Add(Alumno alumno)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                IFichero fichero = (IFichero)FicheroFactory.CrearFichero(Formatos.GetType(Configuraciones.LeerFormatoFichero()), "ListadoAlumno");
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

        public List<Alumno> Leer()
        {
            try
            {
                List<Alumno> alumnos;
                Formato Formato = Formatos.GetType(Configuraciones.LeerFormatoFichero());
                switch (Formato)
                {
                    case (Formato.Texto):
                        this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Formato.ToString());
                        IFichero fichero = (IFichero)FicheroFactory.CrearFichero(Formato, "ListadoAlumno");
                        alumnos = fichero.Leer();
                        this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Formato.ToString());
                        return alumnos;
                    case (Formato.Json):
                        this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Formato.ToString());
                        alumnos = SingletonJson.Instance.Leer();
                        this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Formato.ToString());
                        return alumnos;
                    case (Formato.Xml):
                        this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Formato.ToString());
                        alumnos = SingletonXml.Instance.Leer();
                        this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Formato.ToString());
                        return alumnos;
                    default:
                        this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Formato.ToString());
                        alumnos = SingletonJson.Instance.Leer();
                        this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Formato.ToString());
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
