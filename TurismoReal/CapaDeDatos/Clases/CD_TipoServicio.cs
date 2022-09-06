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
    public class CD_TipoServicio
    {
        readonly CD_Conexion con = new CD_Conexion();
        readonly CE_TipoServicio ce = new CE_TipoServicio();

        #region IdTipoServicio
        public int IdTipoServicio(string Descripcion)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "dbo.SP_P_IdTipoServicio",
                CommandType = CommandType.StoredProcedure,
            };

            com.Parameters.AddWithValue("@descripcion", Descripcion);
            object resultado = com.ExecuteScalar();
            int idtiposerv = (int)resultado;
            con.CerrarConexion();

            return idtiposerv;
        }

        #endregion
        #region nombre formato

        public CE_TipoServicio NombreTipoServicio(int IdTipoServicio)
        {
            SqlDataAdapter da = new SqlDataAdapter("dbo.SP_P_TipoServicio", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@idTipoServicio", SqlDbType.Int).Value = IdTipoServicio;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            ce.Descripcion = Convert.ToString(row[0]);

            return ce;

        }

        #endregion

        #region Listar

        public List<string> ObtenerTipoServicio()
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "dbo.SP_P_CargarTipoServicio",
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = com.ExecuteReader();
            List<string> lista = new List<string>();
            while (reader.Read())
            {
                lista.Add(Convert.ToString(reader["descripcion"]));
            }
            con.CerrarConexion();

            return lista;
        }

        #endregion

    }
}