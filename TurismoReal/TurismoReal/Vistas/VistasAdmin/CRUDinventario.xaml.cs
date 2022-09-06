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
    /// Lógica de interacción para CRUDinventario.xaml
    /// </summary>
    public partial class CRUDinventario : Page
    {

        readonly CN_Artefactos objeto_CN_Artefactos = new CN_Artefactos();

        public CRUDinventario()
        {
            InitializeComponent();
            CargarA();
        }

        #region Cargar FK
        void CargarA()
        {
            List<string> descripcion = objeto_CN_Artefactos.ListarArtefacto();
            for (int i = 0; i < descripcion.Count; i++)
            {
                cbArtefacto.Items.Add(descripcion[i]);
            }
        }
        #endregion

        #region Regresar
        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Inventario();
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