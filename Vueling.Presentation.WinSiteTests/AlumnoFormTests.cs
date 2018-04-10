using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Presentation.WinSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMock;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Models;

namespace Vueling.Presentation.WinSite.Tests
{
    [TestClass()]
    public class AlumnoFormTests
    {
        private MockFactory mocks;
        private Mock<IAlumnoBL> alumnoBLMock;

        [TestInitialize]
        public void Initialize()
        {
            this.mocks = new MockFactory();
            this.alumnoBLMock = this.mocks.CreateMock<IAlumnoBL>();
        }

        [DataRow(1, "Lucas", "Perez", "1234", 20, "22-01-1997")]
        [DataTestMethod]
        public void btnTxt_ClickTest(int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            DateTime fecha = Convert.ToDateTime(fechaNacimiento);
            Alumno alumnoTest = new Alumno();
            alumnoTest.Id = id;
            alumnoTest.Nombre = nombre;
            alumnoTest.Apellidos = apellidos;
            alumnoTest.Dni = dni;
            alumnoTest.FechaNacimiento = fecha;
            
            this.alumnoBLMock.Expects.One
                .MethodWith(alumnoBL => alumnoBL.CalcularEdad(fecha))
                .WillReturn(20);
            Assert.Fail();
        }
    }
}