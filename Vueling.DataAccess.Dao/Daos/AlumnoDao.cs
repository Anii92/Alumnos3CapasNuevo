using Autofac;
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
using Vueling.DataAccess.Dao.Interfaces;
using Vueling.DataAccess.Dao.Resources;
using Vueling.DataAccess.Dao.Singletons;
using static Vueling.Common.Logic.Enums.Formatos;

namespace Vueling.DataAccess.Dao.Daos
{
    public class AlumnoDao : IAlumnoDao
    {
        private ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);

        public Alumno Add(Alumno alumno)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Repositorio repositorio = (Repositorio)AlumnoDaoFactory.GetAlumnoDao();
                Alumno alumnoInsertado = repositorio.Add(alumno);
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

        public int DeleteByGuid(string guid)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Repositorio repositorio = (Repositorio)AlumnoDaoFactory.GetAlumnoDao();
                int delete = repositorio.DeleteByGuid(guid);
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

        public List<Alumno> Leer()
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                //Repositorio repositorio = (Repositorio)AlumnoDaoFactory.GetAlumnoDao();
                //List<Alumno> alumnos = repositorio.Read();


                var builder = new ContainerBuilder();
                builder.Register<IRead>(
                  (c, p) =>
                  {
                      string formato = p.Named<string>("formato");
                      Formato formatoEnum = Formatos.GetType(formato);
                      switch (formatoEnum)
                      {
                          case Formato.Sql:
                              logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                              return new BaseDatosDao(new ReadBaseDatos());
                          case Formato.Texto:
                              logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                              return new FicheroTxtDao(new ReadFicheroTxt());
                          case Formato.Json:
                              logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                              return new FicheroJsonDao(new ReadFicheroJson());
                          case Formato.Xml:
                              logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                              return new FicheroXmlDao(new ReadFicheroXml());
                          case Formato.Procedure:
                              logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                              return new ProcedureDao(new ReadProcedure());
                          default:
                              return new BaseDatosDao(new ReadBaseDatos());
                      }
                  });
                var container = builder.Build();
                var card = container.Resolve<IRead>(new NamedParameter("formato", Configuraciones.LeerFormatoFichero())).Read();

                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return card;
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

        public void CargarDatosDeLosAlumnos(Formatos.Formato formato)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                switch (formato)
                {
                    case Formato.Json:
                        SingletonJson.Instance.Cargar();
                        break;
                    case Formato.Xml:
                        SingletonXml.Instance.Cargar();
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
    }
}
