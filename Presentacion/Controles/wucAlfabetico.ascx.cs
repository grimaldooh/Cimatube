using System;

namespace Controles
{
  public partial class wucAlfabetico : System.Web.UI.UserControl
  {

    public string TextoEtiqueta
    {
      get { return LblEtiqueta.Text.Trim(); }
      set { LblEtiqueta.Text = value; }
    }

    public string Text
    {
      get { return TbAlfabetico.Text.Trim(); }
      set { TbAlfabetico.Text = value; }
    }

    public bool Enabled
    {
      set { TbAlfabetico.Enabled = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
  }
}