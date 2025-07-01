<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucPassWordRequerido.ascx.cs" Inherits="Controles.wucPassWordRequerido" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
<div>
  <asp:Label ID="LblEtiqueta" runat="server" Text="Contraseña" CssClass="fw-bold mb-o"></asp:Label>
  <asp:TextBox ID="TbPassWord" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

  <asp:RequiredFieldValidator
    ID="rfvPassWord" runat="server"
    ControlToValidate="TbPassWord"
    Display="Dynamic"
    CssClass="text-danger font-weight-normal">Debe ingresar la contraseña.    
  </asp:RequiredFieldValidator>

</div>
<div class="mt-3">
  <asp:Label ID="LblConfimacion" runat="server" Text="Confirmación de contraseña" CssClass="fw-bold mb-o"></asp:Label>
  <asp:TextBox ID="TbConfirmacion" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

  <asp:RequiredFieldValidator
    ID="rfvConfirmacion" runat="server"
    ControlToValidate="TbConfirmacion"
    Display="Dynamic"
    CssClass="text-danger font-weight-normal">Debe ingresar la confirmacion de la contraseña.    
  </asp:RequiredFieldValidator>

  <asp:CompareValidator
    ID="cvPassWord" runat="server"
    ControlToValidate="TbPassWord"
    ControlToCompare="TbConfirmacion"
    CssClass="text-danger font-weight-normal"> La contraseña y su confirmación no coinciden
  </asp:CompareValidator>

</div>
