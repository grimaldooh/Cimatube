<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatosMaterias.aspx.cs" Inherits="Presentacion.DatosMaterias" %>

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
                font-size: 2rem;
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
    </style>

</head>
<body>
    <form id="form3" runat="server">
        <div>
            <h1>Hello world</h1>

            <asp:Panel runat="server">
                <table class="table">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Nombre</th>
                            <th>Materias</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="RepeaterMaterias" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# string.Format("{0}", Eval("IdMateria")) %></td>
                                    <td><%# string.Format("{0}", Eval("NombreMateria")) %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan="3">Pie de tabla</td>
                        </tr>
                    </tfoot>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
