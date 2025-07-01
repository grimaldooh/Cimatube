using System;

namespace SiPAAD.Controles
{
  public partial class wcuAlfaNumericoReq : System.Web.UI.UserControl
  {

    protected void Page_Load(object sender, EventArgs e)
    {
     
    }

    public bool Color
    {
      set
      {
        if (value)
        {
          tbAlfaNumerico.BackColor = System.Drawing.Color.Blue;
        }
        else
        {
          tbAlfaNumerico.BackColor = System.Drawing.Color.Green;
        }
      }

    }



    public event EventHandler Etiqueta
    {
      add { LblEtiqute.Text += value; } remove { }
    }
  
    public event EventHandler AceptarClick
    {
      add { BtnAceptar.Click += value; }
      remove { BtnAceptar.Click += value; }
    }
    public string Text
    {     
      get { return tbAlfaNumerico.Text.Trim(); }
      set { tbAlfaNumerico.Text = value; }
    }
    public bool Enabled
    {
      set { tbAlfaNumerico.Enabled = value; }
    }   
  }
}