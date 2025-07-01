using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
 
    public class N_Usuario
    {
        readonly D_Usuario DU = new D_Usuario();
        //Agregar IBM
        public int InsertarUsuario(E_Usuario usuario)
        {
            usuario.Accion = "INSERTAR";
            return DU.IBM_Usuario(usuario);
        }
        public DataTable ListaUsuarios()
        {
            return DU.ListadoUsuarios();
        }

        public DataSet GetUsuario(int idUsuario)
        {
            return DU.GetUsuario(idUsuario);
        }

        public bool ExisteCorreo(string correo)
        {
            DataSet ds = DU.GetUsuario(correo);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public DataTable GetUsuario(string correo)
        {
            DataSet ds = DU.GetUsuario(correo);
            DataTable dt = new DataTable();
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
            }
            return dt;
        }
    }
}
