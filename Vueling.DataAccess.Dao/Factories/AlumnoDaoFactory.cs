using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Enums;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.Dao.Resources;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.DataAccess.Dao.Factories
{
    public static class AlumnoDaoFactory
    {
        public static Object GetAlumnoDao()
        {
            ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
            logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            switch (TiposFichero.GetType(Configuraciones.LeerFormatoFichero()))
            {
                case TipoFichero.Sql:
                    logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                    return new AlumnoBaseDatosDao();
                case TipoFichero.Texto:
                    logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                    return new AlumnoFicheroDao();
                case TipoFichero.Json:
                    logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                    return new AlumnoFicheroDao();
                case TipoFichero.Xml:
                    logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                    return new AlumnoFicheroDao();
                default:
                    return new AlumnoBaseDatosDao();
            }
        }
    }
}
