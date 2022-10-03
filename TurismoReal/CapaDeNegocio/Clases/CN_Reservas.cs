using CapaDeDatos.Clases;
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
    }
}