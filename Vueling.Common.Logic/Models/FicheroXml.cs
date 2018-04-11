using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Vueling.Resources;

namespace Vueling.Common.Logic.Models
{
    public class FicheroXml: IFichero
    {
        Logger logger = new Logger();
        public string Nombre { get; set; }
        public string Ruta { get; set; }

        public FicheroXml(string nombre, string ruta)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;
        }

        public Alumno Guardar(Alumno alumno)
        {
            this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<Alumno> alumnos = new List<Alumno>();
            var xmlSerializer = new XmlSerializer(typeof(List<Alumno>));
            try
            {
                Alumno alumnoInsertado;
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
                alumnoInsertado = this.Leer(alumno.Guid);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumnoInsertado;
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public List<Alumno> Leer()
        {
            throw new NotImplementedException();
        }

        public Alumno Leer(string guid)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                List<Alumno> alumnos = FileUtils.DeserializeFicheroXml(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json"));
                Alumno alumnoInsertado = (alumnos.Where(alumno => alumno.Guid == guid)).FirstOrDefault();
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumnoInsertado;
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (ArgumentNullException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }
    }
}
