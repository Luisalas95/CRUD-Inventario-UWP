using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PruebaTecnica.Models;
using System.Linq;


namespace PruebaTecnica.Models
{
    public class InventarioModel
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public string Categoria {  get; set; }
        public int Cantidad { get; set; }
        public  decimal Precio {  get; set; } 

    }
}
