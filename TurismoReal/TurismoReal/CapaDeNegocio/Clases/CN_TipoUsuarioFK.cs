using CapaDeDatos.Clases;
using CapaDeEntidad.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio.Clases
{
    public class CN_TipoUsuarioFK
    {
        CD_TipoUsuarioFK CD_TipoUsuarioFK = new CD_TipoUsuarioFK();

        public int idTipoUsuario(string tipoUsuario)
        {
            return CD_TipoUsuarioFK.idTipoUsuario(tipoUsuario);
        }

        public CE_TipoUsuarioFK nombreTipoUsuario(int idTipoUsuario)
        {
            return CD_TipoUsuarioFK.nombreTipoUsuario(idTipoUsuario);
        }

        public List<string> ListarTiposUsuario()
        {
            return CD_TipoUsuarioFK.ObtenerTiposUsuario();
        }
    }
}
