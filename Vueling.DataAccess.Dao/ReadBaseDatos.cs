using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.Dao.Interfaces;
using Vueling.DataAccess.Dao.Resources;

namespace Vueling.DataAccess.Dao
{
    public class ReadBaseDatos : IRead
    {
        private string Conexion { get; set; }
        private ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);

        public ReadBaseDatos()
        {
            this.Conexion = Configuraciones.LeerConexionBaseDeDatos();
        }
        public object ReadByGuid(string guid)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Alumno alumno = new Alumno();
                using (SqlConnection connection = new SqlConnection(this.Conexion))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "select * from dbo.Alumnos a where a.Guid = @Guid";
                        command.Parameters.AddWithValue("@Guid", guid);

                        connection.Open();
                        SqlDataReader myReader = command.ExecuteReader();
                        while (myReader.Read())
                        {
                            alumno.Id = Convert.ToInt32(myReader["Id"]);
                            alumno.Nombre = myReader["Nombre"].ToString();
                            alumno.Apellidos = myReader["Apellidos"].ToString();
                            alumno.Dni = myReader["Dni"].ToString();
                            alumno.FechaNacimiento = Convert.ToDateTime(myReader["FechaNacimiento"]);
                            alumno.Edad = Convert.ToInt32(myReader["Edad"]);
                            alumno.FechaHora = Convert.ToDateTime(myReader["FechaCreacion"]);
                            alumno.Guid = myReader["Guid"].ToString();
                        }
                    }
                }
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumno;
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
        }

        public List<Alumno> Read()
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                List<Alumno> alumnos = new List<Alumno>();
                using (SqlConnection connection = new SqlConnection(this.Conexion))
                {
                    connection.Open();
                    using (SqlCommand myCommand = new SqlCommand("select * from dbo.Alumnos", connection))
                    {
                        SqlDataReader myReader = myCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                            Alumno alumno = new Alumno();
                            alumno.Id = Convert.ToInt32(myReader["Id"]);
                            alumno.Nombre = myReader["Nombre"].ToString();
                            alumno.Apellidos = myReader["Apellidos"].ToString();
                            alumno.Dni = myReader["Dni"].ToString();
                            alumno.FechaNacimiento = Convert.ToDateTime(myReader["FechaNacimiento"]);
                            alumno.Edad = Convert.ToInt32(myReader["Edad"]);
                            alumno.FechaHora = Convert.ToDateTime(myReader["FechaCreacion"]);
                            alumno.Guid = myReader["Guid"].ToString();
                            alumnos.Add(alumno);
                        }
                    }
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
        }
    }
}
