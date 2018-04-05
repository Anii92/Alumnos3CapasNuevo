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
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented, settings);
        }

        public static string ToJson(string data, Alumno alumno)
        {
            var employeeList = JsonConvert.DeserializeObject<List<Alumno>>(data);
            employeeList.Add(alumno);
            return JsonConvert.SerializeObject(employeeList, Newtonsoft.Json.Formatting.Indented);
        }

        public static string ToString(Alumno alumno)
        {
            return alumno.Id + "," + alumno.Nombre + "," + alumno.Apellidos + "," + alumno.Dni + "," + alumno.Edad + "," + alumno.FechaNacimiento.ToString() + "," + alumno.FechaHora.ToString() + "," + alumno.MiGuid;
        }

        public static Alumno DeserializeTexto(string pathFile)
        {
            string[] liniaFichero = null;
            foreach (var line in File.ReadAllLines(pathFile))
            {
                liniaFichero = line.Split(',');
            }
            return new Alumno(Convert.ToInt32(liniaFichero[0]), liniaFichero[1], liniaFichero[2], liniaFichero[3], Convert.ToInt32(liniaFichero[4]), Convert.ToDateTime(liniaFichero[5]), Convert.ToDateTime(liniaFichero[6]), liniaFichero[7]);
        }

        public static List<Alumno> DeserializeFicheroTexto(string pathFile)
        {
            List<Alumno> alumnos = new List<Alumno>();
            string[] liniaFichero = null;
            foreach (var line in File.ReadAllLines(pathFile))
            {
                liniaFichero = line.Split(',');
                Alumno alumno = new Alumno(Convert.ToInt32(liniaFichero[0]), liniaFichero[1], liniaFichero[2], liniaFichero[3], Convert.ToInt32(liniaFichero[4]), Convert.ToDateTime(liniaFichero[5]), Convert.ToDateTime(liniaFichero[6]), liniaFichero[7]);
                alumnos.Add(alumno);
            }
            return alumnos;
        }

        public static Alumno DeserializeJson(string pathFile)
        {
            var jsonData = System.IO.File.ReadAllText(pathFile);
            List<Alumno> alumnosList = JsonConvert.DeserializeObject<List<Alumno>>(jsonData);
            return new Alumno(alumnosList[0].Id, alumnosList[0].Nombre, alumnosList[0].Apellidos, alumnosList[0].Dni, alumnosList[0].Edad, alumnosList[0].FechaNacimiento, alumnosList[0].FechaHora, alumnosList[0].MiGuid);
        }

        public static List<Alumno> DeserializeFicheroJson(string pathFile)
        {
            List<Alumno> alumnos = new List<Alumno>();
            if (File.Exists(pathFile))
            {
                var jsonData = System.IO.File.ReadAllText(pathFile);
                alumnos = JsonConvert.DeserializeObject<List<Alumno>>(jsonData);
            }
            return alumnos;
        }

        public static List<Alumno> DeserializeFicheroXml(string pathFile)
        {
            List<Alumno> alumnos = new List<Alumno>();
            if (File.Exists(pathFile))
            {
                var xmlSerializer = new XmlSerializer(alumnos.GetType());

                using (Stream reader = File.OpenRead(pathFile))
                {
                    alumnos = (List<Alumno>)xmlSerializer.Deserialize(reader);
                }
            }
            
            return alumnos;
        }

        public static Alumno DeserializeXml(string pathFile)
        {
            Alumno alumno = new Alumno();
            XmlSerializer serializer = new XmlSerializer(typeof(Alumno));
            using (FileStream fileStream = new FileStream(pathFile, FileMode.Open))
            {
                alumno = (Alumno) serializer.Deserialize(fileStream);
            }
            return alumno;
        }
    }
}
