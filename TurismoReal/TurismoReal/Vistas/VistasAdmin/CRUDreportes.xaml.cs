using CapaDeEntidad.Clases;
using CapaDeNegocio.Clases;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TurismoReal.Vistas.VistasAdmin
{
    /// <summary>
    /// Lógica de interacción para CRUDreportes.xaml
    /// </summary>
    public partial class CRUDreportes : Page
    {
        readonly CN_Reportes objeto_CN_Reportes = new CN_Reportes();
        readonly CE_Reportes objeto_CE_Reportes = new CE_Reportes();

        readonly CN_Departamentos objeto_CN_Departamentos = new CN_Departamentos();
        readonly CN_Comuna objeto_CN_Comuna = new CN_Comuna();

        public CRUDreportes()
        {
            InitializeComponent();
        }


        #region Regresar
        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Reportes();
        }
        #endregion


        #region ValidarCamposVacios
        public bool CamposLlenos()
        {
            if ( cFechaDesde.Text == ""
                || cFechaHasta.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        public int idDepartamento;
        #region Crear
        private void Crear(object sender, RoutedEventArgs e)
        {
            if (CamposLlenos() == true)
            {
                string reporte = "REPORTE-" + " Depto-0" + idDepartamento + "-" + DateTime.Now.ToString("HHmmssddMMyyyy");
                objeto_CE_Reportes.FechaDesde = DateTime.Parse(cFechaDesde.Text);
                DateTime fechad = DateTime.Parse(cFechaDesde.Text);
                objeto_CE_Reportes.FechaHasta = DateTime.Parse(cFechaHasta.Text);
                DateTime fechah = DateTime.Parse(cFechaHasta.Text);
                objeto_CE_Reportes.IdDepartamento = idDepartamento;

                objeto_CN_Reportes.Insertar(objeto_CE_Reportes);
                Imprimir(fechad, fechah, idDepartamento, reporte); 

                Content = new Reportes();
            }
            else
            {
                MessageBox.Show("No se pudo generar el reporte, revise que los datos esten correctamente ingresados");
            }
        }
        #endregion

        #region IMPRIMIR

        void Imprimir(DateTime fechaDesde, DateTime fechaHasta, int idDepartamento, string reporte)
        {
            SaveFileDialog savefile = new SaveFileDialog
            {
                FileName = reporte + ".pdf"
            };
            string Pagina = Properties.Resources.REPORTE.ToString();

            Pagina = Pagina.Replace("@Fecha", DateTime.Now.ToString("dd/MM/yyyy"));
            Pagina = Pagina.Replace("@id", idDepartamento.ToString());
            Pagina = Pagina.Replace("@hora", DateTime.Now.ToString("HH:mm") + "hrs.");

            var d = objeto_CN_Departamentos.Consulta(idDepartamento);
            var c = objeto_CN_Comuna.NombreComuna(d.IdComuna);
            //TEXTO
            Pagina = Pagina.Replace("@nombre", d.Descripcion.ToString() + " de la comuna de " + c.Comuna.ToString());
            Pagina = Pagina.Replace("@comuna", c.Comuna.ToString());
            Pagina = Pagina.Replace("@desde", fechaDesde.ToString("dd/MM/yyyy"));
            Pagina = Pagina.Replace("@hasta", fechaHasta.ToString("dd/MM/yyyy"));
            //Ganancias
            var r = objeto_CN_Reportes.Consulta();
            Pagina = Pagina.Replace("@ganancias", r.Total.ToString());
            //Reservas
            Pagina = Pagina.Replace("@reservas", r.CantReservas.ToString());
            //Gastos
            Pagina = Pagina.Replace("@gastos", r.Gastos.ToString());
            //TEXTO
            Pagina = Pagina.Replace("@reservas", 0.ToString());
            Pagina = Pagina.Replace("@gastos", 0.ToString());


            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document document = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(document, stream);

                    document.Open();

                    using (StringReader sr = new StringReader(Pagina))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);
                    }
                    document.Close();
                    stream.Close();
                }
            }
        }


        #endregion


    }
}
