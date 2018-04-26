using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Exceptions
{
    public class VuelingCommonException: Exception
    {
        public VuelingCommonException()
        {

        }

        public VuelingCommonException(string message) : base(message)
        {

        }

        public VuelingCommonException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
