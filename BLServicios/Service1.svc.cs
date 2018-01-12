using System;


namespace BLServicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        // Métodos de Estados
        public string getEstados(string idE)
        {
            //string datos = AccesoDatos.AccesoDatos.getEstados(idE);
            string datos = AccesoDatos.ManEstados.getEstados(idE);
            return datos.ToString();
        }

        public string CrearEstado(string nombre)
        {
            string datos = AccesoDatos.ManEstados.CrearEstado(nombre);
            return datos.ToString();
        }

        public string EditarEstado(string nombre, string id)
        {
            string datos = AccesoDatos.ManEstados.EditarEstado(nombre,id);
            return datos.ToString();
        }

        public string EliminarEstado(string id)
        {
            string datos = AccesoDatos.ManEstados.EliminarEstado(id);
            return datos.ToString();
        }


        //Métodos de Registros
        public string getRegistros(string idL)
        {
            string datos = AccesoDatos.RegistroLabores.getLabores(idL);
            return datos.ToString();
        }


        //Métodos de Registros
        public string getSistemas(string idS)
        {
            string datos = AccesoDatos.ManSistemas.getSistemas(idS);
            return datos.ToString();
        }


        //Métodos de Acciones
        public string getAcciones(string idA)
        {
            string datos = AccesoDatos.ManAcciones.getAcciones(idA);
            return datos.ToString();
        }


        //Métodos de Unidades
        public string getUnidades(string idU)
        {
            string datos = AccesoDatos.ManUnidades.getUnidades(idU);
            return datos.ToString();
        }
    }
}
