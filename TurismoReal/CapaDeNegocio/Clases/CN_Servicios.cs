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
    public class CN_Servicios
    {
        private readonly CD_Servicios objDatos = new CD_Servicios();

        #region Consultar
        public CE_Servicios Consulta(int idServicio)
        {
            return objDatos.CD_Consulta(idServicio);
        }
        #endregion

        #region Insertar   

        public void Insertar(CE_Servicios Servicios)
        {
            objDatos.CD_Insertar(Servicios);
        }

        #endregion

        #region Eliminar   

        public void Eliminar(CE_Servicios Servicios)
        {
            objDatos.CD_Eliminar(Servicios);
        }

        #endregion

        #region Actualizar Datos   

        public void ActualizarDatos(CE_Servicios Servicios)
        {
            objDatos.CD_ActualizarDatos(Servicios);
        }

        #endregion

        #region CARGAR DEPTOS A LA VISTA

        public DataTable CargarServicio()
        {
            return objDatos.CargarServicio();
        }

        #endregion

        #region BUSCAR USUARIOS

        public DataTable Buscar(string buscar)
        {
            return objDatos.Buscar(buscar);
        }

        #endregion

        #region FILTRAR TIPO DE  USUARIOS

        public DataTable Filtro(string filtro)
        {
            return objDatos.Filtro(filtro);
        }

        #endregion

    }
}
