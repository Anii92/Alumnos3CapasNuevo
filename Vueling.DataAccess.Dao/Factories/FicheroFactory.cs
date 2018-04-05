using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.DataAccess.Dao.Factories
{
    public class FicheroFactory
    {
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static Object CrearFichero(TipoFichero tipoFichero, string nombre)
        {
            Log.Debug("Entra CrearFichero");
            switch (tipoFichero)
            {
                case TipoFichero.Texto:
                    Log.Debug("Sale CrearFichero");
                    return new FicheroTxt(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt"));
                case TipoFichero.Json:
                    Log.Debug("Sale CrearFichero");
                    return new FicheroJson(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json"));
                case TipoFichero.Xml:
                    Log.Debug("Sale CrearFichero");
                    return new FicheroXml(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.xml"));
                default:
                    Log.Debug("Sale CrearFichero");
                    return new FicheroTxt(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt"));
            }
            
        }
    }
}
