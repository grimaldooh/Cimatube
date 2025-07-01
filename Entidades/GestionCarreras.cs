using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Carrera
    {
        #region Atributos
        private int _IdCarrera;
        private string _NombreCarrera;
        #endregion

        #region Constructores
        E_Carrera()
        {
            _IdCarrera = 0;
            _NombreCarrera = string.Empty;
        }

        E_Carrera(int idCarrera, string nombreCarrera)
        {
            _IdCarrera = idCarrera;
            _NombreCarrera = nombreCarrera;
        }


        #endregion

        #region Encapsulamiento
        public int IdCarrera { get => _IdCarrera; set => _IdCarrera = value; }
        public string NombreCarrera { get => _NombreCarrera; set => _NombreCarrera = value; }
        #endregion
    }
}
