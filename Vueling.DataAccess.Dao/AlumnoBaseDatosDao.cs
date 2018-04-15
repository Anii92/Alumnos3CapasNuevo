using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Enums;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.Dao.Resources;

namespace Vueling.DataAccess.Dao
{
    public class AlumnoBaseDatosDao : IAlumnoDao
    {
        public string Conexion { get; set; }
        private Logger logger;

        public AlumnoBaseDatosDao()
        {
            this.Conexion = Configuraciones.LeerConexionBaseDeDatos();
            this.logger = new Logger();
        }

        public Alumno Add(Alumno alumno)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Alumno alumnoInsertado = new Alumno();
                using (SqlConnection connection = new SqlConnection(this.Conexion))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection; 
                        command.CommandType = CommandType.Text;
                        command.CommandText = ResourcesBaseDatos.addAlumno;
                        command.Parameters.AddWithValue("@nombre", alumno.Nombre);
                        command.Parameters.AddWithValue("@apellidos", alumno.Apellidos);
                        command.Parameters.AddWithValue("@dni", alumno.Dni);
                        command.Parameters.AddWithValue("@fechaNacimiento", alumno.FechaNacimiento);
                        command.Parameters.AddWithValue("@edad", alumno.Edad);
                        command.Parameters.AddWithValue("@fechaCreacion", alumno.FechaHora);
                        command.Parameters.AddWithValue("@guid", alumno.Guid);

                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                        if (recordsAffected == 1)
                        {
                            alumnoInsertado = (Alumno) GetFromId(alumno.Id);
                        }
                    }
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
        }

        public object GetFromId(int id)
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
                        command.CommandText = Resources.ResourcesBaseDatos.getId;
                        command.Parameters.AddWithValue("@id", id);

                        connection.Open();
                        SqlDataReader myReader = command.ExecuteReader();
                        while (myReader.Read())
                        {
                            alumno.Id = Convert.ToInt32(myReader[0]);
                            alumno.Nombre = myReader[1].ToString();
                            alumno.Apellidos = myReader[2].ToString();
                            alumno.Dni = myReader[3].ToString();
                            alumno.FechaNacimiento = Convert.ToDateTime(myReader[4]);
                            alumno.Edad = Convert.ToInt32(myReader[5]);
                            alumno.FechaHora = Convert.ToDateTime(myReader[6]);
                            alumno.Guid = myReader[6].ToString();
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

        public void CargarDatosDeLosAlumnos(TiposFichero.TipoFichero tipoFichero)
        {
            
        }

        public List<Alumno> Leer()
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                List<Alumno> alumnos = new List<Alumno>();
                using (SqlConnection connection = new SqlConnection(this.Conexion))
                {
                    connection.Open();
                    using (SqlCommand myCommand = new SqlCommand(Resources.ResourcesBaseDatos.getAll, connection))
                    {
                        SqlDataReader myReader = myCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                            Alumno alumno = new Alumno();
                            alumno.Id = Convert.ToInt32(myReader[0]);
                            alumno.Nombre = myReader[1].ToString();
                            alumno.Apellidos = myReader[2].ToString();
                            alumno.Dni = myReader[3].ToString();
                            alumno.FechaNacimiento = Convert.ToDateTime(myReader[4]);
                            alumno.Edad = Convert.ToInt32(myReader[5]);
                            alumno.FechaHora = Convert.ToDateTime(myReader[6]);
                            alumno.Guid = myReader[7].ToString();
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
