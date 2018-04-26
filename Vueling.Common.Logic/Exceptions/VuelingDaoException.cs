using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Exceptions
{
    public class VuelingDaoException: Exception
    {
        public VuelingDaoException()
        {

        }

        public VuelingDaoException(string message) : base(message)
        {

        }

        public VuelingDaoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
