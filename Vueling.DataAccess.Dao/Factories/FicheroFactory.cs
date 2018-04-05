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
        public static Object CrearFichero(TipoFichero tipoFichero, string nombre)
        {
            switch (tipoFichero)
            {
                case TipoFichero.Texto:
                    return new FicheroTxt(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt"));
                case TipoFichero.Json:
                    return new FicheroJson(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json"));
                case TipoFichero.Xml:
                    return new FicheroXml(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.xml"));
                default:
                    return new FicheroTxt(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt"));
            }
        }
    }
}
