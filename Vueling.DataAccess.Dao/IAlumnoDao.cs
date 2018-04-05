using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.DataAccess.Dao
{
    public interface IAlumnoDao
    {
        Alumno Add(Alumno alumno, TipoFichero tipoFichero);
    }
}
