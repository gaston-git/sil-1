using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;


namespace AccesoDatos
{
    public class ManSistemas
    {
        public static string getSistemas(string idS)
        {//ejecuta una consulta a la BD
            string resultado = string.Empty;
            List<dynamic> lista = new List<dynamic>();
            try
            {
                SqlCommand _comando = Metodos.CrearComando();
                if (idS.Equals("0"))
                    _comando.CommandText = @"select s.id, s.nombre, s.idEstado, s.idUnidad, e.nombre as Estado, u.nombre as Unidad
                                                from Sistemas s, Estados e, Unidades u
                                                where s.idEstado = e.id
                                                and s.idUnidad = u.id
                                                order by s.nombre";
                else
                    _comando.CommandText = @"select s.id, s.nombre, s.idEstado, s.idUnidad, e.nombre as Estado, u.nombre as Unidad
                                                from Sistemas s, Estados e, Unidades u
                                                where s.idEstado = e.id
                                                and s.idUnidad = u.id
                                                and s.id = "+idS+" order by s.nombre";

                DataTable Dt = Metodos.EjecutarComandoSelect(_comando);

                foreach (DataRow row in Dt.Rows)
                {
                    lista.Add(new
                    {
                        id = row["id"].ToString().Trim(),
                        nombre = row["nombre"].ToString().Trim(),
                        idEstado = row["idEstado"].ToString().Trim(),
                        idUnidad = row["idUnidad"].ToString().Trim(),
                        Estado = row["Estado"].ToString().Trim(),
                        Unidad = row["Unidad"].ToString().Trim()
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