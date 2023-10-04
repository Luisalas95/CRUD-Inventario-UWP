using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using PruebaTecnica.Models;
using PruebaTecnica.ViewModels;
using Windows.UI.Xaml.Media;
using Windows.UI;
using System.Globalization;

namespace PruebaTecnica.Views
{
    public sealed partial class vAgregarInventario : Page
    {
        private vm_AgregarInventario ViewModel { get; set; }

        public vAgregarInventario()
        {
            this.InitializeComponent();
            ViewModel = new vm_AgregarInventario();
        }

        private void Cantidad_LostFocus(object sender, RoutedEventArgs e)
        {
            // Validar si la entrada en "Cantidad" es un número entero válido
            if (!int.TryParse(Cantidad.Text, out _))
            {
                // Mostrar un mensaje de error al usuario
                Mensaje.Text = "La Cantidad debe ser un número entero válido.";
                Mensaje.Foreground = new SolidColorBrush(Colors.Red);
                Mensaje.Visibility = Visibility.Visible;
            }
            else
            {
                // Limpiar el mensaje de error si la entrada es válida
                Mensaje.Visibility = Visibility.Collapsed;
            }
        }

        private void Precio_LostFocus(object sender, RoutedEventArgs e)
        {
            // Validar si la entrada en "Precio" es un valor decimal válido
            if (!decimal.TryParse(Precio.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out _))
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

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            string nombreProducto = NombreProducto.Text;
            string categoria = Categoria.Text;
            int cantidad;
            decimal precio;

            if (int.TryParse(Cantidad.Text, out cantidad) && decimal.TryParse(Precio.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out precio))
            {
                // Aquí obtén los valores ingresados por el usuario y llama a la función AgregarInventario del contexto de la base de datos
                InventarioModel nuevoProducto = new InventarioModel
                {
                    NombreProducto = nombreProducto,
                    Categoria = categoria,
                    Cantidad = cantidad,
                    Precio = precio
                };

                // Llama al método InsertarInventario del ViewModel para agregar el nuevo producto
                ViewModel.InsertarInventario(nuevoProducto);

                // Mostrar el mensaje "Producto agregado con éxito."
                Mensaje.Text = "Producto agregado con éxito.";
                Mensaje.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                Mensaje.Visibility = Visibility.Visible;
            }
            else
            {
                // Mostrar un mensaje de error si la entrada no es válida
                Mensaje.Text = "Por favor, ingrese valores válidos en Cantidad y Precio.";
                Mensaje.Foreground = new SolidColorBrush(Colors.Red);
                Mensaje.Visibility = Visibility.Visible;
            }
        }

        private void Regresar_Click(object sender, RoutedEventArgs e)
        {
            // Aquí puedes redirigir a la página vAgregarInventario.xaml
            Frame.Navigate(typeof(vInventario));
        }
    }
}
