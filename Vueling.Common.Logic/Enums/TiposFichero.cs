using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Enums
{
    public class TiposFichero
    {
        public enum TipoFichero
        {
            Texto,
            Json,
            Xml,
            Sql
        }

        public static TipoFichero GetType(string value)
        {
            return (TipoFichero)System.Enum.Parse(typeof(TipoFichero), value);
        }
    }
}
