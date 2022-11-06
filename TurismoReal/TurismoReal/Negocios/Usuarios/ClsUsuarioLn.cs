using Datos.DataBase;
using Entidades.Usuarios;
using System;
using System.Data;
using System.Xml.Schema;

namespace Negocios.Usuarios
{
    public class ClsUsuarioLn
    {
        #region Variables privadas
        private ClsDataBase ObjDataBase = null;
        #endregion

        #region Metodo Index
        public void Index(ref ClsUsuario ObjUsuario)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Usuarios", 
                NombreSP    = "[SP_Usuarios_Index]",
                Scalar      = false
            };
            Ejecutar(ref ObjUsuario);
        }

        #endregion

        #region CRUD Usuario
        public void Create(ref ClsUsuario ObjUsuario)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Usuarios",
                NombreSP = "[SP_Usuarios_Create]",
                Scalar = true
            };

            ObjDataBase.DtParametros.Rows.Add(@"@Nombre","5",ObjUsuario.Nombres);
            ObjDataBase.DtParametros.Rows.Add(@"@Apellidos", "5", ObjUsuario.Apellidos);
            ObjDataBase.DtParametros.Rows.Add(@"@Rut", "5", ObjUsuario.Rut);
            ObjDataBase.DtParametros.Rows.Add(@"@Pasaporte", "5", ObjUsuario.Pasaporte);
            ObjDataBase.DtParametros.Rows.Add(@"@Correo", "5", ObjUsuario.Correo);
            ObjDataBase.DtParametros.Rows.Add(@"@Contrasena", "5", ObjUsuario.Contrasena);
            ObjDataBase.DtParametros.Rows.Add(@"@Celular", "5", ObjUsuario.Celular);
            ObjDataBase.DtParametros.Rows.Add(@"@Pais", "5", ObjUsuario.Pais);
            ObjDataBase.DtParametros.Rows.Add(@"@CodigoVerificacion", "5", ObjUsuario.CodigoVerificacion);
            ObjDataBase.DtParametros.Rows.Add(@"@Habilitada", "1", ObjUsuario.Habilitada);
            //Nose si esta bien asi la llave foranea, hay que buscar bien eso
            ObjDataBase.DtParametros.Rows.Add(@"@IdTipoUsuario", "2", ObjUsuario.IdTipoUsuario);

            Ejecutar(ref ObjUsuario);
        }
        public void Read(ref ClsUsuario ObjUsuario)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Usuarios",
                NombreSP = "[SP_Usuarios_Read]",
                Scalar = false
            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdUsuario", "2", ObjUsuario.IdUsuario);

            Ejecutar(ref ObjUsuario);
        }
        public void Update(ref ClsUsuario ObjUsuario)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Usuarios",
                NombreSP = "[SP_Usuarios_Update]",
                Scalar = true
            };

            ObjDataBase.DtParametros.Rows.Add(@"@IdUsuario", "2", ObjUsuario.IdUsuario);
            ObjDataBase.DtParametros.Rows.Add(@"@Nombre", "5", ObjUsuario.Nombres);
            ObjDataBase.DtParametros.Rows.Add(@"@Apellidos", "5", ObjUsuario.Apellidos);
            ObjDataBase.DtParametros.Rows.Add(@"@Rut", "5", ObjUsuario.Rut);
            ObjDataBase.DtParametros.Rows.Add(@"@Pasaporte", "5", ObjUsuario.Pasaporte);
            ObjDataBase.DtParametros.Rows.Add(@"@Correo", "5", ObjUsuario.Correo);
            ObjDataBase.DtParametros.Rows.Add(@"@Contrasena", "5", ObjUsuario.Contrasena);
            ObjDataBase.DtParametros.Rows.Add(@"@Celular", "5", ObjUsuario.Celular);
            ObjDataBase.DtParametros.Rows.Add(@"@Pais", "5", ObjUsuario.Pais);
            ObjDataBase.DtParametros.Rows.Add(@"@CodigoVerificacion", "5", ObjUsuario.CodigoVerificacion);
            ObjDataBase.DtParametros.Rows.Add(@"@Habilitada", "1", ObjUsuario.Habilitada);
            //Nose si esta bien asi la llave foranea, hay que buscar bien eso
            ObjDataBase.DtParametros.Rows.Add(@"@IdTipoUsuario", "2", ObjUsuario.IdTipoUsuario);

            Ejecutar(ref ObjUsuario);
        }
        public void Delete(ref ClsUsuario ObjUsuario)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "Usuarios",
                NombreSP = "[SP_Usuarios_Delete]",
                Scalar = true
            };

            ObjDataBase.DtParametros.Rows.Add(@"@IdUsuario", "2", ObjUsuario.IdUsuario);
            Ejecutar(ref ObjUsuario);
        }
        #endregion

        #region Metodos privados
        private void Ejecutar(ref ClsUsuario ObjUsuario)
        {
            ObjDataBase.CRUD(ref ObjDataBase);
            if (ObjDataBase.MensajeErrorDB == null)
            {
                if (ObjDataBase.Scalar)
                {
                    ObjUsuario.ValorScalar = ObjDataBase.ValorScalar;
                }
                else
                {
                    ObjUsuario.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    if (ObjUsuario.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in ObjUsuario.DtResultados.Rows)
                        {
                            ObjUsuario.IdUsuario = Convert.ToInt32(item["IdUsuario"].ToString());
                            ObjUsuario.Nombres = item["Nombres"].ToString();
                            ObjUsuario.Apellidos = item["Apellidos"].ToString();
                            ObjUsuario.Rut = item["Rut"].ToString();
                            ObjUsuario.Pasaporte = item["Pasaporte"].ToString();
                            ObjUsuario.Correo = item["Correo"].ToString();
                            ObjUsuario.Contrasena = item["Contrasena"].ToString();
                            ObjUsuario.Celular = item["Celular"].ToString();
                            ObjUsuario.CodigoVerificacion = item["CodigoVerificacion"].ToString();
                            ObjUsuario.Correo = item["Correo"].ToString();
                            ObjUsuario.Contrasena = item["Contrasena"].ToString();
                            ObjUsuario.Habilitada = Convert.ToBoolean(item["Habilitada"].ToString());
                            //nose como llamar la llave foranea de idtipousuario:(
                            //ObjUsuario.IdTipoUsuario = item["IdTipoUsuario"].ToString();
                        }
                    }
                }
            }
            else
            {
                ObjUsuario.MensajeError = ObjDataBase.MensajeErrorDB;
            }
        }

        #endregion

    }
}
