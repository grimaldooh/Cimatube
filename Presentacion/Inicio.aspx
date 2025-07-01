<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Presentacion.Inicio" %>

<%@ Register Src="~/Controles/wcuAlfaNumericoRequerido.ascx" TagPrefix="uc1" TagName="wcuAlfaNumericoRequerido" %>
<%@ Register Src="~/Controles/wucAlfabeticoRequerido.ascx" TagPrefix="uc1" TagName="wucAlfabeticoRequerido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="CSS/site.css" rel="stylesheet" />

    <style>
        /* Estilo para pantallas extra pequeñas (xs) */
        @media (max-width: 575.98px) {
            .ImagenVideo {
                width: 800px;
                height: 300px;
            }

            .titulo-video {
                font-size: 24px;
            }

            .vistas-video {
                font-size: 28px;
            }

            .btn {
                font-size: 36px;
                border-radius: 40px;
                font-weight: bold;
            }
        }

        /* Estilo para pantallas pequeñas (sm) */
        @media (min-width: 576px) and (max-width: 767.98px) {
            .ImagenVideo {
                width: 800px;
                height: 300px;
            }

            .titulo-video {
                font-size: 28px;
            }

            .vistas-video {
                font-size: 28px;
            }

            .btn {
                font-size: 36px;
                border-radius: 40px;
                font-weight: bold;
            }
        }

        /* Estilo para pantallas medianas (md) */
        @media (min-width: 768px) and (max-width: 991.98px) {
            .ImagenVideo {
                width: 950px;
                height: 450px;
            }

            .titulo-video {
                font-size: 36px;
            }

            .vistas-video {
                font-size: 28px;
            }

            .btn {
                font-size: 36px;
                border-radius: 40px;
                font-weight: bold;
            }

            .custom-card {
                height: 400px; /* Ajusta la altura deseada */
                width: 100%; /* Ajusta el ancho deseado */
                box-sizing: content-box; /* Ajusta el modelo de caja */
                padding: 0; /* Establece el relleno a 0 */
                border: none;
            }

            .cel-custom {
                line-height: 7.5;
                font-size: 24px;
            }

            .form-control-file {
                font-size: 24px;
                display: flex;
                justify-content: center; /* Centrar horizontalmente */
                align-items: center;
            }

            .btn-cel {
                font-size: 36px;
                border-radius: 40px;
                font-weight: bold;
                line-height: 2.5;
            }



            .form-video {
                margin-bottom: 20rem;
            }

            form-group {
                font-size: 26px;
            }

            .form-detalles-aut {
                height: 170px;
            }

            .form-detalles-des {
                height: 340px;
            }

            .form-detalles-titulo {
                height: 210px;
            }

            button, input, optgroup, select, textarea {
                margin: 0;
                font-family: inherit;
                font-size: 26px;
                line-height: inherit;
            }

            .form-control {
                font-size: 1rem;
            }

            .mb-3, .my-3 {
                margin-bottom: 12rem !important;
            }

            .cel-card {
                border-radius: 40px;
            }
        }

        /* Estilo para pantallas grandes (lg) */
        @media (min-width: 992px) and (max-width: 1199.98px) {
            .ImagenVideo {
                width: 450px;
                height: 200px;
            }

            .titulo-video {
                font-size: 18px;
            }

            .vistas-video {
                font-size: 18px;
            }
        }

        /* Estilo para pantallas extra grandes (xl) */
        @media (min-width: 1200px) {
            .ImagenVideo {
                width: 450px;
                height: 200px;
            }

            .titulo-video {
                font-size: 12px;
            }

            .vistas-video {
                font-size: 12px;
            }
        }

        .vid-carrera {
            font-size: 2rem;
            padding: 15px;
        }
    </style>

</head>
<body>



    <form id="form1" runat="server">
        <div class="conteiner-fluid pl-0 m-0">
            <div class="fa-border bg-faded mt-3 mb-3" style="background-color: #00723F;">
                <div class="row ">
                    <div class="col-12 mt-2 mb-2">
                        <asp:LinkButton ID="BtnNuevoArchivo" runat="server" CausesValidation="False" CssClass="btn btn-primary ml-3" OnClick="BtnNuevoVideo_Click">Registrar video</asp:LinkButton>
                        <asp:LinkButton ID="BtnImagenes" runat="server" CausesValidation="False" CssClass="btn btn-primary ml-3" OnClick="BtnImagenes_Click"> Galeria de video</asp:LinkButton>
                        <input class="input-group-sm" name="busqueda" id="busqueda" type="text" placeholder="Buscar"/>
                        <asp:Button CssClass="btn btn-primary ml-3" ID="buscar" OnClick="buscar_Click" runat="server" Text="Buscar" />
                    </div>
                </div>
            </div>

            <asp:Panel ID="PnlNuevo" runat="server">
                <div class="container">
                    <div class="card-body custom-card">
                        <div class="card cel-card">
                            <div id="CardHeader" runat="server" class="card-header text-center cel-header" style="background-color: #00723F;">
                                <button id="Btn_Video" runat="server" causesvalidation="False" class="btn btn-success ml-3">Video</button>
                                <button id="Btn_Detalles" runat="server" causesvalidation="False" class="btn btn-success ml-3">Detalles</button>
                                <button id="Btn_Visibilidad" runat="server" causesvalidation="False" class="btn btn-success ml-3">Visibiliad</button>

                            </div>

                            <div class="card-body ">

                                <!--- BOTON DE DETALLES-->

                                <div id="pnl_detalle" class="d-none">
                                    <div class="row pl-2 pr-2">
                                        <div class="col-12">
                                            <div class="form-group ">

                                                <p class="text-dark font-weight-bold m-0" style="font-size: 26px;">Titulo del video</p>
                                                <asp:TextBox ID="TbTituloVideo" runat="server" CssClass="form-control form-detalles-titulo"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row pl-2 pr-2">
                                        <div class="col-12">
                                            <div class="form-group ">
                                                <p class="text-dark font-weight-bold m-0" style="font-size: 26px;">Descripción</p>
                                                <asp:TextBox ID="TbDescripcionVideo" runat="server" TextMode="MultiLine" CssClass="form-control form-detalles-des "></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <!--- SELECCION DE MATERIAS-->
                                    <div class="row pl-2 pr-2">
                                        <div class="col-12">
                                            <p class="text-dark font-weight-bold m-0" style="font-size: 26px;">Selección de carrera y materia</p>

                                            <select class="form-select" aria-label="Default select example">
                                                <option selected="0">Carrera relacionada</option>
                                                <asp:Repeater ID="RepeaterCarreras" runat="server">
                                                    <ItemTemplate>
                                                        <option value="<%# Eval("IdCarrera") %>">
                                                            <%# Eval("NombreCarrera") %></option>

                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </select>



                                            <select name="slctMateria" class="form-select" aria-label="Default select example">
                                                <option selected="0">Materia relacionada</option>
                                                <asp:Repeater ID="RepeaterMaterias" runat="server">
                                                    <ItemTemplate>
                                                        <option value=" <%# Eval("IdMateria") %>">
                                                            <%# Eval("NombreMateria") %></option>

                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </select>


                                        </div>

                                    </div>
                                    <!--- SELECCION DE MATERIAS-->
                                    <div class="row pl-2 pr-2">
                                        <div class="col-12">
                                            <div class="form-group form-detalles">
                                                <p class="text-dark font-weight-bold m-0" style="font-size: 26px;">Imagen miniatura</p>
                                                <asp:FileUpload ID="fuImagen" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--- BOTON DE DETALLES-->
                                <!--- BOTON DE VISIBILIDAD-->

                                <div id="pnl_visibilidad" class="d-none">
                                    <p class="text-center text-dark font-weight-bold mt-20 mb-2 cel-custom">ELIGE QUIEN PODRA VER TU VIDEO</p>
                                    <div class="row pl-2 pr-2" style="display: flex; flex-direction: column;">
                                        <div class="form-check">
                                            <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1" value="0" />
                                            <label class="form-check-label" for="flexRadioDefault1">
                                                Video privado (solo tú lo puedes ver)
                                            </label>
                                        </div>
                                        <div class="form-check">
                                            <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" value="1" checked="checked" />
                                            <label class="form-check-label" for="flexRadioDefault2">
                                                Video público (cualquier persona lo puede ver)
                                            </label>
                                        </div>
                                    </div>
                                </div>

                                <!--- BOTON DE VISIBILIDAD-->


                                <div id="file_video" class="row pl-2 pr-2">
                                    <div class="col-12">
                                        <div class="form-group form-video">
                                            <!--<p class="text-center text-dark font-weight-bold m-0">ARRASTRA UN VIDEO</p>-->
                                            <p class="text-center text-dark font-weight-bold mt-20 mb-2 cel-custom">ARRASTRA UN VIDEO</p>

                                            <asp:FileUpload ID="fuVideo" CssClass="form-control-file" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="card-footer text-muted text-right ">
                                <asp:Button ID="BtnCancelar" runat="server" CssClass="btn btn-warning btn-cel" Text="Cancelar" CausesValidation="False" OnClick="BtnCancelar_Click" />
                                <asp:Button ID="BtnGrabar" runat="server" CssClass="btn btn-success btn-cel" Text="Subir video" CausesValidation="true" OnClick="BtnInsertaVideo_Click" />

                            </div>
                        </div>
                    </div>
                </div>
                <asp:Label ID="lblResultado" runat="server"></asp:Label>
            </asp:Panel>

            <asp:Panel ID="PnlGrvVideos" runat="server">
                <div class="container">
                    <asp:GridView ID="GrvVideos" runat="server"
                        AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                        DataKeyNames="IdVideo" GridLines="None" ForeColor="#333333"
                        OnSelectedIndexChanged="GrvVideos_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="TituloVideo" HeaderText="TITULO" />
                            <asp:BoundField DataField="AutorVideo" HeaderText="AUTOR" />
                            <asp:CommandField ControlStyle-CssClass="btn btn-primary" SelectText="VER VIDEO" ShowSelectButton="True">
                                <ControlStyle CssClass="GrvSelection"></ControlStyle>
                            </asp:CommandField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle CssClass="GrvHeader" BackColor="#2d2d30" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle CssClass="GrvRowStyle" BackColor="#F7F6F3" ForeColor="#333333" />
                        <AlternatingRowStyle CssClass="GrvAlternationRow" BackColor="White" ForeColor="#284775" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </div>
            </asp:Panel>
            <!--- VIDEOS DE BUSQUEDA---->
            <asp:Panel ID="pnlBusqueda" runat="server">
                <div class="vid-carrera">Videos encontrados</div>
                <div class="d-flex ">

                    <div class="container-fluid">
                        <div class="row">

                            <asp:Repeater ID="ReapeterBusqueda" runat="server">
                                <ItemTemplate>
                                    <div class="col-sm-12 col-lg-4 col-md-12 col-xl-3 col-xs-12">

                                        <a href='<%# string.Format("https://localhost:44377/VideoPlayer.aspx?IdVideo={0}", Eval("IdVideo"))%>'>
                                            <img class="img-fluid Imagen ImagenVideo" src="../<%# DataBinder.Eval(Container.DataItem,"ImagenURL")%>" />

                                            <p class="text-reset text-left text-black  font-weight-bold titulo-video"><%#Eval("TituloVideo") %></p>

                                        </a>
                                        <p class="text-reset text-justify text-black vistas-video"><b>Vistas: </b><%# string.Format("{0}", (Eval("Vistas").ToString().Length > 4)? Eval("Vistas").ToString().Substring(0, Eval("Vistas").ToString().Length - 3) + "K":Eval("Vistas").ToString())  %></p>

                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <!--- VIDEOS DE BUSQUEDA---->
            <!--- VIDEOS DE CARRERA---->
            <asp:Panel ID="PnlImagen" runat="server">
                <div class="vid-carrera">Videos relacionados a tu carrera</div>
                <div class="d-flex ">

                    <div class="container-fluid">
                        <div class="row">

                            <asp:Repeater ID="RepeaterImagenes" runat="server">
                                <ItemTemplate>
                                    <div class="col-sm-12 col-lg-4 col-md-12 col-xl-3 col-xs-12">

                                        <a href='<%# string.Format("https://localhost:44377/VideoPlayer.aspx?IdVideo={0}", Eval("IdVideo"))%>'>
                                            <img class="img-fluid Imagen ImagenVideo" src="../<%# DataBinder.Eval(Container.DataItem,"ImagenURL")%>" />

                                            <p class="text-reset text-left text-black  font-weight-bold titulo-video"><%#Eval("TituloVideo") %></p>

                                        </a>
                                        <p class="text-reset text-justify text-black vistas-video"><b>Vistas: </b><%# string.Format("{0}", (Eval("Vistas").ToString().Length > 4)? Eval("Vistas").ToString().Substring(0, Eval("Vistas").ToString().Length - 3) + "K":Eval("Vistas").ToString())  %></p>

                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <!--- VIDEOS DE CARRERA---->
            <!--- VIDEOS EN TENDENCIA---->

            <asp:Panel ID="PnlImage" runat="server">
                <div class="vid-carrera">Videos en tendencia</div>
                <div class="d-flex ">
                    <div class="container-fluid">
                        <div class="row">

                            <asp:Repeater ID="RepeaterTendencia" runat="server">
                                <ItemTemplate>
                                    <div class="col-sm-12 col-lg-4 col-md-12 col-xl-3 col-xs-12">

                                        <a href='<%# string.Format("https://localhost:44377/VideoPlayer.aspx?IdVideo={0}", Eval("IdVideo"))%>'>
                                            <img class="img-fluid Imagen ImagenVideo" src="../<%# DataBinder.Eval(Container.DataItem,"ImagenURL")%>" />

                                            <p class="text-reset text-left text-black  font-weight-bold titulo-video"><%#Eval("TituloVideo") %></p>

                                        </a>
                                        <p class="text-reset text-justify text-black vistas-video"><b>Vistas: </b><%# string.Format("{0}", (Eval("Vistas").ToString().Length > 4)? Eval("Vistas").ToString().Substring(0, Eval("Vistas").ToString().Length - 3) + "K":Eval("Vistas").ToString())  %></p>

                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <!--- VIDEOS EN TENDENCIA---->

            <asp:Panel ID="PnlMensaje" runat="server">
                <div class="modal-dialog modal-notify modal-mensaje" role="document">
                    <div class="modal-content">
                        <div id="ModalHeader" runat="server">
                            <p class="heading lead text-center text-white"><span id="ModalTitulo" runat="server"></span></p>
                        </div>
                        <div class="modal-body">
                            <span id="ModalBody" runat="server"></span>
                        </div>

                        <div class="modal-footer justify-content-center text-white">
                            <asp:LinkButton ID="BtnEntendido" runat="server" CausesValidation="false"> Entendido</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </asp:Panel>


            <!-- Footer -->
            <footer class="text-center text-lg-start bg-white text-muted">
                <!-- Section: Social media -->
                <!--<section class="d-flex justify-content-center justify-content-lg-between p-4 border-bottom">-->
                <section class="d-flex justify-content-center justify-content-lg-between justify-content-md-start p-4 border-bottom align-items-stretch min-vh-100">
                    <!-- Left -->
                    <div class="me-5 mt-auto mb-0">
                        <span>Acerca de nosotros: </span>
                    </div>
                    <!-- Left -->

                    <!-- Right -->
                    <div>
                        <a href="" class="me-4 link-secondary">
                            <i class="fab fa-facebook-f"></i>
                        </a>
                        <a href="" class="me-4 link-secondary">
                            <i class="fab fa-twitter"></i>
                        </a>
                        <a href="" class="me-4 link-secondary">
                            <i class="fab fa-google"></i>
                        </a>
                        <a href="" class="me-4 link-secondary">
                            <i class="fab fa-instagram"></i>
                        </a>
                        <a href="" class="me-4 link-secondary">
                            <i class="fab fa-linkedin"></i>
                        </a>
                        <a href="" class="me-4 link-secondary">
                            <i class="fab fa-github"></i>
                        </a>
                    </div>
                    <!-- Right -->
                </section>
                <!-- Section: Social media -->

                <!-- Section: Links  -->
                <section class="">
                    <div class="row">
                        <div class="col-12 text-center bg-success">
                            <img src="../Imagenes/logo.png" class="img-fluid" alt="Responsive image" />
                            <h2 class="text-center text-white font-weight-bold">CimaTube</h2>
                        </div>
                    </div>

                </section>
                <!-- Section: Links  -->

                <!-- Copyright -->
                <div class="text-center p-4" style="background-color: rgba(0, 0, 0, 0.025);">
                    © 2023 Copyright:
                    <a class="text-reset fw-bold" href="http://fiad.ens.uabc.mx/">http://fiad.ens.uabc.mx/</a>
                </div>
                <!-- Copyright -->
            </footer>
            <!-- Footer -->

        </div>
    </form>

    <script>
        let btn_video = document.getElementById("Btn_Video");
        let btn_detalles = document.getElementById("Btn_Detalles");
        let btn_visilidad = document.getElementById("Btn_Visibilidad");
        let pnl_video = document.getElementById("file_video");
        let pnl_detalle = document.getElementById("pnl_detalle");
        let pnl_nuevo = document.getElementById("PnlNuevo");
        let pnl_visibilidad = document.getElementById("pnl_visibilidad");

        function pd(e) {
            e.preventDefault();
        }

        function pnlVideo(e) {
            pd(e);

            pnl_detalle.classList.add('d-none');
            pnl_video.classList.remove('d-none');
            pnl_visibilidad.classList.add('d-none');
        }

        function pnlDetalle(e) {
            pd(e);

            pnl_video.classList.add('d-none');
            pnl_detalle.classList.remove('d-none');
            pnl_visibilidad.classList.add('d-none');
        }
        function pnlVisibilidad(e) {
            pd(e)
            pnl_detalle.classList.add('d-none');
            pnl_video.classList.add('d-none');
            pnl_visibilidad.classList.remove('d-none');
        }

        function arrastrar(e) {
            pd(e);

            console.log("Suelte el archivo");
        }

        pnl_nuevo.addEventListener("dragover", arrastrar)
        btn_video.addEventListener("click", pnlVideo)
        btn_detalles.addEventListener("click", pnlDetalle)
        btn_visilidad.addEventListener("click", pnlVisibilidad)

        window.addEventListener('DOMContentLoaded', function () {
            adjustFontSizes();

            window.addEventListener('resize', adjustFontSizes);
        });

        function adjustFontSizes() {
            var videoTitles = document.querySelectorAll('.video-title');
            var videoViews = document.querySelectorAll('.video-views');

            var screenSize = window.innerWidth;

            // Ajustar el tamaño de fuente según el tamaño de la pantalla
            if (screenSize < 576) {
                videoTitles.forEach(function (title) {
                    title.style.fontSize = '76px';
                });

                videoViews.forEach(function (views) {
                    views.style.fontSize = '72px';
                });
            } else if (screenSize >= 576 && screenSize < 992) {
                videoTitles.forEach(function (title) {
                    title.style.fontSize = '58px';
                });

                videoViews.forEach(function (views) {
                    views.style.fontSize = '74px';
                });
            } else {
                videoTitles.forEach(function (title) {
                    title.style.fontSize = '70px';
                });

                videoViews.forEach(function (views) {
                    views.style.fontSize = '76px';
                });
            }
        }
    </script>
</body>
</html>
