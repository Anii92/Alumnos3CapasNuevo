using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Vueling.Common.Logic.Models
{
    public class FicheroXml: IFichero
    {
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string Nombre { get; set; }
        public string Ruta { get; set; }

        public FicheroXml(string nombre, string ruta)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;
        }

        public void Guardar(Alumno alumno)
        {
            Log.Debug("Entrar Guaradr");
            List<Alumno> alumnos = new List<Alumno>();
            //TextWriter writer = null;
            var xmlSerializer = new XmlSerializer(typeof(List<Alumno>));
            if (File.Exists(this.Ruta))
            {
                using (Stream reader = File.OpenRead(this.Ruta))
                {
                    alumnos = (List<Alumno>)xmlSerializer.Deserialize(reader);
                }
            }
            alumnos.Add(alumno);
            using (Stream writer = File.Open(this.Ruta, FileMode.OpenOrCreate, FileAccess.Write))
            {
                xmlSerializer.Serialize(writer, alumnos);
            }
            Log.Debug("Sale Guardar");
        }

        public List<Alumno> Leer()
        {
            throw new NotImplementedException();
        }
    }
}
