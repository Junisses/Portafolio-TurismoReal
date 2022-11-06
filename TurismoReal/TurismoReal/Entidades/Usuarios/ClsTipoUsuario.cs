using System.Data;

namespace Entidades.Usuarios
{
    public class ClsTipoUsuario
    {
        #region Atributos privados

        private int _idTipoUsuario;
        private string _tipoUsuario;
        private ClsUsuario _usuarios;

        //atributos de manejo de base de datos
        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;
        #endregion

        #region Atributos públicos
        public int IdTipoUsuario { get => _idTipoUsuario; set => _idTipoUsuario = value; }
        public string TipoUsuario { get => _tipoUsuario; set => _tipoUsuario = value; }
        public ClsUsuario Usuarios { get => _usuarios; set => _usuarios = value; }

        //atributos de manejo de base de datos
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }

        #endregion
    }
}
