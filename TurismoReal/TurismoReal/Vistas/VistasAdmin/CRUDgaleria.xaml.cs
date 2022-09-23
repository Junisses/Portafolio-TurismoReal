using CapaDeEntidad.Clases;
using CapaDeNegocio.Clases;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para CRUDgaleria.xaml
    /// </summary>
    public partial class CRUDgaleria : Page
    {
        readonly CN_Galeria objeto_CN_Galeria = new CN_Galeria();
        readonly CE_Galeria objeto_CE_Galeria = new CE_Galeria();

        readonly CN_Departamentos objeto_CN_Departamentos = new CN_Departamentos();
        readonly CE_Departamentos objeto_CE_Departamentos = new CE_Departamentos();

        public CRUDgaleria()
        {
            InitializeComponent();
        }

        #region Regresar
        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Departamentos();
        }
        #endregion

        #region AGREGAR IMAGEN
        public int idDepartamento;
        private void Crear(object sender, RoutedEventArgs e)
        {
            objeto_CE_Departamentos.IdDepartamento = idDepartamento;
            CRUDgaleria ventana = new CRUDgaleria();
            ventana.idDepartamento = idDepartamento;
            FrameGaleria.Content = ventana;

            objeto_CE_Galeria.Imagen = img;
            objeto_CE_Galeria.IdDepartamento = idDepartamento;

            objeto_CN_Galeria.Insertar(objeto_CE_Galeria);

            MessageBox.Show("Se ha guardado la imagen!\nDepto. n° " + idDepartamento);

            Content = new Departamentos();
        }

        #region SUBIR IMAGEN

        byte[] img;
        private bool imagensubida = false;
        private void Subir(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog()==true)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                img = new byte[fs.Length];
                fs.Read(img, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();

                ImageSourceConverter imgs = new ImageSourceConverter();
                imagen.SetValue(Image.SourceProperty, imgs.ConvertFromString(ofd.FileName.ToString()));

            }
            imagensubida = true;
        }

        #endregion

        #endregion

        #region CONSULTAR
        public int idGaleria;
        public void Consultar()
        {
            var a = objeto_CN_Galeria.Consulta(idGaleria);

            ImageSourceConverter imgs = new ImageSourceConverter();
            imagen.Source = (ImageSource)imgs.ConvertFrom(a.Imagen);
        }
        #endregion

        #region ACTUALIZAR
        private void Actualizar(object sender, RoutedEventArgs e)
        {
            if (imagensubida == true)
            {
                objeto_CE_Galeria.idGaleria = idGaleria;
                objeto_CE_Galeria.Imagen = img;

                objeto_CN_Galeria.ActualizarIMG(objeto_CE_Galeria);
                Content = new Galeria();
            }
            else
            {
                MessageBox.Show("No se a cambiado la imagen");
            }
        }
        #endregion

        #region ELIMINAR
        private void Eliminar(object sender, RoutedEventArgs e)
        {
            objeto_CE_Galeria.idGaleria = idGaleria;
            objeto_CN_Galeria.Eliminar(objeto_CE_Galeria);
            Content = new Departamentos();
        }

        #endregion

        
    }
}

