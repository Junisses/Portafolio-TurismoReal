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
    public class CD_IdentificacionFK
    {
        readonly CD_Conexion con = new CD_Conexion();
        readonly CE_IdentificacionFK ce = new CE_IdentificacionFK();

        #region IdIdentificacion
        public int idIdentificacion(string formato)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_P_IdIdent",
                CommandType = CommandType.StoredProcedure,
            };

            com.Parameters.AddWithValue("@formato", formato);
            object valor = com.ExecuteScalar();
            int ididentificacion = (int)valor;
            con.CerrarConexion();

            return ididentificacion;
        }

        #endregion
        #region nombre formato

        public CE_IdentificacionFK nombreFormato(int idIdentificacion)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_P_FormatoIdent", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@idIdentificacion", SqlDbType.Int).Value = idIdentificacion;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            ce.Formato = Convert.ToString(row[0]);

            return ce;

        }

        #endregion

        #region Listar

        public List<string> ObtenerFormato()
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "dbo.SP_P_CargarFormatoFK",
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = com.ExecuteReader();
            List<string> lista = new List<string>();
            while (reader.Read())
            {
                lista.Add(Convert.ToString(reader["formato"]));
            }
            con.CerrarConexion();

            return lista;
        }

        #endregion

    }
}