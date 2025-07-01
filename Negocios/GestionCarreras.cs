using System;
using System.Collections.Generic;

using Datos;
using System.Data;

namespace Negocios
{
    public class N_Carrera
    {
        readonly D_Carrera DC = new D_Carrera();

        public DataTable ListaCarreras()
        {
            return DC.ListadoCarreras();
        }
    }
}
