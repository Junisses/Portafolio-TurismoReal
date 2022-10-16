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
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : UserControl
    {
        readonly CN_Usuarios objeto_CN_Usuarios = new CN_Usuarios();
        readonly CN_TipoUsuarioFK objeto_CN_TipoUsuarioFK = new CN_TipoUsuarioFK();

        public Clientes()
        {
            InitializeComponent();
            CargarDatos();
        }

        #region CARGAR CLIENTES
        void CargarDatos()
        {
            GridDatos.ItemsSource = objeto_CN_Usuarios.CargarClientes().DefaultView;
        }
        #endregion

        #region FUNCION BUSCAR
        #region Limpiar
        public void LimpiarData()
        {
            tbBuscar.Clear();
            tbRut.Clear();
        }

        #endregion
        private void Ver(object sender, RoutedEventArgs e)
        {
            if (tbBuscar.Text != "")
            {
                GridDatos.ItemsSource = objeto_CN_Usuarios.Buscar(tbBuscar.Text).DefaultView;
            }
            else if (tbRut.Text != "")
            {
                GridDatos.ItemsSource = objeto_CN_Usuarios.BuscarRut(tbRut.Text).DefaultView;
            }
            LimpiarData();
        }
        #endregion
    }
}
