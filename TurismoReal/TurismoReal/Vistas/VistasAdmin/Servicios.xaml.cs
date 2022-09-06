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
    /// Lógica de interacción para Servicios.xaml
    /// </summary>
    public partial class Servicios : UserControl
    {
        public Servicios()
        {
            InitializeComponent();
        }
        #region AGREGAR
        private void BtnAgregarServicio_Click(object sender, RoutedEventArgs e)
        {
            CRUDservicios ventana = new CRUDservicios();
            FrameServicios.Content = ventana;
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
