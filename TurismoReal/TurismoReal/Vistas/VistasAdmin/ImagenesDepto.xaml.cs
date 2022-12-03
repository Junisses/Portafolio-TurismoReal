using CapaDeEntidad.Clases;
using CapaDeNegocio.Clases;
using iTextSharp.tool.xml.html;
using Microsoft.Win32;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Button = System.Windows.Controls.Button;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using Path = System.IO.Path;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;
using UserControl = System.Windows.Controls.UserControl;

namespace TurismoReal.Vistas.VistasAdmin
{
    /// <summary>
    /// Lógica de interacción para ImagenesDepto.xaml
    /// </summary>
    public partial class ImagenesDepto : UserControl
    {
        readonly CN_Galeria objeto_CN_Galeria = new CN_Galeria();
        readonly CE_Galeria objeto_CE_Galeria = new CE_Galeria();

        public ImagenesDepto()
        {
            InitializeComponent();
        }

        #region CARGAR IMAGENES
        void CargarDatos()
        {
            GridDatos.ItemsSource = objeto_CN_Galeria.CargarImagen(idDepartamento).DefaultView;
        }
        #endregion

        #region Regresar
        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Departamentos();
        }
        #endregion

        #region ValidarCamposVacios
        public bool CamposLlenos()
        {
            if (tbDescripcion.Text == ""
                || tbIDdepto.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region AGREGAR IMAGEN
        public int idDepartamento;
        BitmapImage bi = null; // Global
        private void Crear(object sender, RoutedEventArgs e)
        {
            #region NOMBRE/DESCRIPCIÓN
            if (tbDescripcion.Text == "")
            {
                MessageBox.Show("La descripción no puede quedar vacía", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Warning);
                tbDescripcion.Focus();
                return;
            }
            else if (tbDescripcion.Text != "")
            {
                if (tbDescripcion.Text.Length > 30)
                {
                    MessageBox.Show("La descripción es demasiado extensa", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Warning);
                    tbDescripcion.Clear();
                    tbDescripcion.Focus();
                    return;
                }
                else if (tbDescripcion.Text.Length < 3)
                {
                    MessageBox.Show("La descripción es muy corta", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Warning);
                    tbDescripcion.Clear();
                    tbDescripcion.Focus();
                    return;
                }
                //valido que se ingresen solo letras
                else if (Regex.IsMatch(tbDescripcion.Text, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ ]+$") == false)
                {
                    MessageBox.Show("La descripción solo puede tener letras", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Warning);
                    tbDescripcion.Clear();
                    tbDescripcion.Focus();
                    return;
                }
            }
            #endregion

            if (CamposLlenos() == true)
            {
                objeto_CE_Galeria.DescripcionImagen = tbDescripcion.Text + "-" + tbIDdepto.Text;
                objeto_CE_Galeria.IdDepartamento = int.Parse(tbIDdepto.Text);

                #region IMAGEN
                if (imagensubida == true)
                {
                    if (bi != null)
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                        saveFileDialog1.Filter = "Image files|*.jpg;*.png;*.jpeg";
                        saveFileDialog1.Title = "Guardar en la carpeta...";
                        saveFileDialog1.FileName = tbDescripcion.Text + "-" + tbIDdepto.Text;
                        saveFileDialog1.InitialDirectory = @"C:\TurismoRealWeb\turismoRealProyectoWeb\clientes\static\clientes\images";

                        if (saveFileDialog1.ShowDialog() == true)
                        {
                            try
                            {
                                JpegBitmapEncoder jpg = new JpegBitmapEncoder();
                                jpg.Frames.Add(BitmapFrame.Create(bi));
                                using (Stream stm = File.Create(saveFileDialog1.FileName))
                                {
                                    jpg.Save(stm);
                                    objeto_CE_Galeria.Imagen = saveFileDialog1.FileName;
                                    stm.Close(); 
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("La imagen no se ha guardado, intentelo denuevo", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("La imagen no se ha guardado, intentelo denuevo", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                #endregion
                else
                {
                    MessageBox.Show("La imagen no se ha guardado, intentelo denuevo", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                objeto_CN_Galeria.Insertar(objeto_CE_Galeria);
                CargarDatos();
                MessageBox.Show("Se ha guardado la imagen!", "INFORMACIÓN", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarData();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado una imagen", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #region SUBIR IMAGEN

        private bool imagensubida = false;
        private void Subir(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files|*.jpg;*.png;*.jpeg";
            ofd.Title = "Seleccionar imagen";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (ofd.ShowDialog() == true)
            {
                try
                {
                    bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri(ofd.FileName, UriKind.RelativeOrAbsolute);
                    bi.EndInit();

                    imagen.Source = bi;
                   
                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }
                imagensubida = true;
            }
        }

        #endregion

        #endregion

        #region CONSULTAR
        public int idGaleria;
        private void Consultar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            var a = objeto_CN_Galeria.Consulta(id);

            tbIDdepto.IsEnabled = false;
            tbDescripcion.IsEnabled = false;
            BtnActualizar.IsEnabled = false;
            BtnCrear.IsEnabled = false;
            BtnGuardar.IsEnabled = false;

            //ImageSourceConverter imgs = new ImageSourceConverter();
            //imagen.Source = (ImageSource)imgs.ConvertFrom(a.Imagen);
            tbDescripcion.Text = a.DescripcionImagen.ToString();
            tbFile.Text = a.Imagen.ToString();

            if (File.Exists("C:\\TurismoRealWeb\\turismoRealProyectoWeb\\clientes\\static\\clientes\\images\\" + tbDescripcion.Text + ".jpg") == true)
            {
                try
                {
                    bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri("C:\\TurismoRealWeb\\turismoRealProyectoWeb\\clientes\\static\\clientes\\images\\" + tbDescripcion.Text + ".jpg");
                    bi.EndInit();

                    imagen.Source = bi;
                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }
            }
            else if (File.Exists("C:\\TurismoRealWeb\\turismoRealProyectoWeb\\clientes\\static\\clientes\\images\\" + tbDescripcion.Text + ".png") == true)
            {
                try
                {
                    bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri("C:\\TurismoRealWeb\\turismoRealProyectoWeb\\clientes\\static\\clientes\\images\\" + tbDescripcion.Text + ".png");
                    bi.EndInit();

                    imagen.Source = bi;
                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }
            }
            else if (File.Exists("C:\\TurismoRealWeb\\turismoRealProyectoWeb\\clientes\\static\\clientes\\images\\" + tbDescripcion.Text + ".jpeg") == true)
            {
                try
                {
                    bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri("C:\\TurismoRealWeb\\turismoRealProyectoWeb\\clientes\\static\\clientes\\images\\" + tbDescripcion.Text + ".jpeg");
                    bi.EndInit();

                    imagen.Source = bi;
                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }
            }
            else
            {
                MessageBox.Show("La imagen no se encuentra, puede\nque se eliminará del equipo");
            }
        }
        #endregion

        #region ACTUALIZAR

        public void ActualizarC(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            tbDescripcion.IsEnabled = false;
            BtnGuardar.IsEnabled = false;
            BtnCrear.IsEnabled = true;
            BtnActualizar.IsEnabled = true;

            var a = objeto_CN_Galeria.Consulta(id);

            tbID.Text = id.ToString();
            tbDescripcion.Text = a.DescripcionImagen.ToString();

            //ImageSourceConverter imgs = new ImageSourceConverter();
            //imagen.Source = (ImageSource)imgs.ConvertFrom(a.Imagen);

            if (File.Exists("C:\\TurismoRealWeb\\turismoRealProyectoWeb\\clientes\\static\\clientes\\images\\" + tbDescripcion.Text + ".jpg") == true)
            {
                try
                {
                    bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri("C:\\TurismoRealWeb\\turismoRealProyectoWeb\\clientes\\static\\clientes\\images\\" + tbDescripcion.Text + ".jpg");
                    bi.EndInit();

                    imagen.Source = bi;

                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }
            }
            else if (File.Exists("C:\\TurismoRealWeb\\turismoRealProyectoWeb\\clientes\\static\\clientes\\images\\" + tbDescripcion.Text + ".png") == true)
            {
                try
                {
                    bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri("C:\\TurismoRealWeb\\turismoRealProyectoWeb\\clientes\\static\\clientes\\images\\" + tbDescripcion.Text + ".png");
                    bi.EndInit();

                    imagen.Source = bi;
                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }
            }
            else if (File.Exists("C:\\TurismoRealWeb\\turismoRealProyectoWeb\\clientes\\static\\clientes\\images\\" + tbDescripcion.Text + ".jpeg") == true)
            {
                try
                {
                    bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri("C:\\TurismoRealWeb\\turismoRealProyectoWeb\\clientes\\static\\clientes\\images\\" + tbDescripcion.Text + ".jpeg");
                    bi.EndInit();

                    imagen.Source = bi;
                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }
            }
            else
            {
                MessageBox.Show("La imagen no se encuentra, puede\nque se eliminará del equipo");
                LimpiarData();
            }

            MessageBox.Show("Por favor, no cambie el nombre del\nARCHIVO al subirlo a la carpeta,\nsolo reemplacelo por el ya existente.", "INFORMACIÓN", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        private void Actualizar(object sender, RoutedEventArgs e)
        {

            if (CamposLlenos() == true)
            {
                objeto_CE_Galeria.idGaleria = int.Parse(tbID.Text);
                objeto_CE_Galeria.DescripcionImagen = tbDescripcion.Text;

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Image files|*.jpg;*.png;*.jpeg";
                saveFileDialog1.Title = "Guardar en la carpeta...";
                saveFileDialog1.FileName = tbDescripcion.Text;
                saveFileDialog1.InitialDirectory = @"C:\TurismoRealWeb\turismoRealProyectoWeb\clientes\static\clientes\images";

                    if (saveFileDialog1.ShowDialog() == true)
                    {
                        try
                        {
                            JpegBitmapEncoder jpg = new JpegBitmapEncoder();
                            jpg.Frames.Add(BitmapFrame.Create(bi));
                            using (Stream stm = File.Create(saveFileDialog1.FileName))
                            {
                                jpg.Save(stm);
                                objeto_CE_Galeria.Imagen = saveFileDialog1.FileName;
                                stm.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("La imagen no se ha guardado, intentelo denuevo", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                objeto_CN_Galeria.ActualizarIMG(objeto_CE_Galeria);
                CargarDatos();
                MessageBox.Show("Se actualizó exitosamente!!", "INFORMACIÓN", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarData();
                BtnCrear.IsEnabled = true;
                BtnGuardar.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("No se a cambiado la imagen", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region Limpiar Campos

        public void LimpiarData()
        {
            tbDescripcion.Clear();
            tbDescripcion.IsEnabled = true;
            BtnActualizar.IsEnabled = false;
            BtnCrear.IsEnabled = true;
            BtnGuardar.IsEnabled = true;

            if (File.Exists("C:\\TurismoRealWeb\\turismoRealProyectoWeb\\clientes\\static\\clientes\\images\\subir.png") == true)
            {
                try
                {
                    bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri("C:\\TurismoRealWeb\\turismoRealProyectoWeb\\clientes\\static\\clientes\\images\\subir.png");
                    bi.EndInit();

                    imagen.Source = bi;
                    return;
                }
                catch (Exception c)
                {
                    MessageBox.Show(c.Message);
                }
            }

        }
        private void Limpiar(object sender, RoutedEventArgs e)
        {
            LimpiarData();
        }
        #endregion


        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatos();
        }


    }
}