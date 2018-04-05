using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;

namespace Vueling.Common.Logic
{
    public interface IFichero
    {
        string Nombre { get; set; }
        string Ruta { get; set; }

        void Guardar(Alumno alumno);
        List<Alumno> Leer();
    }
}
