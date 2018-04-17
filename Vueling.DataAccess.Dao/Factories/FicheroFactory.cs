using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.Dao.Resources;
using static Vueling.Common.Logic.Enums.Formatos;

namespace Vueling.DataAccess.Dao.Factories
{
    public static class FicheroFactory
    {
        public static Object CrearFichero(Formato Formato, string nombre)
        {
            try
            {
                ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                switch (Formato)
                {
                    case Formato.Texto:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " "+ Formato.ToString());
                        return new FicheroTxt(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt"));
                    case Formato.Json:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Formato.ToString());
                        return new FicheroJson(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json"));
                    case Formato.Xml:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Formato.ToString());
                        return new FicheroXml(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.xml"));
                    case Formato.Sql:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Formato.ToString());
                        return new AlumnoBaseDatosDao();
                    default:
                        logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Formato.ToString());
                        return new FicheroTxt(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt"));
                }
            }
            catch (ArgumentException exception)
            {
                ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
                logger.Error(exception.Message);
                throw;
            }
        }
    }
}
