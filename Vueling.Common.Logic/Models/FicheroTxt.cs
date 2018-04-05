using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;

namespace Vueling.Common.Logic.Models
{
    public class FicheroTxt: IFichero
    {
        public string Nombre { get; set; }
        public string Ruta { get; set; }

        public FicheroTxt(string nombre, string ruta)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;
        }

        public void Guardar(Alumno alumno)
        {
            if (!File.Exists(this.Ruta))
            {
                using (StreamWriter sw = File.CreateText(this.Ruta))
                {
                    sw.WriteLine(FileUtils.ToString(alumno));
                }
            }
            else
            {
                File.AppendAllText(this.Ruta, FileUtils.ToString(alumno) + Environment.NewLine);
            }
        }

        public List<Alumno> Leer()
        {
            return FileUtils.DeserializeFicheroTexto(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt"));
        }
    }
}
