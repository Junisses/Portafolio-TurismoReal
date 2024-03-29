﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDeDatos;
using CapaDeEntidad.Clases;

namespace CapaDeDatos.Clases
{
    public class CD_Usuarios
    {
        private readonly CD_Conexion con = new CD_Conexion();
        private CE_Usuarios ce = new CE_Usuarios();

        //CRUD Usuarios
        #region Insertar
        public void CD_Insertar(CE_Usuarios Usuarios)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "dbo.SP_U_Insertar",
                CommandType = CommandType.StoredProcedure,
            };
            com.Parameters.AddWithValue("@nombres", Usuarios.Nombres);
            com.Parameters.AddWithValue("@apellidos", Usuarios.Apellidos);
            com.Parameters.AddWithValue("@usuario", Usuarios.Usuario);
            com.Parameters.AddWithValue("@correo", Usuarios.Correo);
            com.Parameters.AddWithValue("@contrasena", Usuarios.Contrasena);
            com.Parameters.AddWithValue("@identificacion", Usuarios.Identificacion);
            com.Parameters.AddWithValue("@celular", Usuarios.Celular);
            com.Parameters.AddWithValue("@pais", Usuarios.Pais);
            com.Parameters.AddWithValue("@codigoVerificacion", Usuarios.CodigoVerificacion);
            com.Parameters.AddWithValue("@habilitada", Usuarios.Habilitada);
            com.Parameters.AddWithValue("@idTipoUsuario", Usuarios.IdTipoUsuario);
            com.Parameters.AddWithValue("@idIdentificacion", Usuarios.IdIdentificacion);
            com.Parameters.AddWithValue("@patron", Usuarios.Patron);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }
        #endregion

        #region Consultar

        public CE_Usuarios CD_Consulta(int idUsuario)
        {
            SqlDataAdapter da = new SqlDataAdapter("dbo.SP_U_Consultar", con.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            ce.Nombres = Convert.ToString(row[1]);
            ce.Apellidos = Convert.ToString(row[2]);
            ce.Usuario = Convert.ToString(row[3]);
            ce.Correo = Convert.ToString(row[4]);
            ce.Identificacion = Convert.ToString(row[6]);
            ce.Celular = Convert.ToString(row[7]);
            ce.Pais = Convert.ToString(row[8]);
            ce.CodigoVerificacion = Convert.ToString(row[9]);
            //AUN NO ESTA PROGRAMADO
            //ce.Habilitada = Convert.ToBoolean(row[10]);
            ce.IdTipoUsuario = Convert.ToInt32(row[11]);
            ce.IdIdentificacion = Convert.ToInt32(row[12]);

            return ce;
        }

        #endregion

        #region Eliminar
        public void CD_Eliminar(CE_Usuarios Usuarios)
        {
            SqlCommand com = new SqlCommand();
            com.Connection = con.AbrirConexion();
            com.CommandText = "dbo.SP_U_Eliminar";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@idUsuario", Usuarios.IdUsuario);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }

        #endregion

        #region Actualizar Datos

        public void CD_ActualizarDatos(CE_Usuarios Usuarios)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "dbo.SP_U_Actualizar",
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@idUsuario", Usuarios.IdUsuario);
            com.Parameters.AddWithValue("@nombres", Usuarios.Nombres);
            com.Parameters.AddWithValue("@apellidos", Usuarios.Apellidos);
            com.Parameters.AddWithValue("@usuario", Usuarios.Usuario);
            com.Parameters.AddWithValue("@correo", Usuarios.Correo);
            com.Parameters.AddWithValue("@identificacion", Usuarios.Identificacion);
            com.Parameters.AddWithValue("@celular", Usuarios.Celular);
            com.Parameters.AddWithValue("@pais", Usuarios.Pais);
            com.Parameters.AddWithValue("@codigoVerificacion", Usuarios.CodigoVerificacion);
            com.Parameters.AddWithValue("@habilitada", Usuarios.Habilitada);
            com.Parameters.AddWithValue("@idTipoUsuario", Usuarios.IdTipoUsuario);
            com.Parameters.AddWithValue("@idIdentificacion", Usuarios.IdIdentificacion);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.CerrarConexion();
        }

        #endregion

        #region Actualizar Contraseña

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
