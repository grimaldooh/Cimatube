using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class N_Autores
    {
        readonly D_Autores DA = new D_Autores();
        public DataTable ListaAutores()
        {
            return DA.ListadoAutores();
        }
        public DataTable ListaAutores(int idUsuario)
        {
            return DA.ListadoAutores(idUsuario);
        }

        public int CrearAutor(int IdUsuario)
        {
            return DA.CrearAutor(IdUsuario);
        }
    }
}
