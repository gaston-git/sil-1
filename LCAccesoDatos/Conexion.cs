
using System;
using System.Configuration;

namespace LCAccesoDatos
{
    public class Conexion
    {
        static String cadenaConexion = @"Data Source=0048-08\SQL2014;Initial Catalog=Siprofi; Integrated Security=SSPI;";
        public static string CadenaConexion
        {
            //get { return ReadSetting("llave1"); }
            get { return cadenaConexion; }
        }

        static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                return result;
            }
            catch (Exception e)
            {
                return "Error reading app settings";
            }
        }


    }
}
