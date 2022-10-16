using CapaDeEntidad.Clases;
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
using TurismoReal.Vistas.VistasAdmin;

namespace TurismoReal.Vistas.VistasFuncionario
{
    /// <summary>
    /// Lógica de interacción para CheckInOut.xaml
    /// </summary>
    public partial class CheckInOut : UserControl
    {
        readonly CN_Reservas objeto_CN_Reservas = new CN_Reservas();
        readonly CE_Reservas objeto_CE_Reservas = new CE_Reservas();

        readonly CN_Boletas objeto_CN_Boletas = new CN_Boletas();
        readonly CN_Departamentos objeto_CN_Departamentos = new CN_Departamentos();
        readonly CN_Usuarios objeto_CN_Usuarios = new CN_Usuarios();

        public CheckInOut()
        {
            InitializeComponent();
            CargarDatos();
        }

        #region CARGAR RESERVAS
        void CargarDatos()
        {
            GridDatos.ItemsSource = objeto_CN_Reservas.CargarReservas().DefaultView;
        }
        #endregion

        private void IN_click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDin ventana = new CRUDin();
            ventana.idReserva = id;
            ventana.Consultar();
            var a = objeto_CN_Reservas.Consulta(id);
            FrameCheckINOUT.Content = ventana;
            ventana.Titulo.Text = "CHECK IN Reserva N°" + id;
            ventana.idDepartamento = a.IdDepartamento;
            
        }

        private void ContratarServicio(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            ListadoServicios ventana = new ListadoServicios();
            FrameCheckINOUT.Content = ventana;

            ventana.idReserva = id;
            var a = objeto_CN_Reservas.Consulta(id);
            ventana.idUsuario = a.IdUsuario;
            //ventana.tbCliente.Text = u.Nombres.ToString() + " " + u.Apellidos.ToString();
            //ventana.tbRut.Text = u.Identificacion.ToString();
            //ventana.tbDescripcion.IsEnabled = true;
            //ventana.cFechaPago.IsEnabled = false;
            //ventana.cFechaPago.Text = b.Fecha.ToString();
            //ventana.Titulo.Text = "Pago de servicio Reserva #" + id;
        }

        private void OUT_click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDout ventana = new CRUDout();
            ventana.idReserva = id;
            ventana.Consultar();
            FrameCheckINOUT.Content = ventana;
            ventana.Titulo.Text = "CHECK OUT Reserva N°" + id;
        }

        #region Limpiar
        public void LimpiarData()
        {
            tbBuscar.Clear();
            tbRut.Clear();
        }

        #endregion
        private void Ver(object sender, RoutedEventArgs e)
        {
            if (tbBuscar.Text != "")
            {
                GridDatos.ItemsSource = objeto_CN_Reservas.BuscarN(tbBuscar.Text).DefaultView;
            }
            else if (tbRut.Text != "")
            {
                GridDatos.ItemsSource = objeto_CN_Reservas.BuscarR(tbRut.Text).DefaultView;
            }
            LimpiarData();
        }
    }
}