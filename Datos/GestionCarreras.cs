using System;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using Entidades;

namespace Datos
{
    public class D_Carrera : D_ConexionBD
    {
        public DataTable ListadoCarreras()
        {
            SqlCommand cmd = new SqlCommand();
            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter();

            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Carreras";

                DA.SelectCommand = cmd;
                DA.Fill(DT);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }

            return DT;
        }
    }
}
