using AppPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppPrueba.ViewModels
{
    public class VentaViewModel
    {
        public int Id { get; set; }
        public string CodigoVenta { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

    }
}
