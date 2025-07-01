using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Usuario
    {
        #region Atributos
        private string _Accion;
        private int _IdUsuario;
        private string _Nombre;
        private string _ApellidoPaterno;
        private string _ApellidoMaterno;
        private string _NombreUsuario;
        private DateTime _FechaRegistro;
        private string _Correo;
        private int _IdCarrera;
        #endregion

        #region Constructores
        public E_Usuario()
        {
            IdUsuario = 0;
            Nombre = string.Empty;
            ApellidoPaterno = string.Empty;
            ApellidoMaterno = string.Empty;
            NombreUsuario = string.Empty;
            FechaRegistro = DateTime.Now;
            Correo = string.Empty;
            Accion = string.Empty;
            _IdCarrera = 0;
        }

        public E_Usuario(string accion, int idUsuario, string nombre, string apellidoPaterno, string apellidoMaterno, string nombreUsuario, DateTime fechaRegistro, string correo, int idCarrera)
        {
            Accion = accion;
            IdUsuario = idUsuario;
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            NombreUsuario = nombreUsuario;
            FechaRegistro = fechaRegistro;
            Correo = correo;
            IdCarrera = idCarrera;
        }

        #endregion

        #region Encapsulamiento
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string ApellidoPaterno { get => _ApellidoPaterno; set => _ApellidoPaterno = value; }
        public string ApellidoMaterno { get => _ApellidoMaterno; set => _ApellidoMaterno = value; }
        public string NombreUsuario { get => _NombreUsuario; set => _NombreUsuario = value; }
        public DateTime FechaRegistro { get => _FechaRegistro; set => _FechaRegistro = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public int IdCarrera { get => _IdCarrera; set => _IdCarrera = value; }
        #endregion
    }
}
