using CapaDeNegocio.Clases;
using NPOI.SS.Formula.Functions;
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
    /// Lógica de interacción para Reservas.xaml
    /// </summary>
    public partial class Reservas : UserControl
    {
        readonly CN_Reservas objeto_CN_Reservas = new CN_Reservas();

        public Reservas()
        {
            InitializeComponent();
            CargarDatos();
        }

        #region CARGAR RESERVAS
        void CargarDatos()
        {
            GridDatos.ItemsSource = objeto_CN_Reservas.CargarReservas().DefaultView;
        }
        #endregion

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
                GridDatos.ItemsSource = objeto_CN_Reservas.BuscarN(tbBuscar.Text).DefaultView;
            }
            else if (tbRut.Text != "")
            {
                GridDatos.ItemsSource = objeto_CN_Reservas.BuscarR(tbRut.Text).DefaultView;
            }
            LimpiarData();
        }
    }

}
