using System;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using Entidades;
using System.IO;
using System.Web;
using System.Diagnostics;

namespace Datos
{
    public class D_ConexionBD
    {
        public SqlConnection Conexion;

        public D_ConexionBD()
        {
            Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString);
        }

        public void AbrirConexion()
        {
            try
            {
                if (Conexion.State == ConnectionState.Broken || Conexion.State == ConnectionState.Closed)
                    Conexion.Open();
            }
            catch (Exception e)
            {
                throw new Exception("La conexion no se pudo abrir porque : ", e);
            }
        }
        public void CerrarConexion()
        {
            try
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
            }
            catch (Exception e)
            {
                throw new Exception("La conexion no se pudo cerrar porque : ", e);
            }
        }
    }

    public class D_Video : D_ConexionBD
    {
        public D_Video() { }

        public int IBM_Video(E_Video video)
        {
            int R = 0;
            SqlCommand cmd = new SqlCommand("IBM_Video", Conexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Accion", video.Accion);
            cmd.Parameters.AddWithValue("@IdVideo", video.IdVideo);
            cmd.Parameters.AddWithValue("@TituloVideo", video.TituloVideo);
            cmd.Parameters.AddWithValue("@IdAutor", video.IdAutor);
            cmd.Parameters.AddWithValue("@DescripcionVideo", video.DescripcionVideo);
            cmd.Parameters.AddWithValue("@ValoracionVideo", video.ValoracionVideo);
            cmd.Parameters.AddWithValue("@FechaPublicacion", video.FechaPublicacion);
            cmd.Parameters.AddWithValue("@Vistas", video.Vistas);
            cmd.Parameters.AddWithValue("@ImagenURL", video.ImagenURL);
            cmd.Parameters.AddWithValue("@VideoURL", video.VideoURL);
            cmd.Parameters.AddWithValue("@IdMateria", video.IdMateria);
            cmd.Parameters.AddWithValue("@Visibilidad", video.Visibilidad);


            try
            {
                AbrirConexion();
                R = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                R = 0;
                if (e.InnerException is SqlException sqlEx && sqlEx.Number == 547)
                {
                    R = -1;
                }
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }

            return R;
        }

        public int IBM_Video(E_Video video, HttpPostedFile hpfImagen, HttpPostedFile hpfVideo, string rutaRelativa)
        {
            string nombreVideo = video.IdAutor.ToString() + video.FechaPublicacion.ToString("dd-MM-yyyy-HH-mm-ss-fff") + Path.GetExtension(Path.GetFileName(hpfVideo.FileName));
            //Debug.WriteLine(nombreVideo);
            // Construir la ruta completa de destino

            string rutaCompleta = Path.Combine(rutaRelativa + "Videos", nombreVideo);
            Directory.CreateDirectory(rutaRelativa + "Videos");
            // Crear un FileStream para escribir el archivo en disco
            using (FileStream fs = new FileStream(rutaCompleta, FileMode.Create))
            {
                // Leer el archivo de la solicitud HTTP y escribirlo en el FileStream
                hpfVideo.InputStream.CopyTo(fs);
            }

            //----------------------------------------------------------------------
            //                  Se guarda el video
            //                  Soy conciente de que esta forma
            //                  de guardar los videos tiene sus vulnerabilidad
            //                  una opcion seria guardarlo en una carpeta
            //                  con el id o nombre del autor para que asi
            //                  si en el caso de que dos usuarios suban un
            //                  archivo con el mismo nombre no lo sobrescriba
            //----------------------------------------------------------------------

            string nombreImagen = video.IdAutor.ToString() + video.FechaPublicacion.ToString("dd-MM-yyyy-HH-mm-ss-fff") + Path.GetExtension(Path.GetFileName(hpfImagen.FileName));

            // Construir la ruta completa de destino
            rutaCompleta = Path.Combine(rutaRelativa + "Miniaturas", nombreImagen);
            Directory.CreateDirectory(rutaRelativa + "Miniaturas");
            // Crear un FileStream para escribir el archivo en disco
            using (FileStream fs = new FileStream(rutaCompleta, FileMode.Create))
            {
                // Leer el archivo de la solicitud HTTP y escribirlo en el FileStream
                hpfImagen.InputStream.CopyTo(fs);
            }

            video.VideoURL = "../Videos/" + nombreVideo;
            video.ImagenURL = "../Miniaturas/" + nombreImagen;

            return IBM_Video(video);
        }

        public DataTable ListadoVideos()
        {
            SqlCommand cmd = new SqlCommand();
            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter();

            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TOP 10 * FROM Videos";

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

        public DataTable ListadoVideos(String nombreColumna, int cantidad, string dato)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter();

            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TOP " + cantidad + " * FROM Videos WHERE " + nombreColumna + " LIKE '%" + dato + "%'";

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
        public DataTable ListadoVideos(String nombreColumna, int cantidad, int id)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter();

            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TOP " + cantidad + " " + nombreColumna + " FROM Videos WHERE " + nombreColumna + " = "+id;

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
        public DataSet GetVideo(int IdVideo)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet DS = new DataSet();
            SqlDataAdapter DA = new SqlDataAdapter();

            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Videos WHERE IdVideo = " + IdVideo.ToString();

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
