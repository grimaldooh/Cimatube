<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="CSS/Login.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>

<body>
    <form id="form1" runat="server">



        <div id="CardHeader" runat="server" class="card-header text-right cel-header" style="background-color: #00723F;">
            <div class="header">
            <img src="Imagenes/LOGO CIMATUBE 2.png" alt="UABC" style="width: 40%;" />
                <div class="botones">
                    <button id="Btn_Login" runat="server" causesvalidation="False" class="btn btn-success ml-3">Iniciar sesión</button>
                    <button id="Btn_Registro" runat="server" causesvalidation="False" class="btn btn-success ml-3">Registrarse</button>
                </div>
            </div>

        </div>


        <div id="pnl_imagen">
            <img src="https://i0.wp.com/suplementocampus.com/wp-content/uploads/2022/03/uabc-2-150322.jpg?fit=800%2C538&ssl=1" alt="UABC" style="width: 100%;" />

        </div>

        <div id="pnl_registro" class="d-none">
            <asp:Panel ID="PnlRegistross" runat="server">
                <div class="principal ">
                    <h1 class="titulo">Registrar usuario  </h1>
                    <div class="login-container">
                        <asp:Panel ID="pnlRegistros" runat="server">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Nombre Usuario:"></asp:Label>
                                <input name="NombreUsuario" id="NombreUsuario" type="text" placeholder="example@uabc.edu.mx" class="form-control" />
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblNombre" runat="server" Text="Nombre/s:"></asp:Label>
                                <input name="Nombre" id="Nombre" type="text" placeholder="Nombre/s" class="form-control" />
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblPrimerApellido" runat="server" Text="Primer Apellido:"></asp:Label>
                                <input name="PrimerApellido" id="PrimerApellido" placeholder="Primer Apellido" type="text" class="form-control" />
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblSegundoApellido" runat="server" Text="Segundo Apellido:"></asp:Label>
                                <input name="SegundoApellido" id="SegundoApellido" placeholder="Segundo Apellido" type="text" class="form-control" />
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblCorreoCrear" runat="server" Text="Correo:"></asp:Label>
                                <input name="CorreoCrear" id="CorreoCrear" placeholder="Correo@uabc.edu.mx" type="text" class="form-control" />
                            </div>
                            <div class="form-group">
                                <select name="Carrera" class="form-select" aria-label="Default select example">
                                    <asp:Repeater ID="RepeaterCarreras" runat="server">
                                        <ItemTemplate>
                                            <option value='<%# Eval("IdCarrera") %>'><%# Eval("NombreCarrera") %></option>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </select>
                            </div>

                            <div class="form-group">
                                <asp:Button ID="BtnCrear" runat="server" Text="Crear Cuenta" CssClass="btn btn-primary" Style="font-family: revert; font-weight: bold;" OnClick="BtnCrear_Click" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </asp:Panel>
        </div>

        <!--Iniciar sesion-->
        <div id="pnl_login" class="d-none">
            <asp:Panel ID="PnlLogin" runat="server">
                <div class="principal ">
                    <h1 class="titulo">Iniciar sesión   </h1>
                    <div class="login-container">
                        <asp:Panel ID="Panel2" runat="server">
                            <div class="form-group">
                                <asp:Label ID="LabelNombre" runat="server" Text="Usuario:"></asp:Label>
                                <input id="CorreoLogin" name="CorreoLogin" type="text" placeholder="example@uabc.edu.mx" class="form-control" />
                            </div>


                            <div class="form-group">
                                <asp:Button ID="BtnIniciar" runat="server" Text="Inicia sesión" OnClick="BtnIniciar_Click" CssClass="btn btn-primary" Style="font-family: revert; font-weight: bold;" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </asp:Panel>
        </div>

    </form>
    <script>

        let btn_login = document.getElementById("Btn_Login");
        let btn_registro = document.getElementById("Btn_Registro");
        let pnl_login = document.getElementById("pnl_login");
        let pnl_registro = document.getElementById("pnl_registro");
        let pnl_imagen = document.getElementById("pnl_imagen");
        function pd(e) {
            e.preventDefault();
        }

        function PnlRegistro(e) {
            pd(e);

            pnl_login.classList.add('d-none');
            pnl_imagen.classList.add('d-none');
            pnl_registro.classList.remove('d-none');

        }

        function PnlLogin(e) {
            pd(e);

            pnl_imagen.classList.add('d-none');
            pnl_registro.classList.add('d-none');
            pnl_login.classList.remove('d-none');

        }

        btn_login.addEventListener("click", PnlLogin)
        btn_registro.addEventListener("click", PnlRegistro)

    </script>

</body>
</html>
