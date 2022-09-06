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
        public CheckInOut()
        {
            InitializeComponent();
        }
        #region AGREGAR
        private void BtnVer_Click(object sender, RoutedEventArgs e)
        {
            CRUDcheckInOut ventana = new CRUDcheckInOut();
            FrameCheckINOUT.Content = ventana;
            ventana.BtnCrear.Visibility = Visibility.Visible;
            ventana.BtnActualizar.Visibility = Visibility.Visible;
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

    }
}