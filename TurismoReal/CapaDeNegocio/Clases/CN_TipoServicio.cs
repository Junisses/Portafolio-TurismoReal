using CapaDeDatos.Clases;
using CapaDeEntidad.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio.Clases
{
    public class CN_TipoServicio
    {
        CD_TipoServicio CD_TipoServicio = new CD_TipoServicio();

        public int IdTipoServicio(string Descripcion)
        {
            return CD_TipoServicio.IdTipoServicio(Descripcion);
        }

        public CE_TipoServicio NombreTipoServicio(int IdTipoServicio)
        {
            return CD_TipoServicio.NombreTipoServicio(IdTipoServicio);
        }

        public List<string> ListarTipoServicio()
        {
            return CD_TipoServicio.ObtenerTipoServicio();
        }
    }
}