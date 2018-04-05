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
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IAlumnoDao alumnoDao;

        public AlumnoBL()
        {
            Log.Debug("Entra AlumnoBL");
            alumnoDao = new AlumnoDao();
            Log.Debug("Entra AlumnoBL");
        }

        public Alumno Add(Alumno alumno, TipoFichero tipoFichero)
        {
            Log.Debug("Entra Add");
            alumno.Edad = CalcularEdad(alumno.FechaNacimiento);
            alumno.FechaHora = CalcularFechaRegistro();
            alumnoDao.Add(alumno, tipoFichero);
            Log.Debug("Sale Add");
            return alumno;
        }

        public DateTime CalcularFechaRegistro()
        {
            Log.Debug("Entra CalcularFechaRegistro");
            Log.Debug("Sale CalcularFechaRegistro");
            return DateTime.Now;
        }

        public int CalcularEdad(DateTime fechaNacimiento)
        {
            Log.Debug("Entra CalcularEdad");
            DateTime now = DateTime.Today;
            int age = now.Year - fechaNacimiento.Year;
            if (now < fechaNacimiento.AddYears(age))
            {
                --age;
            }
            Log.Debug("Sale CalcularEdad");
            return age;
        }
    }
}
