using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Utils
{
    public static class DatabaseUtils
    {
        public static void EjecutarScript(string scriptName)
        {
            FileInfo file = new FileInfo(Configuraciones.GetScriptSqlTestPath(scriptName));
            string script = file.OpenText().ReadToEnd();
            using (SqlConnection connection = new SqlConnection(Configuraciones.LeerConexionBaseDeDatos()))
            {
                using (SqlCommand command = new SqlCommand(script, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
