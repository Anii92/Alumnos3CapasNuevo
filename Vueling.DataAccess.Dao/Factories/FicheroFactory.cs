using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.DataAccess.Dao.Factories
{
    public class FicheroFactory
    {
        Logger logger = new Logger();
        public static Object CrearFichero(TipoFichero tipoFichero, string nombre)
        {
            try
            {
                this.logger.Debug("Entra CrearFichero");
                switch (tipoFichero)
                {
                    case TipoFichero.Texto:
                        this.logger.Debug("Sale CrearFichero texto");
                        return new FicheroTxt(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt"));
                    case TipoFichero.Json:
                        this.logger.Debug("Sale CrearFichero json");
                        return new FicheroJson(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json"));
                    case TipoFichero.Xml:
                        this.logger.Debug("Sale CrearFichero xml");
                        return new FicheroXml(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.xml"));
                    default:
                        this.logger.Debug("Sale CrearFichero texto");
                        return new FicheroTxt(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt"));
                }
            }
            catch (ArgumentException exception)
            {
                logger.Error(exception.Message);
                throw;
            }
        }
    }
}
