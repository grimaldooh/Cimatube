using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class D_Comentario : D_ConexionBD
    {
        public enum TIPO
        {
            COMENTARIO,
            VIDEO
        }
        public DataTable ListadoComentarios()
        {
            SqlCommand cmd = new SqlCommand();
            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter();

            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Comentarios";

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

        public DataTable ListadoComentarios(int id)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter();

            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Comentarios WHERE IdVideo = " + id;

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

        public int InsertarComentario(E_Comentario comentario)
        {
            int R = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Comentarios ( IdVideo, IdAutor, Comentario, ValoracionComentario, FechaComentario, NivelComentario) VALUES (@IdVideo, @IdAutor, @Comentario, @ValoracionComentario, @FechaComentario, @NivelComentario)";

            //cmd.Parameters.AddWithValue("@IdRespuesta", comentario.IdRespuesta);
            cmd.Parameters.AddWithValue("@IdAutor", comentario.IdAutor);
            cmd.Parameters.AddWithValue("@IdVideo", comentario.IdVideo);
            cmd.Parameters.AddWithValue("@Comentario", comentario.Comentario);
            cmd.Parameters.AddWithValue("@ValoracionComentario", comentario.ValoracionComentario);
            cmd.Parameters.AddWithValue("@FechaComentario", comentario.FechaComentario);
            cmd.Parameters.AddWithValue("@NivelComentario", comentario.NivelComentario);

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

    }
}
