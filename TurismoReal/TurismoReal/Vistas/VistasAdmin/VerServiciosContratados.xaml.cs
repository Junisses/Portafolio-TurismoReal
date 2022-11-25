using CapaDeEntidad.Clases;
using CapaDeNegocio.Clases;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
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

namespace TurismoReal.Vistas.VistasAdmin
{
    /// <summary>
    /// Lógica de interacción para VerServiciosContratados.xaml
    /// </summary>
    public partial class VerServiciosContratados : UserControl
    {
        readonly CN_Servicios objeto_CN_Servicios = new CN_Servicios();
        readonly CN_DetalleServicio objeto_CN_DetalleServicio = new CN_DetalleServicio();

        readonly CN_Reservas objeto_CN_Reservas = new CN_Reservas();
        readonly CE_Reservas objeto_CE_Reservas = new CE_Reservas();

        readonly CN_Usuarios objeto_CN_Usuarios = new CN_Usuarios();

        const string Usuario = "junissesamanda.03@gmail.com";
        const string Password = "Jun2047.";

        public VerServiciosContratados()
        {
            InitializeComponent();
        }

        #region CARGAR Servicios contratados
        void CargarDatos()
        {
            GridDatos.ItemsSource = objeto_CN_DetalleServicio.VerServiciosContratados(idUsuario, idReserva).DefaultView;
        }
        #endregion
        public int idUsuario;
        public int idReserva;

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatos();
            var u = objeto_CN_Usuarios.Consulta(idUsuario);
            tbPara.Text = u.Correo.ToString();
        }


        private void Enviar(object sender, RoutedEventArgs e)
        {
            string Error = "";
            StringBuilder MensajeBuilder = new StringBuilder();
            MensajeBuilder.Append(tbMensaje.Text);
            EnviarCorreo(MensajeBuilder, DateTime.Now, tbDe.Text, tbPara.Text, tbAsunto.Text, out Error);
        }

        public static void EnviarCorreo(StringBuilder Mensaje, DateTime FechaEnvio, string De,string Para, string Asunto, out string Error)
        {
            Error = "";

            try
            {
                Mensaje.Append(Environment.NewLine);
                Mensaje.Append(String.Format("\nCorreo enviado el día {0:dd/MM/yyyy} a las {0:HH:mm:ss} hrs. \n\n",FechaEnvio));
                Mensaje.Append(Environment.NewLine);

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(De); //De
                mail.To.Add(Para); //Para
                mail.Subject = Asunto;
                mail.Body = Mensaje.ToString();

                SmtpClient smtp = new SmtpClient("smtp.office365.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(Usuario,Password);
                smtp.EnableSsl = true;
                smtp.Send(mail);

                Error = "Éxito";
                MessageBox.Show(Error);

            }
            catch (Exception ex)
            {
                Error = "Error: " + ex.Message;
                MessageBox.Show(Error);
                return;
            }
        }

        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Reservas();
        }
    }
}
