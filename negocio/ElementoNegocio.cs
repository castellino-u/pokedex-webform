using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ElementoNegocio
    {
        public List<Elemento> listar()
        {
			List<Elemento> lista = new List<Elemento>();
			AccesoDatos datos = new AccesoDatos(); //cuando se crea este objeto, ya nace seteado con la cadena de conexión y un par de parámetros más(lector, comando, conexión)


			try
			{
				//lo siguiente a realizar es settear la consulta
				datos.setearConsulta("Select Id, Descripcion From ELEMENTOS;");
				datos.ejecutarLectura();
				//una vez hecho esto, ya tenemos los la conexión lista para poder traer los datos a travez del lectos

				while (datos.Lector.Read())
				{
					Elemento aux = new Elemento();
					aux.Id = (int)datos.Lector["Id"];
					aux.Descripcion = (string)datos.Lector["Descripcion"];

					lista.Add(aux);


				}

				return lista;
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				datos.cerrarConexion(); //acá cerramos la conexión y el lector 
			}

        }



    }
}
