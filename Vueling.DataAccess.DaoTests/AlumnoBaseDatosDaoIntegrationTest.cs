using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.Dao;

namespace Vueling.DataAccess.DaoTests
{
    [TestClass()]
    public class AlumnoBaseDatosDaoIntegrationTest
    {
        private AlumnoBaseDatosDao alumnoBaseDatosDao;
        private Alumno alumnoTest;

        [TestInitialize]
        public void Initialize()
        {
            this.alumnoBaseDatosDao = new AlumnoBaseDatosDao();
            this.alumnoTest = new Alumno(1, "Antonio", "Lopez", "12345678A", 21, Convert.ToDateTime("2017-12-12"), DateTime.Now, "123-123-123");
        }

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            FileInfo file = new FileInfo(Configuraciones.GetScriptSqlTestPath("scriptInsertSqlTest"));
            string script = file.OpenText().ReadToEnd();
            using (SqlConnection connection = new SqlConnection(Configuraciones.LeerConexionBaseDeDatos()))
            {
                using (SqlCommand command = new SqlCommand(script, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        [DataRow(1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void AddSqlTest(int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));
            Alumno alumnoBD = (Alumno)this.alumnoBaseDatosDao.Add(alumno);
            alumno.Equals(alumnoBD);
        }

        [TestMethod]
        public void GetByIdSqlTest()
        {
            Alumno alumnoBD = (Alumno)this.alumnoBaseDatosDao.GetById(this.alumnoTest.Id);
            this.alumnoTest.Equals(alumnoBD);
        }

        [TestMethod]
        public void GetByGuidSqlTest()
        {
            Alumno alumnoBD = (Alumno)this.alumnoBaseDatosDao.GetByGuid(this.alumnoTest.Guid);
            this.alumnoTest.Equals(alumnoBD);
        }

        [DataRow("Manolo")]
        [DataTestMethod]
        public void UpdateNameSqlTest(string nombre)
        {
            Alumno alumnoBD = (Alumno)this.alumnoBaseDatosDao.UpdateName(nombre, this.alumnoTest.Guid);
            Assert.AreEqual(nombre, alumnoBD.Nombre);
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            FileInfo file = new FileInfo(Configuraciones.GetScriptSqlTestPath("scriptDeleteSqlTest"));
            string script = file.OpenText().ReadToEnd();
            using (SqlConnection connection = new SqlConnection(Configuraciones.LeerConexionBaseDeDatos()))
            {
                using (SqlCommand command = new SqlCommand(script, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
