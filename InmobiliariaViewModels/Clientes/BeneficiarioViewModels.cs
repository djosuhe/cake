﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaViewModels.Clientes
{
   public class BeneficiarioViewModels
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dpi { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }

        public int ClienteId { get; set; }
    }
}
