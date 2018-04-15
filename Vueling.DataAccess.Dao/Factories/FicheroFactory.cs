using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Resources;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.DataAccess.Dao.Factories
{
    public static class FicheroFactory
    {
        public static Object CrearFichero(TipoFichero tipoFichero, string nombre)
        {
            try
            {
                Logger logger = new Logger();
                logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                switch (tipoFichero)
                {
                    case TipoFichero.Texto:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " "+ tipoFichero.ToString());
                        return new FicheroTxt(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt"));
                    case TipoFichero.Json:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + tipoFichero.ToString());
                        return new FicheroJson(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json"));
                    case TipoFichero.Xml:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + tipoFichero.ToString());
                        return new FicheroXml(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.xml"));
                    case TipoFichero.Sql:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + tipoFichero.ToString());
                        return new AlumnoBaseDatosDao();
                    default:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + tipoFichero.ToString());
                        return new FicheroTxt(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt"));
                }
            }
            catch (ArgumentException exception)
            {
                Logger logger = new Logger();
                logger.Error(exception.Message);
                throw;
            }
        }
    }
}
