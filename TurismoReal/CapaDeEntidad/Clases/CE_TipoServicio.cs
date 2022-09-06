using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidad.Clases
{
    public class CE_TipoServicio
    {
        private int _IdTipoServicio;
        private string _Descripcion;

        public int IdTipoServicio { get => _IdTipoServicio; set => _IdTipoServicio = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
    }
}
