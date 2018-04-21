using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Factories;
using Vueling.DataAccess.Dao.Singletons;
using Vueling.DataAccess.Dao.Resources;
using static Vueling.Common.Logic.Enums.Formatos;
using Vueling.Common.Logic.Utils;
using Vueling.Common.Logic.Enums;
using Vueling.Common.Logic.Interfaces;
using System.Reflection;
using Vueling.DataAccess.Dao.Interfaces;
using Newtonsoft.Json;

namespace Vueling.DataAccess.Dao.Daos
{
    public class FicheroJsonDao : Repositorio
    {
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        private ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        public FicheroJsonDao(IRead read) : base(read)
        {
            this.Nombre = "ListadoDeAlumnos";
            this.Ruta = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), this.Nombre + ".json");
        }

        public override Alumno Add(Alumno alumno)
        {
            try
            {
                Alumno alumnoInsertado;
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                if (!File.Exists(this.Ruta))
                {
                    List<Alumno> alumnos = new List<Alumno>();
                    alumnos.Add(alumno);
                    using (StreamWriter file = File.CreateText(this.Ruta))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(file, alumnos);
                    }
                }
                else
                {
                    string datosFichero = System.IO.File.ReadAllText(this.Ruta);
                    string jsonData = FileUtils.ToJson(datosFichero, alumno);
                    System.IO.File.WriteAllText(this.Ruta, jsonData);
                }
                alumnoInsertado = (Alumno) this.ReadByGuid(alumno.Guid);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumnoInsertado;
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public override List<Alumno> Read()
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                List<Alumno> alumnos = this.read.Read();
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumnos;
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public override object ReadByGuid(string guid)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Alumno alumno = (Alumno)this.read.ReadByGuid(guid);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumno;
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
