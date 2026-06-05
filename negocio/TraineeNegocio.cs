using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class TraineeNegocio
    {
        AccesoDatos datos = new AccesoDatos();


        public int insertarNuevo(Trainee nuevo)
        {
            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametros("@email", nuevo.Email);
                datos.setearParametros("@pass", nuevo.Pass);
                return datos.ejecutarAccionScalar();
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

        public bool Login(Trainee trainee)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, Email, Pass, Nombre, Apellido, FechaNacimiento, Admin, ImagenPerfil From USERS Where Email = @email AND Pass = @pass ");
                datos.setearParametros("@email", trainee.Email);
                datos.setearParametros("@pass", trainee.Pass);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    trainee.Id = (int)datos.Lector["Id"];
                    trainee.Email = (string)datos.Lector["Email"];
                    trainee.Admin = (bool)datos.Lector["Admin"];
                    trainee.Pass = (string)datos.Lector["Pass"];

                    if (!(datos.Lector["Nombre"] is DBNull))
                    {
                        trainee.Nombre = (string)datos.Lector["Nombre"];
                    }
                    if (!(datos.Lector["Apellido"] is DBNull))
                    {
                        trainee.Apellido = (string)datos.Lector["Apellido"];
                    }
                    if (!(datos.Lector["FechaNacimiento"] is DBNull))
                    {
                        trainee.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    }
                    if (!(datos.Lector["ImagenPerfil"] is DBNull))
                    {
                        trainee.ImagenPerfil = (string)datos.Lector["ImagenPerfil"];
                    }

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

        public void actualizar(Trainee user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update  Users set Nombre = @nombre, Apellido =@apellido, FechaNacimiento = @fechaNacimiento, ImagenPerfil = @imagenPerfil Where Id = @id");
                datos.setearParametros("@nombre", user.Nombre);
                datos.setearParametros("@apellido", user.Apellido);
                datos.setearParametros("@fechaNacimiento", user.FechaNacimiento);
                datos.setearParametros("@imagenPerfil", user.ImagenPerfil);
                datos.setearParametros("@id", user.Id);

                datos.ejecutarAccion();
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
