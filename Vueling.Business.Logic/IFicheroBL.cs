using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.Business.Logic
{
    public interface IFicheroBL
    {
        List<Alumno> Leer(TipoFichero tipoFichero);
        List<Alumno> CargarDatosFichero(TipoFichero tipoFichero);
        List<Alumno> FiltrarFicheroJsonPorNombre(string valor);
    }
}
