﻿﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoPlayer.aspx.cs" Inherits="Presentacion.VideoPlayer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/VideoPlayerDesign.css" rel="stylesheet" />
    <script src="../javascript/VideoPlayerProcess.js" type="text/javascript"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

</head>
<body>

    <form id="form1" runat="server">

        <div class=" col-lg-12 col-xl-12 container">

            <div class="logo-container">
                <a href="/Inicio.aspx">
                    <img src="../Imagenes/logo.png" class="img-fluid logo" alt="Responsive image" /></a>
            </div>

            <!-- Contenedor del video -->
            <div class="video-container">
                <!-- Aquí es donde se inserta el video a reproducir-->
                <div class="col-12 duos">
                    <div class="video-measur">

                        <div class="duos2">
                        <asp:Literal ID="videoTag" runat="server" />

                        <div class="barra-info barra-info-cel">
                    <div class="texto-barra" style="display:flex; flex-direction:row;">
                        Vistas: <asp:Literal ID="videoVistas" runat="server"></asp:Literal>
                        <div class="/">
                            <asp:Button ID="btnLike" runat="server" Text="Me gusta" OnClick="BtnLike_Click" CssClass="btn btn-primary btn-like" />
                           
                        </div>
                    </div>

                </div>
                         </div>

                    </div>
                    <!-- Contenedor de videos recomendados -->





                    <div class="video-info">
                        <div class="edit-video">
                            <div class="name-header">
                                <asp:Literal ID="videoTitle" runat="server"></asp:Literal>

                            </div>
                        </div>
                        <p class="small-text">
                            Autor:
                    <asp:Literal ID="videoAuthor" runat="server"></asp:Literal>
                        </p>
                        <!-- Otros campos del video -->
                        <div class="description-container">
                            <h3 class="des-cel">Descripción</h3>
                            <p class="description">
                                <asp:Literal ID="videoDescription" runat="server"></asp:Literal>
                            </p>
                            <div class="texto-recorrido">
                                <button id="expand-button">Mostrar más</button>
                            </div>


                        </div>

                        <!-- Cuadro de comentarios -->
                        <div class="form-group">
                            <p class="text-dark  m-0 cm2 cel" style="font-size: 16px; color: azure!important">Ingresa un comentario</p>
                            <asp:TextBox ID="Comentarios" runat="server" CssClass="form-control form-detalles-titulo form-control-cel" autocomplete="off"></asp:TextBox>
                        </div>

                        <asp:Button ID="AgregarComentarioBtn" runat="server" Text="Agregar Comentario" OnClick="AgregarComentarioBtn_Click" CssClass="btn btn-primary btn-coment" />

                        <h3 style="padding: 4px;">Comentarios</h3>
                        <div class="comments-container coments" style="height: 230px; overflow-y: auto;">


                            <asp:Repeater ID="RepeaterComentarios" runat="server">
                                <ItemTemplate>

                                    <p class="text-left text-black  font-weight-bold"><%#Eval("Comentario") %></p>
                                    <!--<p class="text-left text-black  font-weight-bold"><%#Eval("Comentario") %></p>-->

                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <!--Cuadro comentarios---->
                    </div>
                </div>
                <!--Barra info---->

                




                <div class="recomended-videos ">Videos relacionados a la materia : </div>
                <div class="video-recomendado">
                    <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
                        <div class="carousel-inner " style="display: flex; flex-direction: row">
                            <asp:Repeater ID="RepeaterImagenes" runat="server">
                                <ItemTemplate>
                                    <div class="carousel-item ruleta" style="margin-top: 10px;">

                                        <div class="videos-crsl">
                                            <a href='videoPlayer.aspx?IdVideo=<%# Eval("IdVideo") %>' class="cel-car">
                                                <img class=" rulet  " style="width: 280px; height: 180px; border-radius: 10px;" src="../<%# DataBinder.Eval(Container.DataItem,"ImagenURL")%>" />
                                                <div class="videos-infoCar">
                                                    <p class=" text-black font-weight-bold text-cel">
                                                        <%#Eval("TituloVideo") %>
                                                    </p>
                                                </div>
                                            </a>

                                        </div>

                                    </div>

                                    <div class="carousel-item ruleta2" style="margin-top: 10px;">
                                        <div class="videos-crsl">
                                            <a href='videoPlayer.aspx?IdVideo=<%# Eval("IdVideo") %>' class="cel-car">
                                                <img class=" rulet  " style="width: 280px; height: 180px; border-radius: 10px;" src="../<%# DataBinder.Eval(Container.DataItem,"ImagenURL")%>" />
                                                <div class="videos-infoCar">
                                                    <p class=" text-black font-weight-bold text-cel">
                                                        <%#Eval("TituloVideo") %>
                                                    </p>
                                                </div>
                                            </a>

                                        </div>

                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <button class="carousel-control-prev custom-botton " type="button" id="prev" data-bs-target="#carouselExampleControls">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden"></span>
                        </button>
                        <button class="carousel-control-next custom-botton " type="button" id="next" data-bs-target="#carouselExampleControls">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden"></span>
                        </button>
                    </div>

                </div>
                <!---CODIGO DE PRUEBA                    ----------------->
                <div class="col-lg-3 col-xl-3 col-md-12">
                    <div class="recomended-videos ">Videos en tendencia : </div>
                    <div class="video-recomendado">


                        <asp:Repeater ID="RepeaterImagenes2" runat="server">
                            <ItemTemplate>
                                <div class="/" style="margin-top: 10px">
                                    <a href='videoPlayer.aspx?IdVideo=<%# Eval("IdVideo") %>'>
                                        <img class="rcmd-img" style="width: 280px; height: 180px; border-radius: 10px;" src="../<%#DataBinder.Eval(Container.DataItem,"ImagenURL")%>" />
                                    </a>
                                    <div class="videos-info">
                                        <p class="text-reset text-left text-black font-weight-bold">
                                            <%#Eval("TituloVideo") %>
                                        </p>
                                        <p class="text-reset text-justify text-black">
                                            <b>Autor: </b><%#Eval("NombreAutor") %>
                                        </p>
                                        <p class="text-reset text-justify text-black" style="margin-bottom: 0.4rem!important;">
                                            <b>Vistas: </b><%# string.Format("{0}",
                      (Eval("Vistas").ToString().Length > 4)?
                      Eval("Vistas").ToString().Substring(0,
                      Eval("Vistas").ToString().Length - 3) +
                      "K":Eval("Vistas").ToString()) %>
                                        </p>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <!---CODIGO DE PRUEBA                    ----------------->
            </div>
        </div>
    </form>
    <script>
        let rulet = document.getElementsByClassName("ruleta");
        let rulet2 = document.getElementsByClassName("ruleta2");
        let prev = document.getElementById("prev");
        let next = document.getElementById("next");
        let indice = 0;
        let indice2 = 1;



        rulet[0].setAttribute("class", "ruleta active")
        rulet2[1].setAttribute("class", "ruleta2 active")

        prev.addEventListener("click", (e) => {
            console.log(indice)
            rulet[indice].setAttribute("class", "ruleta")
            rulet[indice].setAttribute("hidden", "false")
            rulet2[indice2].setAttribute("class", "ruleta2")
            rulet2[indice2].setAttribute("hidden", "false")

            indice -= 1
            indice2 -= 1
            if (indice < 0) {
                indice = rulet.length - 1

            }
            if (indice2 < 0) {
                indice2 = rulet.length - 1
            }

            rulet[indice].removeAttribute("hidden");
            rulet[indice].setAttribute("class", "ruleta active")
            rulet2[indice2].removeAttribute("hidden");
            rulet2[indice2].setAttribute("class", "ruleta2 active")
        })

        next.addEventListener("click", (e) => {
            console.log("adios")
            rulet[indice].setAttribute("class", "ruleta")
            rulet[indice].setAttribute("hidden", "false")
            rulet2[indice2].setAttribute("class", "ruleta2")
            rulet2[indice2].setAttribute("hidden", "false")

            indice += 1;
            indice2 += 1;
            if (indice > rulet.length - 1) {
                indice = 0
            }
            if (indice2 > rulet.length - 1) {
                indice2 = 0
            }
            rulet[indice].removeAttribute("hidden");
            rulet[indice].setAttribute("class", "ruleta active")
            rulet2[indice2].removeAttribute("hidden");
            rulet2[indice2].setAttribute("class", "ruleta2 active")
        })
    </script>
</body>
</html>
