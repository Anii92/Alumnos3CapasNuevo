using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao;
using static Vueling.Common.Logic.Enums.Formatos;
using Vueling.Common.Logic;
using Vueling.Business.Logic.Resources;
using Vueling.Common.Logic.Utils;
using Vueling.Common.Logic.Enums;
using Vueling.Common.Logic.Interfaces;

namespace Vueling.Business.Logic
{
    public class AlumnoBL : IAlumnoBL
    {
        public Formato Formato { get; set; }

        private ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        private IAlumnoDao alumnoDao;

        public AlumnoBL()
        {
            this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            this.alumnoDao = new AlumnoDao();
            this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public Alumno Add(Alumno alumno)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                alumno.Edad = CalcularEdad(alumno.FechaNacimiento);
                alumno.FechaHora = CalcularFechaRegistro();
                Alumno alumnoInsertado = alumnoDao.Add(alumno);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumnoInsertado;
            }
            catch (ArgumentNullException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public DateTime CalcularFechaRegistro()
        {
            this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return DateTime.Now;
        }

        public int CalcularEdad(DateTime fechaNacimiento)
        {
            this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                DateTime now = DateTime.Today;
                int age = now.Year - fechaNacimiento.Year;
                if (now < fechaNacimiento.AddYears(age))
                {
                    --age;
                }
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return age;
            }
            catch (ArgumentNullException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public void CargarDatosDeLosAlumnos(Formato Formato)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                this.alumnoDao.CargarDatosDeLosAlumnos(Formato);
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
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                
                List<Alumno> alumnos = this.alumnoDao.Leer();
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumnos;
            }
            catch (NullReferenceException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public List<Alumno> Filtrar(string clave, string valor)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                List<Alumno> alumnos = this.alumnoDao.Leer();
                alumnos = this.FiltrarLosAlumnos(alumnos, clave, valor);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumnos;
            }
            catch (NullReferenceException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public List<Alumno> FiltrarLosAlumnos(List<Alumno> alumnos, string clave, object valor)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                var alumnosFiltrados =
                    from alumno in alumnos
                    where alumno.GetType().GetProperty(clave).GetValue(alumno).ToString() == valor.ToString()
                    select alumno;
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumnosFiltrados.ToList();
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
                int delete = this.alumnoDao.DeleteByGuid(guid);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return delete;
            }
            catch (NullReferenceException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }
    }
}
