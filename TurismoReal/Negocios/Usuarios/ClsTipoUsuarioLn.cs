using Datos.DataBase;
using Entidades.Usuarios;
using System.Data;
using System;

namespace Negocios.Usuarios
{
    public class ClsTipoUsuarioLn
    {
        #region Variables privadas
        private ClsDataBase ObjDataBase = null;
        #endregion

        #region Metodo Index
        public void Index(ref ClsTipoUsuario ObjTipoUsuario)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "TipoUsuarios",
                NombreSP = "[SP_TipoUsuarios_Index]",
                Scalar = false
            };
            Ejecutar(ref ObjTipoUsuario);
        }

        #endregion

        #region CRUD TipoUsuario
        public void Create(ref ClsTipoUsuario ObjTipoUsuario)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "TipoUsuarios",
                NombreSP = "[SP_TipoUsuarios_Create]",
                Scalar = true
            };

            ObjDataBase.DtParametros.Rows.Add(@"@tipoUsuario", "5", ObjTipoUsuario.TipoUsuario);

            Ejecutar(ref ObjTipoUsuario);
        }
        public void Read(ref ClsTipoUsuario ObjTipoUsuario)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "TipoUsuarios",
                NombreSP = "[SP_TipoUsuarios_Read]",
                Scalar = false
            };
            ObjDataBase.DtParametros.Rows.Add(@"@IdTipoUsuario", "2", ObjTipoUsuario.IdTipoUsuario);

            Ejecutar(ref ObjTipoUsuario);
        }
        public void Update(ref ClsTipoUsuario ObjTipoUsuario)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "TipoUsuarios_Update]",
                Scalar = true
            };

            ObjDataBase.DtParametros.Rows.Add(@"@IdTipoUsuario", "2", ObjTipoUsuario.IdTipoUsuario);
            ObjDataBase.DtParametros.Rows.Add(@"@TipoUsuario", "5", ObjTipoUsuario.TipoUsuario);

            Ejecutar(ref ObjTipoUsuario);
        }
        public void Delete(ref ClsTipoUsuario ObjTipoUsuario)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "TipoUsuarios",
                NombreSP = "[SP_TipoUsuarios_Delete]",
                Scalar = true
            };

            ObjDataBase.DtParametros.Rows.Add(@"@IdTipoUsuario", "2", ObjTipoUsuario.IdTipoUsuario);
            Ejecutar(ref ObjTipoUsuario);
        }
        #endregion

        #region Metodos privados
        private void Ejecutar(ref ClsTipoUsuario ObjTipoUsuario)
        {
            ObjDataBase.CRUD(ref ObjDataBase);
            if (ObjDataBase.MensajeErrorDB == null)
            {
                if (ObjDataBase.Scalar)
                {
                    ObjTipoUsuario.ValorScalar = ObjDataBase.ValorScalar;
                }
                else
                {
                    ObjTipoUsuario.DtResultados = ObjDataBase.DsResultados.Tables[0];
                    if (ObjTipoUsuario.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in ObjTipoUsuario.DtResultados.Rows)
                        {
                            ObjTipoUsuario.IdTipoUsuario = Convert.ToInt32(item["IdTipoUsuario"].ToString());
                            ObjTipoUsuario.TipoUsuario = item["TipoUsuario"].ToString();
                        }
                    }
                }
            }
            else
            {
                ObjTipoUsuario.MensajeError = ObjDataBase.MensajeErrorDB;
            }
        }

        #endregion

    }
}