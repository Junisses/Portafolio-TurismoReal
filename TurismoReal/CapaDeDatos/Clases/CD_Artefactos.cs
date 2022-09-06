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
    public class CD_Artefactos
    {
        readonly CD_Conexion con = new CD_Conexion();
        readonly CE_Artefactos ce = new CE_Artefactos();

        #region IdArtefacto
        public int IdArtefacto(string Descripcion)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "dbo.SP_P_IdArtefacto",
                CommandType = CommandType.StoredProcedure,
            };

            com.Parameters.AddWithValue("@descripcion", Descripcion);
            object resultado = com.ExecuteScalar();
            int idartefacto = (int)resultado;
            con.CerrarConexion();

            return idartefacto;
        }

        #endregion
        #region nombre formato

        public CE_Artefactos NombreArtefacto(int IdArtefacto)
        {
            SqlDataAdapter da = new SqlDataAdapter("dbo.SP_P_Artefacto", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@idArtefacto", SqlDbType.Int).Value = IdArtefacto;
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

        public List<string> ObtenerArtefacto()
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "dbo.SP_P_CargarArtefacto",
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