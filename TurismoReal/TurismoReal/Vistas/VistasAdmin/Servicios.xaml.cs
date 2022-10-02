using CapaDeNegocio.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TurismoReal.Vistas.VistasAdmin
{
    /// <summary>
    /// Lógica de interacción para Servicios.xaml
    /// </summary>
    public partial class Servicios : UserControl
    {
        readonly CN_Servicios objeto_CN_Servicios = new CN_Servicios();
        readonly CN_TipoServicio objeto_CN_TipoServicio = new CN_TipoServicio();

        public Servicios()
        {
            InitializeComponent();
            CargarDatos();
        }
        

        #region CARGAR Servicios
        void CargarDatos()
        {
            GridDatos.ItemsSource = objeto_CN_Servicios.CargarServicio().DefaultView;
        }
        #endregion

        #region AGREGAR
        private void BtnAgregarServicio_Click(object sender, RoutedEventArgs e)
        {
            CRUDservicios ventana = new CRUDservicios();
            FrameServicios.Content = ventana;
            ventana.BtnCrear.Visibility = Visibility.Visible;
        }
        #endregion

        #region CONSULTAR
        private void Consultar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDservicios ventana = new CRUDservicios();
            ventana.idServicio = id;
            ventana.Consultar();
            FrameServicios.Content = ventana;
            ventana.Titulo.Text = "Consultar Servicio";
            ventana.tbDescripcion.IsEnabled = false;
            ventana.tbPrecio.IsEnabled = false;
            ventana.ckbDisponible.IsEnabled = false;
            ventana.cbTipoServicio.IsEnabled = false;
        }


        #endregion

        #region ACTUALIZAR
        private void Actualizar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDservicios ventana = new CRUDservicios();
            ventana.idServicio = id;
            ventana.Consultar();
            FrameServicios.Content = ventana;
            ventana.Titulo.Text = "Actualizar Servicio";
            ventana.tbDescripcion.IsEnabled = true;
            ventana.tbPrecio.IsEnabled = true;
            ventana.ckbDisponible.IsEnabled = true;
            ventana.cbTipoServicio.IsEnabled = true;
            ventana.BtnActualizar.Visibility = Visibility.Visible;
        }
        #endregion

        #region ELIMINAR
        private void Eliminar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDservicios ventana = new CRUDservicios();
            ventana.idServicio = id;
            ventana.Consultar();
            FrameServicios.Content = ventana;
            ventana.Titulo.Text = "Eliminar Servicio";
            ventana.tbDescripcion.IsEnabled = false;
            ventana.tbPrecio.IsEnabled = false;
            ventana.ckbDisponible.IsEnabled = false;
            ventana.cbTipoServicio.IsEnabled = false;
            ventana.BtnEliminar.Visibility = Visibility.Visible;
        }

        #endregion

        #region FUNCION BUSCAR
        public void Buscar(string buscar)
        {
            //GridDatos.ItemsSource = objeto_CN_Usuarios.Buscar(buscar).DefaultView;

        }

        private void Buscando(object sender, TextChangedEventArgs e)
        {
            //Buscar(tbBuscar.Text);
        }
        #endregion

        #region FUNCION FILTRAR
        public void Filtro(string filtro)
        {
            //GridDatos.ItemsSource = objeto_CN_Usuarios.Filtro(filtro).DefaultView;

        }

        private void Filtrando(object sender, SelectionChangedEventArgs e)
        {
            //Filtro(cbFiltroTipo.Text);
        }
        #endregion
    }
}

