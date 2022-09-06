using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidad.Clases
{
    public class CE_Artefactos
    {
        private int _IdArtefacto;
        private string _Descripcion;
        private int _Tamaño;
        private string _Color;
        private int _Valor;
        private int _Cantidad;

        public int IdArtefacto { get => _IdArtefacto; set => _IdArtefacto = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public int Tamaño { get => _Tamaño; set => _Tamaño = value; }
        public string Color { get => _Color; set => _Color = value; }
        public int Valor { get => _Valor; set => _Valor = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
    }
}
