using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace Datos
{
    public class D_Materia : D_ConexionBD
    {
        public DataTable ListadoMaterias()
        {
            SqlCommand cmd = new SqlCommand();
            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter();

            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Materias";

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
        public DataTable ListadoMaterias(int id)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable DT = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter();

            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Materias WHERE IdCarrera = "+id;

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
