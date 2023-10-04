using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Views;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace PruebaTecnica.Models
{
    public class PruebaTecnicaUWP : DbContext
    {
        public DbSet<InventarioModel> Inventario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2CG0BTV;Database=PruebaTecnicaUWP;Trusted_Connection=True");
        }

        public virtual void InsertarInventario(string NombreProducto, string Categoria, int Cantidad, decimal Precio)
        {
            // Declarar los parámetros y asignar valores
            var nombreProductoParam = new SqlParameter("@NombreProducto", NombreProducto);
            var categoriaParam = new SqlParameter("@Categoria", Categoria);
            var cantidadParam = new SqlParameter("@Cantidad", Cantidad);
            var precioParam = new SqlParameter("@Precio", Precio);

            Database.ExecuteSqlCommand("EXEC InsertarInventario @NombreProducto, @Categoria, @Cantidad, @Precio", nombreProductoParam, categoriaParam, cantidadParam, precioParam);
        }

        public virtual void BorrarInventario(string NombreProducto)
        {
            var nombreProductoParam = new SqlParameter("@NombreProducto", NombreProducto);
            Database.ExecuteSqlCommand("EXEC BorrarInventario @NombreProducto", nombreProductoParam);
        }

        public virtual void ActualizarInventario(string NombreProducto, string Categoria, int Cantidad, decimal Precio)
        {
            // Declarar los parámetros y asignar valores
            var nombreProductoParam = new SqlParameter("@NombreProducto", NombreProducto);
            var categoriaParam = new SqlParameter("@Categoria", Categoria);
            var cantidadParam = new SqlParameter("@Cantidad", Cantidad);
            var precioParam = new SqlParameter("@Precio", Precio);

            Database.ExecuteSqlCommand("EXEC ActualizarInventario @NombreProducto, @Categoria, @Cantidad, @Precio", nombreProductoParam, categoriaParam, cantidadParam, precioParam);
        }

        public List<InventarioModel> ObtenerInventario()
        {
            using (var dbContext = new PruebaTecnicaUWP()) 
            {
                var inventario = dbContext.Inventario.ToList();

                return inventario;
            }
        }

    }
}
