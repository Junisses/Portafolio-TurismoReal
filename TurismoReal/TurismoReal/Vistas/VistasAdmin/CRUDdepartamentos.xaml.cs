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
            CargarE();
        }

        #region Cargar FK
        void CargarE()
        {
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
                int estadoDepto = objeto_CN_EstadoDepto.IdEstadoDepto(cbEstadoDepto.Text);
                int comuna = objeto_CN_Comuna.IdComuna(cbComuna.Text);

                objeto_CE_Departamentos.Descripcion = tbNombreDepto.Text;
                objeto_CE_Departamentos.Direccion = tbDireccion.Text;
                objeto_CE_Departamentos.CantHabitaciones = int.Parse(tbCantHabitaciones.Text);
                objeto_CE_Departamentos.CantBanos = int.Parse(tbCantBanos.Text);
                objeto_CE_Departamentos.PrecioNoche = int.Parse(tbPrecio.Text);
                objeto_CE_Departamentos.IdComuna = comuna; 
                objeto_CE_Departamentos.IdEstadoDepto = estadoDepto;

                objeto_CN_Departamentos.Insertar(objeto_CE_Departamentos);

                Content = new Departamentos();
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
                int estadoDepto = objeto_CN_EstadoDepto.IdEstadoDepto(cbEstadoDepto.Text);
                int comuna = objeto_CN_Comuna.IdComuna(cbComuna.Text);

                objeto_CE_Departamentos.IdDepartamento = idDepartamento;
                objeto_CE_Departamentos.Descripcion = tbNombreDepto.Text;
                objeto_CE_Departamentos.IdComuna = comuna; 
                objeto_CE_Departamentos.Direccion = tbDireccion.Text;
                objeto_CE_Departamentos.CantHabitaciones = int.Parse(tbCantHabitaciones.Text);
                objeto_CE_Departamentos.CantBanos = int.Parse(tbCantBanos.Text);
                objeto_CE_Departamentos.PrecioNoche = int.Parse(tbPrecio.Text);
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
            var d = objeto_CN_EstadoDepto.NombreEstado(a.IdEstadoDepto);

            tbNombreDepto.Text = a.Descripcion.ToString();
            MostrarComuna(a.IdComuna);
            tbDireccion.Text = a.Direccion.ToString();
            tbCantHabitaciones.Text = a.CantHabitaciones.ToString();
            tbCantBanos.Text = a.CantBanos.ToString();
            tbPrecio.Text = a.PrecioNoche.ToString();
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

        #region Galeria
        public void BtnGaleria_Click(object sender, RoutedEventArgs e)
        {
            ImagenesDepto ventana = new ImagenesDepto();
            ventana.idDepartamento = idDepartamento;
            FrameGaleria.Content = ventana;
            ventana.BtnActualizar.IsEnabled = false;
            ventana.tbIDdepto.Text = " " + idDepartamento;
            ventana.Titulo.Text = "Galeria Depto. N°" + idDepartamento;
        }
        #endregion

        #region Combobox Anidado
        private void Anidado(object sender, RoutedEventArgs e)
        {
            if (cbComuna.Text == "")
            {
                CargarRegion();
            }
            else
            {
                var a = objeto_CN_Departamentos.Consulta(idDepartamento);
                var c = objeto_CN_Comuna.NombreComuna(a.IdComuna);
                MostrarComuna(a.IdComuna);
                cbRegion.DataContext = objeto_CN_Comuna.MostrarRegion(a.IdComuna);
                cbRegion.SelectedIndex = c.IdRegion - 1;
                CargarRegion();
            }
        }

        public void CargarRegion()
        {
            cbRegion.DisplayMemberPath = "region";
            cbRegion.SelectedValuePath = "idRegion";
            cbRegion.DataContext = objeto_CN_Region.listaRegiones();
        }

        private void Region(object sender, SelectionChangedEventArgs e)
        {
            if (cbComuna.Text == "")
            {
                string regionid = cbRegion.SelectedValue.ToString();
                int idRegion = Convert.ToInt32(regionid);
                CargarComuna(idRegion);
            }
        }

        public void CargarComuna(int idRegion)
        {
            cbComuna.DisplayMemberPath = "comuna";
            cbComuna.SelectedValuePath = "idComuna";
            cbComuna.DataContext = objeto_CN_Comuna.ListarComunas(idRegion);
        }

        public void MostrarComuna(int idComuna)
        {
            cbComuna.DataContext = objeto_CN_Comuna.MostrarComuna(idComuna);
            cbComuna.SelectedIndex = 0;
        }

        #endregion

        private void BtnMantencion_Click(object sender, RoutedEventArgs e)
        {
            Mantencion ventana = new Mantencion();
            ventana.idDepartamento = idDepartamento;
            FrameGaleria.Content = ventana;
            ventana.tbIDdepto.Text = " " + idDepartamento;
            ventana.Titulo.Text = "Mantención Depto. N°" + idDepartamento;
        }
    }
}
