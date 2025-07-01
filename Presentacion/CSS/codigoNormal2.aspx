<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoPlayer.aspx.cs"
Inherits="Presentacion.VideoPlayer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/VideoPlayerDesign.css" rel="stylesheet" />
    <script
      src="../javascript/VideoPlayerProcess.js"
      type="text/javascript"
    ></script>
    <script
      src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js"
      integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM"
      crossorigin="anonymous"
    ></script>
  </head>
  <body>
    <form id="form1" runat="server">
      <div class="col-lg-3 col-xl-4 container">
        <div class="logo-container">
          <a href="/Inicio.aspx">
            <img
              src="../Imagenes/logo.png"
              class="img-fluid logo"
              alt="Responsive image"
          /></a>
        </div>

        <!-- Contenedor del video -->
        <div class="video-container">
          <!-- Aquí es donde se inserta el video a reproducir-->
          <asp:Literal ID="videoTag" runat="server" />
          <!-- Contenedor de videos recomendados -->

          <div class="recomended-videos">
            Videos relacionados a la materia :
          </div>
          <div class="video-recomendado">
            <div
              id="carouselExampleControls"
              class="carousel slide"
              data-bs-ride="carousel"
            >
              <div class="carousel-inner">
                <asp:Repeater ID="RepeaterImagenes" runat="server">
                  <ItemTemplate>
                    <div class="carousel-item ruleta" style="margin-top: 10px">
                      <a href='videoPlayer.aspx?IdVideo=<%# Eval("IdVideo") %>'>
                        <img class="d-block w-100 rulet" style="width: 280px;
                        height: 180px; border-radius: 10px;" src="../<%#
                        DataBinder.Eval(Container.DataItem,"ImagenURL")%>" />
                      </a>
                      <!--  <div class="videos-info ">
                                            <p class="text-reset text-left text-black  font-weight-bold"><%#Eval("TituloVideo") %></p>
                                            <p class="text-reset text-justify text-black"><b>Autor: </b><%#Eval("IdAutor") %></p>
                                            <p class="text-reset text-justify text-black"><b>Vistas: </b><%# string.Format("{0}", (Eval("Vistas").ToString().Length > 4)? Eval("Vistas").ToString().Substring(0, Eval("Vistas").ToString().Length - 3) + "K":Eval("Vistas").ToString())  %></p>
                                        </div>-->
                    </div>
                  </ItemTemplate>
                </asp:Repeater>
              </div>
              <button
                class="carousel-control-prev"
                type="button"
                id="prev"
                data-bs-target="#carouselExampleControls"
              >
                <span
                  class="carousel-control-prev-icon"
                  aria-hidden="true"
                ></span>
                <span class="visually-hidden">Previous</span>
              </button>
              <button
                class="carousel-control-next"
                type="button"
                id="next"
                data-bs-target="#carouselExampleControls"
              >
                <span
                  class="carousel-control-next-icon"
                  aria-hidden="true"
                ></span>
                <span class="visually-hidden">Next</span>
              </button>
            </div>
          </div>
        </div>

        <!-- Contenedor de la información del video -->
        <div class="video-info">
          <h2>
            <asp:Literal ID="videoTitle" runat="server"></asp:Literal>
          </h2>
          <p class="small-text">
            Autor:
            <asp:Literal ID="videoAuthor" runat="server"></asp:Literal>
          </p>
          <!-- Otros campos del video -->
          <div class="description-container">
            <h3>Descripción</h3>
            <p class="description">
              <asp:Literal ID="videoDescription" runat="server"></asp:Literal>
            </p>
            <div class="texto-recorrido">
              <button id="expand-button">Mostrar más</button>
            </div>
          </div>
          <!-- Cuadro de comentarios -->
          <div class="comments-container">
            <h3>Comentarios</h3>
            <p class="comments">Aquí van los comentarios...</p>
          </div>
        </div>
      </div>
    </form>

    <script>
      let rulet = document.getElementsByClassName("ruleta");
      let prev = document.getElementById("prev");
      let next = document.getElementById("next");
      let indice = 0;

      rulet[0].setAttribute("class", "ruleta active");

      prev.addEventListener("click", (e) => {
        console.log(indice);
        rulet[indice].setAttribute("class", "ruleta");
        rulet[indice].setAttribute("hidden", "false");

        indice -= 1;
        if (indice < 0) {
          indice = rulet.length - 1;
        }
        rulet[indice].removeAttribute("hidden");
        rulet[indice].setAttribute("class", "ruleta active");
      });

      next.addEventListener("click", (e) => {
        console.log("adios");
        rulet[indice].setAttribute("class", "ruleta");

        rulet[indice].setAttribute("hidden", "false");
        indice += 1;
        if (indice > rulet.length - 1) {
          indice = 0;
        }
        rulet[indice].removeAttribute("hidden");
        rulet[indice].setAttribute("class", "ruleta active");
      });
    </script>
  </body>
</html>
