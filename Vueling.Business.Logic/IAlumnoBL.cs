using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.Business.Logic
{
    public interface IAlumnoBL
    {
        TipoFichero TipoFichero { get; set; }

        Alumno Add(Alumno alumno, TipoFichero tipoFichero);
        void CargarDatosDeLosAlumnos(TipoFichero tipoFichero);
        List<Alumno> Leer(TipoFichero tipoFichero);
        List<Alumno> Filtrar(string clave, string valor);
        int CalcularEdad(DateTime fechaNacimiento);
    }
}
