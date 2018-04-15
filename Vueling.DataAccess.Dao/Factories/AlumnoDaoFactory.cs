using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Enums;
using Vueling.Common.Logic.Utils;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.DataAccess.Dao.Factories
{
    public static class AlumnoDaoFactory
    {
        public static Object GetAlumnoDao()
        {
            switch(TiposFichero.GetType(Configuraciones.LeerFormatoFichero()))
            {
                case TipoFichero.Sql:
                    return new AlumnoBaseDatosDao();
                case TipoFichero.Texto:
                    return new AlumnoFicheroDao();
                case TipoFichero.Json:
                    return new AlumnoFicheroDao();
                case TipoFichero.Xml:
                    return new AlumnoFicheroDao();
                default:
                    return new AlumnoBaseDatosDao();
            }
        }
    }
}
