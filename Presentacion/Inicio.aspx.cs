using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using Negocios;

namespace Presentacion
{
    public partial class Inicio : System.Web.UI.Page
    {
        private string BackGroundHeader;
        private string BtnColor;
        readonly N_Video NV = new N_Video();
        readonly N_Carrera NC = new N_Carrera();
        readonly N_Materia NM = new N_Materia();
        readonly N_Autores NA = new N_Autores();
        readonly N_Usuario NU = new N_Usuario();
        private int idUsuario = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            PanelesOFF();

            if (!IsPostBack)
            {

                idUsuario = GetIdCookie();
                DataTable dt = NU.GetUsuario(idUsuario).Tables[0];
                DataTable dtMtr = NM.ListaMaterias(int.Parse(dt.Rows[0]["IdCarrera"].ToString()));
                DataTable dtNueva = new DataTable();
                foreach (DataRow row in dtMtr.Rows)
                {
                    string StringidCrr = row["IdCarrera"].ToString();
                    DataTable dtVRCM = NV.ListaVideoPorMateria(int.Parse(StringidCrr));
                    foreach (DataRow rowVRCM in dtVRCM.Rows)
                    {
                        dtNueva.Rows.Add(rowVRCM);
                    }
                }
                if (dtNueva.Rows.Count > 0)
                    RepeaterImagenes.DataSource = dtNueva;
                else
                    RepeaterImagenes.DataSource = NV.ListaVideos();
                RepeaterImagenes.DataBind();
                RepeaterCarreras.DataSource = NC.ListaCarreras();
                RepeaterCarreras.DataBind();
                RepeaterMaterias.DataSource = NM.ListaMaterias();
                RepeaterMaterias.DataBind();
                RepeaterTendencia.DataSource = NV.ListaVideos("Vistas", 20, "");
                RepeaterTendencia.DataBind();
                PnlGrvVideos.Visible = false;
                PnlImagen.Visible = true;
                PnlImage.Visible = true;
            }
        }
        protected void PanelesOFF()
        {
            PnlNuevo.Visible = false;
            PnlGrvVideos.Visible = false;
            PnlImagen.Visible = false;
            PnlImage.Visible = false;
            PnlMensaje.Visible = false;
            pnlBusqueda.Visible = false;
        }
        protected void ControlesClear()
        {
            TbTituloVideo.Text = string.Empty;
            TbDescripcionVideo.Text = string.Empty;
            //TbAutorVideo.Text = string.Empty;
        }

        private int GetIdCookie()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["sesion_cimatube"];

            if (cookie != null)
            {
                string sesion_cookie = cookie.Value.ToString();

                idUsuario = int.Parse(sesion_cookie);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            return idUsuario;
        }

        protected void BtnInsertaVideo_Click(object sender, EventArgs e)
        {
            if (fuImagen.HasFile && fuVideo.HasFile)
            {

                idUsuario = GetIdCookie();

                HttpPostedFile hpfImagen = fuImagen.PostedFile;
                HttpPostedFile hpfVideo = fuVideo.PostedFile;

                int idAutor = 0;
                DataTable dtAutor = NA.ListaAutores(idUsuario);
                if (dtAutor.Rows.Count > 0)
                {
                    idAutor = (int)int.Parse(dtAutor.Rows[0]["IdAutor"].ToString());
                }
                else
                {
                    NA.CrearAutor(idUsuario);
                    dtAutor = NA.ListaAutores(idUsuario);
                    if (dtAutor.Rows.Count > 0)
                    {
                        idAutor = (int)int.Parse(dtAutor.Rows[0]["IdAutor"].ToString());
                    }
                    else
                    {
                        throw new Exception("A ocurrido un erro al crear un autor");
                    }
                }

                byte visibilidad = byte.Parse(Request.Form["flexRadioDefault"]);
                int idMateria = int.Parse(Request.Form["slctMateria"]);
                E_Video video = new E_Video
                {
                    Accion = "INSERTAR",
                    IdVideo = 0,
                    Visibilidad = visibilidad,
                    TituloVideo = TbTituloVideo.Text,
                    IdAutor = idAutor,
                    DescripcionVideo = TbDescripcionVideo.Text,
                    FechaPublicacion = DateTime.Now,
                    Vistas = 0,
                    IdMateria = idMateria,
                    ValoracionVideo = 0

                };

                string R = NV.InsertaVideo(video, hpfImagen, hpfVideo, Server.MapPath("~/"));

                if (R.Contains("Exito"))
                {
                    ModalMsg("Exito: El video grabó exitosamente.");
                    ControlesClear();
                }
                else if (R.Contains("Fatal"))
                {
                    NA.CrearAutor(idAutor);
                    ModalMsg("Error: No se encontraba registrado, intentelo nuevamente.");
                }
                else
                    ModalMsg("Error: Ocurrio un error intentelo nuevamente.");

            }
            else
                ModalMsg("Error: Debe capturar todos los datos");
        }
        protected void LstArchivos()
        {
            GrvVideos.DataSource = NV.ListaVideos(); ;
            GrvVideos.DataBind();
            PnlGrvVideos.Visible = true;
        }
        protected void GrvVideos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdVideo = Convert.ToInt32(GrvVideos.DataKeys[Convert.ToInt16(GrvVideos.SelectedIndex)].Value.ToString());
            //NV.incremetarVisistas(IdVideo)
            Response.Redirect("VideoPlayer.aspx?IdVideo=" + IdVideo);
        }
        protected void EliminarVideo(object sender, EventArgs e)
        {
            int IdVideo = Convert.ToInt32(GrvVideos.DataKeys[Convert.ToInt16(GrvVideos.SelectedIndex)].Value.ToString());
            NV.BorraVideo(IdVideo);
        }


        protected void BtnTodos_Click(object sender, EventArgs e)
        {
            PnlGrvVideos.Visible = true;
            LstArchivos();
        }
        protected void BtnImagenes_Click(object sender, EventArgs e)
        {
            RepeaterImagenes.DataSource = NV.ListaVideos();
            RepeaterImagenes.DataBind();
            PnlGrvVideos.Visible = false;
            PnlImagen.Visible = true;
            PnlImage.Visible = true;
        }
        protected void BtnNuevoVideo_Click(object sender, EventArgs e)
        {
            PanelesOFF();
            PnlNuevo.Visible = true;
        }
        protected void AtributosModal(string Tipo)
        {
            switch (Tipo)
            {
                case "Exito": BackGroundHeader = "bg-success"; BtnColor = "btn btn-md btn-success"; break;
                case "Error": BackGroundHeader = "bg-danger"; BtnColor = "btn btn-md btn-danger"; break;
                case "Informacion": BackGroundHeader = "bg-info"; BtnColor = "btn btn-md btn-info"; break;

            }
        }
        public void ModalMsg(string pMsg)
        {
            String[] TipoMsg = pMsg.Split(':');
            AtributosModal(TipoMsg[0]);
            ModalHeader.Attributes.Clear();
            ModalHeader.Attributes.Add("class", BackGroundHeader);
            ModalTitulo.InnerHtml = string.Format("{0}", TipoMsg[0]);
            ModalBody.InnerHtml = string.Format("{0}", TipoMsg[1]);
            BtnEntendido.Attributes.Clear();
            BtnEntendido.Attributes.Add("class", BtnColor);
            BtnEntendido.Attributes.Add("href", "/Inicio.aspx");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "#modal-mensaje", true);
            PnlMensaje.Visible = true;
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            ControlesClear();
            PanelesOFF();
            RepeaterImagenes.DataSource = NV.ListaVideos();
            RepeaterImagenes.DataBind();
            PnlGrvVideos.Visible = false;
            PnlImagen.Visible = true;
        }

        protected void OnKeyPressBusqueda(object sender, EventArgs e)
        {
            pnlBusqueda.Visible = true;
        }


        protected void BtnListado_Click(object sender, EventArgs e) => LstArchivos();

        protected void buscar_Click(object sender, EventArgs e)
        {
            string respuesta = Request.Form["busqueda"];

            pnlBusqueda.Visible = true;
            ReapeterBusqueda.DataSource = NV.ListaVideos("TituloVideo", 12, respuesta);
            ReapeterBusqueda.DataBind();

        }
    }
}