
using Datos;
using System.Data;

namespace Negocios
{
    public class N_Materia
    {
        readonly D_Materia DM = new D_Materia();

        public DataTable ListaMaterias()
        {
            return DM.ListadoMaterias();
        }

        public DataTable ListaMaterias(int id)
        {
            return DM.ListadoMaterias(id);
        }
    }
}
