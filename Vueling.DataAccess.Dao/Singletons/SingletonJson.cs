using log4net;
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
using Vueling.DataAccess.Dao.Resources;

namespace Vueling.DataAccess.Dao.Singletons
{
    public sealed class SingletonJson
    {
        private static SingletonJson instance = null;
        private static readonly object padlock = new object();

        private ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        private List<Alumno> alumnos { get; set; }

        private SingletonJson()
        {
            alumnos = new List<Alumno>();
        }

        public static SingletonJson Instance
        {
            get
            {
                if (instance == null)
                {
                    lock(padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonJson();
                        }
                    }
                }
                return instance;
            }
        }

        public void Cargar()
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                alumnos = FileUtils.DeserializeFicheroJson(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json"));
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public List<Alumno> Leer()
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return this.alumnos;
            }
            catch (NullReferenceException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public List<Alumno> Filtrar(string valor)
        {
            try
            {
                this.logger.Debug("Entra Filtrar");
                var alumnosFiltrados =
                    from alumno in alumnos
                    where alumno.Nombre == valor
                    select alumno;
                this.logger.Debug("Sale Filtrar");
                return alumnosFiltrados.ToList();
            }
            catch (NullReferenceException exception)
            {
                this.logger.Error("Referencia nula" + exception.Message);
                throw;
            }
        }
    }
}
