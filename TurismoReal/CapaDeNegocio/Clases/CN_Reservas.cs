﻿using CapaDeDatos.Clases;
using CapaDeEntidad.Clases;
using System.Data;

namespace CapaDeNegocio.Clases
{
    public class CN_Reservas
    {
        private readonly CD_Reservas objDatos = new CD_Reservas();

        #region CARGAR BOLETAS A LA VISTA

        public DataTable CargarReservas()
        {
            return objDatos.CargarReservas();
        }

        #endregion

        #region Consultar
        public CE_Reservas Consulta(int idReserva)
        {
            return objDatos.CD_Consulta(idReserva);
        }
        #endregion

        #region Actualizar Datos   

        public void ActualizarDatos(CE_Reservas Reservas)
        {
            objDatos.CD_ActualizarDatos(Reservas);
        }

        #endregion
    }
}