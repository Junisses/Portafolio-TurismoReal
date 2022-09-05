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
    /// Lógica de interacción para Departamentos.xaml
    /// </summary>
    public partial class Departamentos : UserControl
    {
        public Departamentos()
        {
            InitializeComponent();
        }
        #region AGREGAR
        private void BtnAgregarDepto_Click(object sender, RoutedEventArgs e)
        {
            CRUDdepartamentos ventana = new CRUDdepartamentos();
            FrameDepartamentos.Content = ventana;
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
