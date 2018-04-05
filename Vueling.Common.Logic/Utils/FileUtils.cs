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
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string ToJson(this object value)
        {
            Log.Debug("Entra ToJson");
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            Log.Debug("Sale ToJson");
            return JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented, settings);
        }

        public static string ToJson(string data, Alumno alumno)
        {
            Log.Debug("Entra ToJson");
            var employeeList = JsonConvert.DeserializeObject<List<Alumno>>(data);
            employeeList.Add(alumno);
            Log.Debug("Sale ToJson");
            return JsonConvert.SerializeObject(employeeList, Newtonsoft.Json.Formatting.Indented);
        }

        public static string ToString(Alumno alumno)
        {
            Log.Debug("Entra ToString");
            Log.Debug("Sale ToString");
            return alumno.Id + "," + alumno.Nombre + "," + alumno.Apellidos + "," + alumno.Dni + "," + alumno.Edad + "," + alumno.FechaNacimiento.ToString() + "," + alumno.FechaHora.ToString() + "," + alumno.MiGuid;
        }

        public static Alumno DeserializeTexto(string pathFile)
        {
            Log.Debug("Entra DeserializeTexto");
            string[] liniaFichero = null;
            foreach (var line in File.ReadAllLines(pathFile))
            {
                liniaFichero = line.Split(',');
            }
            Log.Debug("Sale DeserializeTexto");
            return new Alumno(Convert.ToInt32(liniaFichero[0]), liniaFichero[1], liniaFichero[2], liniaFichero[3], Convert.ToInt32(liniaFichero[4]), Convert.ToDateTime(liniaFichero[5]), Convert.ToDateTime(liniaFichero[6]), liniaFichero[7]);
        }

        public static List<Alumno> DeserializeFicheroTexto(string pathFile)
        {
            Log.Debug("Entra DeserializeFicheroTexto");

            List<Alumno> alumnos = new List<Alumno>();
            if (File.Exists(pathFile))
            {
                string[] liniaFichero = null;
                foreach (var line in File.ReadAllLines(pathFile))
                {
                    liniaFichero = line.Split(',');
                    Alumno alumno = new Alumno(Convert.ToInt32(liniaFichero[0]), liniaFichero[1], liniaFichero[2], liniaFichero[3], Convert.ToInt32(liniaFichero[4]), Convert.ToDateTime(liniaFichero[5]), Convert.ToDateTime(liniaFichero[6]), liniaFichero[7]);
                    alumnos.Add(alumno);
                }
            }
            Log.Debug("Sale DeserializeFicheroTexto");

            return alumnos;
        }

        public static Alumno DeserializeJson(string pathFile)
        {
            Log.Debug("Entra DeserializeJson");
            var jsonData = System.IO.File.ReadAllText(pathFile);
            List<Alumno> alumnosList = JsonConvert.DeserializeObject<List<Alumno>>(jsonData);
            Log.Debug("Sale DeserializeJson");
            return new Alumno(alumnosList[0].Id, alumnosList[0].Nombre, alumnosList[0].Apellidos, alumnosList[0].Dni, alumnosList[0].Edad, alumnosList[0].FechaNacimiento, alumnosList[0].FechaHora, alumnosList[0].MiGuid);
        }

        public static List<Alumno> DeserializeFicheroJson(string pathFile)
        {
            Log.Debug("Entra DeserializeFicheroJson");
            List<Alumno> alumnos = new List<Alumno>();
            if (File.Exists(pathFile))
            {
                var jsonData = System.IO.File.ReadAllText(pathFile);
                alumnos = JsonConvert.DeserializeObject<List<Alumno>>(jsonData);
            }
            Log.Debug("Sale DeserializeFicheroJson");
            return alumnos;
        }

        public static List<Alumno> DeserializeFicheroXml(string pathFile)
        {
            Log.Debug("Entra DeserializeFicheroXml");
            List<Alumno> alumnos = new List<Alumno>();
            if (File.Exists(pathFile))
            {
                var xmlSerializer = new XmlSerializer(alumnos.GetType());

                using (Stream reader = File.OpenRead(pathFile))
                {
                    alumnos = (List<Alumno>)xmlSerializer.Deserialize(reader);
                }
            }
            Log.Debug("Sale DeserializeFicheroXml");
            return alumnos;
        }

        public static Alumno DeserializeXml(string pathFile)
        {
            Log.Debug("Entra DeserializeFicheroXml");
            Alumno alumno = new Alumno();
            XmlSerializer serializer = new XmlSerializer(typeof(Alumno));
            using (FileStream fileStream = new FileStream(pathFile, FileMode.Open))
            {
                alumno = (Alumno) serializer.Deserialize(fileStream);
            }
            Log.Debug("Sale DeserializeFicheroXml");
            return alumno;
        }
    }
}
