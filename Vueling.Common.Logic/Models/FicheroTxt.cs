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
        Logger logger = new Logger();
        public string Nombre { get; set; }
        public string Ruta { get; set; }

        public FicheroTxt(string nombre, string ruta)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;
        }

        public void Guardar(Alumno alumno)
        {
            try
            {
                this.logger.Debug("Entra Guardar");
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
                this.logger.Debug("Sale Guardar");
            }
            catch (PathTooLongException exception)
            {
                this.logger.Error("path demasiado largo" + exception.Message);
                throw;
            }
            catch (FileLoadException exception)
            {
                this.logger.Error("Carga de fichero fallida" + exception.Message);
                throw;
            }
        }

        public List<Alumno> Leer()
        {
            try
            {
                this.logger.Debug("Entra Leer");
                this.logger.Debug("Sale Leer");
                return FileUtils.DeserializeFicheroTexto(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt"));
            }
            catch(FileNotFoundException exception)
            {
                this.logger.Error(exception.Message);
                throw;
            }
        }
    }
}
