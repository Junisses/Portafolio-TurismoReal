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
    /// Lógica de interacción para CRUDcheckInOut.xaml
    /// </summary>
    public partial class CRUDcheckInOut : Page
    {
        public CRUDcheckInOut()
        {
            InitializeComponent();
        }

        #region AGREGAR
        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new CheckInOut();
        }
        #endregion


        #region Crear
        private void Crear(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Actualizar
        private void Actualizar(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Consultar
        private void Consultar(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Eliminar
        private void Eliminar(object sender, RoutedEventArgs e)
        {

        }
        #endregion

    }
}