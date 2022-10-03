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
    public class CD_Boletas
    {
        private readonly CD_Conexion con = new CD_Conexion();
        private CE_Boletas ce = new CE_Boletas();

        #region CARGAR BOLETAS A LA VISTA
        public DataTable CargarBoletas()
        {
            SqlDataAdapter da = new SqlDataAdapter("dbo.SP_B_CargarBoletas", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            con.CerrarConexion();

            return dt;
        }

        #endregion 
    }
}
