using log4net;
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
    public sealed class SingletonXml
    {
        Logger logger = new Logger();
        private static SingletonXml instance = null;
        private static readonly object padlock = new object();

        private List<Alumno> alumnos;

        private SingletonXml()
        {

        }

        public static SingletonXml Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonXml();
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
                this.logger.Debug("Entra Leer");
                alumnos = FileUtils.DeserializeFicheroXml(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.xml"));
                this.logger.Debug("Sale Leer");
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
                this.logger.Debug("Entra Filtrar");
                var alumnosFiltrados =
                    from alumno in alumnos
                    where alumno.Nombre == valor
                    select alumno;
                this.logger.Debug("Sale Filtrar");
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

