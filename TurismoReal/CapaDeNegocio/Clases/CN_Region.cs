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
    public class CN_Region
    {
        CD_Region CD_Region = new CD_Region();

        public int IdRegion(string Region)
        {
            return CD_Region.IdRegion(Region);
        }

        public CE_Region NombreRegion(int IdRegion)
        {
            return CD_Region.NombreRegion(IdRegion);
        }

        public List<string> ListarRegion()
        {
            return CD_Region.ObtenerRegion();
        }

        //listar
        public DataTable listaRegiones()
        {
            return CD_Region.listaRegion();
        }


    }
}

