using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Factories;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.DataAccess.Dao
{
    public class AlumnoDao : IAlumnoDao
    {
        public AlumnoDao()
        {
        }

        public Alumno Add(Alumno alumno, TipoFichero tipoFichero)
        {
            IFichero fichero = (IFichero)FicheroFactory.CrearFichero(tipoFichero, "ListadoAlumno");
            fichero.Guardar(alumno);
            return alumno;
        }
    }
}
