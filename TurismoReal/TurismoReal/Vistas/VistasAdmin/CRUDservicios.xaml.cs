using CapaDeEntidad.Clases;
using CapaDeNegocio.Clases;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TurismoReal.Vistas.VistasAdmin
{
    /// <summary>
    /// Lógica de interacción para CRUDservicios.xaml
    /// </summary>
    public partial class CRUDservicios : Page
    {
        readonly CN_Servicios objeto_CN_Servicios = new CN_Servicios();
        readonly CE_Servicios objeto_CE_Servicios = new CE_Servicios();
        readonly CN_TipoServicio objeto_CN_TipoServicio = new CN_TipoServicio();

        public CRUDservicios()
        {
            InitializeComponent();
            CargarTP();
        }

        #region Cargar FK
        void CargarTP()
        {
            List<string> tiposervicio = objeto_CN_TipoServicio.ListarTipoServicio();
            for (int i = 0; i < tiposervicio.Count; i++)
            {
                cbTipoServicio.Items.Add(tiposervicio[i]);
            }
        }
        #endregion

        #region Resgresar
        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Servicios();
        }
        #endregion

        #region ValidarCamposVacios
        public bool CamposLlenos()
        {
            if (tbDescripcion.Text == ""
                || tbPrecio.Text == ""
                || cbTipoServicio.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #region Disponibilidad
        private void Disponible_Check(object sender, RoutedEventArgs e)
        {
            string disp;
            if (ckbDisponible.IsChecked == true)
            {
                disp = "Disponible";
            }
            else
            {
                disp = "No Disponible";
            }
        }

        #endregion
        #endregion


        #region CREAR
        public int idServicio;
        private void Crear(object sender, RoutedEventArgs e)
        {
            if (CamposLlenos() == true)
            {
                try
                {
                    int tiposervicio = objeto_CN_TipoServicio.IdTipoServicio(cbTipoServicio.Text);

                    objeto_CE_Servicios.Descripcion = tbDescripcion.Text;
                    if (ckbDisponible.IsChecked == true)
                    {
                        objeto_CE_Servicios.Disponibilidad = "Disponible";
                    }
                    else
                    {
                        objeto_CE_Servicios.Disponibilidad = "No Disponible";
                    }
                    objeto_CE_Servicios.Precio = int.Parse(tbPrecio.Text);
                    objeto_CE_Servicios.IdTipoServicio = tiposervicio;

                    objeto_CN_Servicios.Insertar(objeto_CE_Servicios);

                    Content = new Servicios();
                }
                catch
                {
                    MessageBox.Show("No pueden quedar campos vacíos!");
                }
            }
            else
            {
                MessageBox.Show("No se pudo ingresar el servicio,\n revise los datos e intentelo denuevo");
            }
        }
        #endregion

        #region Actualizar
        private void Actualizar(object sender, RoutedEventArgs e)
        {
            if (CamposLlenos() == true)
            {
                int tiposervicio = objeto_CN_TipoServicio.IdTipoServicio(cbTipoServicio.Text);

                objeto_CE_Servicios.IdServicio = idServicio;
                objeto_CE_Servicios.Descripcion = tbDescripcion.Text;
                if (ckbDisponible.IsChecked == true)
                {
                    objeto_CE_Servicios.Disponibilidad = "Disponible";
                }
                else
                {
                    objeto_CE_Servicios.Disponibilidad = "No Disponible";
                }
                objeto_CE_Servicios.Precio = int.Parse(tbPrecio.Text);
                objeto_CE_Servicios.IdTipoServicio = tiposervicio;

                objeto_CN_Servicios.ActualizarDatos(objeto_CE_Servicios);
                Content = new Servicios();
            }
            else
            {
                MessageBox.Show("Por favor, no dejar campos vacios");
            }
        }
        #endregion

        #region Consultar
        public void Consultar()
        {
            var a = objeto_CN_Servicios.Consulta(idServicio);
            var ts = objeto_CN_TipoServicio.NombreTipoServicio(a.IdTipoServicio);

            BtnTipoServicio.IsEnabled = false;
            tbDescripcion.Text = a.Descripcion.ToString();
            tbPrecio.Text = a.Precio.ToString();
            cbTipoServicio.Text = ts.TipoServicio.ToString();
            if (a.Disponibilidad == "Disponible")
            {
                ckbDisponible.IsChecked = true;
            }
            else
            {
                ckbDisponible.IsChecked = false;
            }
        }
        #endregion

        #region Eliminar
        private void Eliminar(object sender, RoutedEventArgs e)
        {
            objeto_CE_Servicios.IdServicio = idServicio;

            objeto_CN_Servicios.Eliminar(objeto_CE_Servicios);

            Content = new Servicios();
        }
        #endregion

        private void BtnTipoServicio_Click(object sender, RoutedEventArgs e)
        {
            Content = new TipoServicio();
        }
    }
}