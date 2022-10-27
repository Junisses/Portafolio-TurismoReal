using CapaDeEntidad.Clases;
using CapaDeNegocio.Clases;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        #region VALIDAR SOLO NÚMEROS
        private void Verificar(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }
        #endregion

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
            #region NOMBRE/DESCRIPCIÓN
            if (tbDescripcion.Text == "")
            {
                MessageBox.Show("La descripción no puede quedar vacía");
                tbDescripcion.Focus();
                return;
            }
            else if (tbDescripcion.Text != "")
            {
                if (tbDescripcion.Text.Length > 30)
                {
                    MessageBox.Show("La descripción es demasiado extensa");
                    tbDescripcion.Clear();
                    tbDescripcion.Focus();
                    return;
                }
                else if (tbDescripcion.Text.Length < 3)
                {
                    MessageBox.Show("La descripción es muy corta");
                    tbDescripcion.Clear();
                    tbDescripcion.Focus();
                    return;
                }
                //valido que se ingresen solo letras
                else if (Regex.IsMatch(tbDescripcion.Text, @"^[a-zA-Z]+$") == false)
                {
                    MessageBox.Show("La descripción solo puede contener letras");
                    tbDescripcion.Clear();
                    tbDescripcion.Focus();
                    return;
                }
            }
            #endregion

            #region PRECIO
            if (tbPrecio.Text == "")
            {
                MessageBox.Show("Debe ingresar precio del servicio");
                tbPrecio.Focus();
                return;
            }
            else if (int.Parse(tbPrecio.Text) == 0)
            {
                MessageBox.Show("El precio no puede ser 0");
                tbPrecio.Clear();
                tbPrecio.Focus();
                return;
            }
            #endregion

            #region ESTADO
            else if (cbTipoServicio.Text == "")
            {
                MessageBox.Show("Debe seleccionar un Tipo de servicio");
                return;
            }
            #endregion

            #region ESTADO DE CUENTA
            else if (ckbDisponible.IsChecked == false)
            {
                MessageBox.Show("Se ingreso un servicio que no se encuentra disponible", "INFORMACIÓN");
            }
            #endregion

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