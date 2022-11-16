using System;
using System.Collections.Generic;
using System.Data;

namespace Entidades.Usuarios
{
    public class ClsUsuario
    {
        #region Atributos privados

        private int _idUsuario;
        private string _nombres;
        private string _apellidos;
        private string _rut;
        private string _pasaporte;
        private string _correo;
        private string _contrasena;
        private string _celular;
        private string _pais;
        private string _codigoVerificacion;
        private bool _habilitada;
        private List<ClsTipoUsuario> _idTipoUsuario;

        //atributos de manejo de base de datos
        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;

        #endregion

        #region Atributos públicos
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string Nombres { get => _nombres; set => _nombres = value; }
        public string Apellidos { get => _apellidos; set => _apellidos = value; }
        public string Rut { get => _rut; set => _rut = value; }
        public string Pasaporte { get => _pasaporte; set => _pasaporte = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Contrasena { get => _contrasena; set => _contrasena = value; }
        public string Celular { get => _celular; set => _celular = value; }
        public string Pais { get => _pais; set => _pais = value; }
        public string CodigoVerificacion { get => _codigoVerificacion; set => _codigoVerificacion = value; }
        public bool Habilitada { get => _habilitada; set => _habilitada = value; }
        public List<ClsTipoUsuario> IdTipoUsuario { get => _idTipoUsuario; set => _idTipoUsuario = value; }

        //atributos de manejo de base de datos
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }

        #endregion
    }
}
