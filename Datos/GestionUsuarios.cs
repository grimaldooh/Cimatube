using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Entidades;

namespace Datos
{
    public class D_Usuario: D_ConexionBD
    {
        public int IBM_Usuario(E_Usuario usuario)
        {
            int R = 0;
            SqlCommand cmd = new SqlCommand("IBM_Usuario", Conexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Accion", usuario.Accion);
            cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
            cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
            cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
            cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
            cmd.Parameters.AddWithValue("@FechaRegistro", usuario.FechaRegistro);
            cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
            cmd.Parameters.AddWithValue("@IdCarrera", usuario.IdCarrera);


            try
            {
                AbrirConexion();
                R = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                R = 0;
                throw e;
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }

            return R;
        }
        public DataTable ListadoUsuarios()
        {
            SqlCommand cmd = new SqlCommand();
            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter();

            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuarios";

                DA.SelectCommand = cmd;
                DA.Fill(DT);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }

            return DT;
        }

        public DataSet GetUsuario(int IdUsuario)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet DS = new DataSet();
            SqlDataAdapter DA = new SqlDataAdapter();

            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuarios WHERE IdUsuario = " + IdUsuario.ToString();

                DA.SelectCommand = cmd;
                DA.Fill(DS);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }

            return DS;
        }
        public DataSet GetUsuario(string Correo)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet DS = new DataSet();
            SqlDataAdapter DA = new SqlDataAdapter();

            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuarios WHERE Correo = @Correo";

                cmd.Parameters.AddWithValue("@Correo", Correo);
                DA.SelectCommand = cmd;
                DA.Fill(DS);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }

            return DS;
        }
    }
}
