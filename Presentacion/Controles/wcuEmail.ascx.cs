using System;

namespace Controles
{
  public partial class wcuEmail : System.Web.UI.UserControl
  {
    public string TextoEtiqueta
    {
      get { return LblEtiqueta.Text.Trim(); }
      set { LblEtiqueta.Text = value; }
    }
    public string Text
    {
      get { return TbEmail.Text.Trim(); }
      set { TbEmail.Text = value; }
    }
    public bool Enabled
    {
      set { TbEmail.Enabled = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
    }
  }
}