using CapaDeEntidad.Clases;
using CapaDeNegocio.Clases;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TurismoReal.Vistas.VistasAdmin
{
    /// <summary>
    /// Lógica de interacción para CRUDdepartamentos.xaml
    /// </summary>
    public partial class CRUDdepartamentos : Page
    {
        readonly CN_Departamentos objeto_CN_Departamentos = new CN_Departamentos();
        readonly CE_Departamentos objeto_CE_Departamentos = new CE_Departamentos();

        readonly CN_Comuna objeto_CN_Comuna = new CN_Comuna();
        readonly CN_Region objeto_CN_Region = new CN_Region();
        readonly CN_EstadoDepto objeto_CN_EstadoDepto = new CN_EstadoDepto();

        public CRUDdepartamentos()
        {
            InitializeComponent();
            CargarRCE();
        }

        #region Cargar FK
        void CargarRCE()
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

            List<string> estadoDepto = objeto_CN_EstadoDepto.ListarEstado();
            for (int i = 0; i < estadoDepto.Count; i++)
            {
                cbEstadoDepto.Items.Add(estadoDepto[i]);
            }
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
            if (tbNombreDepto.Text == ""
                || tbDireccion.Text == ""
                || tbCantHabitaciones.Text == ""
                || tbCantBanos.Text == ""
                || tbPrecio.Text == ""
                || cbComuna.Text == ""
                || cbRegion.Text == ""
                || cFechaEstado.Text == ""
                || cbEstadoDepto.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        public int idDepartamento;
        public int idRegion;
        public int idComuna;
        #region Crear
        private void Crear(object sender, RoutedEventArgs e)
        {
            if (CamposLlenos() == true)
            {
                try
                {
                    int region = objeto_CN_Region.IdRegion(cbRegion.Text);
                    int comuna = objeto_CN_Comuna.IdComuna(cbComuna.Text);
                    int estadoDepto = objeto_CN_EstadoDepto.IdEstadoDepto(cbEstadoDepto.Text);

                    objeto_CE_Departamentos.Descripcion = tbNombreDepto.Text;
                    objeto_CE_Departamentos.Direccion = tbDireccion.Text;
                    objeto_CE_Departamentos.CantHabitaciones = int.Parse(tbCantHabitaciones.Text);
                    objeto_CE_Departamentos.CantBanos = int.Parse(tbCantBanos.Text);
                    objeto_CE_Departamentos.PrecioNoche = int.Parse(tbPrecio.Text);
                    objeto_CE_Departamentos.FechaEstadoDepto = DateTime.Parse(cFechaEstado.Text);
                    objeto_CE_Departamentos.IdComuna = comuna;
                    objeto_CE_Departamentos.IdEstadoDepto = estadoDepto;

                    objeto_CN_Departamentos.Insertar(objeto_CE_Departamentos);

                    Content = new Departamentos();
                }
                catch
                {
                    MessageBox.Show("No pueden quedar campos vacíos!");
                }
            }
            else
            {
                MessageBox.Show("No se pudo ingresar el depto,\n revise los datos e intentelo denuevo");
            }
        }
        #endregion

        #region Actualizar
        private void Actualizar(object sender, RoutedEventArgs e)
        {
            if (CamposLlenos() == true)
            {
                //int region = objeto_CN_Region.IdRegion(cbRegion.Text);
                int comuna = objeto_CN_Comuna.IdComuna(cbComuna.Text);
                int estadoDepto = objeto_CN_EstadoDepto.IdEstadoDepto(cbEstadoDepto.Text);

                objeto_CE_Departamentos.IdDepartamento = idDepartamento;
                objeto_CE_Departamentos.Descripcion = tbNombreDepto.Text;
                //objeto_CE_Departamentos.IdRegion = region;
                objeto_CE_Departamentos.IdComuna = comuna;
                objeto_CE_Departamentos.Direccion = tbDireccion.Text;
                objeto_CE_Departamentos.CantHabitaciones = int.Parse(tbCantHabitaciones.Text);
                objeto_CE_Departamentos.CantBanos = int.Parse(tbCantBanos.Text);
                objeto_CE_Departamentos.PrecioNoche = int.Parse(tbPrecio.Text);
                objeto_CE_Departamentos.FechaEstadoDepto = DateTime.Parse(cFechaEstado.Text);
                objeto_CE_Departamentos.IdEstadoDepto = estadoDepto;

                objeto_CN_Departamentos.ActualizarDatos(objeto_CE_Departamentos);

                Content = new Departamentos();
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
            var a = objeto_CN_Departamentos.Consulta(idDepartamento);
            //var r = objeto_CN_Region.NombreRegion(a.IdRegion);
            var c = objeto_CN_Comuna.NombreComuna(a.IdComuna);
            var d = objeto_CN_EstadoDepto.NombreEstado(a.IdEstadoDepto);

            tbNombreDepto.Text = a.Descripcion.ToString();
            //cbRegion.Text = r.IdRegion.ToString();
            cbComuna.Text = c.Comuna.ToString();
            tbDireccion.Text = a.Direccion.ToString();
            tbCantHabitaciones.Text = a.CantHabitaciones.ToString();
            tbCantBanos.Text = a.CantBanos.ToString();
            tbPrecio.Text = a.PrecioNoche.ToString();
            cFechaEstado.Text = a.FechaEstadoDepto.ToString();
            cbEstadoDepto.Text = d.EstadoDepto.ToString();  
        }
        #endregion

        #region Eliminar
        private void Eliminar(object sender, RoutedEventArgs e)
        {
            objeto_CE_Departamentos.IdDepartamento = idDepartamento;

            objeto_CN_Departamentos.Eliminar(objeto_CE_Departamentos);

            Content = new Departamentos();
        }
        #endregion

        public void BtnGaleria_Click(object sender, RoutedEventArgs e)
        {
            ImagenesDepto ventana = new ImagenesDepto();
            ventana.idDepartamento = idDepartamento;
            FrameGaleria.Content = ventana;
            ventana.BtnActualizar.IsEnabled = false;
            ventana.tbIDdepto.Text = " " + idDepartamento;
            ventana.Titulo.Text = "Galeria Depto. N°" + idDepartamento;
        }
    }
}
