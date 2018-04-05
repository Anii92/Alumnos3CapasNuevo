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
        private IAlumnoDao alumnoDao;

        public AlumnoBL()
        {
            alumnoDao = new AlumnoDao();
        }

        public Alumno Add(Alumno alumno, TipoFichero tipoFichero)
        {
            alumno.Edad = CalcularEdad(alumno.FechaNacimiento);
            alumno.FechaHora = CalcularFechaRegistro();
            alumnoDao.Add(alumno, tipoFichero);
            return alumno;
        }

        public DateTime CalcularFechaRegistro()
        {
            return DateTime.Now;
        }

        public int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - fechaNacimiento.Year;
            if (now < fechaNacimiento.AddYears(age))
            {
                --age;
            }
            return age;
        }
    }
}
