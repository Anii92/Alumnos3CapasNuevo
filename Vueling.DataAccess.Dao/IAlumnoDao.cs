using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;
using static Vueling.Common.Logic.Enums.Formatos;

namespace Vueling.DataAccess.Dao
{
    public interface IAlumnoDao
    {
        Alumno Add(Alumno alumno);
        void CargarDatosDeLosAlumnos(Formato Formato);
        List<Alumno> Leer();
        int DeleteByGuid(string guid);
    }
}
