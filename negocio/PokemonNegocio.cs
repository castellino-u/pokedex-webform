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
        public List<Pokemon> listarConSp()
        {
            List<Pokemon> listaPokemon = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("storedListar");
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

                    listaPokemon.Add(aux);
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

            return listaPokemon;
        }
        public List<Pokemon> Listar( string id = "")
        {
            List<Pokemon> listaPokemon = new List<Pokemon>();  //acá vamos a poner los objetos tipo pokemon que traemos de la db y que modelaremos en la interface
            SqlConnection conexion = new SqlConnection(); //esto es para poder conectarme a algún lado, es empezar a trazar los caminos a la base de datos
            SqlCommand comando = new SqlCommand(); //acá voy a configurar los comandos que voy a usar una vez establecida la conexión
            SqlDataReader lector; //no le vamos generar una instancia a este lector porque cuando haga la lectura, voy a tener como una instancia, un objeto de tipo sqlReader



            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; Initial Catalog=POKEDEX_DB; integrated security=true;  "; //esta es la dirección de mi motor de base de datos local
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select P.Activo, P.Id, P.Numero, P.Nombre, P.Descripcion, P.UrlImagen, E.Descripcion AS Tipo, D.Descripcion AS Debilidad, P.IdTipo, P.IdDebilidad  From POKEMONS P, ELEMENTOS E, ELEMENTOS D  WHERE  E.Id = P.IdTipo AND D.Id = P.IdDebilidad And P.Activo = 1 \r\n"; //Consejo:hacer y  probar primero la consulta sql en la db antes de mandarla, para evitar ese gran margen de error
                if (id != "")
                {
                    comando.CommandText += "and P.Id == " + id; //esta forma está buena para traer un solo elemento por id
                }
                comando.Connection = conexion; //El comando configurado arriba, lo vamos a ejecutar en esta línea


                conexion.Open();
                lector = comando.ExecuteReader(); //es ExecuteReader porqu estoy haciendo una lectura. Esto da como resultado un objeto sqlDataReader, 
                while (lector.Read()) //Si hay un objeto en la base de datos, o sea, algo que leyó el select, esto me va a dar true y va a entrar al while, si no leyó nada, va a dar false y se va a salir
                {
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

        public void agregarConSP(Pokemon nuevo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                
                accesoDatos.setearProcedimiento("storedAltaPokemon");
                accesoDatos.setearParametros("@numero", nuevo.Numero);
                accesoDatos.setearParametros("@nombre", nuevo.Nombre);
                accesoDatos.setearParametros("@descripcion", nuevo.Descripcion);
                accesoDatos.setearParametros("@img", nuevo.UrlImagen);
                accesoDatos.setearParametros("@idTipo", nuevo.Tipo.Id);
                accesoDatos.setearParametros("@idDebilidad", nuevo.Debilidad.Id);

                accesoDatos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }


        public void modificar(Pokemon modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update POKEMONS set Numero = @numero, Nombre = @nombre, Descripcion = @desc, UrLImagen = @urlImagen, IdTipo = @idTipo, IdDebilidad = @idDebilidad where Id = @id;");
                datos.setearParametros("@numero", modificado.Numero);
                datos.setearParametros("@nombre", modificado.Nombre);
                datos.setearParametros("@desc", modificado.Descripcion);
                datos.setearParametros("@urlImagen", modificado.UrlImagen);
                datos.setearParametros("@idTipo", modificado.Tipo.Id);
                datos.setearParametros("@idDebilidad", modificado.Debilidad.Id);
                datos.setearParametros("@id", modificado.Id);

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

        public void modificarConSP(Pokemon modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedModificarPokemon");
                datos.setearParametros("@numero", modificado.Numero);
                datos.setearParametros("@nombre", modificado.Nombre);
                datos.setearParametros("@desc", modificado.Descripcion);
                datos.setearParametros("@img", modificado.UrlImagen);
                datos.setearParametros("@idTipo", modificado.Tipo.Id);
                datos.setearParametros("@idDebilidad", modificado.Debilidad.Id);
                datos.setearParametros("@id", modificado.Id);

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

        public void eliminarConSP(int id)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearProcedimiento("storedEliminarConSP");
                accesoDatos.setearParametros("@id", id);


                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
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

        public void eliminarLogicoConSP(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedEliminarLogico");
                datos.setearParametros("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }
    }
}
