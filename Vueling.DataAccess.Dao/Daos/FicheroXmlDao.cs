﻿using log4net;
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
using System.Xml.Serialization;
using Vueling.Common.Logic.Exceptions;

namespace Vueling.DataAccess.Dao.Daos
{
    public class FicheroXmlDao : Repositorio
    {
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        private ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        public FicheroXmlDao(IRead read) : base(read)
        {
            this.Nombre = "ListadoDeAlumnos";
            this.Ruta = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), this.Nombre + ".xml");
        }

        public override Alumno Add(Alumno alumno)
        {
            this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<Alumno> alumnos = new List<Alumno>();
            var xmlSerializer = new XmlSerializer(typeof(List<Alumno>));
            try
            {
                Alumno alumnoInsertado;
                if (File.Exists(this.Ruta))
                {
                    using (Stream reader = File.OpenRead(this.Ruta))
                    {
                        alumnos = (List<Alumno>)xmlSerializer.Deserialize(reader);
                    }
                }
                alumnos.Add(alumno);
                using (Stream writer = File.Open(this.Ruta, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    xmlSerializer.Serialize(writer, alumnos);
                }
                alumnoInsertado = (Alumno) this.ReadByGuid(alumno.Guid);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumnoInsertado;
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
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
                throw new VuelingDaoException(exception.Message, exception.InnerException);
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
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
            catch (ArgumentNullException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
        }
    }
}
