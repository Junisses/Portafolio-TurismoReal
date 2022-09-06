using CapaDeEntidad.Clases;
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
    /// Lógica de interacción para CRUDservicios.xaml
    /// </summary>
    public partial class CRUDservicios : Page
    {
        
        readonly CN_TipoServicio objeto_CN_TipoServicio = new CN_TipoServicio();

        public CRUDservicios()
        {
            InitializeComponent();
            CargarTP();
        }

        void CargarTP()
        {
            List<string> tiposervicio = objeto_CN_TipoServicio.ListarTipoServicio();
            for (int i = 0; i < tiposervicio.Count; i++)
            {
                cbTipoServicio.Items.Add(tiposervicio[i]);
            }

        }


        #region AGREGAR
        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Servicios();
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