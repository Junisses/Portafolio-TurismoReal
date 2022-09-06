using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidad.Clases
{
    public class CE_Departamentos
    {
        private int _IdDepartamento;
        private string _Descripcion;
        private string _Direccion;
        private int _CantHabitaciones;
        private int _CantBanos;
        private int _PrecioNoche;
        private string EstadoDepto;
        private DateTime _FechaEstadoDepto;
        private int _IdComuna;

        public int IdDepartamento { get => _IdDepartamento; set => _IdDepartamento = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public int CantHabitaciones { get => _CantHabitaciones; set => _CantHabitaciones = value; }
        public int CantBanos { get => _CantBanos; set => _CantBanos = value; }
        public int PrecioNoche { get => _PrecioNoche; set => _PrecioNoche = value; }
        public string EstadoDepto1 { get => EstadoDepto; set => EstadoDepto = value; }
        public DateTime FechaEstadoDepto { get => _FechaEstadoDepto; set => _FechaEstadoDepto = value; }
        public int IdComuna { get => _IdComuna; set => _IdComuna = value; }
    }
}
