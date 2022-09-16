using CapaDeNegocio.Clases;
using System;
using System.Collections.Generic;
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
        readonly CN_TipoUsuarioFK objeto_CN_TipoUsuarioFK = new CN_TipoUsuarioFK();

        #region INICIAL
        public Usuarios()
        {
            InitializeComponent();
            CargarDatos();
            CargarCB();
        }
        #endregion

        #region Cargar FK
        void CargarCB()
        {
            List<string> tipousuario = objeto_CN_TipoUsuarioFK.ListarTiposUsuario();
            for (int i = 0; i < tipousuario.Count; i++)
            {
                cbFiltroTipo.Items.Add(tipousuario[i]);
            }
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
            ventana.BtnCrear.Visibility = Visibility.Visible;
            ventana.ChangePassword.Visibility = Visibility.Hidden;
            ventana.tbContrasena.Visibility = Visibility.Visible;
            ventana.txtContra.Visibility = Visibility.Visible;
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
            ventana.Titulo.Text = "Consultar Usuario";
            ventana.tbNombre.IsEnabled = false;
            ventana.tbApellido.IsEnabled = false;
            ventana.tbCel.IsEnabled = false;
            ventana.tbPais.IsEnabled = false;
            ventana.tbCorreo.IsEnabled = false;
            ventana.tbRut.IsEnabled = false;
            ventana.tbUser.IsEnabled = false;
            ventana.tbContrasena.IsEnabled = false;
            ventana.cbTipoUsuario.IsEnabled = false;
            ventana.ChangePassword.Visibility = Visibility.Hidden;
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
            ventana.Titulo.Text = "Información del Usuario";
            ventana.tbNombre.IsEnabled = true;
            ventana.tbApellido.IsEnabled = true;
            ventana.tbCel.IsEnabled = true;
            ventana.tbPais.IsEnabled = true;
            ventana.tbCorreo.IsEnabled = true;
            ventana.tbRut.IsEnabled = true;
            ventana.tbUser.IsEnabled = true;
            ventana.tbContrasena.IsEnabled = true;
            ventana.cbTipoUsuario.IsEnabled = true;
            ventana.BtnActualizar.Visibility = Visibility.Visible;
            ventana.ChangePassword.Visibility = Visibility.Visible;
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
            ventana.Titulo.Text = "Eliminar Usuario";
            ventana.tbNombre.IsEnabled = false;
            ventana.tbApellido.IsEnabled = false;
            ventana.tbCel.IsEnabled = false;
            ventana.tbPais.IsEnabled = false;
            ventana.tbCorreo.IsEnabled = false;
            ventana.tbRut.IsEnabled = false;
            ventana.tbUser.IsEnabled = false;
            ventana.tbContrasena.IsEnabled = false;
            ventana.cbTipoUsuario.IsEnabled = false;
            //ventana.BtnEliminar.Visibility = Visibility.Visible;
            ventana.ChangePassword.Visibility = Visibility.Hidden;
        }

        #endregion

        #region FUNCION BUSCAR
        public void Buscar(string buscar)
        {
            GridDatos.ItemsSource = objeto_CN_Usuarios.Buscar(buscar).DefaultView;
        }

        private void Buscando(object sender, TextChangedEventArgs e)
        {
            Buscar(tbBuscar.Text);
        }
        #endregion

        #region FUNCION FILTRAR
        public void Filtro(string filtro)
        {
            GridDatos.ItemsSource = objeto_CN_Usuarios.Filtro(filtro).DefaultView;
        }

        private void Filtrando(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbFiltroTipo.SelectedValue != null)
                    Filtro(cbFiltroTipo.Text);
            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudo cargar el dgv: " + error.Message);
            }
        }

        #endregion
    }
}
