using System;

namespace GestionDeInventario
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            Console.WriteLine("*=======* BIENVENIDOS AL SISTEMA DE GESTION DE INVENTARIO *=======*");

            Console.Write("Cuántos productos desea ingresar? --> ");
            int cantidad = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\nProducto {i + 1}: ");
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Precio: ");
                decimal precio = decimal.Parse(Console.ReadLine());

                Producto producto = new Producto(nombre, precio);
                inventario.AgregarProductos(producto);
            }

            Console.Write("\nIngrese el precio mínimo para filtrar los productos: ");
            decimal precioMinimo = decimal.Parse(Console.ReadLine());

            var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);
            Console.WriteLine("\n----Productos filtrados y ordenados por precio: ");
            foreach(var producto in productosFiltrados)
            {
                producto.MostrarInformacion();
            }
        }
    }
}