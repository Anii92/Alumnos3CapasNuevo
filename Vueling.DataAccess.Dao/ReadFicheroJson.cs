using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.Dao.Interfaces;
using Vueling.DataAccess.Dao.Resources;

namespace Vueling.DataAccess.Dao
{
    public class ReadFicheroJson : IRead
    {
        private ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        private string Nombre { get; set; }
        private string Ruta { get; set; }

        public ReadFicheroJson()
        {
            this.Nombre = "ListadoDeAlumnos";
            this.Ruta = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), this.Nombre + ".json");
        }

        public List<Alumno> Read()
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return FileUtils.DeserializeFicheroJson(this.Ruta);
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public object ReadByGuid(string guid)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                List<Alumno> alumnos = FileUtils.DeserializeFicheroJson(this.Ruta);
                Alumno alumnoInsertado = (alumnos.Where(alumno => alumno.Guid == guid)).FirstOrDefault();
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumnoInsertado;
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (ArgumentNullException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }
    }
}
