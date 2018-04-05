using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;

namespace Vueling.DataAccess.Dao.Singletons
{
    public sealed class SingletonJson
    {
        Logger logger = new Logger();
        private static SingletonJson instance = null;
        private static readonly object padlock = new object();

        private List<Alumno> alumnos;

        private SingletonJson()
        {

        }

        public static SingletonJson Instance
        {
            get
            {
                if (instance == null)
                {
                    lock(padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonJson();
                        }
                    }
                }
                return instance;
            }
        }

        public List<Alumno> Leer()
        {
            try
            {
                alumnos = FileUtils.DeserializeFicheroJson(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json"));
                return alumnos;
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error("No se ha podido cargar el fichero" + exception.Message);
                throw;
            }
        }

        public List<Alumno> Filtrar(string valor)
        {
            try
            {
                var alumnosFiltrados =
                    from alumno in alumnos
                    where alumno.Nombre == valor
                    select alumno;
                return alumnosFiltrados.ToList();
            }
            catch (NullReferenceException exception)
            {
                this.logger.Error("Referencia nula" + exception.Message);
                throw;
            }
        }
    }
}
