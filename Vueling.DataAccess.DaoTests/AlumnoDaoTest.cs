using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.DataAccess.DaoTests
{
    [TestClass()]
    public class AlumnoDaoTest
    {
        private MockFactory mocks;
        private Mock<IFichero> ficheroMock;

        [TestInitialize]
        public void Initialize()
        {
            this.mocks = new MockFactory();
            this.ficheroMock = this.mocks.CreateMock<IFichero>();
        }

        [DataRow(TipoFichero.Texto, 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void AddTest(TipoFichero tipo, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));

            this.ficheroMock.Expects.One
                .MethodWith(fichero => fichero.Guardar(alumno))
                .WillReturn(alumno);
            Alumno alumnoInsertado = this.ficheroMock.MockObject.Guardar(alumno);

            Assert.IsTrue(alumno.Equals(alumnoInsertado));
        }
    }
}
