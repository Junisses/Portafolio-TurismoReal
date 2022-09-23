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
    public class CN_Galeria
    {
        private readonly CD_Galeria objDatos = new CD_Galeria();

        #region Consultar
        public CE_Galeria Consulta(int idGaleria)
        {
            return objDatos.CD_Consultar(idGaleria);
        }
        #endregion

        #region Insertar   

        public void Insertar(CE_Galeria Galeria)
        {
            objDatos.CD_Inserta(Galeria);
        }

        #endregion

        #region Eliminar   

        public void Eliminar(CE_Galeria Galeria)
        {
            objDatos.CD_Eliminar(Galeria);
        }

        #endregion

        #region Actualizar Datos   

        public void ActualizarIMG(CE_Galeria Galeria)
        {
            objDatos.CD_ActualizarIMG(Galeria);
        }

        #endregion

        
        #region CARGAR USUARIOS A LA VISTA

        public DataTable CargarImagen()
        {
            return objDatos.CargarImagen();
        }

        #endregion

        


    }
}
