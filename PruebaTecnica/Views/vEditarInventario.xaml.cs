using PruebaTecnica.Models;
using PruebaTecnica.ViewModels;
using System.Globalization;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PruebaTecnica.Views
{
    public sealed partial class vEditarInventario : Page
    {
        private InventarioModel L_inventario;

        private vm_EditarInventario ViewModel { get; set; }

        public vEditarInventario()
        {
            this.InitializeComponent();
            ViewModel = new vm_EditarInventario();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e.Parameter is InventarioModel)
            {

                // Recibe el objeto InventarioModel desde vInventario.xaml
                L_inventario = e.Parameter as InventarioModel;

                // Rellena los TextBox con los datos del inventario
                NombreProductoTextBox.Text = L_inventario.NombreProducto;
                CategoriaTextBox.Text = L_inventario.Categoria;
                CantidadTextBox.Text = L_inventario.Cantidad.ToString(); // Convierte a cadena
                PrecioTextBox.Text = L_inventario.Precio.ToString();   // Convierte a cadena
            }
        }
        private void Precio_LostFocus(object sender, RoutedEventArgs e)
        {
            // Validar si la entrada en "Precio" es un valor decimal válido
            if (!decimal.TryParse(PrecioTextBox.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out _))
            {
                // Mostrar un mensaje de error al usuario
                Mensaje.Text = "El Precio debe ser un valor decimal válido.";
                Mensaje.Foreground = new SolidColorBrush(Colors.Red);
                Mensaje.Visibility = Visibility.Visible;
            }
            else
            {
                // Limpiar el mensaje de error si la entrada es válida
                Mensaje.Visibility = Visibility.Collapsed;
            }
        }
        private async void GuardarCambios_Click(object sender, RoutedEventArgs e)
        {
            string nombreProducto = NombreProductoTextBox.Text;
            string categoria = CategoriaTextBox.Text;
            int cantidad;
            decimal precio;

            // Validar si la entrada en "Cantidad" es un número entero válido
            if (!int.TryParse(CantidadTextBox.Text, out cantidad))
            {
                // Mostrar un mensaje de error al usuario
                MensajeActualizacion.Text = "La Cantidad debe ser un número entero válido.";
                MensajeActualizacion.Foreground = new SolidColorBrush(Colors.Red);
                MensajeActualizacion.Visibility = Visibility.Visible;
                return; // Salir del método si la validación falla
            }

            // Validar si la entrada en "Precio" es un valor decimal válido
            if (!decimal.TryParse(PrecioTextBox.Text, out precio))
            {
                // Mostrar un mensaje de error al usuario
                MensajeActualizacion.Text = "El Precio debe ser un valor decimal válido.";
                MensajeActualizacion.Foreground = new SolidColorBrush(Colors.Red);
                MensajeActualizacion.Visibility = Visibility.Visible;
                return; // Salir del método si la validación falla
            }

            // Aquí puedes obtener los valores ingresados por el usuario y llama a la función ActualizarInventario del ViewModel con los valores actualizados

            // Asigna los valores editados al objeto InventarioModel existente
            L_inventario.NombreProducto = nombreProducto;
            L_inventario.Categoria = categoria;
            L_inventario.Cantidad = cantidad;
            L_inventario.Precio = precio;

            // Llama al método ActualizarInventario con el objeto InventarioModel actualizado
            ViewModel.ActualizarInventario(L_inventario);

            // Muestra el mensaje de éxito
            MensajeActualizacion.Text = "Datos actualizados con éxito.";
            MensajeActualizacion.Foreground = new SolidColorBrush(Colors.Green);
            MensajeActualizacion.Visibility = Visibility.Visible;

            // Luego, puedes redirigir a la página vInventario.xaml para ver los cambios reflejados en el GridView
            Frame.Navigate(typeof(vInventario));
        }


    }
}
