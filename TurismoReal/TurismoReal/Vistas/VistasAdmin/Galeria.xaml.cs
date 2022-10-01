using CapaDeEntidad.Clases;
using CapaDeNegocio.Clases;
using Microsoft.Win32;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TurismoReal.Vistas.VistasAdmin
{
    /// <summary>
    /// Lógica de interacción para Galeria.xaml
    /// </summary>
    public partial class Galeria : UserControl
    {
        readonly CN_Departamentos objeto_CN_Departamentos = new CN_Departamentos();

        public Galeria()
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
        private void BtnAgregarArtefacto_Click(object sender, RoutedEventArgs e)
        {
            CRUDgaleria ventana = new CRUDgaleria();
            FrameInventario.Content = ventana;
            ventana.BtnActualizar.IsEnabled = false;
        }
        #endregion

        #region INVENTARIO
        private void Consultar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDgaleria ventana = new CRUDgaleria();
            FrameInventario.Content = ventana;
            ventana.BtnActualizar.IsEnabled = false;
            ventana.tbIDdepto.Text = "" + id;
            ventana.Titulo.Text = "Galeria Depto. N°" + id;
        }
        #endregion
    }
}
