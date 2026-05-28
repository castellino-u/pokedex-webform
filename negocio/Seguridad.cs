using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public static class Seguridad
    {
        public static bool sessionActiva(object usuario)
        {
            Trainee aux = usuario as Trainee; 
            if (aux != null)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }

        public static bool esAdmin(object usuario)
        {
            Trainee aux = usuario as Trainee;
            if(aux != null && aux.Admin)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }
    }
}
