﻿<%------------------------------------------------------------------------------+
| Autor: Victor Rafael N.Velazquez Mejía                                        |
| Archivo: wcuEmail.ascx                                                        |
| Fecha de creación: 13 de abril de 2017                                        |
| Fecha de modificación: 13 de abril de 2017                                    |
|-------------------------------------------------------------------------------|
| Función: Validar el formato de entrada de un correo electrónico.              |
| La entrada de datos es obligatoria. NO                                        |
| Formato de entrada: usuario@servidor.pas                                      |
|                                                                               |  
|             usuario: Nombre de idenfificación del usuario los caracteres.     |
|                      válidos son: Letras miúsculas [a-z] números [0-9], los   |
|                      los carácteres punto y guión medio [.-].                 |
|                   @: El caracter @ es obligatorio despues del usuario.        |
|            servidor: Nombre de idenfificación del servidor donde esta ospedado|
|                      el correo los caracteres válidos son: Letras miúsculas   |
|                      [a-z], números [0-9], los carácteres punto y guión medio |
|                      [.-].                                                    |
|                 pas: Iniciales del pais de donde es el correo 2 o 3 letras.   |
|-------------------------------------------------------------------------------|
| D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software). | 
---------------------------------------------------------------------------------%>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wcuEmail.ascx.cs" Inherits="Controles.wcuEmail" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" />
<asp:Label ID="LblEtiqueta" runat="server" CssClass="fw-bold mb-o"></asp:Label>
<asp:TextBox ID="TbEmail" runat="server" CssClass="form-control mb-3"></asp:TextBox>

<asp:RequiredFieldValidator ID="rfvTbEmail" runat="server"
  ErrorMessage="*"
  ControlToValidate="TbEmail"
  CssClass="text-danger fw-normal"
  Display="Dynamic">Debe capturar el correo electrónico.
</asp:RequiredFieldValidator>

<asp:RegularExpressionValidator
  ID="revTbEmail" runat="server" ControlToValidate="tbEmail" ErrorMessage="*"
  ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$"
  Display="Dynamic"
  CssClass="text-danger font-weight-normal">
  Parece que no es una dirección de correo electrónico válida.  
</asp:RegularExpressionValidator>

