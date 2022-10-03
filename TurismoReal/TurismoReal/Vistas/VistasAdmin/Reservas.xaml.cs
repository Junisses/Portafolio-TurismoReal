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
    }

}
