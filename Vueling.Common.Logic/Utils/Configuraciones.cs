using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.Resources;
using static Vueling.Common.Logic.Enums.TiposFichero;

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
        public static void GuardarFormatoFichero(TipoFichero tipoFichero)
        {
            try
            {
                logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings[ResourcesConfiguracion.ExtensionFichero]))
                {
                    config.AppSettings.Settings.Add(ResourcesConfiguracion.ExtensionFichero, tipoFichero.ToString());
                }
                else
                {
                    config.AppSettings.Settings[Resources.ResourcesConfiguracion.ExtensionFichero].Value = tipoFichero.ToString();
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
            var tipoLog = Environment.GetEnvironmentVariable(Resources.ResourcesConfiguracion.TipoLog, EnvironmentVariableTarget.User);
            var key = System.Configuration.ConfigurationManager.AppSettings[tipoLog];

            Type t = Assembly.GetExecutingAssembly().GetType(key);

            object[] mParam = new object[] { typeDeclaring };
            ILogger log = (ILogger)Activator.CreateInstance(t, mParam);
            return (ILogger)Activator.CreateInstance(t, mParam);
        } 
        #endregion
    }
}
