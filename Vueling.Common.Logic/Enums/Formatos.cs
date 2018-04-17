using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Enums
{
    public class Formatos
    {
        public enum Formato
        {
            Texto,
            Json,
            Xml,
            Sql,
            Procedure
        }

        public static Formato GetType(string value)
        {
            return (Formato)System.Enum.Parse(typeof(Formato), value);
        }
    }
}
