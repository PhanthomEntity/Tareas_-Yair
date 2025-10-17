using System;

class ProgramaCadenas
{
    static void Main()
    {
        Console.WriteLine("=== MANEJO DE CADENAS DE TEXTO EN C# ===\n");

        // Solicita una cadena de texto válida
        string texto = LeerCadena("Ingrese una cadena de texto: ");

        // a) Contar la cantidad de vocales
        int cantidadVocales = ContarVocales(texto);
        Console.WriteLine($"\nCantidad de vocales en el texto: {cantidadVocales}");

        // b) Invertir la cadena
        string textoInvertido = InvertirCadena(texto);
        Console.WriteLine($"Texto invertido: {textoInvertido}");

        // c) Validar prefijo y sufijo
        ValidarPrefijoYSufijo(texto);

        Console.WriteLine("\n=== Fin del programa ===");
    }

    // ------------------------------------------------------------
    // Método para leer una cadena de texto no vacía
    // Controla errores para evitar cadenas vacías o nulas
    static string LeerCadena(string mensaje)
    {
        string texto = "";
        while (true)
        {
            try
            {
                Console.Write(mensaje);
                texto = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(texto))
                {
                    Console.WriteLine("Error: La cadena no puede estar vacía. Intente nuevamente.\n");
                }
                else
                {
                    return texto;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Ocurrió un problema al leer el texto. Intente de nuevo.\n");
            }
        }
    }

    // ------------------------------------------------------------
    // Método para contar las vocales en un texto
    // Usa un ciclo y el método Contains() de la clase string
    static int ContarVocales(string texto)
    {
        int contador = 0;
        string vocales = "aeiouáéíóúAEIOUÁÉÍÓÚ";

        foreach (char letra in texto)
        {
            if (vocales.Contains(letra))
            {
                contador++;
            }
        }

        return contador;
    }

    // ------------------------------------------------------------
    // Método para invertir una cadena de texto
    // Recorre el texto desde el final hacia el inicio
    static string InvertirCadena(string texto)
    {
        string invertida = "";
        for (int i = texto.Length - 1; i >= 0; i--)
        {
            invertida += texto[i];
        }
        return invertida;
    }

    // ------------------------------------------------------------
    // Método que solicita y valida prefijo y sufijo, con control de errores
    static void ValidarPrefijoYSufijo(string texto)
    {
        string prefijo = LeerCadena("\nIngrese un prefijo a verificar: ");
        string sufijo = LeerCadena("Ingrese un sufijo a verificar: ");

        // Verificar si el texto comienza con el prefijo
        if (texto.StartsWith(prefijo))
        {
            Console.WriteLine($"El texto SÍ comienza con \"{prefijo}\".");
        }
        else
        {
            Console.WriteLine($"El texto NO comienza con \"{prefijo}\".");
        }

        // Verificar si el texto termina con el sufijo
        if (texto.EndsWith(sufijo))
        {
            Console.WriteLine($"El texto SÍ termina con \"{sufijo}\".");
        }
        else
        {
            Console.WriteLine($"El texto NO termina con \"{sufijo}\".");
        }
    }
}
