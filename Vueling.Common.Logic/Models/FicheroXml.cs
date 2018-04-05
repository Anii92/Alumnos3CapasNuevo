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
        public string Nombre { get; set; }
        public string Ruta { get; set; }

        public FicheroXml(string nombre, string ruta)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;
        }

        public void Guardar(Alumno alumno)
        {
            List<Alumno> alumnos = new List<Alumno>();
            //TextWriter writer = null;
            var xmlSerializer = new XmlSerializer(typeof(List<Alumno>));
            try
            {
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
                //var serializer = new XmlSerializer(alumno.GetType());
                //if (!File.Exists(this.Ruta))
                //{
                //    writer = new StreamWriter(this.Ruta, false);
                    
                //}
                //else
                //{
                //    writer = new StreamWriter(this.Ruta, true);
                //}
                //serializer.Serialize(writer, alumno);
            }
            finally
            {
                //if (writer != null)
                //{
                //    writer.Close();
                //}
                    
            }
        }

        public List<Alumno> Leer()
        {
            throw new NotImplementedException();
        }
    }
}
