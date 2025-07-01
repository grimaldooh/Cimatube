using System;

namespace Entidades
{
    public class E_Video
    {

        #region Atributos
        private string _Accion;
        private int _IdVideo;
        private string _TituloVideo;
        private int _IdAutor;
        private string _DescripcionVideo;
        private int _ValoracionVideo;
        private DateTime _FechaPublicacion;
        private int _Vistas;
        private string _ImagenURL;
        private string _VideoURL;
        private int _IdMateria;
        private byte _Visibilidad;
        #endregion

        #region Constructores
        public E_Video()
        {
            _Accion = string.Empty;
            _IdVideo = 0;
            _TituloVideo = string.Empty;
            _IdAutor = 0;
            _DescripcionVideo = string.Empty;
            _ValoracionVideo = 0;
            _FechaPublicacion = DateTime.Now;
            _Vistas = 0;
            _VideoURL = null;
            _ImagenURL = null;
            _IdMateria = 0;
        }
        public E_Video(string accion, int idVideo, string tituloVideo, int idAutor, string descripcionVideo, int valoracionVideo, DateTime fechaPublicacion, int vistas, byte[] imagen, byte[] video, string videoURL, string imagenURL, int idMateria, byte visibilidad)
        {
            _Accion = accion;
            _IdVideo = idVideo;
            _TituloVideo = tituloVideo;
            _IdAutor = idAutor;
            _DescripcionVideo = descripcionVideo;
            _ValoracionVideo = valoracionVideo;
            _FechaPublicacion = fechaPublicacion;
            _Vistas = vistas;
            _VideoURL = videoURL;
            _ImagenURL = imagenURL;
            _IdMateria = 0;
            _Visibilidad = visibilidad;
        }
        #endregion

        #region Encapsulamientos
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdVideo { get => _IdVideo; set => _IdVideo = value; }
        public string TituloVideo { get => _TituloVideo; set => _TituloVideo = value; }
        public int IdAutor { get => _IdAutor; set => _IdAutor = value; }
        public string DescripcionVideo { get => _DescripcionVideo; set => _DescripcionVideo = value; }
        public int ValoracionVideo { get => _ValoracionVideo; set => _ValoracionVideo = value; }
        public DateTime FechaPublicacion { get => _FechaPublicacion; set => _FechaPublicacion = value; }
        public int Vistas { get => _Vistas; set => _Vistas = value; }
        public string VideoURL { get => _VideoURL; set => _VideoURL = value; }
        public string ImagenURL { get => _ImagenURL; set => _ImagenURL = value; }
        public int IdMateria { get => _IdMateria; set => _IdMateria = value; }
        public byte Visibilidad { get => _Visibilidad; set => _Visibilidad = value; }
        #endregion
    }
}
