using CapaDeDatos.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio.Clases
{
    public class CN_Boletas
    {
        private readonly CD_Boletas objDatos = new CD_Boletas();

        #region CARGAR BOLETAS A LA VISTA

        public DataTable CargarBoletas()
        {
            return objDatos.CargarBoletas();
        }

        #endregion
    }
}
