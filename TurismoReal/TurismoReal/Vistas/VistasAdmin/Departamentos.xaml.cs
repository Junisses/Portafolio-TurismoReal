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
    /// Lógica de interacción para Departamentos.xaml
    /// </summary>
    public partial class Departamentos : UserControl
    {
        readonly CN_Departamentos objeto_CN_Departamentos= new CN_Departamentos();
        readonly CN_EstadoDepto objeto_CN_EstadoDepto = new CN_EstadoDepto();
        readonly CN_Region objeto_CN_Region = new CN_Region();
        readonly CN_Comuna objeto_CN_Comuna = new CN_Comuna();

        #region INICIAL
        public Departamentos()
        {
            InitializeComponent();
            CargarDatos();
        }
        #endregion

        #region CARGAR Departamentos
        void CargarDatos()
        {
            GridDatos.ItemsSource = objeto_CN_Departamentos.CargarDeptos().DefaultView;
        }
        #endregion

        #region AGREGAR
        private void BtnAgregarDepto_Click(object sender, RoutedEventArgs e)
        {
            CRUDdepartamentos ventana = new CRUDdepartamentos();
            FrameDepartamentos.Content = ventana;
            ventana.BtnCrear.Visibility = Visibility.Visible;
        }
        #endregion

        #region CONSULTAR
        private void Consultar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDdepartamentos ventana = new CRUDdepartamentos();
            ventana.idDepartamento = id;
            ventana.Consultar();
            FrameDepartamentos.Content = ventana;
            ventana.Titulo.Text = "Consultar Departamento";
            ventana.tbNombreDepto.IsEnabled = false;
            ventana.cbRegion.IsEnabled = false;
            ventana.cbComuna.IsEnabled = false;
            ventana.tbDireccion.IsEnabled = false;
            ventana.tbCantHabitaciones.IsEnabled = false;
            ventana.tbCantBanos.IsEnabled = false;
            ventana.tbPrecio.IsEnabled = false;
            ventana.cbEstadoDepto.IsEnabled = false;
            ventana.cFechaEstado.IsEnabled = false;
            ventana.BtnGaleria.IsEnabled = false;
        }


        #endregion

        #region ACTUALIZAR
        private void Actualizar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDdepartamentos ventana = new CRUDdepartamentos();
            ventana.idDepartamento = id;
            ventana.Consultar();
            FrameDepartamentos.Content = ventana;
            ventana.Titulo.Text = "Información Depto.";
            ventana.tbNombreDepto.IsEnabled = true;
            ventana.cbRegion.IsEnabled = true;
            ventana.cbComuna.IsEnabled = true;
            ventana.tbDireccion.IsEnabled = true;
            ventana.tbCantHabitaciones.IsEnabled = true;
            ventana.tbCantBanos.IsEnabled = true;
            ventana.tbPrecio.IsEnabled = true;
            ventana.cbEstadoDepto.IsEnabled = true;
            ventana.cFechaEstado.IsEnabled = true;
            ventana.BtnGaleria.IsEnabled = true;
            ventana.BtnActualizar.Visibility = Visibility.Visible;
        }
        #endregion

        #region ELIMINAR
        private void Eliminar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDdepartamentos ventana = new CRUDdepartamentos();
            ventana.idDepartamento = id;
            ventana.Consultar();
            FrameDepartamentos.Content = ventana;
            ventana.Titulo.Text = "Eliminar Depto";
            ventana.tbNombreDepto.IsEnabled = false;
            ventana.cbRegion.IsEnabled = false;
            ventana.cbComuna.IsEnabled = false;
            ventana.tbDireccion.IsEnabled = false;
            ventana.tbCantHabitaciones.IsEnabled = false;
            ventana.tbCantBanos.IsEnabled = false;
            ventana.tbPrecio.IsEnabled = false;
            ventana.cbEstadoDepto.IsEnabled = false;
            ventana.cFechaEstado.IsEnabled = false;
            ventana.BtnGaleria.IsEnabled = false;
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

