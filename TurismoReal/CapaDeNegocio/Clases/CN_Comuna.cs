using CapaDeDatos.Clases;
using CapaDeEntidad.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio.Clases
{
    public class CN_Comuna
    {
        CD_Comuna CD_Comuna = new CD_Comuna();

        public int IdComuna(string Comuna)
        {
            return CD_Comuna.IdComuna(Comuna);
        }

        public CE_Comuna NombreComuna(int IdComuna)
        {
            return CD_Comuna.NombreComuna(IdComuna);
        }

        public List<string> ListarComuna()
        {
            return CD_Comuna.ObtenerComuna();
        }
    }
}
