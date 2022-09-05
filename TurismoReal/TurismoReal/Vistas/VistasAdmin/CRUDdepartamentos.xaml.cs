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
    /// Lógica de interacción para CRUDdepartamentos.xaml
    /// </summary>
    public partial class CRUDdepartamentos : Page
    {
        public CRUDdepartamentos()
        {
            InitializeComponent();
        }

        #region Regresar
        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Departamentos();
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

        private void BtnGaleria_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("En la seguiente versión se podrán subir imagenes!☺");
        }
    }
}
