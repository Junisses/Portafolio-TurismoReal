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
    public class CD_Reservas
    {
        private readonly CD_Conexion con = new CD_Conexion();
        private CE_Reservas ce = new CE_Reservas();

        #region CARGAR RESERVAS A LA VISTA
        public DataTable CargarReservas()
        {
            SqlDataAdapter da = new SqlDataAdapter("dbo.SP_R_CargarReservas", con.AbrirConexion());
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
