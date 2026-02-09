using System;
using System.Collections.Generic; 

namespace FarmaciaJuan
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<string> nombres = new List<string>();
            List<int> cantidades = new List<int>();
            List<double> precios = new List<double>();
            
            double totalVentas = 0;
            string opcion = "";

            
            while (opcion != "5")
            {
                Console.WriteLine("\n--- FARMACIA DE JUAN ---");
                Console.WriteLine("1. Registrar medicamento");
                Console.WriteLine("2. Consultar inventario");
                Console.WriteLine("3. Vender medicamento");
                Console.WriteLine("4. Ver total de ventas");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();

                
                if (opcion == "1")
                {
                    RegistrarMedicamento(nombres, cantidades, precios);
                }
                else if (opcion == "2")
                {
                    ConsultarInventario(nombres, cantidades, precios);
                }
                else if (opcion == "3")
                {
                    
                    totalVentas = VenderMedicamento(nombres, cantidades, precios, totalVentas);
                }
                else if (opcion == "4")
                {
                    MostrarTotalVentas(totalVentas);
                }
                else if (opcion == "5")
                {
                    Console.WriteLine("Saliendo del programa...");
                }
                else
                {
                    Console.WriteLine("Opción no válida.");
                }
            }
        }

        
        static void RegistrarMedicamento(List<string> nombres, List<int> cantidades, List<double> precios)
        {
            Console.Write("Ingrese el nombre del medicamento: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la cantidad: ");
            int cantidad = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el precio unitario: ");
            double precio = double.Parse(Console.ReadLine());

            
            nombres.Add(nombre);
            cantidades.Add(cantidad);
            precios.Add(precio);

            Console.WriteLine("¡Medicamento registrado con éxito!");
        }

        
        static void ConsultarInventario(List<string> nombres, List<int> cantidades, List<double> precios)
        {
            Console.WriteLine("\n--- INVENTARIO ACTUAL ---");
            if (nombres.Count == 0)
            {
                Console.WriteLine("No hay medicamentos registrados.");
                return;
            }

            for (int i = 0; i < nombres.Count; i++)
            {
                Console.WriteLine($"Medicamento: {nombres[i]} | Cantidad: {cantidades[i]} | Precio: {precios[i]}");
            }
        }

        
        static double VenderMedicamento(List<string> nombres, List<int> cantidades, List<double> precios, double totalVentas)
        {
            Console.Write("Ingrese el nombre del medicamento a vender: ");
            string nombreBusqueda = Console.ReadLine();

            int indice = -1; 

            
            for (int i = 0; i < nombres.Count; i++)
            {
                if (nombres[i].ToLower() == nombreBusqueda.ToLower())
                {
                    indice = i;
                    break;
                }
            }

            
            if (indice == -1)
            {
                Console.WriteLine("Error: El medicamento no existe en el inventario.");
                return totalVentas;
            }

            Console.Write($"Cantidad disponible: {cantidades[indice]}. Ingrese cantidad a vender: ");
            int cantidadVenta = int.Parse(Console.ReadLine());

            
            if (cantidadVenta > cantidades[indice])
            {
                Console.WriteLine("Error: No hay suficiente stock para realizar la venta.");
            }
            else if (cantidadVenta <= 0)
            {
                Console.WriteLine("Error: La cantidad a vender debe ser mayor a 0.");
            }
            else
            {
                
                cantidades[indice] -= cantidadVenta;
                
                
                double costoVenta = cantidadVenta * precios[indice];
                totalVentas += costoVenta;

                Console.WriteLine($"Venta exitosa. Total de esta venta: {costoVenta}");
                Console.WriteLine($"Stock actual de {nombres[indice]}: {cantidades[indice]}");
            }

            return totalVentas;
        }

        
        static void MostrarTotalVentas(double totalVentas)
        {
            Console.WriteLine($"\nEl total de ventas realizadas en el día es: {totalVentas}");
        }
    }
}