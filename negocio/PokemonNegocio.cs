using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //esta librería es la que vamos a usar para poder conectarnos a la base de datos
using dominio;




namespace negocio
{
    public class PokemonNegocio
    {
        //Esta es la clase que me va a permitir conectarme con mi base de datos
        //Acá yo voy a crear los métodos de acceso a datos para los pokemons de la base de datos

        public List<Pokemon> Listar()
        {
            //Acá vamos vamos a establecer la configuración inicial para poder conectarnos a la base de datos
            List<Pokemon> listaPokemon = new List<Pokemon>();  //acá vamos a poner los objetos tipo pokemon que traemos de la db y que modelaremos en la interface
            //Yo voy a necesitar conectarme a la base de datos, a una conexión, por ende voy a necesitar declarar esos métodos. 
            //Primero establezco la conexión
            SqlConnection conexion = new SqlConnection(); //esto es para poder conectarme a algún lado, es empezar a trazar los caminos a la base de datos
            //una vez conectado, voy a necesiatr realizar acciones,para eso voy a establecer un camino, comandos en este caso
            SqlCommand comando = new SqlCommand(); //acá voy a configurar los comandos que voy a usar una vez establecida la conexión
            //como resultado de la lectura que voy a hacer contra la base de datos, voy a obtener un set de datos, esto lo voy a alojar en un lector
            SqlDataReader lector; //no le vamos generar una instancia a este lector porque cuando haga la lectura, voy a tener como una instancia, un objeto de tipo sqlReader
                                  //por mas qu quiera crear una instancia , no se puede, me saltaría error. 




            try
            {
                //acá dentro del try vamos a poner toda funcionalidad que pueda fallar, que en este caso es 
                //la conexión y lectura de base de datos. 
                //acá hacemos la conexión a la db

                //Primero configuramos el estado de la cadena de conexión, que sería proporcionarle una url o dirección de conexion en este caso a la base de datos
                //en esta cadena le voy a declarar a donde me voy a conectar
                conexion.ConnectionString = "server=.\\SQLEXPRESS; Initial Catalog=POKEDEX_DB; integrated security=true;  "; //esta es la dirección de mi motor de base de datos local
                //con el . (punto) hago referencia a mi entorno local
                //server digo a donde me voy a conectar, a un servidor, que en este caso el servidor es \\SQLEXPRESS
                //lo siguiente es a que base de datos, ya que en nuestro servidor solemos tener varias bases de datos, en mi caso tengo la db Discos y pokemon
                //lo siguiente es decirle como me voy a conectar, si con windows autentication o que, en este caso como trabajo de manera local, si uso el windows autentication
                //en caso de conectarse a un server remoto, hay que poner integrated security=false; y acá el user y la password

                //Ahora lo siguiente a configurar es el comando. El COMANDO sirve para realizar la accion en la base de datos, leer, escribir, actualizar, etc
                //Nosotros vamos a hacer una lectura, y esta la haremos mandandole la sentencia sql. INYECTANDO LA SENTENCIA SQL. 
                //aL COANDO LE VOY A DECIR DE QUE TIPO ES, tipo type
                comando.CommandType = System.Data.CommandType.Text;
                //los tipos que tenemos son 3, y los mas usados son el Text. 
                // una vez que le digo que es de tipo text, voy  a mandarle el texto. El texto va a ser la consulta sql
                comando.CommandText = "Select P.Activo, P.Id, P.Numero, P.Nombre, P.Descripcion, P.UrlImagen, E.Descripcion AS Tipo, D.Descripcion AS Debilidad, P.IdTipo, P.IdDebilidad  From POKEMONS P, ELEMENTOS E, ELEMENTOS D  WHERE  E.Id = P.IdTipo AND D.Id = P.IdDebilidad And P.Activo = 1;\r\n"; //Consejo:hacer y  probar primero la consulta sql en la db antes de mandarla, para evitar ese gran margen de error
                //lo siguiente es decirle al comando que ejecute esa conexión en esta ejecución
                comando.Connection = conexion; //El comando configurado arriba, lo vamos a ejecutar en esta línea


                //Lo siguiente es abrir la conexión 
                conexion.Open();
                //Realizo la lectura, o sea ejecuto el comando
                lector = comando.ExecuteReader(); //es ExecuteReader porqu estoy haciendo una lectura. Esto da como resultado un objeto sqlDataReader, 
                                                  //ese resultado es lo que vamos a poner en el lector, así que decimos lector = plin plin plin 

                //hasta acá yo, y si todo sale bien, yo tengo los datos. Los datos los tengo en la variable lector

                //Esto me va a generar una suerte de tabla virtual con un puntero en memoria, que va a apuntar a un dato en cada fila y columna del objeto que me trajo de la db, a la vez yo voy a transformarlo en esa colección de objetos de tipo pokemons
                //Voy a ir leyendo a la variable lector que contiene el objeto que contiene los datos pedidos de cada pokemoin 

                //Para leerlo yo lo voy a hacer con un while
                while (lector.Read()) //Si hay un objeto en la base de datos, o sea, algo que leyó el select, esto me va a dar true y va a entrar al while, si no leyó nada, va a dar false y se va a salir
                {
                    //El puntero va a apuntar a la fila 1, columna 1 como esta en la base de datos, va a leer la columna correspondiente, obvio el titutlo no sino el valor, y me va a devolver un dato
                    //La lectura va a ser en orden, fila 1, columna 1, después fila 1, columna 2, fila 1 columna 3 y así hasta que termine
                    //Acá voy a generar un nuevo pokemon y lo voy a empezar a cargar con los datos del registro
                    Pokemon aux = new Pokemon();
                    //Ahora cargamos los datos del lector en mi objeto
                    aux.Estado = (bool)lector["Activo"];
                    aux.Id = (int)lector["Id"];
                    aux.Numero = (int)lector["Numero"];  //esta es una forma de mapear el objeto y 
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];

                    //Acá se rompe porque puede que la urlimagen puede que sea nula
                    
                    if (!(lector["UrlImagen"] is DBNull))
                    {
                        aux.UrlImagen = (string)lector["UrlImagen"];
                    }

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)lector["Tipo"];

                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    //despues de cargar los datos de mi pokemon auxiliar, cargo ese pokemon a mi lista de pokemons
                    listaPokemon.Add(aux);


                    //Termina de leer eso y va a pasar a la suigiente fila y va a traer a un segundo objeto, o sea datos nuevos

                }
                //ya para cerrar, cerramos la conexión y retornamos la lista
                conexion.Close();
                return listaPokemon;
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }


        //acá creamos el método de agregar
        public void agregar(Pokemon nuevo)
        {
            //insert into POKEMONS(Numero, Nombre, Descripcion, UrlImagen, Activo) values (1, ' ', ' ', '', 1);
            AccesoDatos datos = new AccesoDatos();


            try
            {
                //seteamos la consulta
                datos.setearConsulta("insert into POKEMONS(Numero, Nombre, Descripcion, UrlImagen, Activo, IdTipo, IdDebilidad) values ( @numero , @nombre, @descripcion, @urlImagenTapa , 1, @idTipo, @idDebilidad);");

                //seteamos parametros para hacerlo más dinámico y no tengamos que armar toda esa concatenación de elementos
                datos.setearParametros("@numero", nuevo.Numero);
                datos.setearParametros("@nombre", nuevo.Nombre);
                datos.setearParametros("@descripcion", nuevo.Descripcion);
                datos.setearParametros("@urlImagenTapa", nuevo.UrlImagen);

                datos.setearParametros("@idTipo", nuevo.Tipo.Id);
                datos.setearParametros("@idDebilidad", nuevo.Debilidad.Id);


                //ejecutamos la consulta
                datos.ejecutarAccion();



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void modificar(Pokemon modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update POKEMONS set Numero = @numero, Nombre = @nombre, Descripcion = @desc, UrLImagen = @urlImagen, IdTipo = @idTipo, IdDebilidad = @idDebilidad where Id = @id;");
                datos.setearParametros("@numero", modificado.Numero );
                datos.setearParametros("@nombre", modificado.Nombre );
                datos.setearParametros("@desc", modificado.Descripcion );
                datos.setearParametros("@urlImagen", modificado.UrlImagen );
                datos.setearParametros("@idTipo", modificado.Tipo.Id );
                datos.setearParametros("@idDebilidad", modificado.Debilidad.Id );
                datos.setearParametros("@id", modificado.Id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex ;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos accesoDatos = new AccesoDatos();
                accesoDatos.setearConsulta("Delete from POKEMONS where id = @id");
                accesoDatos.setearParametros("@id", id);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarLogico(int id)
        {
            try
            {
                AccesoDatos accesoDatos = new AccesoDatos();
                accesoDatos.setearConsulta("Update POKEMONS set Activo = 0 where Id = @id;");
                accesoDatos.setearParametros("@id", id);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Pokemon> filtrar(string campo, string criterio, string filtro)
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            string consulta = "Select P.Activo, P.Id, P.Numero, P.Nombre, P.Descripcion, P.UrlImagen, E.Descripcion AS Tipo, D.Descripcion AS Debilidad, P.IdTipo, P.IdDebilidad  From POKEMONS P, ELEMENTOS E, ELEMENTOS D  WHERE  E.Id = P.IdTipo AND D.Id = P.IdDebilidad And P.Activo = 1 AND ";


            try
            {
                if (campo == "Número")
                {
                    if (criterio == "Mayor a")
                    {
                        consulta += "P.Numero > " + filtro;
                    }
                    else if (criterio == "Menor a")
                    {
                        consulta += "P.Numero < " + filtro;
                    }
                    else
                    {
                        consulta += "P.Numero = " + filtro;
                    }
                }
                else if (campo == "Nombre")
                {
                    if (criterio == "Empieza con")
                    {
                        consulta += "P.Nombre like '" + filtro + "%'";
                    }
                    else if (criterio == "Termina con")
                    {
                        consulta += "P.Nombre like '%" + filtro + "'";
                    }
                    else
                    {
                        consulta += "P.Nombre like '%" + filtro + "%'";
                    }
                }
                else
                {
                    if (campo == "Descripción")
                    {
                        if (criterio == "Empieza con")
                        {
                            consulta += "P.Descripcion like '" + filtro + "%'";
                        }
                        else if (criterio == "Termina con")
                        {
                            consulta += "P.Descripcion like '%" + filtro + "'";
                        }
                        else
                        {
                            consulta += "P.Descripcion like '%" + filtro + "%'";
                        }
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read()) //Si hay un objeto en la base de datos, o sea, algo que leyó el select, esto me va a dar true y va a entrar al while, si no leyó nada, va a dar false y se va a salir
                {
                    Pokemon aux = new Pokemon();
                    aux.Estado = (bool)datos.Lector["Activo"];
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = (int)datos.Lector["Numero"];  //esta es una forma de mapear el objeto y 
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["UrlImagen"] is DBNull))
                    {
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    }

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];

                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                datos.cerrarConexion();
            }

            return lista;
        }
    }
}
