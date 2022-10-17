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
    /// Lógica de interacción para Reportes.xaml
    /// </summary>
    public partial class Reportes : UserControl
    {
        readonly CN_Departamentos objeto_CN_Departamentos = new CN_Departamentos();
        readonly CN_EstadoDepto objeto_CN_EstadoDepto = new CN_EstadoDepto();
        readonly CN_Region objeto_CN_Region = new CN_Region();
        readonly CN_Comuna objeto_CN_Comuna = new CN_Comuna();

        #region INICIAL
        public Reportes()
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

        #region CONSULTAR
        private void Consultar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDreportes ventana = new CRUDreportes();
            ventana.idDepartamento = id;
            FrameDepartamentos.Content = ventana;
            ventana.Titulo.Text = "Reporte departamento N° "+ id;

        }


        #endregion

        #region FUNCION BUSCAR
        #region Limpiar
        public void LimpiarData()
        {
            tbBuscar.Clear();
        }

        #endregion
        private void Ver(object sender, RoutedEventArgs e)
        {
            GridDatos.ItemsSource = objeto_CN_Departamentos.BuscarDepto(tbBuscar.Text).DefaultView;
            LimpiarData();
        }
        #endregion
    }
}
