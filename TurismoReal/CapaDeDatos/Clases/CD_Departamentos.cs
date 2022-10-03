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
    public class CD_Departamentos
    {
        private readonly CD_Conexion con = new CD_Conexion();
        private CE_Departamentos ce = new CE_Departamentos();

        //CRUD Departamentos
        #region Insertar
        public void CD_Insertar(CE_Departamentos Departamentos)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "dbo.SP_D_Insertar",
                CommandType = CommandType.StoredProcedure,
            };
            com.Parameters.AddWithValue("@descripcion", Departamentos.Descripcion);
            com.Parameters.AddWithValue("@direccion", Departamentos.Direccion);
            com.Parameters.AddWithValue("@cantHabitaciones", Departamentos.CantHabitaciones);
            com.Parameters.AddWithValue("@cantBanos", Departamentos.CantBanos);
            com.Parameters.AddWithValue("@precioNoche", Departamentos.PrecioNoche);
            com.Parameters.Add("@fechaEstadoDepto", SqlDbType.Date).Value = Departamentos.FechaEstadoDepto;
            com.Parameters.AddWithValue("@idComuna", Departamentos.IdComuna);
            com.Parameters.AddWithValue("@idEstadoDepto", Departamentos.IdEstadoDepto);

            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }
        #endregion

        #region Consultar

        public CE_Departamentos CD_Consulta(int idDepartamento)
        {
            SqlDataAdapter da = new SqlDataAdapter("dbo.SP_D_Consultar", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@idDepartamento", SqlDbType.Int).Value = idDepartamento;

            
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            ce.Descripcion = Convert.ToString(row[1]);
            ce.Direccion = Convert.ToString(row[2]);
            ce.CantHabitaciones = Convert.ToInt32(row[3]);
            ce.CantBanos = Convert.ToInt32(row[4]);
            ce.PrecioNoche = Convert.ToInt32(row[5]);
            ce.FechaEstadoDepto = Convert.ToDateTime(row[6]);
            ce.IdComuna = Convert.ToInt32(row[7]);
            ce.IdEstadoDepto = Convert.ToInt32(row[8]);

            return ce;
        }

        #endregion

        #region Eliminar
        public void CD_Eliminar(CE_Departamentos Departamentos)
        {
            SqlCommand com = new SqlCommand();
            com.Connection = con.AbrirConexion();
            com.CommandText = "dbo.SP_D_Eliminar";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@idDepartamento", Departamentos.IdDepartamento);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }

        #endregion

        #region Actualizar Datos

        public void CD_ActualizarDatos(CE_Departamentos Departamentos)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "dbo.SP_D_Actualizar",
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@idDepartamento", Departamentos.IdDepartamento);
            com.Parameters.AddWithValue("@descripcion", Departamentos.Descripcion);
            com.Parameters.AddWithValue("@direccion", Departamentos.Direccion);
            com.Parameters.AddWithValue("@cantHabitaciones", Departamentos.CantHabitaciones);
            com.Parameters.AddWithValue("@cantBanos", Departamentos.CantBanos);
            com.Parameters.AddWithValue("@precioNoche", Departamentos.PrecioNoche); 
            com.Parameters.Add("@fechaEstadoDepto", SqlDbType.Date).Value = Departamentos.FechaEstadoDepto;
            com.Parameters.AddWithValue("@idComuna", Departamentos.IdComuna);
            com.Parameters.AddWithValue("@idEstadoDepto", Departamentos.IdEstadoDepto);

            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }

        #endregion

        #region ************************

        public void CD_ActualizarPass(CE_Usuarios Usuarios)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "dbo.SP_U_ActualizarPass",
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@idUsuario", Usuarios.IdUsuario);
            com.Parameters.AddWithValue("@contrasena", Usuarios.Contrasena);
            com.Parameters.AddWithValue("@patron", Usuarios.Patron);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }
        #endregion

        #region CARGAR DEPARTAMENTOS A LA VISTA

        public DataTable CargarDepartamentos()
        {
            SqlDataAdapter da = new SqlDataAdapter("dbo.SP_D_CargarDeptos", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            con.CerrarConexion();

            return dt;
        }

        #endregion

        #region BUSCAR DEPTO.

        public DataTable BuscarDepto(string buscarDepto)
        {
            SqlDataAdapter da = new SqlDataAdapter("dbo.SP_D_BuscarDepto", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@buscarDepto", SqlDbType.VarChar).Value = buscarDepto;
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
