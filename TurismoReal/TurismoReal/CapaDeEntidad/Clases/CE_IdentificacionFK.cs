using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidad.Clases
{
    public class CE_IdentificacionFK
    {
        private int _idIdentificacion;
        private string _formato;

        public int IdIdentificacion { get => _idIdentificacion; set => _idIdentificacion = value; }
        public string Formato { get => _formato; set => _formato = value; }
    }
}
