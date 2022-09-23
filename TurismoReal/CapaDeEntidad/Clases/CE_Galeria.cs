using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidad.Clases
{
    public class CE_Galeria
    {
        private int _IdGaleria;
        private byte[] _Imagen;
        private int _IdDepartamento;

        public int IdGaleria { get => _IdGaleria; set => _IdGaleria = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public int IdDepartamento { get => _IdDepartamento; set => _IdDepartamento = value; }
    }
}
