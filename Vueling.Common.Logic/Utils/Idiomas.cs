using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.Resources;

namespace Vueling.Common.Logic.Utils
{
    public static class Idiomas
    {
        #region ConfigurarIdiomaUsuario
        public static string LeerIdiomaUsuario()
        {
            ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
            try
            {
                logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string format = config.AppSettings.Settings[ResourcesConfiguracion.Idioma].Value;
                logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return format;
            }
            catch (ConfigurationErrorsException exception)
            {
                logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }
        public static void GuardarIdiomaUsuario(string culture)
        {
            ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
            try
            {
                logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings[ResourcesConfiguracion.Idioma]))
                {
                    config.AppSettings.Settings.Add(ResourcesConfiguracion.Idioma, culture);
                }
                else
                {
                    config.AppSettings.Settings[Resources.ResourcesConfiguracion.Idioma].Value = culture;
                }
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("appSettings");
                logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (ConfigurationErrorsException exception)
            {
                logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }
        #endregion

        public static void CambiarIdioma(string idioma)
        {
            GuardarIdiomaUsuario(idioma);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(idioma);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(idioma);
        }
    }
}
