using CapaDeNegocio.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace TurismoReal.Vistas.VistasFuncionario
{
    /// <summary>
    /// Lógica de interacción para ServiciosContratados.xaml
    /// </summary>
    public partial class ServiciosContratados : UserControl
    {
        readonly CN_Servicios objeto_CN_Servicios = new CN_Servicios();
        readonly CN_DetalleServicio objeto_CN_DetalleServicio = new CN_DetalleServicio();

        public ServiciosContratados()
        {
            InitializeComponent();
        }

        #region CARGAR Servicios contratados
        void CargarDatos()
        {
            GridDatos.ItemsSource = objeto_CN_DetalleServicio.VerServiciosContratados(idUsuario,idReserva).DefaultView;
        }
        #endregion
        public int idUsuario;
        public int idReserva;


        #region FUNCION BUSCAR
        #region Limpiar
        public void LimpiarData()
        {
            tbBuscar.Clear();
        }

        #endregion
        private void Ver(object sender, RoutedEventArgs e)
        {
            if (tbBuscar.Text != "")
            {
                if (tbBuscar.Text.Length > 25)
                {
                    MessageBox.Show("Por favor, no ingrese tantos caracteres", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Warning);
                    LimpiarData();
                    tbBuscar.Focus();
                    return;
                }
                else if (Regex.IsMatch(tbBuscar.Text, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ]+$") == false)
                {
                    MessageBox.Show("La búsqueda se realiza solo con letras", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Warning);
                    LimpiarData();
                    tbBuscar.Focus();
                    return;
                }
                else
                {
                    GridDatos.ItemsSource = objeto_CN_Servicios.BuscarServDispo(tbBuscar.Text).DefaultView;
                    LimpiarData();
                    if (GridDatos.Items.Count == 0)
                    {
                        MessageBox.Show("No se encontraron resultados", "INFORMACIÓN", MessageBoxButton.OK, MessageBoxImage.Information);
                        CargarDatos();
                    }
                }

            }

            else
            {
                MessageBox.Show("Ingrese una descripción para buscar", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatos();
        }
    }
}

