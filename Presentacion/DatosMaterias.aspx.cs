using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class DatosMaterias : System.Web.UI.Page
    {
        readonly N_Materia NM = new N_Materia();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idCarrera = Convert.ToInt32(Request.QueryString["IdCarrera"]);
                RepeaterMaterias.DataSource = NM.ListaMaterias(idCarrera);
                RepeaterMaterias.DataBind();
            }
        }
    }
}