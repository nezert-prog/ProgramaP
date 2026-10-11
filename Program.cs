using System;

namespace CalculadoraAprobacion
{
    class Program
    {
        const double NOTA_MINIMA_APROBAR = 70.0;

        // Lee un numero decimal y repite la pregunta hasta que sea valido
        static double LeerNumero(string mensaje)
        {
            double valor;
            while (true)
            {
                Console.Write(mensaje);
                if (double.TryParse(Console.ReadLine(), out valor))
                {
                    return valor;
                }
                Console.WriteLine("Error: debe ingresar un numero valido.");
            }
        }

        // Lee un numero entero dentro de un rango
        static int LeerEntero(string mensaje, int minimo, int maximo)
        {
            int valor;
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out valor))
                {
                    if (valor >= minimo && valor <= maximo)
                    {
                        return valor;
                    }
                    Console.WriteLine("Error: ingrese un valor entre " + minimo + " y " + maximo + ".");
                }
                else
                {
                    Console.WriteLine("Error: debe ingresar un numero entero.");
                }
            }
        }

        // Lee una nota valida (entre 0 y 100)
        static double LeerNota(string mensaje)
        {
            double nota;
            while (true)
            {
                nota = LeerNumero(mensaje);
                if (nota >= 0 && nota <= 100)
                {
                    return nota;
                }
                Console.WriteLine("Error: la nota debe estar entre 0 y 100.");
            }
        }

        static void OperacionAritmetica(int opcion)
        {
            double a = LeerNumero("Ingrese el primer numero: ");
            double b = LeerNumero("Ingrese el segundo numero: ");

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Resultado: " + a + " + " + b + " = " + (a + b));
                    break;
                case 2:
                    Console.WriteLine("Resultado: " + a + " - " + b + " = " + (a - b));
                    break;
                case 3:
                    Console.WriteLine("Resultado: " + a + " * " + b + " = " + (a * b));
                    break;
                case 4:
                    if (b == 0)
                    {
                        Console.WriteLine("Error: no se puede dividir entre cero.");
                    }
                    else
                    {
                        Console.WriteLine("Resultado: " + a + " / " + b + " = " + (a / b));
                    }
                    break;
            }
        }

        static void VerificarAprobado()
        {
            Console.Write("Nombre del estudiante: ");
            string nombre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                nombre = "El estudiante";
            }

            int cantidad = LeerEntero("Cantidad de calificaciones (1-10): ", 1, 10);
            double suma = 0;

            for (int i = 1; i <= cantidad; i++)
            {
                suma += LeerNota("Calificacion " + i + " (0-100): ");
            }

            double promedio = suma / cantidad;
            Console.WriteLine("Promedio: " + promedio);

            if (promedio >= NOTA_MINIMA_APROBAR)
            {
                Console.WriteLine(nombre + " APROBO.");
            }
            else
            {
                Console.WriteLine(nombre + " REPROBO.");
            }
        }

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.WriteLine("\n===== MENU PRINCIPAL =====");
                Console.WriteLine("1. Sumar");
                Console.WriteLine("2. Restar");
                Console.WriteLine("3. Multiplicar");
                Console.WriteLine("4. Dividir");
                Console.WriteLine("5. Verificar si un estudiante aprobo");
                Console.WriteLine("6. Salir");

                opcion = LeerEntero("Seleccione una opcion: ", 1, 6);

                if (opcion >= 1 && opcion <= 4)
                {
                    OperacionAritmetica(opcion);
                }
                else if (opcion == 5)
                {
                    VerificarAprobado();
                }
            } while (opcion != 6);

            Console.WriteLine("Programa finalizado. Hasta luego.");
        }
    }
}