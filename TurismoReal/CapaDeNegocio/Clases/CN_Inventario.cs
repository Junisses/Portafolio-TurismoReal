using CapaDeDatos.Clases;
using CapaDeEntidad.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio.Clases
{
    public class CN_Inventario
    {

        private readonly CD_Inventario objDatos = new CD_Inventario();

        #region Insertar   

        public void Insertar(CE_Inventario Inventario)
        {
            objDatos.CD_Insertar(Inventario);
        }

        #endregion

        #region Consultar
        public CE_Inventario Consulta(int idInventario)
        {
            return objDatos.CD_Consulta(idInventario);
        }
        #endregion

        #region Actualizar Datos   

        public void ActualizarDatos(CE_Inventario Inventario)
        {
            objDatos.CD_ActualizarDatos(Inventario);
        }

        #endregion

        #region Eliminar   

        public void Eliminar(CE_Inventario Inventario)
        {
            objDatos.CD_Eliminar(Inventario);
        }

        #endregion

        #region CARGAR ARTEFACTOS AL GRID

        public DataTable CargarInventario()
        {
            return objDatos.CargarInventario();
        }

        #endregion
    }
}
