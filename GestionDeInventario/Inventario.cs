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
    }
}
