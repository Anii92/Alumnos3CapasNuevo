using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Models
{
    public class FicheroJson: IFichero
    {
        Logger logger = new Logger();
        public string Nombre { get; set; }
        public string Ruta { get; set; }

        public FicheroJson(string nombre, string ruta)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;
        }

        public Alumno Guardar(Alumno alumno)
        {
            try
            {
                Alumno alumnoInsertado;
                this.logger.Debug("Entra Guardar");
                if (!File.Exists(this.Ruta))
                {
                    List<Alumno> alumnos = new List<Alumno>();
                    alumnos.Add(alumno);
                    using (StreamWriter file = File.CreateText(this.Ruta))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(file, alumnos);
                    }
                }
                else
                {
                    string datosFichero = System.IO.File.ReadAllText(this.Ruta);
                    string jsonData = FileUtils.ToJson(datosFichero, alumno);
                    System.IO.File.WriteAllText(this.Ruta, jsonData);
                }
                alumnoInsertado = this.Leer(alumno.Guid);
                this.logger.Debug("Sale Guardar");
                return alumnoInsertado;
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error("No se ha podido cargar el fichero" + exception.Message);
                throw;
            }
        }

        public List<Alumno> Leer()
        {
            try
            {
                this.logger.Debug("Entra Leer");
                this.logger.Debug("Sale Leer");
                return FileUtils.DeserializeFicheroJson(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json"));
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error("No se ha podido cargar el fichero" + exception.Message);
                throw;
            }
        }

        public Alumno Leer(string guid)
        {
            try
            {
                this.logger.Debug("Entra Leer");
                List<Alumno> alumnos = FileUtils.DeserializeFicheroJson(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json"));
                Alumno alumnoInsertado = (alumnos.Where(alumno => alumno.Guid == guid)).FirstOrDefault();
                this.logger.Debug("Salir Leer");
                return alumnoInsertado;
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error(exception.Message);
                throw;
            }
            catch (ArgumentNullException exception)
            {
                this.logger.Error(exception.Message);
                throw;
            }
        }
    }
}
