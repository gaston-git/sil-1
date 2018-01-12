using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;


namespace AccesoDatos
{
    public class RegistroLabores
    {
        public static string getLabores(string idL)
        {//ejecuta una consulta a la BD
            string resultado = string.Empty;
            List<dynamic> lista = new List<dynamic>();
            try
            {
                SqlCommand _comando = Metodos.CrearComando();
                if (idL.Equals("0"))
                    _comando.CommandText = @"SELECT R.id,convert(varchar,R.fecha,101) Fecha,convert(varchar(5),R.horaInicio,108) horaInicio,
                                                    convert(varchar(5), R.horaFinal, 108) horaFinal,S.nombre AS Sistema, A.nombre AS Accion, R.detalle,
                                                    R.observacion,R.avance, E.nombre AS Estado
                                            FROM registros R, sistemas S, Acciones A, Estados E
                                            WHERE R.idSistema = S.id
                                            AND R.idAccion = A.id
                                            AND R.idEstado = E.id order by R.fecha, R.horaInicio";
                else
                    _comando.CommandText = @"SELECT R.id,convert(varchar,R.fecha,101) Fecha,convert(varchar(5),R.horaInicio,108) horaInicio,
                                                    convert(varchar(5), R.horaFinal, 108) horaFinal,S.nombre AS Sistema, A.nombre AS Accion, R.detalle,
                                                    R.observacion,R.avance, E.nombre AS Estado
                                            FROM registros R, sistemas S, Acciones A, Estados E
                                            WHERE R.idSistema = S.id
                                            AND R.idAccion = A.id
                                            AND R.idEstado = E.id and R.id = " + idL;

                DataTable Dt = Metodos.EjecutarComandoSelect(_comando);

                foreach (DataRow row in Dt.Rows)
                {
                    lista.Add(new
                    {
                        id = row["id"].ToString().Trim(),
                        Fecha = row["Fecha"].ToString().Trim(),
                        horaInicio = row["horaInicio"].ToString().Trim(),
                        horaFinal = row["horaFinal"].ToString().Trim(),
                        Sistema = row["Sistema"].ToString().Trim(),
                        Accion = row["Accion"].ToString().Trim(),
                        detalle = row["detalle"].ToString().Trim(),
                        observacion = row["observacion"].ToString().Trim(),
                        avance = row["avance"].ToString().Trim(),
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

        /*
         var query = @"INSERT INTO[dbo].[Registros]
                    ([idEmpleado],[fecha],[horaInicio],[horaFinal],[idSistema],[idAccion],[detalle],[observacion],[avance],[idUnidad],[idEstado])
                   VALUES(@0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10)";
        var row = bd.QuerySingle(query, 1, fecha, horaIni, horaFin, idsistema, idaccion, Detalle, Observacion, porcentajeAvance, idunidad, 1);

             
        public static string CrearLineaLabor(string Fecha, string horaInicio, string horaFinal, string idSistema, string idAccion, string detalle, string observacion, string )
        {//ejecuta una consulta a la BD
            string resultado = string.Empty;
            List<dynamic> lista = new List<dynamic>();
            try
            {
                SqlCommand _comando = Metodos.CrearComando();
                _comando.CommandText = "insert into Estados(nombre) values('" + nombre + "')";
                int res = Metodos.EjecutarComando(_comando);

                lista.Add("Exito: Estado creado");
            }
            catch (Exception e)
            {
                lista.Add("Error: " + e.Message);
            }

            resultado = JsonConvert.SerializeObject(lista, Newtonsoft.Json.Formatting.Indented);
            return resultado;
        }
        /*
        public static string EditarEstado(string nombre, string id)
        {//ejecuta una consulta a la BD
            string resultado = string.Empty;
            List<dynamic> lista = new List<dynamic>();
            try
            {
                SqlCommand _comando = Metodos.CrearComando();
                _comando.CommandText = "update Estados set nombre = '" + nombre + "' where id = " + id;
                int res = Metodos.EjecutarComando(_comando);

                lista.Add("Exito: Estado modificado");
            }
            catch (Exception e)
            {
                lista.Add("Error: " + e.Message);
            }

            resultado = JsonConvert.SerializeObject(lista, Newtonsoft.Json.Formatting.Indented);
            return resultado;
        }

        public static string EliminarEstado(string id)
        {//ejecuta una consulta a la BD
            string resultado = string.Empty;
            List<dynamic> lista = new List<dynamic>();
            try
            {
                SqlCommand _comando = Metodos.CrearComando();
                _comando.CommandText = "delete Estados where id = " + id;
                int res = Metodos.EjecutarComando(_comando);

                lista.Add("Exito: Estado eliminado");
            }
            catch (Exception e)
            {
                lista.Add("Error: " + e.Message);
            }

            resultado = JsonConvert.SerializeObject(lista, Newtonsoft.Json.Formatting.Indented);
            return resultado;
        }
        */
    }
}