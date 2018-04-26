using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using Vueling.Business.Facade.WebServices.Resources;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.Utils;

namespace Vueling.Business.Facade.WebServices.Controllers
{
    public class AlumnoController : ApiController
    {
        //private ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        private IAlumnoBL alumnoBL = new AlumnoBL();

        [HttpGet()]
        public IHttpActionResult GetAllStudents()
        {
            try
            {
                //this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return Ok(this.alumnoBL.Leer());
            }
            catch (Exception exception)
            {
                //this.logger.Error(exception.Message + exception.StackTrace);
                return InternalServerError();
            }
        }
    }
}
