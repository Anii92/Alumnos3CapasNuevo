using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Vueling.DataAccess.Dao.Factories;
using static Vueling.Common.Logic.Enums.Formatos;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Utils;
using Vueling.Common.Logic.Models;
using Newtonsoft.Json;
using Vueling.Business.Logic;
using Vueling.DataAccess.Dao.Singletons;

namespace Vueling.DataAccess.Dao.Tests
{
    [TestClass()]
    public class AlumnoDaoIntegrationTests
    {
        private AlumnoFicheroDao alumnoDao;

        [TestInitialize]
        public void Initialize()
        {
            this.alumnoDao = new AlumnoFicheroDao();
            this.EliminarFichero();
        }

        private void EliminarFichero()
        {
            string[] fileEntries = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.*");
            for (int i = 0; i < fileEntries.Length; ++i)
            {
                File.Delete(fileEntries[i]);
            }
        }

        [DataRow(Formato.Texto, "MiPrimerFicheroTxt.txt")]
        [DataTestMethod]
        public void CrearFormatoFactoryTest(Formato tipo, string nombre)
        {
            IFichero fichero = (IFichero)FicheroFactory.CrearFichero(tipo, nombre);
            Assert.IsTrue(fichero.GetType() == typeof(FicheroTxt));
        }

        [DataRow(Formato.Json, "MiPrimerFicheroJson.json")]
        [DataTestMethod]
        public void CrearFormatoJsonFactoryTest(Formato tipo, string nombre)
        {
            IFichero fichero = (IFichero)FicheroFactory.CrearFichero(tipo, nombre);
            Assert.IsTrue(fichero.GetType() == typeof(FicheroJson));
        }

        [DataRow(Formato.Xml, "MiPrimerFicheroJson.xml")]
        [DataTestMethod]
        public void CrearFormatoXmlFactoryTest(Formato tipo, string nombre)
        {
            IFichero fichero = (IFichero)FicheroFactory.CrearFichero(tipo, nombre);
            Assert.IsTrue(fichero.GetType() == typeof(FicheroXml));
        }

        [DataRow(Formato.Texto, "ListadoDeAlumnos.txt", 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataRow(Formato.Json, "ListadoDeAlumnos.json", 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataRow(Formato.Xml, "ListadoDeAlumnos.xml", 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void CrearFicheroTest(Formato tipo, string nombreFichero, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            IFichero fichero = (IFichero)FicheroFactory.CrearFichero(tipo, nombreFichero);
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));

            fichero.Guardar(alumno);
            Assert.IsTrue(File.Exists(fichero.Ruta));
        }

        [DataRow(Formato.Texto, "ListadoDeAlumnos.txt", 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void GuardarAlumnoFicheroTextoTest(Formato tipo, string nombreFichero, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            IFichero fichero = (IFichero)FicheroFactory.CrearFichero(tipo, nombreFichero);
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));

            fichero.Guardar(alumno);

            Alumno alumnoFichero = FileUtils.DeserializeTexto(fichero.Ruta);
            Assert.IsTrue(alumno.Equals(alumnoFichero));
        }

        [DataRow(Formato.Json, "ListadoDeAlumnos.json", 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void GuardarAlumnoFicheroJsonTest(Formato tipo, string nombreFichero, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            IFichero fichero = (IFichero)FicheroFactory.CrearFichero(tipo, nombreFichero);
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));

            fichero.Guardar(alumno);

            Alumno alumnoFichero = FileUtils.DeserializeJson(fichero.Ruta);
            Assert.IsTrue(alumno.Equals(alumnoFichero));
        }

        [DataRow(Formato.Xml, "ListadoDeAlumnos.xml", 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void GuardarAlumnoFicheroXmlTest(Formato tipo, string nombreFichero, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            IFichero fichero = (IFichero)FicheroFactory.CrearFichero(tipo, nombreFichero);
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));

            fichero.Guardar(alumno);

            Alumno alumnoFichero = FileUtils.DeserializeXml(fichero.Ruta);
            Assert.IsTrue(alumno.Equals(alumnoFichero));
        }

        [DataRow(Formato.Xml)]
        [DataTestMethod]
        public void CargarDatosDeLosAlumnosXmlTest(Formato Formato)
        {
            Configuraciones.GuardarFormatoFichero(Formato);
            this.alumnoDao.CargarDatosDeLosAlumnos(Formato);
            List<Alumno> alumnos = this.alumnoDao.Leer();
            Assert.IsNotNull(alumnos);
        }

        [DataRow(Formato.Json)]
        [DataTestMethod]
        public void CargarDatosDeLosAlumnosJsonTest(Formato Formato)
        {
            Configuraciones.GuardarFormatoFichero(Formato);
            this.alumnoDao.CargarDatosDeLosAlumnos(Formato);
            List<Alumno> alumnos = this.alumnoDao.Leer();
            Assert.IsNotNull(alumnos);
        }
    }
}