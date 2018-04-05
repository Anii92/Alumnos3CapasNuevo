using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Models
{
    public class Alumno: Persona
    {
        public Alumno()
        {

        }
        //[JsonConstructor]
        public Alumno(int id, string nombre, string apellidos, string dni, int edad, DateTime fechaNacimiento) : base(id, nombre, apellidos, dni, edad, fechaNacimiento)
        {

        }

        public Alumno(int id, string nombre, string apellidos, string dni, int edad, DateTime fechaNacimiento, DateTime fechaHora, string guid) : base(id, nombre, apellidos, dni, edad, fechaNacimiento, fechaHora, guid)
        {

        }
    }
}
