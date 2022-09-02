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

        public int IdIdentificacion(string Formato)
        {
            return CD_IdentificacionFK.IdIdentificacion(Formato);
        }

        public CE_IdentificacionFK NombreFormato(int IdIdentificacion)
        {
            return CD_IdentificacionFK.NombreFormato(IdIdentificacion);
        }

        public List<string> ListarFormato()
        {
            return CD_IdentificacionFK.ObtenerFormato();
        }
    }
}
