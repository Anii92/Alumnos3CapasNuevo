﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Exceptions;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.Dao.Interfaces;
using Vueling.DataAccess.Dao.Resources;

namespace Vueling.DataAccess.Dao.Daos
{
    public class ProcedureDao : Repositorio
    {
        private string Conexion { get; set; }
        private ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        
        public ProcedureDao(IRead read) : base(read)
        {
            this.Conexion = Configuraciones.LeerConexionBaseDeDatos();
        }

        public override Alumno Add(Alumno alumno)
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
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "addAlumno";
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
                            //en lugar de hacerlo por el id hacerlo por el guid
                            alumnoInsertado = (Alumno)ReadByGuid(alumno.Guid);
                        }
                    }
                }
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumnoInsertado;
            }
            catch (InvalidOperationException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
            catch (SqlException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
            catch (InvalidCastException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
        }

        public override List<Alumno> Read()
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                List<Alumno> alumnos = this.read.Read();
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumnos;
            }
            catch (InvalidOperationException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
            catch (SqlException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
            catch (InvalidCastException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
        }

        public override object ReadByGuid(string guid)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Alumno alumno = (Alumno)this.read.ReadByGuid(guid);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumno;
            }
            catch (InvalidOperationException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
            catch (SqlException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
            catch (InvalidCastException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
        }

        public object GetById(int id)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                List<Alumno> alumnos = new List<Alumno>();
                using (SqlConnection connection = new SqlConnection(this.Conexion))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "getById";
                        command.Parameters.AddWithValue("@Id", id);
                        SqlDataReader myReader = command.ExecuteReader();
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
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
            catch (SqlException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
            catch (InvalidCastException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
        }

        public override int DeleteByGuid(string guid)
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
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "deleteByGuid";
                        command.Parameters.AddWithValue("@Guid", guid);
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                        this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                        return recordsAffected;
                    }
                }
            }
            catch (InvalidOperationException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
            catch (SqlException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
            catch (InvalidCastException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
        }

        public override int DeleteById(int id)
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
                        command.CommandText = "deleteById";
                        command.Parameters.AddWithValue("@Id", id);
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                        this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                        return recordsAffected;
                    }
                }
            }
            catch (InvalidOperationException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
            catch (SqlException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
            catch (InvalidCastException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
        }
    }
}
