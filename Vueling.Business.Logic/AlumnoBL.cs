using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Interfaces;
using Vueling.DataAccess.Dao.Daos;
using static Vueling.Common.Logic.Enums.Formatos;
using Vueling.Common.Logic;
using Vueling.Business.Logic.Resources;
using Vueling.Common.Logic.Utils;
using Vueling.Common.Logic.Enums;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Exceptions;

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
            catch (VuelingDaoException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingBusinessException(exception.Message, exception.InnerException);
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
            catch (VuelingDaoException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingBusinessException(exception.Message, exception.InnerException);
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
            catch (VuelingDaoException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingBusinessException(exception.Message, exception.InnerException);
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
            catch (VuelingDaoException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingBusinessException(exception.Message, exception.InnerException);
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
            catch (VuelingDaoException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingBusinessException(exception.Message, exception.InnerException);
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
            catch (VuelingDaoException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingBusinessException(exception.Message, exception.InnerException);
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
            catch (VuelingDaoException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingBusinessException(exception.Message, exception.InnerException);
            }
        }
    }
}
