using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;


namespace AccesoDatos
{
    public class ManUnidades
    {
        public static string getUnidades(string idU)
        {//ejecuta una consulta a la BD
            string resultado = string.Empty;
            List<dynamic> lista = new List<dynamic>();
            try
            {
                SqlCommand _comando = Metodos.CrearComando();
                if (idU.Equals("0"))
                    _comando.CommandText = @"select u.id, u.nombre, u.idEstado, u.idDepartamento, e.nombre as Estado, d.nombre as Departamento
                                            from Unidades u, Estados e, Departamentos d
                                            where u.idEstado = e.id
                                            and u.idDepartamento = d.id
                                            order by u.nombre";
                else
                    _comando.CommandText = @"select u.id, u.nombre, u.idEstado, u.idDepartamento, e.nombre as Estado, d.nombre as Departamento
                                            from Unidades u, Estados e, Departamentos d
                                            where u.idEstado = e.id
                                            and u.idDepartamento = d.id
                                            and u.id = "+ idU +" order by u.nombre";

                DataTable Dt = Metodos.EjecutarComandoSelect(_comando);

                foreach (DataRow row in Dt.Rows)
                {
                    lista.Add(new
                    {
                        id = row["id"].ToString().Trim(),
                        nombre = row["nombre"].ToString().Trim(),
                        idEstado = row["idEstado"].ToString().Trim(),
                        idDepartamento = row["idDepartamento"].ToString().Trim(),
                        Estado = row["Estado"].ToString().Trim(),
                        Departamento = row["Departamento"].ToString().Trim()
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