using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace Presentacion
{
    public partial class VideoPlayer : Page
    {
        readonly N_Video NV = new N_Video();
        readonly N_Autores NA = new N_Autores();
        readonly N_Usuario NU = new N_Usuario();
        //private N_Comentario negocioComentario;
        readonly N_Comentario NC = new N_Comentario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Carga el video especificado en la URL.
                int idVideo = Convert.ToInt32(Request.QueryString["IdVideo"]);
                DataTable dtVideos = NV.ListaVideos();
                dtVideos.Columns.Add("NombreAutor", typeof(string));
                
                foreach (DataRow row in dtVideos.Rows)
                {
                    string idUsuario;
                    DataSet dsUsuario;
                    string id = row["IdAutor"].ToString();
                    DataTable dtAutores = NA.ListaAutores((int)int.Parse(id));
                    if (dtAutores.Rows.Count > 0)
                    {
                        idUsuario = dtAutores.Rows[0]["IdUsuario"].ToString();
                        // Obtén el DataSet con los datos de GetUsuario
                        dsUsuario = NU.GetUsuario((int)int.Parse(idUsuario));

                        // Verifica si el DataSet contiene al menos una tabla
                        if (dsUsuario.Tables.Count > 0)
                        {
                            // Obtén la primera tabla del DataSet
                            DataTable dtUsuario = dsUsuario.Tables[0];

                            // Verifica si la tabla contiene al menos una fila
                            if (dtUsuario.Rows.Count > 0)
                            {
                                // Obtén el valor de la columna "Nombre" de la primera fila
                                string nombreUsuario = dtUsuario.Rows[0]["Nombre"].ToString();

                                // Asigna el nombre del usuario a row["IdAutor"]
                                row["NombreAutor"] = nombreUsuario;
                            }
                            else
                            {
                                row["NombreAutor"] = "No encontrado";
                            }
                        }
                        else
                        {
                            row["NombreAutor"] = "No encontrado";
                        }

                    }
                }
                // Carga los videos recomendados.
                RepeaterImagenes.DataSource = NV.ListaVideos();
                RepeaterImagenes.DataBind();
                RepeaterImagenes2.DataSource = dtVideos;
                RepeaterImagenes2.DataBind();
                RepeaterComentarios.DataSource = NC.ListaComentarios(idVideo);
                RepeaterComentarios.DataBind();
                // Inicializar la instancia de N_Comentario
                //negocioComentario = new N_Comentario();

                //negocioComentario = new N_Comentario();

                // Obtener los datos del video desde la base de datos
                DataSet DS = NV.GetVideo(idVideo);

                //Arreglar esta parte de logica y agregar una verificacion de si existe algo en la tabla
                DataTable DT = DS.Tables[0];

                // Actualizar la lista de comentarios mostrada en la página

                //ActualizarListaComentarios();

                //AgregarComentarioBtn_Click(sender, e);


                videoTag.Text = DT.Rows[0]["VideoURL"].ToString();

                // Verificar si se encontraron datos del video
                if (DT != null && DT.Rows.Count > 0)
                {
                    E_Video ev = new E_Video();
                    ev.Accion = "MODIFICAR";
                    ev.IdVideo = idVideo;
                    ev.VideoURL = (string)DT.Rows[0]["VideoURL"];
                    ev.Vistas = (int)DT.Rows[0]["Vistas"] + 1;
                    ev.TituloVideo = (string)DT.Rows[0]["TituloVideo"];
                    ev.IdAutor = (int)DT.Rows[0]["IdAutor"];
                    ev.DescripcionVideo = (string)DT.Rows[0]["DescripcionVideo"];
                    ev.FechaPublicacion = (DateTime)DT.Rows[0]["FechaPublicacion"];
                    ev.ImagenURL = (string)DT.Rows[0]["ImagenURL"];
                    ev.ValoracionVideo = 0;
                    ev.IdMateria = (int)DT.Rows[0]["IdMateria"];

                    E_Comentario ec = new E_Comentario();
                    //ec.Comentario = (string)DT.Rows[0]["Comentario"];

                    NV.ModificarVideo(ev);
                    //NV.BorraVideo(idVideo);

                    // Asignar los datos del video a los controles en la página
                    videoTag.Text = $"<video width='780' height='580' controls><source src='{DT.Rows[0]["VideoURL"].ToString()}' type='video/mp4'>Your browser does not support the video tag.</video>";
                    //videosCarousel.Text = $"<video width='640' height='480' controls><source src='../{DT.Rows[0]["VideoURL"].ToString()}' type='video/mp4'>Your browser does not support the video tag.</video>";

                    videoTitle.Text = DT.Rows[0]["TituloVideo"].ToString();
                    videoAuthor.Text = DT.Rows[0]["IdAutor"].ToString();
                    videoDescription.Text = DT.Rows[0]["DescripcionVideo"].ToString();
                    videoVistas.Text = ev.Vistas.ToString();


                    //.Text = DT.Rows[0]["Vistas"].ToString(); // Corregir esta línea

                    // Actualizar las vistas del video en la base de datos
                    //int vistas = Convert.ToInt32(DT.Rows[0]["Vistas"]) + 1;
                    //NV.ActualizarVistas(idVideo, vistas);
                }
                else
                {
                    // No se encontraron datos del video, mostrar un mensaje o realizar alguna acción adecuada
                }
            }
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*private void ActualizarListaComentarios()
        {
            // Obtener los comentarios utilizando la capa de negocios
            DataTable comentarios = negocioComentario.ListaComentarios();

            // Asignar los comentarios al Repeater
            RepeaterComentarios.DataSource = comentarios;
            RepeaterComentarios.DataBind();
        }*/


        protected void AgregarComentarioBtn_Click(object sender, EventArgs e)
        {
            int idVideo = Convert.ToInt32(Request.QueryString["IdVideo"]);
            HttpCookie cookie = HttpContext.Current.Request.Cookies["sesion_cimatube"];
            int idAutor = 0;
            string id;
            DataTable tbAutores;
            if (cookie != null)
            {
                string sesion_cookie = cookie.Value.ToString();

                int idUsuario = (int)int.Parse(sesion_cookie);
                tbAutores = NA.ListaAutores(idUsuario);
                if (tbAutores.Rows.Count > 0)
                {
                    id = tbAutores.Rows[0]["IdAutor"].ToString();
                    idAutor = (int)int.Parse(id);
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            //int R =0;
            E_Comentario comentario = new E_Comentario
            {

                Comentario = Comentarios.Text,
                IdAutor = idAutor,
                FechaComentario = DateTime.Now,
                IdComentario = 0,
                IdVideo = idVideo,
                NivelComentario = 0,
                ValoracionComentario = 0,
            };


            int resultado = NC.InsertarComentario(comentario);
            if (resultado > 0)
            {

                // El comentario se insertó correctamente
                Comentarios.Text = ""; // Limpiar el cuadro de texto de comentarios

                // Mostrar un mensaje de comentario enviado exitosamente


                // Actualizar la lista de comentarios mostrada en la página
                ActualizarListaComentarios(idVideo);

            }
            if (!Page.IsValid)
            {
                // Evitar la acción predeterminada
                return;
            }

        }

        private void ActualizarListaComentarios(int idVideo)
        {
            // Obtener los comentarios utilizando la capa de negocios
            //int idVideo = Convert.ToInt32(Request.QueryString["IdVideo"]);
            DataTable comentarios = NC.ListaComentarios(idVideo);

            // Asignar los comentarios al Repeater
            RepeaterComentarios.DataSource = comentarios;
            RepeaterComentarios.DataBind();
        }

        protected void BtnLike_Click(object sender, EventArgs e)
        {
            // Lógica para incrementar el contador de "Me gusta"
            // Puedes actualizar la base de datos o realizar otras acciones necesarias
        }

        protected void BtnDislike_Click(object sender, EventArgs e)
        {
            // Lógica para incrementar el contador de "No me gusta"
            // Puedes actualizar la base de datos o realizar otras acciones necesarias
        }



    }
}
