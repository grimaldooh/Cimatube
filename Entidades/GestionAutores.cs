using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Autor
    {
        #region Atributos
        private int _IdAutor;
        private int _IdUsuario;
        #endregion

        #region Constructores
        E_Autor()
        {
            IdUsuario = 0;
            _IdAutor = 0;
        }

        E_Autor(int idAutor, int idUsuario)
        {
            _IdAutor = idAutor;
            _IdUsuario = idUsuario;
        }


        #endregion

        #region Encapsulamiento
        public int IdAutor { get => _IdAutor; set => _IdAutor = value; }
        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        #endregion
    }
}
