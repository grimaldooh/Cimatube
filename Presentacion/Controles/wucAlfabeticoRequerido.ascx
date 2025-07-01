﻿<%------------------------------------------------------------------------------+
| Autor: Victor Rafael N.Velazquez Mejía                                        |
| Archivo: wcuAlfabeticoReq.ascx                                                |
| Fecha de creación: 13 de abril de 2017                                        |
| Fecha de modificación: 13 de abril de 2017                                    |
|-------------------------------------------------------------------------------|
| Función: Validar los caracteres de entrada en una cadena alfabética.          |
| La entrada de datos es obligatoria. SI                                        |
| Caracteres válidos: Letras minusculas [a-z] y mayúsculas [A-Z].               |
|                     Letras acentuadas [áéíóúÁÉÍÓÚ].                           |
|                     Letra ñ y Ñ [ñÑ]                                          |
|                     Carácter de espacio [\s].                                 |
|-------------------------------------------------------------------------------|
| D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software). | 
---------------------------------------------------------------------------------%>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucAlfabeticoRequerido.ascx.cs" Inherits="Controles.wucAlfabeticoReq" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" />

<asp:Label ID="LblEtiqueta" runat="server" CssClass="mb-0 fw-bold" ></asp:Label>
<asp:TextBox ID="TbAlfabetico" runat="server" CssClass="form-control mb-3"></asp:TextBox>

<asp:RegularExpressionValidator
  ID="revAlfabetico" runat="server" ControlToValidate="TbAlfabetico" ErrorMessage="*"
  ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+"
  Display="Dynamic"
  CssClass="text-danger font-weight-normal"><i class="text-danger fas fa-exclamation-triangle mr-2"></i>El campo tiene caracteres no válidos.</asp:RegularExpressionValidator>
  
<asp:RequiredFieldValidator
  ID="rfvTbAlfabetico" runat="server" ErrorMessage="*"
  ControlToValidate="TbAlfabetico"   
  Display="Dynamic" 
  CssClass="text-danger font-weight-normal"><i class="text-danger fas fa-exclamation-triangle mr-2"></i>Campo requerido.
</asp:RequiredFieldValidator>

