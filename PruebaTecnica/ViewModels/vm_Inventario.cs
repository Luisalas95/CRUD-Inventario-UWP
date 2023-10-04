using PruebaTecnica.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Data.SqlClient;

namespace PruebaTecnica.ViewModels
{
    public class vm_Inventario: INotifyPropertyChanged
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

      
        public vm_Inventario()
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


        // Métodos para realizar operaciones CRUD en los productos (Agregar, Modificar, Eliminar, Buscar)
        public void InsertarInventario(InventarioModel inventario)
        {
            using (var dbContext = new PruebaTecnicaUWP()) 
            {
                dbContext.InsertarInventario(inventario.NombreProducto, inventario.Categoria, inventario.Cantidad, inventario.Precio);
            }
        }

        public void BorrarInventario(InventarioModel inventario)
        {
            using (var dbContext = new PruebaTecnicaUWP())
            {
                dbContext.BorrarInventario(inventario.NombreProducto);
            }
        }

        public void ActualizarInventario(InventarioModel inventario)
        {
            using (var dbContext = new PruebaTecnicaUWP())
            {
                dbContext.ActualizarInventario(inventario.NombreProducto, inventario.Categoria, inventario.Cantidad, inventario.Precio);
            }
        }

        public void ObtenerInventario(InventarioModel inventario)
        {
            //Connection();
            using (var dbContext = new PruebaTecnicaUWP())
            {
                dbContext.ObtenerInventario();
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
