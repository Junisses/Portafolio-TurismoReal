using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidad.Clases
{
    public class CE_TipoUsuarioFK
    {
        private int _idTipoUsuario;
        private string _tipoUsuario;

        public int IdTipoUsuario { get => _idTipoUsuario; set => _idTipoUsuario = value; }
        public string TipoUsuario { get => _tipoUsuario; set => _tipoUsuario = value; }
    }
}
