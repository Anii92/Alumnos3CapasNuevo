using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Models
{
    public class Persona: VuelingObject
    {
        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public DateTime FechaHora { get; set; } 
        #endregion

        public Persona()
        {
            this.MiGuid = Guid.NewGuid().ToString();
        }

        public Persona(int id, string nombre, string apellidos, string dni, int edad, DateTime fechaNacimiento)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Dni = dni;
            this.Edad = edad;
            this.FechaNacimiento = fechaNacimiento;
            this.FechaHora = DateTime.Now;
            this.MiGuid = Guid.NewGuid().ToString();
        }

        public Persona(int id, string nombre, string apellidos, string dni, int edad, DateTime fechaNacimiento, DateTime fechaHora, string guid)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Dni = dni;
            this.Edad = edad;
            this.FechaNacimiento = fechaNacimiento;
            this.FechaHora = fechaHora;
            this.MiGuid = guid;
        }

        public override bool Equals(object obj)
        {
            var persona = obj as Persona;
            return persona != null &&
                   Id == persona.Id &&
                   Nombre == persona.Nombre &&
                   Apellidos == persona.Apellidos &&
                   Dni == persona.Dni &&
                   FechaNacimiento.ToString() == persona.FechaNacimiento.ToString() &&
                   Edad == persona.Edad &&
                   FechaHora.ToString() == persona.FechaHora.ToString() &&
                   MiGuid == persona.MiGuid;
        }

        public override int GetHashCode()
        {
            var hashCode = 292974432;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
            hashCode = hashCode * -1521134295 + FechaNacimiento.GetHashCode();
            hashCode = hashCode * -1521134295 + Edad.GetHashCode();
            hashCode = hashCode * -1521134295 + FechaHora.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MiGuid);
            return hashCode;
        }
    }
}
