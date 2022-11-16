using CapaDeNegocio.Clases;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace TurismoReal.Vistas.VistasAdmin
{

    public partial class Usuarios : UserControl
    {
        readonly CN_Usuarios objeto_CN_Usuarios = new CN_Usuarios();

        #region INICIAL
        public Usuarios()
        {
            InitializeComponent();
            CargarDatos();

        }
        #endregion

        #region CARGAR USUARIOS
        void CargarDatos()
        {
            GridDatos.ItemsSource = objeto_CN_Usuarios.CargarUsuarios().DefaultView;
        }
        #endregion

        #region AGREGAR
        private void BtnAgregarUser_Click(object sender, RoutedEventArgs e)
        {
            CRUDusuarios ventana = new CRUDusuarios();
            FrameUsuarios.Content = ventana;
            Contenido.Visibility = Visibility.Hidden;
            ventana.BtnCrear.Visibility = Visibility.Visible;
        }
        #endregion

        #region CONSULTAR
        private void Consultar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDusuarios ventana = new CRUDusuarios();
            ventana.idUsuario = id;
            ventana.Consultar();
            FrameUsuarios.Content = ventana;
            Contenido.Visibility = Visibility.Hidden;
            ventana.Titulo.Text = "Consultar Usuario";
            ventana.tbNombre.IsEnabled = false;
            ventana.tbApellido.IsEnabled = false;
            ventana.tbCel.IsEnabled = false;
            ventana.tbPais.IsEnabled = false;
            ventana.tbCorreo.IsEnabled = false;
            ventana.tbRut.IsEnabled = false;
            ventana.tbUser.IsEnabled = false;
            ventana.tbContrasena.IsEnabled = false;
            ventana.cbIdentificacion.IsEnabled = false;
            ventana.cbTipoUsuario.IsEnabled = false;
        }
        #endregion

        #region ACTUALIZAR
        private void Actualizar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDusuarios ventana = new CRUDusuarios();
            ventana.idUsuario = id;
            ventana.Consultar();
            FrameUsuarios.Content = ventana;
            Contenido.Visibility = Visibility.Hidden;
            ventana.Titulo.Text = "Actualizar Información de Usuario";
            ventana.tbNombre.IsEnabled = true;
            ventana.tbApellido.IsEnabled = true;
            ventana.tbCel.IsEnabled = true;
            ventana.tbPais.IsEnabled = true;
            ventana.tbCorreo.IsEnabled = true;
            ventana.tbRut.IsEnabled = true;
            ventana.tbUser.IsEnabled = true;
            ventana.tbContrasena.IsEnabled = true;
            ventana.cbIdentificacion.IsEnabled = true;
            ventana.cbTipoUsuario.IsEnabled = true;
            ventana.BtnActualizar.Visibility = Visibility.Visible;
        }
        #endregion

        #region ELIMINAR
        private void Eliminar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDusuarios ventana = new CRUDusuarios();
            ventana.idUsuario = id;
            ventana.Consultar();
            FrameUsuarios.Content = ventana;
            Contenido.Visibility = Visibility.Hidden;
            ventana.Titulo.Text = "Eliminar Usuario";
            ventana.tbNombre.IsEnabled = false;
            ventana.tbApellido.IsEnabled = false;
            ventana.tbCel.IsEnabled = false;
            ventana.tbPais.IsEnabled = false;
            ventana.tbCorreo.IsEnabled = false;
            ventana.tbRut.IsEnabled = false;
            ventana.tbUser.IsEnabled = false;
            ventana.tbContrasena.IsEnabled = false;
            ventana.cbIdentificacion.IsEnabled = false;
            ventana.cbTipoUsuario.IsEnabled = false;
            ventana.BtnEliminar.Visibility = Visibility.Visible;
        }
        #endregion
    }
}
