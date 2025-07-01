using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Comentario
    {
        #region Atributos
        private int _IdComentario;
        private int _IdRespuesta;
        private int _IdVideo;
        private int _IdAutor;
        private string _Comentario;
        private int _ValoracionComentario;
        private DateTime _FechaComentario;
        private int _NivelComentario;
        #endregion

        #region Constructores
        public E_Comentario()
        {
            _IdComentario = 0;
            _IdRespuesta = 0;
            _IdVideo = 0;
            _IdAutor = 0;
            _Comentario = string.Empty;
            _ValoracionComentario = 0;
            _FechaComentario = DateTime.Now;
            _NivelComentario = 0;
        }
        public E_Comentario(int idCometario, int idRespuesta, int IdVideo, int IdAutor, string comentario, int valoracionComentario, DateTime fechaComentario, int nivelComentario)
        {
            _IdComentario = idCometario;
            _IdRespuesta = idRespuesta;
            _IdAutor = IdAutor;
            _Comentario = comentario;
            _ValoracionComentario = valoracionComentario;
            _FechaComentario = fechaComentario;
            _NivelComentario = nivelComentario;
            _IdVideo = IdVideo;
        }
        #endregion

        #region Encapsulamiento
        public int IdComentario { get => _IdComentario; set => _IdComentario = value; }
        public int IdRespuesta { get => _IdRespuesta; set => _IdRespuesta = value; }
        public int IdAutor { get => _IdAutor; set => _IdAutor = value; }
        public string Comentario { get => _Comentario; set => _Comentario = value; }
        public int ValoracionComentario { get => _ValoracionComentario; set => _ValoracionComentario = value; }
        public DateTime FechaComentario { get => _FechaComentario; set => _FechaComentario = value; }
        public int NivelComentario { get => _NivelComentario; set => _NivelComentario = value; }
        public int IdVideo { get => _IdVideo; set => _IdVideo = value; }
        #endregion
    }
}
