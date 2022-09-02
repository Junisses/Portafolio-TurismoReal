using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidad.Clases
{
    public class CE_IdentificacionFK
    {
        private int _IdIdentificacion;
        private string _Formato;

        public int IdIdentificacion { get => _IdIdentificacion; set => _IdIdentificacion = value; }
        public string Formato { get => _Formato; set => _Formato = value; }
    }
}
