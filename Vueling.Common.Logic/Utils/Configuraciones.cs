using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.Resources;
using static Vueling.Common.Logic.Enums.Formatos;

namespace Vueling.Common.Logic.Utils
{
    public static class Configuraciones
    {
        #region Atributos
        private static ILogger logger = CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType); 
        #endregion

        #region ConfigurarFormatoFichero
        public static string LeerFormatoFichero()
        {
            try
            {
                logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string format = config.AppSettings.Settings[ResourcesConfiguracion.ExtensionFichero].Value;
                logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return format;
            }
            catch (ConfigurationErrorsException exception)
            {
                logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }
        public static void GuardarFormatoFichero(Formato Formato)
        {
            try
            {
                logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings[ResourcesConfiguracion.ExtensionFichero]))
                {
                    config.AppSettings.Settings.Add(ResourcesConfiguracion.ExtensionFichero, Formato.ToString());
                }
                else
                {
                    config.AppSettings.Settings[Resources.ResourcesConfiguracion.ExtensionFichero].Value = Formato.ToString();
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

        #region Conexion Base de datos
        public static string LeerConexionBaseDeDatos()
        {
            return Environment.GetEnvironmentVariable(Resources.ResourcesConfiguracion.ConexionBD, EnvironmentVariableTarget.User);
        }
        #endregion

        #region ConfigurarLogger
        public static ILogger CreateInstanceClassLog(Type typeDeclaring)
        {
            try
            {
                var tipoLog = Environment.GetEnvironmentVariable(Resources.ResourcesConfiguracion.TipoLog, EnvironmentVariableTarget.User);
                var key = LeerAppConfig(tipoLog);

                Type t = Assembly.GetExecutingAssembly().GetType(key);

                object[] mParam = new object[] { typeDeclaring };
                return (ILogger)Activator.CreateInstance(t, mParam);
            }
            catch (ArgumentNullException exception)
            {
                throw;
            }
            catch (ArgumentException exception)
            {
                throw;
            }
            
        }
        #endregion

        public static string GetScriptSqlTestPath(string scriptName)
        {
            try
            {
                logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                var key = LeerAppConfig(scriptName);
                var scriptPath = Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.User);
                logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return scriptPath;
            }
            catch (ArgumentNullException exception)
            {
                logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (ArgumentException exception) 
            {
                logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public static string LeerAppConfig(string key)
        {
            try
            {
                System.Configuration.Configuration configuration = null;
                if (HttpContext.Current != null)
                {
                    configuration = WebConfigurationManager.OpenWebConfiguration("~");
                }
                else
                {
                    configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                }
                string log = configuration.AppSettings.Settings[key].Value;
                return log;
            }
            catch (ConfigurationErrorsException exception)
            {
                throw;
            }
        }
        public static void GuardarAppConfig(string key, string value)
        {
            try
            {
                logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Configuration configuration = null;
                if (HttpContext.Current != null)
                {
                    configuration = WebConfigurationManager.OpenWebConfiguration("~");
                }
                else
                {
                    configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                }
                configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings[key]))
                {
                    configuration.AppSettings.Settings.Add(key, value);
                }
                else
                {
                    configuration.AppSettings.Settings[key].Value = value;
                }
                configuration.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("appSettings");
                logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (ConfigurationErrorsException exception)
            {
                logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }
    }
}
