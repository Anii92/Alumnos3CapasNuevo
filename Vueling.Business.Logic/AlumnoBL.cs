using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.Business.Logic
{
    public class AlumnoBL : IAlumnoBL
    {
        Logger logger = new Logger();
        private IAlumnoDao alumnoDao;

        public AlumnoBL()
        {
            this.logger.Debug("Entra AlumnoBL");
            alumnoDao = new AlumnoDao();
            this.logger.Debug("Entra AlumnoBL");
        }

        public Alumno Add(Alumno alumno, TipoFichero tipoFichero)
        {
            try
            {
                alumno.Edad = CalcularEdad(alumno.FechaNacimiento);
                alumno.FechaHora = CalcularFechaRegistro();
                alumnoDao.Add(alumno, tipoFichero);
                return alumno;
            }
            catch (ArgumentNullException exception)
            {
                this.logger.Error("Agumento nulo" + exception.Message);
                throw;
            }
        }

        public DateTime CalcularFechaRegistro()
        {
            this.logger.Debug("Entra CalcularFechaRegistro");
            this.logger.Debug("Sale CalcularFechaRegistro");
            return DateTime.Now;
        }

        public int CalcularEdad(DateTime fechaNacimiento)
        {
            try
            {
                DateTime now = DateTime.Today;
                int age = now.Year - fechaNacimiento.Year;
                if (now < fechaNacimiento.AddYears(age))
                {
                    --age;
                }
                return age;
            }
            catch (ArgumentNullException exception)
            {
                this.logger.Error("Referencia nula" + exception.Message);
                throw;
            }
        }
    }
}
