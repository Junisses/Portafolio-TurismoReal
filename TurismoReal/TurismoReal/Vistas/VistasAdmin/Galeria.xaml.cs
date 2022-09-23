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
    /// Lógica de interacción para Galeria.xaml
    /// </summary>
    public partial class Galeria : UserControl
    {
        readonly CN_Galeria objeto_CN_Galeria = new CN_Galeria();
        readonly CE_Galeria objeto_CE_Galeria = new CE_Galeria();

        readonly CN_Departamentos objeto_CN_Departamentos = new CN_Departamentos();
        readonly CE_Departamentos objeto_CE_Departamentos = new CE_Departamentos();

        public Galeria()
        {
            InitializeComponent();
            CargarImagen();
        }

        #region Regresar
        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Departamentos();
        }
        #endregion


        #region CARGAR Imagenes
        void CargarImagen()
        {
            GridDatos.ItemsSource = objeto_CN_Galeria.CargarImagen().DefaultView;
        }
        #endregion

        #region AGREGAR
        public int idDepartamento;
        private void BtnAgregarServicio_Click(object sender, RoutedEventArgs e)
        {
            objeto_CE_Departamentos.IdDepartamento = idDepartamento;
            CRUDgaleria ventana = new CRUDgaleria();
            ventana.BtnCrear.Visibility = Visibility.Visible;
            ventana.BtnGuardar.Visibility = Visibility.Visible;
            ventana.idDepartamento = idDepartamento;
            FrameGaleria.Content = ventana;
            MessageBox.Show("" + idDepartamento);
        }
        #endregion

        #region CONSULTAR
        public void Consultar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDgaleria ventana = new CRUDgaleria();
            ventana.idGaleria = id;
            ventana.Consultar();
            FrameGaleria.Content = ventana;
            ventana.Titulo.Text = "Ver imagen";
            ventana.imagen.IsEnabled = false;
        }
     
        public void Consulta()
        {
            var a = objeto_CN_Departamentos.Consulta(idDepartamento);

            MessageBox.Show("" + idDepartamento);
        }
        #endregion

        #region ACTUALIZAR
        private void Actualizar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDgaleria ventana = new CRUDgaleria();
            ventana.idGaleria = id;
            ventana.Consultar();
            FrameGaleria.Content = ventana;
            ventana.Titulo.Text = "Actualizar Imagen";
            ventana.imagen.IsEnabled = true;
            ventana.BtnCrear.Visibility = Visibility.Visible;
            ventana.BtnActualizar.Visibility = Visibility.Visible;
        }
        #endregion

        #region ELIMINAR
        private void Eliminar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDgaleria ventana = new CRUDgaleria();
            ventana.idGaleria = id;
            ventana.Consultar();
            FrameGaleria.Content = ventana;
            ventana.Titulo.Text = "Eliminar Imagen";
            ventana.imagen.IsEnabled = false;
            
            ventana.BtnEliminar.Visibility = Visibility.Visible;
        }

        #endregion

    }
}

