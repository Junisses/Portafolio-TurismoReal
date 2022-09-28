using CapaDeEntidad.Clases;
using CapaDeNegocio.Clases;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;

namespace TurismoReal.Vistas.VistasAdmin
{
    /// <summary>
    /// Lógica de interacción para CRUDartefacto.xaml
    /// </summary>
    public partial class CRUDartefacto : Page
    {
        readonly CN_UnidadMedida objeto_CN_UnidadMedida = new CN_UnidadMedida();
        readonly CN_Artefactos objeto_CN_Artefactos = new CN_Artefactos();
        readonly CE_Artefactos objeto_CE_Artefactos = new CE_Artefactos();

        public CRUDartefacto()
        {
            InitializeComponent();
            CargarU();
            CargarDatos();
        }

        #region CARGAR Artefactos
        void CargarDatos()
        {
            GridDatos.ItemsSource = objeto_CN_Artefactos.CargarArtefactos().DefaultView;
        }
        #endregion

        #region Cargar FK
        void CargarU()
        {
            List<string> tipoUnidad = objeto_CN_UnidadMedida.ListarUnidad();
            for (int i = 0; i < tipoUnidad.Count; i++)
            {
                cbUnidad.Items.Add(tipoUnidad[i]);
            }
        }
        #endregion

        #region Regresar
        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Inventario();
        }
        #endregion

        #region ValidarCamposVacios
        public bool CamposLlenos()
        {
            if (tbDescripcion.Text == ""
                || tbTamaño.Text == ""
                || tbColor.Text == ""
                || tbValor.Text == ""
                || cbUnidad.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        public int idArtefactos;
        public int idUnidadMedida;
        #region Crear
        private void Crear(object sender, RoutedEventArgs e)
        {
            if (CamposLlenos() == true)
            {
                try
                {
                    int unidad = objeto_CN_UnidadMedida.IdUnidad(cbUnidad.Text);

                    objeto_CE_Artefactos.Descripcion = tbDescripcion.Text;
                    objeto_CE_Artefactos.Tamano = int.Parse(tbTamaño.Text);
                    objeto_CE_Artefactos.Color = tbColor.Text; 
                    objeto_CE_Artefactos.Valor = int.Parse(tbValor.Text);
                    objeto_CE_Artefactos.IdUnidadMedida = unidad;

                    objeto_CN_Artefactos.Insertar(objeto_CE_Artefactos);
                    CargarDatos();
                    MessageBox.Show("Se registro exitosamente");
                    LimpiarData();
                }
                catch
                {
                    MessageBox.Show("No pueden quedar campos vacíos!");
                }
            }
            else
            {
                MessageBox.Show("No se pudo registrar el Artefacto,\n revise los datos e intentelo denuevo");
            }
        }
        #endregion
        public void ActualizarC(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            tbDescripcion.IsEnabled = true;
            tbTamaño.IsEnabled = true;
            tbColor.IsEnabled = true;
            tbValor.IsEnabled = true;
            cbUnidad.IsEnabled = true;
            BtnCrear.IsEnabled = false;
            BtnActualizar.IsEnabled = true;

            var a = objeto_CN_Artefactos.Consulta(id);
            var c = objeto_CN_UnidadMedida.NombreUnidad(a.IdUnidadMedida);

            tbID.Text = id.ToString();
            tbDescripcion.Text = a.Descripcion.ToString();
            tbTamaño.Text = a.Tamano.ToString();
            tbColor.Text = a.Color.ToString();
            tbValor.Text = a.Valor.ToString();
            cbUnidad.Text = c.TipoUnidad.ToString();
            
        }
    
        #region Actualizar
        public void Actualizar(object sender, RoutedEventArgs e)
        {
            if (CamposLlenos() == true)
            {
                int unidad = objeto_CN_UnidadMedida.IdUnidad(cbUnidad.Text);

                objeto_CE_Artefactos.IdArtefactos = int.Parse(tbID.Text);
                objeto_CE_Artefactos.Descripcion = tbDescripcion.Text;
                objeto_CE_Artefactos.Tamano = int.Parse(tbTamaño.Text);
                objeto_CE_Artefactos.Color = tbColor.Text;
                objeto_CE_Artefactos.Valor = int.Parse(tbValor.Text);
                objeto_CE_Artefactos.IdUnidadMedida = unidad;

                objeto_CN_Artefactos.ActualizarDatos(objeto_CE_Artefactos);
                CargarDatos();
                MessageBox.Show("Se actualizó exitosamente!!");
                LimpiarData();
            }
            else
            {
                MessageBox.Show("Por favor, no dejar campos vacios");
            }
        }
        #endregion

        #region Consultar
        private void Consultar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            tbDescripcion.IsEnabled = false;
            tbTamaño.IsEnabled = false;
            tbColor.IsEnabled = false;
            tbValor.IsEnabled = false;
            cbUnidad.IsEnabled = false;
            BtnActualizar.IsEnabled = false;
            BtnCrear.IsEnabled = false;

            var a = objeto_CN_Artefactos.Consulta(id);
            var c = objeto_CN_UnidadMedida.NombreUnidad(a.IdUnidadMedida);

            tbDescripcion.Text = a.Descripcion.ToString();
            tbTamaño.Text = a.Tamano.ToString();
            tbColor.Text = a.Color.ToString();
            tbValor.Text = a.Valor.ToString();
            cbUnidad.Text = c.TipoUnidad.ToString();
        }
        #endregion

        #region Eliminar
        private void Eliminar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            if (MessageBox.Show("¿Esta seguro de eliminar el artefacto?", "Eliminar Artefacto", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                objeto_CE_Artefactos.IdArtefactos = id;
                objeto_CN_Artefactos.Eliminar(objeto_CE_Artefactos);
                CargarDatos();
            }
            else
            {
                CargarDatos();
            }
            
        }
        #endregion


        #region Limpiar Campos

        public void LimpiarData()
        {
            tbDescripcion.Clear();
            tbColor.Clear();
            tbTamaño.Clear();
            tbValor.Clear();
            tbDescripcion.IsEnabled = true;
            tbTamaño.IsEnabled = true;
            tbColor.IsEnabled = true;
            tbValor.IsEnabled = true;
            cbUnidad.IsEnabled = true;
            BtnCrear.IsEnabled = true;
        }
        private void Limpiar(object sender, RoutedEventArgs e)
        {
            LimpiarData();
        }
        #endregion

        
    }
}