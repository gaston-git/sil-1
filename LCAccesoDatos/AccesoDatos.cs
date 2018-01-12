using System;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;


namespace LCAccesoDatos
{
    public class AccesoDatos
    {

        public static int insertarUsuario(string usuario, string password, string nombre, string apellido, int pais, char sexo, string correo, string telefono)
        {
            SqlCommand _comando = Metodos.CrearComandoProc("insUsuario");
            _comando.Parameters.AddWithValue("@usuario ", usuario);
            _comando.Parameters.AddWithValue("@password", password);
            _comando.Parameters.AddWithValue("@nombre  ", nombre);
            _comando.Parameters.AddWithValue("@apellido", apellido);
            _comando.Parameters.AddWithValue("@pais    ", pais);
            _comando.Parameters.AddWithValue("@sexo    ", sexo);
            _comando.Parameters.AddWithValue("@correo  ", correo);
            _comando.Parameters.AddWithValue("@telefono", telefono);
            return Metodos.EjecutarComando(_comando);
        }

        public static DataTable verificarUsuario(string usuario, string pass)
        {
            SqlCommand _comando = Metodos.CrearComando();
            _comando.CommandText = "SELECT usuario FROM usuarios WHERE usuario = '" + usuario + "' AND password = '" + pass + "'";
            return Metodos.EjecutarComandoSelect(_comando);
        }

        public static string getMonedas(string idM)
        {//ejecuta una consulta a la BD
            string resultado = string.Empty;
            List<dynamic> lista = new List<dynamic>();
            try
            {
                SqlCommand _comando = Metodos.CrearComando();
                if (idM.Equals("0"))
                    _comando.CommandText = "select IdMoneda,Nombre,Simbolo,Estado from Monedas;";
                else
                    _comando.CommandText = "select IdMoneda,Nombre,Simbolo,Estado from Monedas where IdMoneda = " + idM;

                DataTable Dt = Metodos.EjecutarComandoSelect(_comando);

                foreach (DataRow row in Dt.Rows)
                {
                    lista.Add(new
                    {
                        IdMoneda = row["IdMoneda"].ToString().Trim(),
                        Nombre = row["Nombre"].ToString().Trim(),
                        Simbolo = row["Simbolo"].ToString().Trim(),
                        Estado = row["Estado"].ToString().Trim()
                    });
                }
            }
            catch (Exception e)
            {
                lista.Add("Error: " + e.Message);
            }

            resultado = JsonConvert.SerializeObject(lista, Newtonsoft.Json.Formatting.Indented);
            return resultado;
        }

        public static string getTitulos(string idTit)
        {//ejecuta el llamado a un SP y devuelve select del SP
            string resultado = string.Empty;
            List<dynamic> lista = new List<dynamic>();
            try
            {
                SqlCommand _comando = Metodos.CrearComandoProc("uspObtenerTitulos");
                _comando.Parameters.AddWithValue("@pIdTitulo ", idTit);
                // return Metodos.EjecutarComandoSelect(_comando); // así se llama en caso de ser SP que actualiza datos

                DataTable Dt = Metodos.EjecutarComandoSelect(_comando);
                foreach (DataRow row in Dt.Rows)
                {
                    lista.Add(new
                    {
                        IdTipoTitulo = row["IdTipoTitulo"].ToString().Trim(),
                        IdMoneda = row["IdMoneda"].ToString().Trim(),
                        Nombre = row["Nombre"].ToString().Trim(),
                        Estado = row["Estado"].ToString().Trim()
                    });
                }
            }
            catch (Exception e)
            {
                lista.Add("Error: " + e.Message);
            }

            resultado = JsonConvert.SerializeObject(lista, Newtonsoft.Json.Formatting.Indented);
            return resultado;
        }


    }
}