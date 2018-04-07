using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Vueling.Common.Logic.Models;

namespace Vueling.Common.Logic
{
    public static class FileUtils
    {
        public static string ToJson(this object value)
        {
            Logger logger = new Logger();
            logger.Debug("Entra ToJson");
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            logger.Debug("Sale ToJson");
            return JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented, settings);
        }

        public static string ToJson(string data, Alumno alumno)
        {
            try
            {
                Logger logger = new Logger();
                logger.Debug("Entra ToJson");
                var employeeList = JsonConvert.DeserializeObject<List<Alumno>>(data);
                employeeList.Add(alumno);
                logger.Debug("Sale ToJson");
                return JsonConvert.SerializeObject(employeeList, Newtonsoft.Json.Formatting.Indented);
            }
            catch (FileNotFoundException exception)
            {
                Logger logger = new Logger();
                logger.Error("No se ha podido cargar el fichero" + exception.Message);
                throw;
            }
        }

        public static string ToString(Alumno alumno)
        {
            Logger logger = new Logger();
            logger.Debug("Entra ToString");
            logger.Debug("Sale ToString");
            return alumno.Id + "," + alumno.Nombre + "," + alumno.Apellidos + "," + alumno.Dni + "," + alumno.Edad + "," + alumno.FechaNacimiento.ToString() + "," + alumno.FechaHora.ToString() + "," + alumno.Guid;
        }

        public static Alumno DeserializeTexto(string pathFile)
        {
            try
            {
                Logger logger = new Logger();
                logger.Debug("Entra DeserializeTexto");
                string[] liniaFichero = null;
                foreach (var line in File.ReadAllLines(pathFile))
                {
                    liniaFichero = line.Split(',');
                }
                logger.Debug("Sale DeserializeTexto");
                return new Alumno(Convert.ToInt32(liniaFichero[0]), liniaFichero[1], liniaFichero[2], liniaFichero[3], Convert.ToInt32(liniaFichero[4]), Convert.ToDateTime(liniaFichero[5]), Convert.ToDateTime(liniaFichero[6]), liniaFichero[7]);
            }
            catch (FileLoadException exception)
            {
                Logger logger = new Logger();
                logger.Error("No se ha podido cargar el fichero" + exception.Message);
                throw;
            }
            
        }

        public static List<Alumno> DeserializeFicheroTexto(string pathFile)
        {
            try
            {
                Logger logger = new Logger();
                logger.Debug("Entra DeserializeFicheroTexto");
                List<Alumno> alumnos = new List<Alumno>();
                string[] liniaFichero = null;
                foreach (var line in File.ReadAllLines(pathFile))
                {
                    liniaFichero = line.Split(',');
                    Alumno alumno = new Alumno(Convert.ToInt32(liniaFichero[0]), liniaFichero[1], liniaFichero[2], liniaFichero[3], Convert.ToInt32(liniaFichero[4]), Convert.ToDateTime(liniaFichero[5]), Convert.ToDateTime(liniaFichero[6]), liniaFichero[7]);
                    alumnos.Add(alumno);
                }
                logger.Debug("Sale DeserializeFicheroTexto");
                return alumnos;
            }
            catch (FileLoadException exception)
            {
                Logger logger = new Logger();
                logger.Error("No se ha podido cargar el fichero" + exception.Message);
                throw;
            }
        }

        public static Alumno DeserializeJson(string pathFile)
        {
            try
            {
                Logger logger = new Logger();
                logger.Debug("Entra DeserializeJson");
                var jsonData = System.IO.File.ReadAllText(pathFile);
                List<Alumno> alumnosList = JsonConvert.DeserializeObject<List<Alumno>>(jsonData);
                logger.Debug("Sale DeserializeJson");
                return new Alumno(alumnosList[0].Id, alumnosList[0].Nombre, alumnosList[0].Apellidos, alumnosList[0].Dni, alumnosList[0].Edad, alumnosList[0].FechaNacimiento, alumnosList[0].FechaHora, alumnosList[0].Guid);
            
            }
            catch (FileNotFoundException exception)
            {
                Logger logger = new Logger();
                logger.Error("No se ha podido cargar el fichero" + exception.Message);
                throw;
            }
            
        }

        public static List<Alumno> DeserializeFicheroJson(string pathFile)
        {
            try
            {
                Logger logger = new Logger();
                logger.Debug("Entra DeserializeFicheroJson");
                List<Alumno> alumnos = new List<Alumno>();
                if (File.Exists(pathFile))
                {
                    var jsonData = System.IO.File.ReadAllText(pathFile);
                    alumnos = JsonConvert.DeserializeObject<List<Alumno>>(jsonData);
                }
                logger.Debug("Sale DeserializeFicheroJson");
                return alumnos;
            }
            catch (FileNotFoundException exception)
            {
                Logger logger = new Logger();
                logger.Error("No se ha podido cargar el fichero" + exception.Message);
                throw;
            }
        }

        public static List<Alumno> DeserializeFicheroXml(string pathFile)
        {
            try
            {
                Logger logger = new Logger();
                logger.Debug("Entra DeserializeFicheroXml");
                List<Alumno> alumnos = new List<Alumno>();
                if (File.Exists(pathFile))
                {
                    var xmlSerializer = new XmlSerializer(alumnos.GetType());

                    using (Stream reader = File.OpenRead(pathFile))
                    {
                        alumnos = (List<Alumno>)xmlSerializer.Deserialize(reader);
                    }
                }
                logger.Debug("Sale DeserializeFicheroXml");
                return alumnos;
            }
            catch (FileLoadException exception)
            {
                Logger logger = new Logger();
                logger.Error("No se ha podido cargar el fichero" + exception.Message);
                throw;
            }
        }

        public static Alumno DeserializeXml(string pathFile)
        {
            try
            {
                Logger logger = new Logger();
                logger.Debug("Entra DeserializeFicheroXml");
                Alumno alumno = new Alumno();
                XmlSerializer serializer = new XmlSerializer(typeof(Alumno));
                using (FileStream fileStream = new FileStream(pathFile, FileMode.Open))
                {
                    alumno = (Alumno)serializer.Deserialize(fileStream);
                }
                logger.Debug("Sale DeserializeFicheroXml");
                return alumno;
            }
            catch (FileLoadException exception)
            {
                Logger logger = new Logger();
                logger.Error("No se ha podido cargar el fichero" + exception.Message);
                throw;
            }
        }
    }
}
