using CapaDeEntidad.Clases;
using CapaDeNegocio.Clases;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using TurismoReal.Vistas.VistasAdmin;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TurismoReal.Vistas.VistasFuncionario
{
    /// <summary>
    /// Lógica de interacción para CRUDin.xaml
    /// </summary>
    public partial class CRUDin : Page
    {

        readonly CN_Reservas objeto_CN_Reservas = new CN_Reservas();
        readonly CE_Reservas objeto_CE_Reservas = new CE_Reservas();

        readonly CN_Usuarios objeto_CN_Usuarios = new CN_Usuarios();
        readonly CN_Boletas objeto_CN_Boletas = new CN_Boletas();

        public CRUDin()
        {
            InitializeComponent();
        }
        public int idReserva;

        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new CheckInOut();
        }

        #region Consultar
        public void Consultar()
        {
            var a = objeto_CN_Reservas.Consulta(idReserva);
            var u = objeto_CN_Usuarios.Consulta(a.IdUsuario);

            tbCliente.Text = u.Nombres.ToString() + " " + u.Apellidos.ToString();
            tbRut.Text = u.Identificacion.ToString();
            cFechaDesde.Text = a.FechaDesde.ToString();
            cFechaHasta.Text = a.FechaHasta.ToString();
            cbEstadoReserva.Text = a.EstadoRerserva.ToString();
            tbPrecioNoche.Text = a.PrecioNocheReserva.ToString();
            tbSaldo.Text = a.Saldo.ToString();


           cFechaIngreso.IsEnabled = false;
           cFechaIngreso.Text = a.CheckIN.ToString();


        }
        #endregion

        private void Crear(object sender, RoutedEventArgs e)
        {
            
            if (cFechaIngreso.Text != "")
            {
                objeto_CE_Reservas.IdReserva = idReserva;
                objeto_CE_Reservas.CheckIN = DateTime.Parse(cFechaIngreso.Text);

                objeto_CN_Reservas.ActualizarIN(objeto_CE_Reservas);
                MessageBox.Show("Se ingreso exitosamente!!");
                BtnCrear.IsEnabled = false;
                cFechaIngreso.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("La fecha de ingreso esta vacía");
            }
        }

        private void Pagar(object sender, RoutedEventArgs e)
        {
            Pagos ventana = new Pagos();
            FramePago.Content = ventana;
            ventana.idReserva = idReserva;
            var a = objeto_CN_Reservas.Consulta(idReserva);
            var u = objeto_CN_Usuarios.Consulta(a.IdUsuario);
            var b = objeto_CN_Boletas.Ver(idReserva);
            ventana.BtnGuardar.Visibility = Visibility.Visible;
            ventana.idUsuario = u.IdUsuario;
            ventana.tbCliente.Text = u.Nombres.ToString() + " " + u.Apellidos.ToString();
            ventana.tbRut.Text = u.Identificacion.ToString();
            ventana.tbDescripcion.IsEnabled = false;
            ventana.tbDescripcion.Text = "Pago saldo de reserva";
            ventana.cFechaPago.IsEnabled = false;
            ventana.cFechaPago.Text = b.Fecha.ToString();
            ventana.Titulo.Text = "Cobro de Saldo Reserva #" + idReserva;
        }
    }
}
