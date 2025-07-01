<%------------------------------------------------------------------------------+
| Autor: Victor Rafael N.Velazquez Mejía                                        |
| Archivo: wcuAlfabeticoReq.ascx                                                |
| Fecha de creación: 13 de abril de 2017                                        |
| Fecha de modificación: 13 de abril de 2017                                    |
|-------------------------------------------------------------------------------|
| Función: Validar que se capture datos                                         |
| La entrada de datos es obligatoria. SI                                        |
| Caracteres válidos: Todos.                                                    |
|-------------------------------------------------------------------------------|
| D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software). | 
---------------------------------------------------------------------------------%>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wcuAlfaNumericoRequerido.ascx.cs" Inherits="SiPAAD.Controles.wcuAlfaNumericoReq" %>


<link href="../CSS/bootstrap.min.css" rel="stylesheet" />

<asp:Label ID="LblEtiqute" runat="server" CssClass="mb-0 form-control" Text="Nombre de usuairo" ></asp:Label>
<asp:TextBox ID="tbAlfaNumerico" runat="server" CssClass="form-control mb-0"></asp:TextBox>

<asp:RequiredFieldValidator
  ID="rfvtbAlfaNumerico" runat="server" ErrorMessage="*"
  ControlToValidate="tbAlfaNumerico"
  CssClass="text-danger"
  Display="Dynamic">No puede deje este campo en blanco.
</asp:RequiredFieldValidator>

<asp:Button ID="BtnAceptar" runat="server" Text="Button" />


