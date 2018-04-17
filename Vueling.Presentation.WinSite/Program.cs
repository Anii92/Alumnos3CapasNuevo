using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vueling.Common.Logic.Utils;
using static Vueling.Common.Logic.Enums.Formatos;

namespace Vueling.Presentation.WinSite
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Configurar();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AlumnoForm());
        }

        private static void Configurar()
        {
            log4net.Config.XmlConfigurator.Configure();
            Configuraciones.GuardarFormatoFichero(Formato.Texto);
            Idiomas.GuardarIdiomaUsuario(Resources.ResourcesIdiomas.Castellano);
            Idiomas.CambiarIdioma(Resources.ResourcesIdiomas.Castellano);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Idiomas.LeerIdiomaUsuario());
        }
    }
}
