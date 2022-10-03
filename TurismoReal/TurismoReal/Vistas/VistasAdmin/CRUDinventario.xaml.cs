using CapaDeEntidad.Clases;
using CapaDeNegocio.Clases;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TurismoReal.Vistas.VistasAdmin
{
    /// <summary>
    /// Lógica de interacción para CRUDinventario.xaml
    /// </summary>
    public partial class CRUDinventario : Page
    {

        readonly CN_Artefactos objeto_CN_Artefactos = new CN_Artefactos();
        readonly CN_Inventario objeto_CN_Inventario = new CN_Inventario();
        readonly CE_Inventario objeto_CE_Inventario = new CE_Inventario();
        
        public CRUDinventario()
        {
            InitializeComponent();
            CargarA();
            CargarDatos();
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

        #region CARGAR inventario
        void CargarDatos()
        {
            GridDatos.ItemsSource = objeto_CN_Inventario.CargarInventario().DefaultView;
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
            if (tbIDdepto.Text == ""
                || tbCantidad.Text == ""
                || cbArtefacto.Text == "")
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
        public int idInventario;
        #region Crear
        private void Crear(object sender, RoutedEventArgs e)
        {
            if (CamposLlenos() == true)
            {
                try
                {
                    int artefacto = objeto_CN_Artefactos.IdArtefacto(cbArtefacto.Text);

                    objeto_CE_Inventario.Cantidad = int.Parse(tbCantidad.Text);
                    objeto_CE_Inventario.IdDepartamento = int.Parse(tbIDdepto.Text);
                    objeto_CE_Inventario.IdArtefactos = artefacto;

                    objeto_CN_Inventario.Insertar(objeto_CE_Inventario);
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
            tbIDdepto.IsEnabled = false;
            tbCantidad.IsEnabled = true;
            cbArtefacto.IsEnabled = true;
            BtnCrear.IsEnabled = false;
            BtnActualizar.IsEnabled = true;

            var a = objeto_CN_Inventario.Consulta(id);
            var c = objeto_CN_Artefactos.NombreArtefacto(a.IdArtefactos);

            tbID.Text = id.ToString();
            tbCantidad.Text = a.Cantidad.ToString();
            cbArtefacto.Text = c.Descripcion.ToString();

        }

        #region Actualizar
        public void Actualizar(object sender, RoutedEventArgs e)
        {
            
            if (CamposLlenos() == true)
            {
                int artefacto = objeto_CN_Artefactos.IdArtefacto(cbArtefacto.Text);

                objeto_CE_Inventario.IdInventario = int.Parse(tbID.Text);
                objeto_CE_Inventario.Cantidad = int.Parse(tbCantidad.Text);
                objeto_CE_Inventario.IdArtefactos = artefacto;

                objeto_CN_Inventario.ActualizarDatos(objeto_CE_Inventario);
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
            tbIDdepto.IsEnabled = false;
            tbCantidad.IsEnabled = false;
            cbArtefacto.IsEnabled = false;
            BtnActualizar.IsEnabled = false;
            BtnCrear.IsEnabled = false;

            var a = objeto_CN_Inventario.Consulta(id);
            var c = objeto_CN_Artefactos.NombreArtefacto(a.IdArtefactos);

            tbCantidad.Text = a.Cantidad.ToString();
            cbArtefacto.Text = c.Descripcion.ToString();
        }
        #endregion

        #region Eliminar
        private void Eliminar(object sender, RoutedEventArgs e)
        {

            int id = (int)((Button)sender).CommandParameter;
            if (MessageBox.Show("¿Esta seguro de eliminar el artefacto?", "Eliminar Artefacto", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                objeto_CE_Inventario.IdInventario = id;
                objeto_CN_Inventario.Eliminar(objeto_CE_Inventario);
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
            tbCantidad.Clear();
            tbID.Clear();
            cbArtefacto.SelectedIndex = -1;
            cbArtefacto.IsEnabled = true;
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