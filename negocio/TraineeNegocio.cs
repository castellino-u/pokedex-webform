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
                datos.setearConsulta("Select Id, Admin FROM USERS Where Email = @email AND Pass = @pass ");
                datos.setearParametros("@email", trainee.Email);
                datos.setearParametros("@pass", trainee.Pass);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    trainee.Id = (int)datos.Lector["Id"];
                    trainee.Admin = (bool)datos.Lector["Admin"];
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
