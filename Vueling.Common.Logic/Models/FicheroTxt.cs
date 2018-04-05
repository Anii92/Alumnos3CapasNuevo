using log4net;
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
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string Nombre { get; set; }
        public string Ruta { get; set; }

        public FicheroTxt(string nombre, string ruta)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;
        }

        public void Guardar(Alumno alumno)
        {
            Log.Debug("Entra Guardar");
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
            Log.Debug("Sale Guardar");
        }

        public List<Alumno> Leer()
        {
            Log.Debug("Entra Leer");
            Log.Debug("Sale Leer");
            return FileUtils.DeserializeFicheroTexto(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt"));
        }
    }
}
