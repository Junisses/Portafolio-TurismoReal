using CapaDeEntidad.Clases;
using CapaDeNegocio.Clases;
using Microsoft.Win32;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

using iTextSharp.text;
using iTextSharp.tool.xml;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Documents;
using System.Windows.Forms;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

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
        public int idUsuario;
        public int idServicio;

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

        #region CREAR
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
            else if (tbMonto.Text.Length != 4 && Regex.IsMatch(tbMonto.Text, @"^\d +$:") == true)
            {
                MessageBox.Show("Resvise el monto ingresado\nNo hay montos a pagar menores a mil!");
                return;
            }

            if (CamposLlenos() == true)
            {   
                string comprobante = "C-" + DateTime.Now.ToString("HHmmssttddMMyyyy") + "-0" + idReserva;
                objeto_CE_Boletas.MedioDePago = tbMedioPago.Text;
                objeto_CE_Boletas.Fecha = DateTime.Now;
                objeto_CE_Boletas.Banco = tbBanco.Text;
                objeto_CE_Boletas.Comprobante = comprobante;
                objeto_CE_Boletas.Monto = int.Parse(tbMonto.Text);
                objeto_CE_Boletas.Descripcion = tbDescripcion.Text;
                objeto_CE_Boletas.IdReserva = idReserva;
                objeto_CE_Boletas.IdServicio = idServicio;

                objeto_CN_Boletas.Insertar(objeto_CE_Boletas);
                MessageBox.Show("Se ingreso exitosamente!!");

                Imprimir(comprobante);
                LimpiarData();
                CargarDatos();
            }
            
        }
        #endregion

        #region CONSULTAR
        private void Consultar(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region IMPRIMIR
        void Imprimir (string comprobante)
        {
            string cambio = "0";
            SaveFileDialog savefile = new SaveFileDialog
            {
                FileName = comprobante + ".pdf"
            };

            string Pagina = Properties.Resources.Ticket.ToString();
            Pagina = Pagina.Replace("@Ticket", comprobante);
            Pagina = Pagina.Replace("@efectivo", tbMonto.Text.ToString());
            Pagina = Pagina.Replace("@cambio", cambio);
            Pagina = Pagina.Replace("@Fecha", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

            Pagina = Pagina.Replace("@TOTAL", tbMonto.Text.ToString());

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document document = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(document, stream);
                    document.Open();

                    using (StringReader sr= new StringReader(Pagina))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);
                    }
                    document.Close();
                    stream.Close();
                }
                MessageBox.Show("Se hizo un pdf:3");
            }
        }
        

        #endregion  

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
