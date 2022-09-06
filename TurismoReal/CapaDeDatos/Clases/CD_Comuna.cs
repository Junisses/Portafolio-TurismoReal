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
    public class CD_Comuna
    {
        readonly CD_Conexion con = new CD_Conexion();
        readonly CE_Comuna ce = new CE_Comuna();

        #region IdComuna
        public int IdComuna(string Comuna)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "dbo.SP_P_IdComuna",
                CommandType = CommandType.StoredProcedure,
            };

            com.Parameters.AddWithValue("@comuna", Comuna);
            object resultado = com.ExecuteScalar();
            int idcomuna = (int)resultado;
            con.CerrarConexion();

            return idcomuna;
        }

        #endregion
        #region nombre formato

        public CE_Comuna NombreComuna(int IdComuna)
        {
            SqlDataAdapter da = new SqlDataAdapter("dbo.SP_P_Comuna", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@idComuna", SqlDbType.Int).Value = IdComuna;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            ce.Comuna = Convert.ToString(row[0]);

            return ce;

        }

        #endregion

        #region Listar

        public List<string> ObtenerComuna()
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "dbo.SP_P_CargarComuna",
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = com.ExecuteReader();
            List<string> lista = new List<string>();
            while (reader.Read())
            {
                lista.Add(Convert.ToString(reader["comuna"]));
            }
            con.CerrarConexion();

            return lista;
        }

        #endregion

    }
}