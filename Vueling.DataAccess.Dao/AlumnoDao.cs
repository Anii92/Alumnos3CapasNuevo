using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Factories;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.DataAccess.Dao
{
    public class AlumnoDao : IAlumnoDao
    {
        Logger logger = new Logger();
        public AlumnoDao()
        {
        }

        public Alumno Add(Alumno alumno, TipoFichero tipoFichero)
        {
            try
            {
                this.logger.Debug("Entra Add");
                IFichero fichero = (IFichero)FicheroFactory.CrearFichero(tipoFichero, "ListadoAlumno");
                fichero.Guardar(alumno);
                this.logger.Debug("Sale Add");
                return alumno;
            }
            catch (ArgumentException exception)
            {
                logger.Error(exception.Message);
                throw;
            }
        }
    }
}
