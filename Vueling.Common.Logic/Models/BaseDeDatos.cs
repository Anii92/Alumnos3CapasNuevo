using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Utils;

namespace Vueling.Common.Logic.Models
{
    public class BaseDeDatos
    {
        public string Conexion { get; set; }
        private Logger logger;

        public BaseDeDatos()
        {
            this.Conexion = Configuraciones.LeerConexionBaseDeDatos();
            this.logger = new Logger();
        }

        public List<Alumno> Leer()
        {
            try
            {
                List<Alumno> alumnos = new List<Alumno>();
                SqlConnection myConnection = new SqlConnection(this.Conexion);
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand("select * from dbo.Alumnos",
                                                         myConnection);
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
                    alumno.Guid = myReader[6].ToString();
                    alumnos.Add(alumno);
                }
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
