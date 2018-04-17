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
using static Vueling.Common.Logic.Enums.Formatos;

namespace Vueling.DataAccess.DaoTests
{
    [TestClass()]
    public class AlumnoDaoTest
    {
        private MockFactory mocks;
        private Mock<IFichero> ficheroMock;
        private Mock<IAlumnoBL> alumnoBLMock;

        [TestInitialize]
        public void Initialize()
        {
            this.mocks = new MockFactory();
            this.ficheroMock = this.mocks.CreateMock<IFichero>();
            this.alumnoBLMock = this.mocks.CreateMock<IAlumnoBL>();
        }

        [DataRow(Formato.Texto, 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void AddTest(Formato tipo, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));

            this.ficheroMock.Expects.One
                .MethodWith(fichero => fichero.Guardar(alumno))
                .WillReturn(alumno);
            Alumno alumnoInsertado = this.ficheroMock.MockObject.Guardar(alumno);

            Assert.IsTrue(alumno.Equals(alumnoInsertado));
        }

        [DataRow(Formato.Texto, 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void LeerTest(Formato tipo, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));
            List<Alumno> alumnos = new List<Alumno>();
            alumnos.Add(alumno);
            this.ficheroMock.Expects.One
                .MethodWith(fichero => fichero.Leer())
                .WillReturn(alumnos);
            List<Alumno> listadoAlumnos = this.ficheroMock.MockObject.Leer();

            Assert.IsNotNull(listadoAlumnos);
        }

        [DataRow("22-01-1992")]
        [DataTestMethod]
        public void CalcularEdad(string fechaNacimiento)
        {
            DateTime fecha = Convert.ToDateTime(fechaNacimiento);
            this.alumnoBLMock.Expects.One
                .MethodWith(alumnoBL => alumnoBL.CalcularEdad(fecha))
                .WillReturn(20);
        }
    }
}
