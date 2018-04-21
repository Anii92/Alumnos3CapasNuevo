using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Enums;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.Dao.Daos;
using Vueling.DataAccess.Dao.Resources;
using static Vueling.Common.Logic.Enums.Formatos;

namespace Vueling.DataAccess.Dao.Factories
{
    public static class AlumnoDaoFactory
    {
        public static Object GetAlumnoDao()
        {
            ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
            logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            switch (Formatos.GetType(Configuraciones.LeerFormatoFichero()))
            {
                case Formato.Sql:
                    logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                    return new BaseDatosDao(new ReadBaseDatos());
                case Formato.Texto:
                    logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                    return new FicheroTxtDao(new ReadFicheroTxt());
                case Formato.Json:
                    logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                    return new FicheroJsonDao(new ReadFicheroJson());
                case Formato.Xml:
                    logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                    return new FicheroXmlDao(new ReadFicheroXml());
                case Formato.Procedure:
                    logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + Configuraciones.LeerFormatoFichero());
                    return new ProcedureDao(new ReadProcedure());
                default:
                    return new BaseDatosDao(new ReadBaseDatos());
            }
        }
    }
}
