using System;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace GestionDeInventario
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            Console.WriteLine("*=======* BIENVENIDOS AL SISTEMA DE GESTION DE INVENTARIO *=======*");
            bool j = true;
            bool aux; 
            do
            {
                Console.WriteLine("\n*====* Seleccione una opcion *====*");
                Console.WriteLine("*--* 1.Agregar productos\n*--* 2.Actualizar precio de producto");
                Console.WriteLine("*--* 3.Eliminar producto\n*--* 4.Ver inventario clasificado por precios");
                Console.WriteLine("*--* 5.Generar reporte de inventario\n*--* 6.Salir");
                Console.Write("opcion --> ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Write("\nCuántos productos desea agregar? --> ");
                        int cantidad = int.Parse(Console.ReadLine());
                        for (int i = 0; i < cantidad; i++)
                        {
                            Console.WriteLine($"\nProducto {i + 1}: ");
                            
                            //verificar que el nombre no sea vacio
                            string nombre = string.Empty;
                            while (string.IsNullOrWhiteSpace(nombre))
                            {
                                Console.Write("Nombre: ");
                                nombre = Console.ReadLine();
                            }
                            
                            //verificar que el precio sea positivo
                            decimal precio = 0;
                            aux = true;
                            while (aux)
                            {
                                Console.Write("Precio: ");
                                precio = decimal.Parse(Console.ReadLine());
                                aux = (precio > 0) ? false : true;  
                            }
                            
                            Producto producto = new Producto(nombre, precio);
                            inventario.AgregarProductos(producto);
                        }
                        break;
                    case 2:
                        //verificar que el nombre no sea vacio
                        string nombreProducto = string.Empty;
                        while (string.IsNullOrWhiteSpace(nombreProducto))
                        {
                            Console.Write("\nIngrese el nombre del producto al que desea actualizar el precio: ");
                            nombreProducto = Console.ReadLine();
                        }

                        //verificar que el nuevo precio sea positivo
                        decimal precioNuevo = 0;
                        aux = true;
                        while (aux)
                        {
                            Console.Write("Precio nuevo: ");
                            precioNuevo = decimal.Parse(Console.ReadLine());
                            aux = (precioNuevo > 0) ? false : true;
                        } 
                        
                        inventario.ActualizarPrecio(nombreProducto, precioNuevo);
                        break;
                    case 3:
                        //verificar que el nombre no sea vacio
                        string productoEliminar = string.Empty;
                        while (string.IsNullOrWhiteSpace(productoEliminar))
                        {
                            Console.Write("\nIngrese el nombre del producto que desea eliminar del inventario: ");
                            productoEliminar = Console.ReadLine();
                        }

                        inventario.EliminarProducto(productoEliminar);
                        break;
                    case 4:
                        Console.WriteLine("\n-------------------------------------------------------");
                        Console.WriteLine("\n*====* I N V E N T A R I O *====*");
                        //productos cuyo precio esta entre 1-100
                        var GrupoProductos1 = inventario.ContarProductos1();
                        Console.WriteLine("\n*----* Productos con precio entre $1-$100 *----*");
                        foreach (var producto in GrupoProductos1)
                        {
                            producto.MostrarInformacion();
                        }

                        //productos cuyo precio esta entre 101-500
                        var GrupoProductos2 = inventario.ContarProductos2();
                        Console.WriteLine("\n*----* Productos con precio entre $101-$500 *----*");
                        foreach (var producto in GrupoProductos2)
                        {
                            producto.MostrarInformacion();
                        }

                        //productos cuyo precio es de +500
                        var GrupoProductos3 = inventario.ContarProductos3();
                        Console.WriteLine("\n*---* Productos con precio mayor a $500 *---*");
                        foreach(var producto in GrupoProductos3)
                        {
                            producto.MostrarInformacion();
                        }
                        break;
                    case 5:
                        Console.WriteLine("\n-------------------------------------------------------");
                        Console.WriteLine("          *====* Reporte de inventario *====*");
                        Console.WriteLine("\n........Total de productos en el inventario........");
                        inventario.CantidadProductos();
                        
                        Console.WriteLine("\n.......Precio promedio de todos los productos......");
                        inventario.PrecioPromedio();
                        
                        Console.WriteLine("\n..........Producto con el precio más alto..........");
                        inventario.PrecioAlto();
                        
                        Console.WriteLine("\n..........Producto con el precio más bajo..........");
                        inventario.PrecioBajo();
                        break;
                    case 6:
                        Console.WriteLine("guardando...");
                        j = false;
                        break;
                    default:
                        Console.WriteLine("(!) Ups... ha ocurrido un error....");
                        break;
                }
            }
            while (j);



        }
            
    }
}