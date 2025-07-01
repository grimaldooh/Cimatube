using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Autores: D_ConexionBD
    {
        public DataTable ListadoAutores()
        {
            SqlCommand cmd = new SqlCommand();
            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter();

            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Autores";

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

        public DataTable ListadoAutores(int idUsuario)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter();

            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Autores WHERE IdUsuario = "+idUsuario;

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

        public int CrearAutor(int IdUsuario)
        {
            int R = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Autores ( IdUsuario) VALUES ( @IdUsuario )";

            //cmd.Parameters.AddWithValue("@IdRespuesta", comentario.IdRespuesta);
            cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

            try
            {
                AbrirConexion();
                R = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                R = 0;
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }

            return R;
        }
    }
}
