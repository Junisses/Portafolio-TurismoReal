using CapaDeDatos.Clases;
using CapaDeEntidad.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio.Clases
{
    public class CN_IdentificacionFK
    {
        CD_IdentificacionFK CD_IdentificacionFK = new CD_IdentificacionFK();

        public int idIdentificacion(string formato)
        {
            return CD_IdentificacionFK.idIdentificacion(formato);
        }

        public CE_IdentificacionFK nombreFormato(int idIdentificacion)
        {
            return CD_IdentificacionFK.nombreFormato(idIdentificacion);
        }

        public List<string> ListarFormato()
        {
            return CD_IdentificacionFK.ObtenerFormato();
        }
    }
}
