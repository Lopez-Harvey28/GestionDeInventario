using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeInventario
{
    public class Inventario
    {
        private List<Producto> Productos;

        public Inventario()
        {
            Productos = new List<Producto>();
        }

        public void AgregarProductos(Producto producto)
        {
            Productos.Add(producto);
        }

        public IEnumerable<Producto> FiltrarYOrdenarProductos(decimal precioMinimo)
        {
            return Productos
                .Where(p => p.Precio > precioMinimo)
                .OrderBy(p => p.Precio);

        }

        public void ActualizarPrecio(string nombre, decimal nuevoPrecio)
        {
            int indiceProducto = Productos.FindIndex(p => p.Nombre == nombre);
            if (indiceProducto != -1)
            {
                Productos[indiceProducto].Precio = nuevoPrecio;
                Console.WriteLine("El precio del producto ha sido actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("(!) Ups... Producto no encontrado...");
            }

        }

        public void EliminarProducto(string nombre)
        {
            int indiceProducto = Productos.FindIndex(p => p.Nombre == nombre);
            if (indiceProducto != -1)
            {
                Productos.Remove(Productos[indiceProducto]);
                Console.WriteLine("El producto ha sido eliminado del inventario.");
            }
            else
            {
                Console.WriteLine("(!) Ups... Producto no encontrado...");
            }
        }

        //cuenta productos cuyo precio esta entre 0-100
        public IEnumerable<Producto> ContarProductos1()
        {
            return Productos.Where(p => p.Precio > 0 && p.Precio <= 100)
                .OrderBy(p => p.Precio);
                
        }

        public IEnumerable<Producto> ContarProductos2()
        {
            return Productos.Where(p => p.Precio > 100 && p.Precio <= 500)
                .OrderBy(p => p.Precio);

        }

        public IEnumerable<Producto> ContarProductos3()
        {
            return Productos.Where(p => p.Precio > 500)
                .OrderBy(p => p.Precio);

        }

        public void PrecioPromedio()
        {
            var precioPromedio = Productos.Average(p => p.Precio);
            Console.WriteLine($"Precio promedio de los productos: ${precioPromedio}");
        }

        public void PrecioAlto()
        {
            var precioMax = Productos.Max(p => p.Precio);
            Console.WriteLine($"El precio más alto de los productos es de: ${precioMax}");
        }

        public void PrecioBajo()
        {
            var precioMin = Productos.Min(p => p.Precio);
            Console.WriteLine($"El precio más bajo de los productos es de: ${precioMin}");
        }

        public void CantidadProductos()
        {
            var cantidadProductos = Productos.Count();
            Console.WriteLine($"La cantidad de productos en el inventario es de: {cantidadProductos}");
        }
    }

}
