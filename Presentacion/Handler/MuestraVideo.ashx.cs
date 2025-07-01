using System;
using System.Data;
using System.IO;
using System.Web;
using Entidades;
using Negocios;

namespace Presentacion.Handler
{
    public class MuestraVideo : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            int Id = Convert.ToInt32(context.Request.QueryString["IdVideo"]);

            N_Video NV = new N_Video();
            DataTable DT = new DataTable();
            DT = NV.GetVideo(Id).Tables[0];

            if (DT != null)
            {

                try
                {
                    E_Video e = new E_Video();
                    e.Accion = "MODIFICAR";
                    e.IdVideo = Id;
                    //e.Video = (byte[])DT.Rows[0]["Video"];
                    //e.Vistas = (int)DT.Rows[0]["Vistas"] + 1;
                    e.TituloVideo = (string)DT.Rows[0]["TituloVideo"];
                    //e.AutorVideo = (string)DT.Rows[0]["Autorvideo"];
                    e.DescripcionVideo = (string)DT.Rows[0]["DescripcionVideo"];
                    e.FechaPublicacion = (DateTime)DT.Rows[0]["FechaPublicacion"];
                    //e.Imagen = (byte[])DT.Rows[0]["Imagen"];
                    e.ValoracionVideo = 0;
                    NV.ModificarVideo(e);
                }
                catch (Exception a)
                {
                    _ = a.ToString();
                    return;
                }

                using (Stream Str = new MemoryStream((byte[])DT.Rows[0]["Video"]))
                //using (Stream Str = new MemoryStream((byte[])DT.Rows[0]["Imagen"]))
                {
                    //context.Response.ContentType = "image/jpg";
                    context.Response.ContentType = "video/mp4";
                    byte[] buffer = new byte[16384];
                    int SecuenciaByte = Str.Read(buffer, 0, 16384);

                    while (SecuenciaByte > 0)
                    {
                        context.Response.OutputStream.Write(buffer, 0, SecuenciaByte);
                        SecuenciaByte = Str.Read(buffer, 0, 16384);
                    }
                }
            }
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
}