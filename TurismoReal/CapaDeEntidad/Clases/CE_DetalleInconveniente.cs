﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidad.Clases
{
    public class CE_DetalleInconveniente
    {
        private int _IdDetalleInconveniente;
        private string _Detalle;
        private int _Monto;
        private int _IdReserva;

        public int IdDetalleInconveniente { get => _IdDetalleInconveniente; set => _IdDetalleInconveniente = value; }
        public string Detalle { get => _Detalle; set => _Detalle = value; }
        public int Monto { get => _Monto; set => _Monto = value; }
        public int IdReserva { get => _IdReserva; set => _IdReserva = value; }
    }
}
