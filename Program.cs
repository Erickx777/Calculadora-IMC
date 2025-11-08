/*CALCULADORA DE IMC. si es menor a 18.5 es bajo, si es menor a 25 es normal,
si esta por debajo de 30 es sobrepeso y si esta fuera de esos rangos, es obecidad.*/

using System;
using System.Threading.Tasks.Dataflow;
using System.Xml;

class CalculadoraIMC
{
    static void Main()
    {
        bool continuar = true;

            while (continuar)
            {

                Console.Clear();
                Console.WriteLine("\n------CALCULADORA IMC------");

            try
            {
                Console.Write("\nColoque su peso en KG: ");
                double peso = double.Parse(Console.ReadLine());

                Console.Write("Coloque su altura en metros: ");
                double altura = double.Parse(Console.ReadLine());

                double imc = peso / (altura * altura);

                Console.WriteLine("\n------RESULTADOS------");
                Console.WriteLine($"\nSu altura es: {altura}");
                Console.WriteLine($"Su peso es: {peso}");
                Console.WriteLine($"Su IMC es: {imc:F2}");

                if (imc < 18.5)
                {
                    Console.WriteLine("Tienes un peso bajo.");
                }
                else if (imc < 25)
                {
                    Console.WriteLine("Tienes un peso normal.");
                }
                else if (imc < 30)
                {
                    Console.WriteLine("Tienes Sobrepeso");
                }
                else
                {
                    Console.WriteLine("Tienes Obecidad.");
                }
            }

            catch (FormatException)
        {
            Console.WriteLine("\nError: Debes coloar datos validos. EJEMPLO(1.72 EN ALTURA Y 84 O 77.2 EN PESO.)");
        }

        Console.WriteLine("\nQue deseas hacer?");
        Console.WriteLine("\nPresiona ENTER para salir.");
        Console.WriteLine("Presiona R para reintentar");
        Console.Write("Selecciona una opcion: ");

        ConsoleKeyInfo teclaU = Console.ReadKey();
        Console.WriteLine();

        if(teclaU.Key == ConsoleKey.Enter)
        {
            Console.WriteLine("\nAdios singa tu madre, vayase al diablo.");
            continuar = false;
        }else if(teclaU.Key == ConsoleKey.R)
        {
            Console.WriteLine("\nBienvenido de nuevo, EL MEJOR!");
                System.Threading.Thread.Sleep(1000);

        }else
        {
            Console.WriteLine("\nDebes seleccionar una de las opciones que se te pide BUEN MMG, AHORA TE WUA SACAR.");
            continuar = false;
        }
           
            }
            
            
    }
}


