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
    /// Lógica de interacción para CheckList.xaml
    /// </summary>
    public partial class CheckList : UserControl
    {
        public CheckList()
        {
            InitializeComponent();
        }
        #region AGREGAR
        private void BtnAgregarArtefacto_Click(object sender, RoutedEventArgs e)
        {
            CRUDartefacto ventana = new CRUDartefacto();
            FrameInventario.Content = ventana;
            ventana.BtnCrear.Visibility = Visibility.Visible;
        }
        #endregion

        #region AGREGAR
        private void BtnInventario_Click(object sender, RoutedEventArgs e)
        {
            CRUDinventario ventana = new CRUDinventario();
            FrameInventario.Content = ventana;
            ventana.BtnCrear.Visibility = Visibility.Visible;
        }
        #endregion

        #region CONSULTAR
        private void Consultar(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region ACTUALIZAR
        private void Actualizar(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region ELIMINAR
        private void Eliminar(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}
