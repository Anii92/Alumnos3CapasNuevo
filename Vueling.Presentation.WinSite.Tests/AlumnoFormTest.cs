using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using Vueling.Business.Logic;

namespace Vueling.Presentation.WinSite.Tests
{
    [TestClass]
    public class AlumnoFormTest
    {
        private MockFactory mocks;
        private Mock<IAlumnoBL> alumnoDaoMock;
        private AlumnoBL alumnoBL;

        [TestInitialize]
        public void Initialize()
        {
            this.mocks = new MockFactory();
            this.alumnoDaoMock = this.mocks.CreateMock<IAlumnoBL>();
            this.alumnoBL = new AlumnoBL();
        }

        [TestMethod]
        public void AddTest()
        {

        }
    }
}
