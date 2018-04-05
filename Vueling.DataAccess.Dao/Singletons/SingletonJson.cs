using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;

namespace Vueling.DataAccess.Dao.Singletons
{
    public sealed class SingletonJson
    {
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
            alumnos = FileUtils.DeserializeFicheroJson(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json"));
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
