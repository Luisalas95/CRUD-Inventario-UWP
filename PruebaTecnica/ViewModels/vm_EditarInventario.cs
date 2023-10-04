using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.ViewModels
{
    public class vm_EditarInventario
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
        // Implementación de INotifyPropertyChanged para notificar cambios en las propiedades
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ActualizarInventario(InventarioModel inventario)
        {
            using (var dbContext = new PruebaTecnicaUWP())
            {
                dbContext.ActualizarInventario(inventario.NombreProducto, inventario.Categoria, inventario.Cantidad, inventario.Precio);
            }
        }

    }
}
