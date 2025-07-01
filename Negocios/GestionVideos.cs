using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Entidades;
using Datos;
using System.Data;
using System.Web;
using System.IO;

namespace Negocios
{
    public class N_Video
    {
        readonly D_Video DV = new D_Video();

        public string InsertaVideo(E_Video video, HttpPostedFile hpfImagen, HttpPostedFile hpfVideo, string rutaRelativa)
        {
            video.Accion = "INSERTAR";
            int R = DV.IBM_Video(video, hpfImagen, hpfVideo, rutaRelativa);
            if (R > 0)
            {
                return "Exito: El los datos del video se insertaron correctamente.";
            }
            else if (R == 0)
            {
                return "Error: Los datos del video no se pudieron insertar.";
            }
            else
                return "Fatal: No cuenta con permisos de subir videos.";
        }
        public string BorraVideo(int Idvideo)
        {
            E_Video video = new E_Video();

            video.IdVideo= Idvideo;
            video.Accion = "BORRAR";

            if (DV.IBM_Video(video) > 0)
                return "Exito: El los datos del video se borraron correctamente.";
            else
                return "Error: Los datos del video no se pudieron borrar.";
        }
        public string ModificarVideo(E_Video video)
        {
            video.Accion = "MODIFICAR";

            if (DV.IBM_Video(video) > 0)
                return "Exito: El los datos del video se modificaron correctamente.";
            else
                return "Error: Los datos del video no se pudieron modificar.";
        }

        public DataSet GetVideo(int IdVideo)
        {
            return DV.GetVideo(IdVideo);
        }
        public DataTable ListaVideos()
        {
            return DV.ListadoVideos();
        }

        public DataTable ListaVideos(String nombreColumna, int cantidad, string dato)
        {
            return DV.ListadoVideos(nombreColumna, cantidad, dato);
        }
        //Lista videos
        public DataTable ListaVideoPorMateria(int id)
        {
            return DV.ListadoVideos("IdMateria", 2, id);
        }
    }

}
