using log4net;
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
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private SingletonJson singletonJson;

        public FicheroDao()
        {
            Log.Debug("Entra FicheroDao");
            this.singletonJson = SingletonJson.Instance;
            Log.Debug("Sale FicheroDao");
        }

        public List<Alumno> Leer(TipoFichero tipoFichero)
        {
            Log.Debug("Entra Leer");
            IFichero fichero = (IFichero)FicheroFactory.CrearFichero(tipoFichero, "ListadoAlumno");
            Log.Debug("Sale Leer");
            return fichero.Leer();
        }

        public List<Alumno> CargarDatosFichero(TipoFichero tipoFichero)
        {
            Log.Debug("Entra CargarDatosFichero");
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
            Log.Debug("Sale CargarDatosFichero");
            return alumnos;
        }

        public List<Alumno> FiltrarFicheroJsonPorNombre(string valor)
        {
            Log.Debug("Entra FiltrarFicheroJsonPorNombre");
            Log.Debug("Sale FiltrarFicheroJsonPorNombre");
            return this.singletonJson.Filtrar(valor);
        }

        public List<Alumno> CargarDatosFicheroXml()
        {
            Log.Debug("Entra CargarDatosFicheroXml");
            Log.Debug("Sale CargarDatosFicheroXml");
            return new List<Alumno>();
        }
    }
}
