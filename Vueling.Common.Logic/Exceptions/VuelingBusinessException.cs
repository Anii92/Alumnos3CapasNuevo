using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Exceptions
{
    public class VuelingBusinessException: Exception
    {
        public VuelingBusinessException()
        {

        }

        public VuelingBusinessException(string message) : base(message)
        {

        }

        public VuelingBusinessException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
