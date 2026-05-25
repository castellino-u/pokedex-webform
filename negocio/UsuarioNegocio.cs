using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        //ahora solo vamos a crear una función para loguearse
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, TipoUser FROM USERS Where usuario = @user AND pass = @pass ");
                datos.setearParametros("@user", usuario.User);
                datos.setearParametros("@pass", usuario.Pass);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.TipoUsuario = (int)datos.Lector["TipoUser"] == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

            
        }
    }
}
