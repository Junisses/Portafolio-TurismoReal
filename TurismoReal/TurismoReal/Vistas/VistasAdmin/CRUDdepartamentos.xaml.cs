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
    /// Lógica de interacción para CRUDdepartamentos.xaml
    /// </summary>
    public partial class CRUDdepartamentos : Page
    {
        readonly CN_Comuna objeto_CN_Comuna = new CN_Comuna();
        readonly CN_Region objeto_CN_Region = new CN_Region();

        public CRUDdepartamentos()
        {
            InitializeComponent();
            CargarRC();
        }

        #region Cargar FK
        void CargarRC()
        {
            List<string> region = objeto_CN_Region.ListarRegion();
            for (int i = 0; i < region.Count; i++)
            {
                cbRegion.Items.Add(region[i]);
            }

            List<string> comuna = objeto_CN_Comuna.ListarComuna();
            for (int i = 0; i < comuna.Count; i++)
            {
                cbComuna.Items.Add(comuna[i]);
            }
        }
        #endregion

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
