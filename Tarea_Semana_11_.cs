//Acontinuación los ejercicios propuestos en la semana 11 de Programación Estructurada
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("Elija una de las opciones:");
            Console.WriteLine("1: Carga y suma");
            Console.WriteLine("2: Promedio de calificaciones");
            Console.WriteLine("3: Buscar un valor");
            Console.WriteLine("4: Ordenar valores");
            Console.WriteLine("5: Valores repetidos");
            Console.WriteLine("6: Puntos Extras");
            Console.WriteLine("0: Salir");
            Console.Write("Ingrese su opción (0-6): ");

            string? entrada = Console.ReadLine();
            if (!int.TryParse(entrada, out int opcion))
            {
                Console.WriteLine("Entrada inválida. Presione una tecla para intentar de nuevo...");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Ejercicio1();
                    break;
                case 2:
                    Ejercicio2();
                    break;
                case 3:
                    Ejercicio3();
                    break;
                case 4:
                    Ejercicio4();
                    break;
                case 5:
                    Ejercicio5();
                    break;
                case 6:
                    Ejercicio6();
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Presione una tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }


    // EJERCICIO 1: Carga y suma
    static void Ejercicio1()
    {
        Console.Clear();
        const int n = 5;
        int[] numeros = new int[n];
        int suma = 0;

        for (int i = 0; i < n; i++)
        {
            while (true)
            {
                Console.Write($"Ingrese el número {i + 1} de {n}: ");
                string? entrada = Console.ReadLine();
                try
                {
                    numeros[i] = int.Parse(entrada ?? throw new Exception("Entrada nula."));
                    break;
                }
                catch
                {
                    Console.WriteLine("Valor inválido. Intente de nuevo.");
                }
            }
            suma += numeros[i];
        }

        Console.WriteLine($"\nNúmeros ingresados: {string.Join(", ", numeros)}");
        Console.WriteLine($"Suma total: {suma}");
        FinDeEjercicio();
    }


    // EJERCICIO 2: Promedio de calificaciones
    static void Ejercicio2()
    {
        Console.Clear();
        const int n = 6;
        double[] calificaciones = new double[n];
        double suma = 0;

        for (int i = 0; i < n; i++)
        {
            while (true)
            {
                Console.Write($"Ingrese la calificación {i + 1} de {n} (0-100): ");
                string? entrada = Console.ReadLine();

                try
                {
                    double valor = double.Parse(entrada ?? throw new Exception());
                    if (valor < 0 || valor > 100)
                        throw new ArgumentOutOfRangeException();
                    calificaciones[i] = valor;
                    break;
                }
                catch
                {
                    Console.WriteLine("Valor inválido. Intente de nuevo.");
                }
            }
            suma += calificaciones[i];
        }

        double promedio = suma / n;
        Console.WriteLine($"\nPromedio general: {promedio:F2}");
        Console.WriteLine("Calificaciones por encima del promedio:");
        bool alguno = false;
        for (int i = 0; i < n; i++)
        {
            if (calificaciones[i] > promedio)
            {
                Console.WriteLine($"Estudiante {i + 1}: {calificaciones[i]:F2}");
                alguno = true;
            }
        }
        if (!alguno)
            Console.WriteLine("Ninguna calificación está por encima del promedio.");

        FinDeEjercicio();
    }


    // EJERCICIO 3: Buscar un valor
    static void Ejercicio3()
    {
        Console.Clear();
        string[] nombres = { "Ana", "Luis", "María", "Carlos", "Sofía", "Pedro" };
        Console.WriteLine("Nombres disponibles: " + string.Join(", ", nombres));

        while (true)
        {
            Console.Write("Ingrese el nombre a buscar: ");
            string? entrada = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine("Debe ingresar un nombre no vacío.");
                continue;
            }

            string buscado = entrada.Trim();
            bool encontrado = Array.Exists(nombres, n => n.Equals(buscado, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine(encontrado
                ? $"El nombre '{buscado}' se encontró en el arreglo."
                : $"El nombre '{buscado}' NO se encontró en el arreglo.");

            break;
        }

        FinDeEjercicio();
    }

    
    // EJERCICIO 4: Ordenar valores
    static void Ejercicio4()
    {
        Console.Clear();
        const int n = 6;
        int[] numeros = new int[n];

        for (int i = 0; i < n; i++)
        {
            while (true)
            {
                Console.Write($"Ingrese el número {i + 1} de {n}: ");
                string? entrada = Console.ReadLine();
                try
                {
                    numeros[i] = int.Parse(entrada ?? throw new Exception());
                    break;
                }
                catch
                {
                    Console.WriteLine("Valor inválido. Intente de nuevo.");
                }
            }
        }

        Console.WriteLine($"\nOrden ingresado: {string.Join(", ", numeros)}");
        int[] ordenado = (int[])numeros.Clone();
        Array.Sort(ordenado);
        Console.WriteLine($"Orden ascendente: {string.Join(", ", ordenado)}");
        FinDeEjercicio();
    }

  
    // EJERCICIO 5: Valores repetidos
    static void Ejercicio5()
    {
        Console.Clear();
        const int n = 10;
        int[] numeros = new int[n];

        for (int i = 0; i < n; i++)
        {
            while (true)
            {
                Console.Write($"Ingrese el número {i + 1} de {n}: ");
                string? entrada = Console.ReadLine();
                try
                {
                    numeros[i] = int.Parse(entrada ?? throw new Exception());
                    break;
                }
                catch
                {
                    Console.WriteLine("Valor inválido. Intente de nuevo.");
                }
            }
        }

        Console.WriteLine("\nNúmeros ingresados: " + string.Join(", ", numeros));
        var conteos = new Dictionary<int, int>();
        foreach (var num in numeros)
            conteos[num] = conteos.ContainsKey(num) ? conteos[num] + 1 : 1;

        Console.WriteLine("\nValores repetidos:");
        bool hayRepetidos = false;
        foreach (var kvp in conteos)
        {
            if (kvp.Value > 1)
            {
                Console.WriteLine($"Valor {kvp.Key} se repite {kvp.Value} veces.");
                hayRepetidos = true;
            }
        }
        if (!hayRepetidos)
            Console.WriteLine("No hay valores repetidos.");

        FinDeEjercicio();
    }


    // EJERCICIO 6: Puntos extra - Facturación simple
    static void Ejercicio6()
    {
        Console.Clear();
        var productos = new List<(int id, string nombre, decimal precio)>
        {
            (1, "Leche 1L", 25.50m),
            (2, "Pan", 12.00m),
            (3, "Huevos (12)", 48.75m),
            (4, "Arroz 1kg", 30.00m),
            (5, "Azúcar 1kg", 28.90m)
        };

        while (true)
        {
            Console.WriteLine("\n=== MENÚ FACTURACIÓN ===");
            Console.WriteLine("1. Mostrar catálogo de productos");
            Console.WriteLine("2. Imprimir factura");
            Console.WriteLine("3. Volver al menú principal");
            Console.Write("Seleccione una opción (1-3): ");

            string? opcionStr = Console.ReadLine();
            if (!int.TryParse(opcionStr, out int opcion) || opcion < 1 || opcion > 3)
            {
                Console.WriteLine("Opción inválida. Intente de nuevo.");
                continue;
            }

            if (opcion == 1)
            {
                Console.WriteLine("\nCatálogo de productos:");
                foreach (var p in productos)
                    Console.WriteLine($"{p.id}. {p.nombre} - {p.precio:C2}");
            }
            else if (opcion == 2)
            {
                var carrito = new List<(string nombre, decimal precio, int cantidad)>();
                while (true)
                {
                    Console.Write("Ingrese ID del producto (0 para terminar): ");
                    string? idStr = Console.ReadLine();
                    if (!int.TryParse(idStr, out int id)) continue;
                    if (id == 0) break;

                    var producto = productos.Find(p => p.id == id);
                    if (producto == default)
                    {
                        Console.WriteLine("ID no encontrado.");
                        continue;
                    }

                    Console.Write("Cantidad: ");
                    if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
                    {
                        Console.WriteLine("Cantidad inválida.");
                        continue;
                    }

                    carrito.Add((producto.nombre, producto.precio, cantidad));
                }

                Console.WriteLine("\n====== FACTURA ======");
                if (carrito.Count == 0)
                {
                    Console.WriteLine("No se agregaron productos.");
                }
                else
                {
                    decimal total = 0;
                    Console.WriteLine("Producto\tCant.\tPrecio\tSubtotal");
                    foreach (var item in carrito)
                    {
                        decimal subtotal = item.precio * item.cantidad;
                        total += subtotal;
                        Console.WriteLine($"{item.nombre}\t{item.cantidad}\t{item.precio:C2}\t{subtotal:C2}");
                    }
                    Console.WriteLine("--------------------------");
                    Console.WriteLine($"Total: {total:C2}");
                }
            }
            else
            {
                return;
            }
        }
    }

    // Funcion para pausar al final de cada ejercicio
    static void FinDeEjercicio()
    {
        Console.WriteLine("\nPresione una tecla para volver al menú principal...");
        Console.ReadKey();
    }
}
