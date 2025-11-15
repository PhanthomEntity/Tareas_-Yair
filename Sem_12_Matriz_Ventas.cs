using System;

class MatrizVentas
{
    
    // Método que imprime la matriz en formato tabular con encabezados
 
    static void ImprimirMatriz(int[,] ventas)
    {
        Console.WriteLine("\n=== MATRIZ DE VENTAS ===\n");

        // Imprimir encabezado de columnas (meses)
        Console.Write("Producto/Mes\t");
        for (int mes = 0; mes < ventas.GetLength(1); mes++)
        {
            Console.Write($"Mes {mes + 1}\t");
        }
        Console.WriteLine();

        // Imprimir cada fila con su encabezado de producto
        for (int prod = 0; prod < ventas.GetLength(0); prod++)
        {
            Console.Write($"Producto {prod + 1}\t");
            for (int mes = 0; mes < ventas.GetLength(1); mes++)
            {
                Console.Write(ventas[prod, mes] + "\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }

   
    // Método auxiliar para leer un entero válido desde la consola.
    // - Muestra el mensaje 'prompt'
    // - Repite la petición hasta que el usuario ingrese un entero válido >= 0
    // - Controla errores inesperados con try/catch y vuelve a pedir
   
    static int LeerEntero(string prompt)
    {
        while (true)
        {
            try
            {
                Console.Write(prompt);                 // Mostrar mensaje al usuario
                string entrada = Console.ReadLine();   // Leer línea

                // Si ReadLine devuelve null (EOF), lanzamos excepción para manejarlo
                if (entrada == null)
                {
                    throw new Exception("Entrada no recibida. Intente de nuevo.");
                }

                // Intentamos convertir a entero
                bool ok = int.TryParse(entrada.Trim(), out int valor);

                // Validación adicional: no permitir números negativos
                if (!ok)
                {
                    Console.WriteLine("Entrada inválida. Por favor escriba un número entero (ej: 1200).");
                    continue; // volver a pedir
                }

                if (valor < 0)
                {
                    Console.WriteLine("No se permiten valores negativos. Ingrese 0 o un número positivo.");
                    continue; // volver a pedir
                }

                // Si llegamos aquí, el valor es válido
                return valor;
            }
            catch (Exception ex)
            {
                // Capturamos cualquier excepción inesperada y pedimos reintento
                Console.WriteLine("Ocurrió un error: " + ex.Message);
                Console.WriteLine("Por favor intente de nuevo.\n");
                // El bucle while se repite y vuelve a pedir
            }
        }
    }

    static void Main(string[] args)
    {
      
        // SECCIÓN 1: Crear la matriz ventas (4 productos x 3 meses) pidiendo al usuario
      
        Console.WriteLine("Programa: Matriz de Ventas (4 productos x 3 meses)");
        Console.WriteLine("Vas a ingresar las ventas (números enteros, sin signo negativo).");
        Console.WriteLine("Si cometes un error, te lo pediremos de nuevo.\n");

        int filas = 4;    // Número de productos
        int columnas = 3; // Número de meses

        int[,] ventas = new int[filas, columnas];

        // Pedir cada valor con validación
        for (int prod = 0; prod < filas; prod++)
        {
            for (int mes = 0; mes < columnas; mes++)
            {
                // Mensaje claro indicando qué dato se solicita
                string mensaje = $"Ingrese la venta para Producto {prod + 1}, Mes {mes + 1}: ";
                ventas[prod, mes] = LeerEntero(mensaje);
            }
        }

        // Mostrar la matriz completa
        ImprimirMatriz(ventas);

      
        // SECCIÓN 2: Suma por filas (total por producto)
       
        Console.WriteLine("=== TOTAL POR PRODUCTO ===");
        for (int prod = 0; prod < filas; prod++)
        {
            int totalProducto = 0; // acumulador para el producto actual

            for (int mes = 0; mes < columnas; mes++)
            {
                totalProducto += ventas[prod, mes];
            }

            Console.WriteLine($"Total del Producto {prod + 1}: {totalProducto}");
        }

        Console.WriteLine(); // espacio visual

        // SECCIÓN 3: Suma por columnas (total por mes)
       
        Console.WriteLine("=== TOTAL POR MES ===");
        for (int mes = 0; mes < columnas; mes++)
        {
            int totalMes = 0; // acumulador para el mes actual

            for (int prod = 0; prod < filas; prod++)
            {
                totalMes += ventas[prod, mes];
            }

            Console.WriteLine($"Total del Mes {mes + 1}: {totalMes}");
        }

        Console.WriteLine(); // espacio visual

 
        // SECCIÓN 4: Búsqueda del valor máximo y su posición

        int ventaMasAlta = ventas[0, 0]; // inicializamos con el primer valor
        int productoMasVendido = 1;      // almacenan posiciones 'humanas' (1-based)
        int mesDeMejorVenta = 1;

        for (int prod = 0; prod < filas; prod++)
        {
            for (int mes = 0; mes < columnas; mes++)
            {
                if (ventas[prod, mes] > ventaMasAlta)
                {
                    ventaMasAlta = ventas[prod, mes];   // nuevo máximo encontrado
                    productoMasVendido = prod + 1;      // +1 para mostrar al usuario (no índice)
                    mesDeMejorVenta = mes + 1;
                }
            }
        }

        // Mostrar resultado de la búsqueda del máximo
        Console.WriteLine("=== VENTA MÁS ALTA ===");
        Console.WriteLine($"La venta más alta fue de {ventaMasAlta}, correspondiente al Producto {productoMasVendido} en el Mes {mesDeMejorVenta}.");

        Console.WriteLine("\nPrograma finalizado. Presiona Enter para salir.");
        Console.ReadLine(); // Mantener la consola abierta hasta que el usuario presione Enter
    }
}
