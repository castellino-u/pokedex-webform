using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace negocio
{
    public class AccesoDatos
    {
        //acá vamos a declarar los objetos que necesitamos para establecer una conexión 
        //para establecer una conexión necesitamos 3 cosas, establecer una cadena de conexión
        //establecer un comando
        //y un objeto slq data reader

        //declaramos los objetos vacíos y como atributos de la propia clase

        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        //vamos a crear otra property para que podamos acceder en este caso a la propiedad de lectura, la prop va a 
        //service igual al lector pero en este caso, esta prop me va a permitir leer desde el exterior a mi lector privado
        //por eso solo va a tener un get y no un setter

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        //definimos un constructor qu en este caso incluya al momento de crear una instancia de la clase, haga la 
        //conexión

        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; Initial Catalog=POKEDEX_DB; integrated security=true;  ");
            comando = new SqlCommand();
        }

        //vamos a hacer una función para configurar la consulta

        public void setearConsulta(string consulta)   //de este modo, encapsulamos el darle un tipo y la consulta al comando
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        //ejecutamos la lectura
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //ejecutar insert
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //setear parametros al comando

        public void setearParametros(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        //necesitamos ahora cerrar la conexión

        public void cerrarConexion()
        {
            if (lector != null) { lector.Close(); }  //esto lo hacemos porque al lector también hay que cerrarlo
            conexion.Close();
        }

        //ejecutar un delete

        //ejecutar un update

    }
}
