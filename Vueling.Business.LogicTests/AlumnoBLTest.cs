using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Business.Logic;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao;
using static Vueling.Common.Logic.Enums.Formatos;

namespace Vueling.Business.LogicTests
{
    [TestClass()]
    public class AlumnoBLTest
    {
        private MockFactory mocks;
        private Mock<IAlumnoDao> alumnoDaoMock;
        private Mock<IAlumnoBL> alumnoBLMock;

        [TestInitialize]
        public void Initialize()
        {
            this.mocks = new MockFactory();
            this.alumnoDaoMock = mocks.CreateMock<IAlumnoDao>();
            this.alumnoBLMock = mocks.CreateMock<IAlumnoBL>();
        }

        [TestCleanup]
        public void Exit()
        {
            mocks.ClearExpectations();
        }

        [DataRow(Formato.Texto, 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void AddTest(Formato tipo, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));

            this.alumnoDaoMock.Expects.One
                .MethodWith(alumnoDao => alumnoDao.Add(alumno))
                .WillReturn(alumno);
            Alumno alumnoInsertado = this.alumnoDaoMock.MockObject.Add(alumno);

            Assert.IsTrue(alumno.Equals(alumnoInsertado));
        }

        [DataRow(Formato.Texto, 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void LeerTest(Formato tipo, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));
            List<Alumno> alumnos = new List<Alumno>();
            alumnos.Add(alumno);
            this.alumnoDaoMock.Expects.One
                .MethodWith(alumnoDao => alumnoDao.Leer())
                .WillReturn(alumnos);
            List<Alumno> listadoAlumnos = this.alumnoDaoMock.MockObject.Leer();

            Assert.IsNotNull(listadoAlumnos);
        }

        [DataRow(Formato.Texto, "Nombre", "Lucas", 1, "Lucas", "Perez", "1234", 20, "22-01-1997")]
        [DataRow(Formato.Texto, "Apellidos", "Perez", 1, "Maria", "Perez", "9876", 22, "22-01-1999")]
        [DataRow(Formato.Texto, "Id", "1", 1, "Lucas", "Perez", "1234", 20, "22-01-1997")]
        [DataRow(Formato.Texto, "Dni", "1234", 1, "Lucas", "Perez", "1234", 20, "22-01-1997")]
        [DataRow(Formato.Texto, "Apellidos", "Martinez", 1, "Maria", "Perez", "9876", 22, "22-01-1999")]
        [DataTestMethod]
        public void FiltrarFicheroDeTextoTest(Formato tipo, string clave, string valor, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            Alumno alumnoTest = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));
            this.alumnoDaoMock.Expects.One
                .MethodWith(alumnoDao => alumnoDao.Leer())
                .WillReturn(new List<Alumno> { alumnoTest });
            List<Alumno> alumnos = alumnoDaoMock.MockObject.Leer();

            this.alumnoBLMock.Expects.One
                .MethodWith(alumnoBL => alumnoBL.Filtrar(clave, valor))
                .WillReturn(new List<Alumno> { alumnoTest });

            List<Alumno> alumnosFiltrados = alumnoBLMock.MockObject.Filtrar(clave, valor);
            Assert.IsTrue(alumnosFiltrados.Contains(alumnoTest));
        }

        [DataRow(Formato.Json, "Nombre", "Lucas", 1, "Lucas", "Perez", "1234", 20, "22-01-1997")]
        [DataRow(Formato.Json, "Apellidos", "Perez", 1, "Maria", "Perez", "9876", 22, "22-01-1999")]
        [DataRow(Formato.Json, "Id", "1", 1, "Lucas", "Perez", "1234", 20, "22-01-1997")]
        [DataRow(Formato.Json, "Dni", "1234", 1, "Lucas", "Perez", "1234", 20, "22-01-1997")]
        [DataRow(Formato.Json, "Apellidos", "Martinez", 1, "Maria", "Perez", "9876", 22, "22-01-1999")]
        [DataTestMethod]
        public void FiltrarFicheroDeJsonTest(Formato tipo, string clave, string valor, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            Alumno alumnoTest = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));
            this.alumnoDaoMock.Expects.One
                .MethodWith(alumnoDao => alumnoDao.Leer())
                .WillReturn(new List<Alumno> { alumnoTest });
            List<Alumno> alumnos = this.alumnoDaoMock.MockObject.Leer();

            this.alumnoBLMock.Expects.One
                .MethodWith(alumnoBL => alumnoBL.Filtrar(clave, valor))
                .WillReturn(new List<Alumno> { alumnoTest });
            List<Alumno> alumnosFiltrados = alumnoBLMock.MockObject.Filtrar(clave, valor);
            Assert.IsTrue(alumnosFiltrados.Contains(alumnoTest));
        }

        [DataRow(Formato.Xml, "Nombre", "Lucas", 1, "Lucas", "Perez", "1234", 20, "22-01-1997")]
        [DataRow(Formato.Xml, "Apellidos", "Perez", 1, "Maria", "Perez", "9876", 22, "22-01-1999")]
        [DataRow(Formato.Xml, "Id", "1", 1, "Lucas", "Perez", "1234", 20, "22-01-1997")]
        [DataRow(Formato.Xml, "Dni", "1234", 1, "Lucas", "Perez", "1234", 20, "22-01-1997")]
        [DataRow(Formato.Xml, "Apellidos", "Martinez", 1, "Maria", "Perez", "9876", 22, "22-01-1999")]
        [DataTestMethod]
        public void FiltrarFicheroDeXmlTest(Formato tipo, string clave, string valor, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            Alumno alumnoTest = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));
            this.alumnoDaoMock.Expects.One
                .MethodWith(alumnoDao => alumnoDao.Leer())
                .WillReturn(new List<Alumno> { alumnoTest });
            List<Alumno> alumnos = this.alumnoDaoMock.MockObject.Leer();

            this.alumnoBLMock.Expects.One
                .MethodWith(alumnoBL => alumnoBL.Filtrar(clave, valor))
                .WillReturn(new List<Alumno> { alumnoTest });
            List<Alumno> alumnosFiltrados = alumnoBLMock.MockObject.Filtrar(clave, valor);

            Assert.IsTrue(alumnosFiltrados.Contains(alumnoTest));
        }
    }
}
