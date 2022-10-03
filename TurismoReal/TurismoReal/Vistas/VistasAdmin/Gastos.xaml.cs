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
    /// Lógica de interacción para Gastos.xaml
    /// </summary>
    public partial class Gastos : UserControl
    {
        readonly CN_Departamentos objeto_CN_Departamentos = new CN_Departamentos();
        public Gastos()
        {
            InitializeComponent();
            CargarDatos();
        }

        #region CARGAR Departamentos
        void CargarDatos()
        {
            GridDatos.ItemsSource = objeto_CN_Departamentos.CargarDeptos().DefaultView;
        }
        #endregion

        #region ARTEFACTOS
        private void BtnAñadirNuevo_Click(object sender, RoutedEventArgs e)
        {
            CRUDtipoGasto ventana = new CRUDtipoGasto();
            FrameGastos.Content = ventana;
            ventana.BtnActualizar.IsEnabled = false;
        }
        #endregion

        #region GASTOS
        private void Consultar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDgastos ventana = new CRUDgastos();
            FrameGastos.Content = ventana;
            ventana.BtnActualizar.IsEnabled = false;
            ventana.tbIDdepto.Text = "" + id;
            ventana.Titulo.Text = "Gastos Depto. N°" + id;
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
