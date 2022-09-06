using CapaDeEntidad.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Clases
{
    public class CD_Region
    {
        readonly CD_Conexion con = new CD_Conexion();
        private CE_Region ce = new CE_Region();

        #region IdRegion
        public int IdRegion(string Region)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "dbo.SP_P_IdRegion",
                CommandType = CommandType.StoredProcedure,
            };

            com.Parameters.AddWithValue("@region", Region);
            object resultado = com.ExecuteScalar();
            int idregion = (int)resultado;
            con.CerrarConexion();

            return idregion;
        }

        #endregion
        #region nombre formato

        public CE_Region NombreRegion(int IdRegion)
        {
            SqlDataAdapter da = new SqlDataAdapter("dbo.SP_P_Region", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@idRegion", SqlDbType.Int).Value = IdRegion;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            ce.Region = Convert.ToString(row[0]);

            return ce;

        }

        #endregion

        #region Listar

        public List<string> ObtenerRegion()
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "dbo.SP_P_CargarRegion",
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = com.ExecuteReader();
            List<string> lista = new List<string>();
            while (reader.Read())
            {
                lista.Add(Convert.ToString(reader["region"]));
            }
            con.CerrarConexion();

            return lista;
        }

        #endregion

    }
}