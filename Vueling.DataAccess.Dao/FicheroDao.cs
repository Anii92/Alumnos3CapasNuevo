using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Factories;
using Vueling.DataAccess.Dao.Singletons;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.DataAccess.Dao
{
    public class FicheroDao: IFicheroDao
    {
        private SingletonJson singletonJson;

        public FicheroDao()
        {
            this.singletonJson = SingletonJson.Instance;
        }

        public List<Alumno> Leer(TipoFichero tipoFichero)
        {
            IFichero fichero = (IFichero)FicheroFactory.CrearFichero(tipoFichero, "ListadoAlumno");
            return fichero.Leer();
        }

        public List<Alumno> CargarDatosFichero(TipoFichero tipoFichero)
        {
            List<Alumno> alumnos = new List<Alumno>();
            switch(tipoFichero)
            {
                case (TipoFichero.Json):
                    alumnos = SingletonJson.Instance.Leer();
                    break;
                case (TipoFichero.Xml):
                    alumnos = SingletonXml.Instance.Leer();
                    break;
                default:
                    alumnos = SingletonJson.Instance.Leer();
                    break;
            }
            return alumnos;
        }

        public List<Alumno> FiltrarFicheroJsonPorNombre(string valor)
        {
            return this.singletonJson.Filtrar(valor);
        }

        public List<Alumno> CargarDatosFicheroXml()
        {
            return new List<Alumno>();
        }
    }
}
