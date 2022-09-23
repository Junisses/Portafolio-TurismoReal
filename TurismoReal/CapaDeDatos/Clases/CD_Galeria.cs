using CapaDeEntidad.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Clases
{
    public class CD_Galeria
    {
        private readonly CD_Conexion con = new CD_Conexion();
        private readonly CE_Galeria ce = new CE_Galeria();

        //CRUD Usuarios
        #region Insertar
        public void CD_Inserta(CE_Galeria Galeria)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "dbo.SP_G_Insertar",
                CommandType = CommandType.StoredProcedure,
            };
            com.Parameters.AddWithValue("@imagen", Galeria.Imagen);
            com.Parameters.AddWithValue("@idDepartamento", Galeria.IdDepartamento);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }
        #endregion

        #region Consultar

        public CE_Galeria CD_Consultar(int IdDepartamento)
        {
            SqlDataAdapter da = new SqlDataAdapter("dbo.SP_G_Consultar", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@idDepartamento", SqlDbType.Int).Value = IdDepartamento;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            ce.Imagen = (byte[])row[1];
            ce.IdDepartamento = Convert.ToInt32(row[2]);

            return ce;
        }

        #endregion

        #region Eliminar
        public void CD_Eliminar(CE_Galeria Galeria)
        {
            SqlCommand com = new SqlCommand();
            com.Connection = con.AbrirConexion();
            com.CommandText = "dbo.SP_G_Eliminar";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@idGaleria", Galeria.IdGaleria);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }

        #endregion

        #region Actualizar Imagen

        public void CD_ActualizarIMG(CE_Galeria Galeria)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "dbo.SP_G_Actualizar",
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@idGaleria", Galeria.IdGaleria);
            com.Parameters.AddWithValue("@imagen", Galeria.Imagen);

            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }

        #endregion

        #region CARGAR USUARIOS A LA VISTA

        public DataTable CargarUsuarios()
        {
            SqlDataAdapter da = new SqlDataAdapter("dbo.SP_U_CargarUsuarios", con.AbrirConexion());
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

