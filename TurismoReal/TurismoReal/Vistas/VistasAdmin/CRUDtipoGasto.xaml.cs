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
    /// Lógica de interacción para CRUDtipoGasto.xaml
    /// </summary>
    public partial class CRUDtipoGasto : Page
    {
        readonly CN_TipoGasto objeto_CN_TipoGasto = new CN_TipoGasto();
        readonly CE_TipoGasto objeto_CE_TipoGasto = new CE_TipoGasto();
        public CRUDtipoGasto()
        {
            InitializeComponent();
            CargarDatos();
        }

        #region CARGAR Artefactos
        void CargarDatos()
        {
            GridDatos.ItemsSource = objeto_CN_TipoGasto.CargarTipoGasto().DefaultView;
        }
        #endregion


        #region Regresar
        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Gastos();
        }
        #endregion

        #region ValidarCamposVacios
        public bool CamposLlenos()
        {
            if (tbTipoGasto.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        public int idTipoGasto;
        #region Crear
        private void Crear(object sender, RoutedEventArgs e)
        {
            if (CamposLlenos() == true)
            {
                try
                {
                    objeto_CE_TipoGasto.TipoGasto = tbTipoGasto.Text;
                    objeto_CN_TipoGasto.Insertar(objeto_CE_TipoGasto);

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
                MessageBox.Show("No se pudo registrar el Gasto,\n revise los datos e intentelo denuevo");
            }
        }
        #endregion
        public void ActualizarC(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            tbTipoGasto.IsEnabled = true;
            BtnCrear.IsEnabled = false;
            BtnActualizar.IsEnabled = true;

            var a = objeto_CN_TipoGasto.Consulta(id);

            tbID.Text = id.ToString();
            tbTipoGasto.Text = a.TipoGasto.ToString();

        }

        #region Actualizar
        public void Actualizar(object sender, RoutedEventArgs e)
        {
            if (CamposLlenos() == true)
            {
                objeto_CE_TipoGasto.IdTipoGasto = int.Parse(tbID.Text);
                objeto_CE_TipoGasto.TipoGasto = tbTipoGasto.Text;

                objeto_CN_TipoGasto.ActualizarDatos(objeto_CE_TipoGasto);
                CargarDatos();
                MessageBox.Show("Se actualizó exitosamente!!");
                LimpiarData();
                BtnCrear.IsEnabled = true;
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
            tbTipoGasto.IsEnabled = false;
            BtnActualizar.IsEnabled = false;
            BtnCrear.IsEnabled = false;

            var a = objeto_CN_TipoGasto.Consulta(id);

            tbTipoGasto.Text = a.TipoGasto.ToString();
        }
        #endregion

        #region Eliminar
        private void Eliminar(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            if (MessageBox.Show("¿Esta seguro de eliminar el artefacto?", "Eliminar Artefacto", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                objeto_CE_TipoGasto.IdTipoGasto = id;
                objeto_CN_TipoGasto.Eliminar(objeto_CE_TipoGasto);
                CargarDatos();
                LimpiarData();
            }
            else
            {
                CargarDatos();
                LimpiarData();
            }
        }
        #endregion


        #region Limpiar Campos

        public void LimpiarData()
        {
            tbTipoGasto.Clear();
            tbTipoGasto.IsEnabled = true;
            BtnActualizar.IsEnabled = false;
            BtnCrear.IsEnabled = true;
        }
        private void Limpiar(object sender, RoutedEventArgs e)
        {
            LimpiarData();
        }
        #endregion


    }
}
