using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;


namespace Vueling.DataAccess.Dao.Singletons
{
    public sealed class SingletonXml
    {
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
            //Hay que hacerlo para XML
            alumnos = FileUtils.DeserializeFicheroXml(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.xml"));
            return alumnos;
        }

        public List<Alumno> Filtrar(string valor)
        {
            var alumnosFiltrados =
                from alumno in alumnos
                where alumno.Nombre == valor
                select alumno;
            return alumnosFiltrados.ToList();
        }
    }
}
