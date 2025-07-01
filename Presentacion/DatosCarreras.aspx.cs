using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Negocios;

namespace Presentacion
{
    public partial class DatosCarreras : System.Web.UI.Page
    {
        readonly N_Carrera NC = new N_Carrera();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                repeaterCarreras.DataSource = NC.ListaCarreras();
                repeaterCarreras.DataBind();
            }
        }

        protected void repeaterCarreras_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}