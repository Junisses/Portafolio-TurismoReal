using CapaDeDatos.Clases;
using CapaDeEntidad.Clases;
using System.Data;

namespace CapaDeNegocio.Clases
{
    public class CN_Usuarios
    {
        private readonly CD_Usuarios objDatos = new CD_Usuarios();
        
        #region Consultar
        public CE_Usuarios Consulta(int idUsuario)
        {
            return objDatos.CD_Consulta(idUsuario);
        }
        #endregion

        #region Insertar   

        public void Insertar(CE_Usuarios Usuarios)
        {
            objDatos.CD_Insertar(Usuarios);
        }

        #endregion

        #region Eliminar   

        public void Eliminar(CE_Usuarios Usuarios)
        {
            objDatos.CD_Eliminar(Usuarios);
        }

        #endregion

        #region Actualizar Datos   

        public void ActualizarDatos(CE_Usuarios Usuarios)
        {
            objDatos.CD_ActualizarDatos(Usuarios);
        }

        #endregion

        #region Actualizar Pass   

        public void ActualizarPass(CE_Usuarios Usuarios)
        {
            objDatos.CD_ActualizarPass(Usuarios);
        }

        #endregion

        #region CARGAR USUARIOS A LA VISTA

        public DataTable CargarUsuarios()
        {
            return objDatos.CargarUsuarios();
        }

        #endregion
    }
}
