using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PruebaTecnica.Models;
using PruebaTecnica.ViewModels;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace PruebaTecnica.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class vInventario : Page
    {
        public vInventario()
        {
            this.InitializeComponent();

        }
        private void InsertarProducto_Click(object sender, RoutedEventArgs e)
        {
            // Redirigir a la página vAgregarInventario.xaml
            Frame.Navigate(typeof(vAgregarInventario));
        }

        private async void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            // Objeto de datos asociado a la fila en la que se hizo clic en el botón "Eliminar"
            Button button = sender as Button;
            InventarioModel inventario = button.CommandParameter as InventarioModel;

            // Validación para asegurarse de que el objeto no sea nulo
            if (inventario == null)
            {
                // Mensaje de error en la consola.
                Console.WriteLine("Objeto de inventario nulo. No se puede eliminar.");
                return; // Salir del método si el objeto es nulo.
            }

            // Mostrar un cuadro de diálogo de confirmación
            var confirmDialog = new ConfirmDeleteDialog();
            var result = await confirmDialog.ShowAsync();

            if (result == ContentDialogResult.Primary) // Si el usuario seleccionó "Sí"
            {
                // Acceder a la propiedad ViewModel para obtener la instancia de la vista modelo
                var viewModel = DataContext as vm_Inventario;

                // Validación adicional si la vista modelo no está configurada correctamente
                if (viewModel == null)
                {
                    
                    Console.WriteLine("ViewModel nulo. No se puede eliminar.");
                    return; // Salir del método si el ViewModel es nulo.
                }

                // Llamar a la función "BorrarInventario" en la vista modelo
                viewModel.BorrarInventario(inventario);
                Frame.Navigate(typeof(vInventario));

            }
        }
        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            // Obtén el objeto de datos asociado a la fila en la que se hizo clic en el botón "Editar"
            Button button = sender as Button;
            InventarioModel inventario = button.CommandParameter as InventarioModel;

            // Aquí redirige a la página de edición (vEditarInventario.xaml) y pasa los datos del elemento seleccionado
            Frame.Navigate(typeof(vEditarInventario), inventario);
        }

    }
}
