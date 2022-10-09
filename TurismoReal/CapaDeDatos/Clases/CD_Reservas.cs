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


        #region Consultar

        public CE_Reservas CD_Consulta(int idReserva)
        {
            SqlDataAdapter da = new SqlDataAdapter("dbo.SP_R_Consultar", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@idReserva", SqlDbType.Int).Value = idReserva;


            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            ce.FechaDesde = Convert.ToDateTime(row[1]); 
            ce.FechaHasta = Convert.ToDateTime(row[2]);
            ce.EstadoRerserva = Convert.ToBoolean(row[3]);
            ce.Abono = Convert.ToInt32(row[4]);

            //if (!row.IsNull("checkIn"))
            //{
                ce.CheckIN = DateTime.Now;
            //}


            ce.PrecioNocheReserva = Convert.ToInt32(row[8]);
            ce.Saldo = Convert.ToInt32(row[9]);
            ce.IdUsuario = Convert.ToInt32(row[11]);

            return ce;
        }

        #endregion

        #region Actualizar Datos

        public void CD_ActualizarDatos(CE_Reservas Reservas)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "dbo.SP_R_IngresarIN",
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@idReserva", Reservas.IdReserva);
            com.Parameters.Add("@checkIn", SqlDbType.DateTime).Value = Reservas.CheckIN;

            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }

        #endregion
    }
}
