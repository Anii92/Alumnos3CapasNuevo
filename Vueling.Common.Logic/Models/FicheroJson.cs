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
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string Nombre { get; set; }
        public string Ruta { get; set; }

        public FicheroJson(string nombre, string ruta)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;
        }

        public void Guardar(Alumno alumno)
        {
            Log.Debug("Entra Guardar");
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
            Log.Debug("Sale Guardar");
        }

        public List<Alumno> Leer()
        {
            Log.Debug("Entra Leer");
            Log.Debug("Sale Leer");
            return FileUtils.DeserializeFicheroJson(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json"));
        }
    }
}
