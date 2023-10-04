using PruebaTecnica.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Data.SqlClient;

namespace PruebaTecnica.ViewModels
{
    public class vm_AgregarInventario
    {
        private ObservableCollection<InventarioModel> V_inventario;

        public ObservableCollection<InventarioModel> Inventario
        {
            get { return V_inventario; }
            set
            {
                V_inventario = value;
                OnPropertyChanged();
            }
        }

        
        public vm_AgregarInventario()
        {
            Inventario = new ObservableCollection<InventarioModel>();

            using (var V_dbContext = new PruebaTecnicaUWP())
            {
                var productosDesdeBD = V_dbContext.Inventario.ToList();

                foreach (var inventario in productosDesdeBD)
                {
                    Inventario.Add(inventario);
                }
            }
        }


        // Métodos para realizar operaciones Agregar productos
        public void InsertarInventario(InventarioModel inventario)
        {
            // Connection();
            using (var dbContext = new PruebaTecnicaUWP())
            {
                dbContext.InsertarInventario(inventario.NombreProducto, inventario.Categoria, inventario.Cantidad, inventario.Precio);
            }
        }

     
        // Implementación de INotifyPropertyChanged para notificar cambios en las propiedades
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
