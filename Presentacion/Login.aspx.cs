using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        readonly N_Carrera NC = new N_Carrera();
        readonly N_Usuario NU = new N_Usuario();
        readonly N_Autores NA = new N_Autores();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["sesion_cimatube"];

                if (cookie != null)
                {
                    Response.Redirect("Inicio.aspx");
                }
                RepeaterCarreras.DataSource = NC.ListaCarreras();
                RepeaterCarreras.DataBind();

            }
        }

        protected void BtnIniciar_Click(object sender, EventArgs e)
        {
            string correo = Request.Form["CorreoLogin"].ToString();
            DataTable dt = NU.GetUsuario(correo);
            if (dt.Rows.Count > 0){
                if ((string) dt.Rows[0]["Correo"].ToString() == correo)
                {
                    HttpCookie cookie = new HttpCookie("sesion_cimatube")
                    {
                        Value = dt.Rows[0]["IdUsuario"].ToString(),
                        Expires = DateTime.Now.AddDays(7) // Establecer la fecha de caducidad (en este caso, 7 días a partir de ahora)
                    };

                    // Agregar la cookie a la respuesta del servidor
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    Response.Redirect("Inicio.aspx");
                }
                
            }
        }

        protected void BtnCrear_Click(object sender, EventArgs e)
        {
            string nombreUsuario = HttpContext.Current.Request["NombreUsuario"];
            string nombre = HttpContext.Current.Request["Nombre"];
            string primerApellido = HttpContext.Current.Request["PrimerApellido"];
            string segundoApellido = HttpContext.Current.Request["SegundoApellido"];
            string correoCrear = HttpContext.Current.Request["CorreoCrear"];
            string carrera = HttpContext.Current.Request["Carrera"];
            E_Usuario usuario = new E_Usuario { 
                Accion = "INSERTAR",
                IdUsuario = 0,
                Nombre = nombre,
                ApellidoPaterno = primerApellido,
                ApellidoMaterno = segundoApellido,
                NombreUsuario = nombreUsuario,
                Correo = correoCrear,
                IdCarrera = (int) int.Parse(carrera),
                FechaRegistro = DateTime.Now
            };

            if (NU.InsertarUsuario(usuario) > 0)
            {
                DataTable dt = NU.GetUsuario(correoCrear);
                if(dt.Rows.Count > 0)
                {
                    NA.CrearAutor(int.Parse(dt.Rows[0]["IdUsuario"].ToString()));
                }
                
            }
            
        }
    }
}