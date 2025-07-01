using Datos;
using Entidades;
using System.Data;

namespace Negocios
{
    public class N_Comentario
    {
        readonly D_Comentario DC = new D_Comentario();

        public DataTable ListaComentarios()
        {
            return DC.ListadoComentarios();
        }

        public DataTable ListaComentarios(int id)
        {
            return DC.ListadoComentarios(id);
        }

        /*public DataTable ListaComentarios(int id)
        {
            return DC.ListadoComentarios(id);
        }*/

        public int InsertarComentario(E_Comentario comentario)
        {
            return DC.InsertarComentario(comentario);
        }
    }
}
