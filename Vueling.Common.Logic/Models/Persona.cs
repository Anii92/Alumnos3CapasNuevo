using log4net;
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

        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Persona()
        {
            Log.Debug("Entra Persona");
            this.MiGuid = Guid.NewGuid().ToString();
            Log.Debug("Sale Persona");
        }

        public Persona(int id, string nombre, string apellidos, string dni, int edad, DateTime fechaNacimiento)
        {
            Log.Debug("Entra Persona");
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Dni = dni;
            this.Edad = edad;
            this.FechaNacimiento = fechaNacimiento;
            this.FechaHora = DateTime.Now;
            this.MiGuid = Guid.NewGuid().ToString();
            Log.Debug("Sale Persona");
        }

        public Persona(int id, string nombre, string apellidos, string dni, int edad, DateTime fechaNacimiento, DateTime fechaHora, string guid)
        {
            Log.Debug("Entra Persona");
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Dni = dni;
            this.Edad = edad;
            this.FechaNacimiento = fechaNacimiento;
            this.FechaHora = fechaHora;
            this.MiGuid = guid;
            Log.Debug("Sale Persona");
        }

        public override bool Equals(object obj)
        {
            Log.Debug("Entra Equals");
            var persona = obj as Persona;
            Log.Debug("Sale Equals");
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
            Log.Debug("Entra GetHashCode");
            var hashCode = 292974432;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
            hashCode = hashCode * -1521134295 + FechaNacimiento.GetHashCode();
            hashCode = hashCode * -1521134295 + Edad.GetHashCode();
            hashCode = hashCode * -1521134295 + FechaHora.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MiGuid);
            Log.Debug("Sale GetHashCode");
            return hashCode;
        }
    }
}
