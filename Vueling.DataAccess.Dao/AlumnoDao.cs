using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Enums;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.Dao.Factories;
using Vueling.DataAccess.Dao.Resources;
using static Vueling.Common.Logic.Enums.Formatos;

namespace Vueling.DataAccess.Dao
{
    public class AlumnoDao : IAlumnoDao
    {
        private ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);

        public Alumno Add(Alumno alumno)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Alumno alumnoInsertado;
                switch (Formatos.GetType(Configuraciones.LeerFormatoFichero()))
                {
                    case Formato.Sql:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                        AlumnoBaseDatosDao alumnoBaseDatosDao = new AlumnoBaseDatosDao();
                        alumnoInsertado = alumnoBaseDatosDao.Add(alumno);
                        break;
                    case Formato.Procedure:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                        AlumnoProcedureDao alumnoProcedureDao = new AlumnoProcedureDao();
                        alumnoInsertado = alumnoProcedureDao.Add(alumno);
                        break;
                    case Formato.Texto:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                        AlumnoFicheroDao alumnoFicheroTextoDao = new AlumnoFicheroDao();
                        alumnoInsertado = alumnoFicheroTextoDao.Add(alumno);
                        break;
                    case Formato.Json:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                        AlumnoFicheroDao alumnoFicheroJsonDao = new AlumnoFicheroDao();
                        alumnoInsertado = alumnoFicheroJsonDao.Add(alumno);
                        break;
                    case Formato.Xml:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                        AlumnoFicheroDao alumnoFicheroXmlDao = new AlumnoFicheroDao();
                        alumnoInsertado = alumnoFicheroXmlDao.Add(alumno);
                        break;
                    default:
                        AlumnoBaseDatosDao alumnoBaseDatosDegfaultDao = new AlumnoBaseDatosDao();
                        alumnoInsertado = alumnoBaseDatosDegfaultDao.Add(alumno);
                        break;
                }

                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumnoInsertado;
            }
            catch (InvalidOperationException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (SqlException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (InvalidCastException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
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

        public void CargarDatosDeLosAlumnos(Formatos.Formato formato)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                switch (Formatos.GetType(Configuraciones.LeerFormatoFichero()))
                {
                    case Formato.Json:
                        AlumnoFicheroDao alumnoFicheroJsonDao = new AlumnoFicheroDao();
                        alumnoFicheroJsonDao.CargarDatosDeLosAlumnos(formato);
                        break;
                    case Formato.Xml:
                        AlumnoFicheroDao alumnoFicheroXmlDao = new AlumnoFicheroDao();
                        alumnoFicheroXmlDao.CargarDatosDeLosAlumnos(formato);
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

        public List<Alumno> Leer()
        {
            try
            {
                List<Alumno> alumnos;
                switch (Formatos.GetType(Configuraciones.LeerFormatoFichero()))
                {
                    case Formato.Sql:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                        AlumnoBaseDatosDao alumnoBaseDatosDao = new AlumnoBaseDatosDao();
                        alumnos = alumnoBaseDatosDao.GetAll();
                        break;
                    case Formato.Procedure:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                        AlumnoProcedureDao alumnoProcedureDao = new AlumnoProcedureDao();
                        alumnos = alumnoProcedureDao.GetAll();
                        break;
                    case Formato.Texto:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                        AlumnoFicheroDao alumnoFicheroTextoDao = new AlumnoFicheroDao();
                        alumnos = alumnoFicheroTextoDao.Leer();
                        break;
                    case Formato.Json:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                        AlumnoFicheroDao alumnoFicheroJsonDao = new AlumnoFicheroDao();
                        alumnos = alumnoFicheroJsonDao.Leer();
                        break;
                    case Formato.Xml:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                        AlumnoFicheroDao alumnoFicheroXmlDao = new AlumnoFicheroDao();
                        alumnos = alumnoFicheroXmlDao.Leer();
                        break;
                    default:
                        AlumnoBaseDatosDao alumnoBaseDatosDegfaultDao = new AlumnoBaseDatosDao();
                        alumnos = alumnoBaseDatosDegfaultDao.GetAll();
                        break;
                }

                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumnos;
            }
            catch (InvalidOperationException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (SqlException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (InvalidCastException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (NullReferenceException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public int DeleteByGuid(string guid)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                int delete = -1;
                switch (Formatos.GetType(Configuraciones.LeerFormatoFichero()))
                {
                    case Formato.Sql:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                        AlumnoBaseDatosDao alumnoBaseDatosDao = new AlumnoBaseDatosDao();
                        delete = alumnoBaseDatosDao.DeleteByGuid(guid);
                        break;
                    case Formato.Procedure:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                        AlumnoProcedureDao alumnoProcedureDao = new AlumnoProcedureDao();
                        delete = alumnoProcedureDao.DeleteByGuid(guid);
                        break;
                    case Formato.Texto:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                        AlumnoFicheroDao alumnoFicheroTextoDao = new AlumnoFicheroDao();
                        //alumnoInsertado = alumnoFicheroTextoDao.Add(alumno);
                        break;
                    case Formato.Json:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                        AlumnoFicheroDao alumnoFicheroJsonDao = new AlumnoFicheroDao();
                        //alumnoInsertado = alumnoFicheroJsonDao.Add(alumno);
                        break;
                    case Formato.Xml:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                        AlumnoFicheroDao alumnoFicheroXmlDao = new AlumnoFicheroDao();
                        //alumnoInsertado = alumnoFicheroXmlDao.Add(alumno);
                        break;
                    default:
                        AlumnoBaseDatosDao alumnoBaseDatosDegfaultDao = new AlumnoBaseDatosDao();
                        //alumnoInsertado = alumnoBaseDatosDegfaultDao.Add(alumno);
                        break;
                }

                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return delete;
            }
            catch (InvalidOperationException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (SqlException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (InvalidCastException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
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
    }
}
