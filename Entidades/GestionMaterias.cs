using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Materia
    {
        #region Atributos
        private int _IdMateria;
        private int _IdCarrera;
        private string _NombreMateria;
        #endregion

        #region Constructores
        E_Materia()
        {
            _IdMateria = 0;
            _IdCarrera = 0;
            _NombreMateria = string.Empty;
        }

        E_Materia(int idMateria, int idCarrera, string nombreMateria)
        {
            _IdMateria = idMateria;
            _IdCarrera = idCarrera;
            _NombreMateria = nombreMateria;
        }

        E_Materia(int idMateria, E_Carrera carrera, string nombreMateria)
        {
            _IdMateria = idMateria;
            _IdCarrera = carrera.IdCarrera;
            _NombreMateria = nombreMateria;
        }
        #endregion

        #region Encapsulamiento
        public int IdMateria { get => _IdMateria; set => _IdMateria = value; }
        public int IdCarrera { get => _IdCarrera; set => _IdCarrera = value; }
        public string NombreMateria { get => _NombreMateria; set => _NombreMateria = value; }
        #endregion
    }

}

