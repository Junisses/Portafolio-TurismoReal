using CapaDeEntidad.Clases;
using CapaDeNegocio.Clases;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
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

        public CRUDin()
        {
            InitializeComponent();
        }
        public int idReserva;

        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new CheckInOut();
        }

        #region ValidarCamposVacios
        public bool CamposLlenos()
        {
            if (cFechaIngreso.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        #region Consultar
        public void Consultar()
        {
            var a = objeto_CN_Reservas.Consulta(idReserva);
            var u = objeto_CN_Usuarios.Consulta(a.IdUsuario);

            tbCliente.Text = u.Nombres.ToString()+ " " + u.Apellidos.ToString();
            tbRut.Text = u.Identificacion.ToString();
            cFechaDesde.Text = a.FechaDesde.ToString();
            cFechaHasta.Text = a.FechaHasta.ToString();
            cbEstadoReserva.Text = a.EstadoRerserva.ToString();
            tbPrecioNoche.Text = a.PrecioNocheReserva.ToString();
            tbSaldo.Text = a.Saldo.ToString();

        }
        #endregion

        private void Crear(object sender, RoutedEventArgs e)
        {
            if (CamposLlenos() == true)
            {
                objeto_CE_Reservas.CheckIN = DateTime.Parse(cFechaIngreso.Text);

                objeto_CN_Reservas.ActualizarDatos(objeto_CE_Reservas);
                MessageBox.Show("Se ingreso exitosamente!!");
                BtnCrear.IsEnabled = false;
                cFechaIngreso.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("La fecha de ingreso esta vacía");
            }
        }

    }
}
