using CapaDeDatos.Clases;
using CapaDeEntidad.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio.Clases
{
    public class CN_Artefactos
    {
        CD_Artefactos CD_Artefactos = new CD_Artefactos();

        public int IdArtefacto(string Descripcion)
        {
            return CD_Artefactos.IdArtefacto(Descripcion);
        }

        public CE_Artefactos NombreArtefacto(int IdArtefacto)
        {
            return CD_Artefactos.NombreArtefacto(IdArtefacto);
        }

        public List<string> ListarArtefacto()
        {
            return CD_Artefactos.ObtenerArtefacto();
        }
    }
}
