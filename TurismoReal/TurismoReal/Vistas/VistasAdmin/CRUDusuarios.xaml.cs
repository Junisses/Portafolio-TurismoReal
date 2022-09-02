using CapaDeEntidad.Clases;
using CapaDeNegocio.Clases;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace TurismoReal.Vistas.VistasAdmin
{
    
    public partial class CRUDusuarios : Page
    {
        readonly CN_Usuarios objeto_CN_Usuarios = new CN_Usuarios();
        readonly CE_Usuarios objeto_CE_Usuarios = new CE_Usuarios();
        readonly CN_TipoUsuarioFK objeto_CN_TipoUsuarioFK = new CN_TipoUsuarioFK();
        readonly CN_IdentificacionFK objeto_CN_IdentificacionFK= new CN_IdentificacionFK();

        #region Inicial
        public CRUDusuarios()
        {
            InitializeComponent();
            CargarCB();
        }
        #endregion

        #region Regresar
        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Usuarios();
        }
        #endregion

        #region Cargar FK
        void CargarCB()
        {
            List<string> tipousuario = objeto_CN_TipoUsuarioFK.ListarTiposUsuario();
            for(int i=0; i < tipousuario.Count; i++)
            {
                cbTipoUsuario.Items.Add(tipousuario[i]);
            }

            List<string> forma = objeto_CN_IdentificacionFK.ListarFormato();
            for (int i = 0; i < forma.Count; i++)
            {
                cbIdentificacion.Items.Add(forma[i]);
            }
        }
        #endregion

        #region ValidarCamposVacios

        public bool CamposLlenos()
        {
            if (tbNombre.Text == ""
                || tbApellido.Text == ""
                //RbHabilitar es un radio button como bit!!
                || tbCel.Text == ""
                || tbCorreo.Text == ""
                || tbPais.Text == ""
                || tbRut.Text == ""
                || tbContrasena.Text == ""
                || tbUser.Text == ""
                || cbIdentificacion.Text == ""
                || cbTipoUsuario.Text == "")
            {
               return false;
            }
            else 
            { 
                return true;
            }
        }

        #endregion

        #region CRUD
        public int idUsuario;
        public string Patron = "Portafolio";

        #region CREAR
        private void Crear(object sender, RoutedEventArgs e)
        {
            if(CamposLlenos() == true && tbContrasena.Text != "")
            {
                
                int tipousuario = objeto_CN_TipoUsuarioFK.idTipoUsuario(cbTipoUsuario.Text);
                int forma = objeto_CN_IdentificacionFK.idIdentificacion(cbIdentificacion.Text);

                objeto_CE_Usuarios.Nombres = tbNombre.Text;
                objeto_CE_Usuarios.Apellidos = tbApellido.Text;
                objeto_CE_Usuarios.Usuario = tbUser.Text;
                objeto_CE_Usuarios.Correo = tbCorreo.Text;
                objeto_CE_Usuarios.Contrasena = tbContrasena.Text;
                objeto_CE_Usuarios.Patron = Patron;
                objeto_CE_Usuarios.Identificacion = tbRut.Text;
                objeto_CE_Usuarios.Celular = tbCel.Text;
                objeto_CE_Usuarios.Pais = tbPais.Text;
                objeto_CE_Usuarios.CodigoVerificacion = " ";
                objeto_CE_Usuarios.Habilitada = true;
                objeto_CE_Usuarios.IdTipoUsuario = tipousuario;
                objeto_CE_Usuarios.IdIdentificacion = forma;

                objeto_CN_Usuarios.Insertar(objeto_CE_Usuarios);

                Content = new Usuarios();

            }
            else
            {
                MessageBox.Show("No pueden quedar los campos vacios");
            }
        }
        #endregion
        #region READ
        public void Consultar()
        {
            var a = objeto_CN_Usuarios.Consulta(idUsuario);
            tbNombre.Text = a.Nombres.ToString();
            tbApellido.Text = a.Apellidos.ToString();
            tbUser.Text = a.Usuario.ToString();
            tbCorreo.Text = a.Correo.ToString();
            tbRut.Text = a.Identificacion.ToString();
            tbCel.Text = a.Celular.ToString(); 
            tbPais.Text = a.Pais.ToString();

            var b = objeto_CN_TipoUsuarioFK.nombreTipoUsuario(a.IdTipoUsuario);
            cbTipoUsuario.Text = b.TipoUsuario;
            var c = objeto_CN_IdentificacionFK.nombreFormato(a.IdIdentificacion);
            cbIdentificacion.Text = c.Formato;
        }
        #endregion
        #region UPDATE
        private void Actualizar(object sender, RoutedEventArgs e)
        {
            if(CamposLlenos() == true)
            {
                //pendiente
                int tipousuario = objeto_CN_TipoUsuarioFK.idTipoUsuario(cbTipoUsuario.Text);
                int forma = objeto_CN_IdentificacionFK.idIdentificacion(cbIdentificacion.Text);

                objeto_CE_Usuarios.IdUsuario = idUsuario;
                objeto_CE_Usuarios.Nombres = tbNombre.Text;
                objeto_CE_Usuarios.Apellidos = tbApellido.Text;
                objeto_CE_Usuarios.Usuario = tbUser.Text;
                objeto_CE_Usuarios.Correo = tbCorreo.Text;
                objeto_CE_Usuarios.Contrasena = tbContrasena.Text;
                objeto_CE_Usuarios.Patron = Patron;
                objeto_CE_Usuarios.Identificacion = tbRut.Text;
                objeto_CE_Usuarios.Celular = tbCel.Text;
                objeto_CE_Usuarios.Pais = tbPais.Text;
                objeto_CE_Usuarios.CodigoVerificacion = " ";
                objeto_CE_Usuarios.Habilitada = true;
                objeto_CE_Usuarios.IdTipoUsuario = tipousuario;
                objeto_CE_Usuarios.IdIdentificacion = forma;

                objeto_CN_Usuarios.ActualizarDatos(objeto_CE_Usuarios);

                Content = new Usuarios();
            }
            else
            {
                MessageBox.Show("No llenos");
            }

            if(tbContrasena.Text != "")
            {
                objeto_CE_Usuarios.IdUsuario = idUsuario;
                objeto_CE_Usuarios.Contrasena = tbContrasena.Text;
                objeto_CE_Usuarios.Patron = Patron;

                objeto_CN_Usuarios.ActualizarPass(objeto_CE_Usuarios);
                Content = new Usuarios();
            }

        }
        #endregion
        #region DELETE
        private void Eliminar(object sender, RoutedEventArgs e)
        {
            objeto_CE_Usuarios.IdUsuario = idUsuario;

            objeto_CN_Usuarios.Eliminar(objeto_CE_Usuarios);

            Content = new Usuarios();
        }
        #endregion
        #endregion
    }
}
