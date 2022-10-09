using CapaDeEntidad.Clases;
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
    /// Lógica de interacción para Pagos.xaml
    /// </summary>
    public partial class Pagos : UserControl
    {
        readonly CN_Boletas objeto_CN_Boletas = new CN_Boletas();
        readonly CE_Boletas objeto_CE_Boletas = new CE_Boletas();
        public Pagos()
        {
            InitializeComponent();
        }

        #region CARGAR BOLETAS DEL CLIENTE
        void CargarDatos()
        {
            GridDatos.ItemsSource = objeto_CN_Boletas.CargarPorReserva(idReserva).DefaultView;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatos();
        }
        #endregion

        public int idReserva;
        public int idDetalleServicio = 0;
        public int idUsuario;

        #region ValidarCamposVacios
        public bool CamposLlenos()
        {
            if (tbMedioPago.Text == ""
                || tbBanco.Text == ""
                || tbMonto.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region REGRESAR
        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new CheckInOut();
        }
        #endregion


        private void Crear(object sender, RoutedEventArgs e)
        {
            if (tbMedioPago.Text == "")
            {
                MessageBox.Show("Porfavor ingrese medio de pago");
                tbMedioPago.Focus();
            }
            else if (tbBanco.Text == "")
            {
                MessageBox.Show("Porfavor ingrese banco");
                tbBanco.Focus();
            }
            else if (tbMonto.Text == "")
            {
                MessageBox.Show("Porfavor ingrese monto pagado");
                tbMonto.Focus();
            }
            else if (tbMonto.Text.Length != 4 && Regex.IsMatch(tbMonto.Text, @"^\d +$:") == false)
            {
                MessageBox.Show("Resvise el monto ingresado\nNo hay montos a pagar menores a mil!");
                return;
            }

            if (CamposLlenos() == true)
            {
                objeto_CE_Boletas.MedioDePago = tbMedioPago.Text;
                objeto_CE_Boletas.Fecha = DateTime.Now;
                objeto_CE_Boletas.Banco = tbBanco.Text;
                objeto_CE_Boletas.Monto = int.Parse(tbMonto.Text);
                objeto_CE_Boletas.Descripcion = tbDescripcion.Text;
                objeto_CE_Boletas.IdReserva = idReserva;
                objeto_CE_Boletas.IdDetalleServicio = idDetalleServicio;

                objeto_CN_Boletas.Insertar(objeto_CE_Boletas);
                MessageBox.Show("Se ingreso exitosamente!!");
                LimpiarData();
                CargarDatos();
            }
        }

        private void Consultar(object sender, RoutedEventArgs e)
        {

        }

        #region Limpiar Campos

        public void LimpiarData()
        {
            tbMedioPago.Clear();
            cbMedioPago.SelectedIndex = -1;
            cbBanco.SelectedIndex = -1;
            tbBanco.Clear();
            tbMonto.Clear();
            tbDescripcion.Clear();

            BtnGuardar.IsEnabled = true;
        }
        private void Limpiar(object sender, RoutedEventArgs e)
        {
            LimpiarData();
        }
        #endregion 
    }
}
