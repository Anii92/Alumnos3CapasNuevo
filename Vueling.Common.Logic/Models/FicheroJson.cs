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
        public string Nombre { get; set; }
        public string Ruta { get; set; }

        public FicheroJson(string nombre, string ruta)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;
        }

        public void Guardar(Alumno alumno)
        {
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
        }

        public List<Alumno> Leer()
        {
            return FileUtils.DeserializeFicheroJson(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json"));
        }
    }
}
