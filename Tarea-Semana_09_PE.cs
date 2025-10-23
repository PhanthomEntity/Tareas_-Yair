using System;
using System.Collections.Generic;

class ProgramaEstructuras
{
    static void Main()
    {
        List<string> pila = new List<string>();
        List<string> cola = new List<string>();
        Stack<string> deshacer = new Stack<string>();
        Stack<string> rehacer = new Stack<string>();

        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Insertar en la Pila (Push)");
            Console.WriteLine("2. Extraer de la Pila (Pop)");
            Console.WriteLine("3. Insertar en la Cola");
            Console.WriteLine("4. Extraer de la Cola");
            Console.WriteLine("5. Simular Deshacer/Rehacer");
            Console.WriteLine("6. Mostrar diferencias entre LIFO y FIFO");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            
            string opcion = Console.ReadLine();
            Console.Clear();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese un valor para insertar en la pila: ");
                    string valorPush = LeerTextoValido();
                    pila.Add(valorPush);
                    deshacer.Push("Insertar " + valorPush);
                    Console.WriteLine("\nElemento agregado a la pila.");
                    MostrarPila(pila);
                    break;

                case "2":
                    if (pila.Count > 0)
                    {
                        string valorPop = pila[pila.Count - 1];
                        pila.RemoveAt(pila.Count - 1);
                        deshacer.Push("Eliminar " + valorPop);
                        Console.WriteLine($"\nElemento extraído de la pila: {valorPop}");
                    }
                    else
                    {
                        Console.WriteLine("\nLa pila está vacía.");
                    }
                    MostrarPila(pila);
                    break;

                case "3":
                    Console.Write("Ingrese un valor para insertar en la cola: ");
                    string valorCola = LeerTextoValido();
                    cola.Add(valorCola);
                    deshacer.Push("InsertarCola " + valorCola);
                    Console.WriteLine("\nElemento agregado a la cola.");
                    MostrarCola(cola);
                    break;

                case "4":
                    if (cola.Count > 0)
                    {
                        string valorExtraido = cola[0];
                        cola.RemoveAt(0);
                        deshacer.Push("EliminarCola " + valorExtraido);
                        Console.WriteLine($"\nElemento extraído de la cola: {valorExtraido}");
                    }
                    else
                    {
                        Console.WriteLine("\nLa cola está vacía.");
                    }
                    MostrarCola(cola);
                    break;

                case "5":
                    SimularDeshacerRehacer(deshacer, rehacer);
                    break;

                case "6":
                    MostrarDiferencias();
                    break;

                case "7":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }
        }

        Console.WriteLine("\nPrograma finalizado. ¡Hasta luego!");
    }

    // ===== MÉTODOS AUXILIARES =====

    static string LeerTextoValido()
    {
        while (true)
        {
            string entrada = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entrada))
                return entrada.Trim();
            Console.Write("Entrada inválida. Intente de nuevo: ");
        }
    }

    static void MostrarPila(List<string> pila)
    {
        Console.WriteLine("\n--- Contenido de la Pila (LIFO) ---");
        if (pila.Count == 0)
        {
            Console.WriteLine("La pila está vacía.");
        }
        else
        {
            for (int i = pila.Count - 1; i >= 0; i--)
                Console.WriteLine($"[{pila[i]}]");
        }
    }

    static void MostrarCola(List<string> cola)
    {
        Console.WriteLine("\n--- Contenido de la Cola (FIFO) ---");
        if (cola.Count == 0)
        {
            Console.WriteLine("La cola está vacía.");
        }
        else
        {
            foreach (string item in cola)
                Console.Write($"[{item}] ");
            Console.WriteLine();
        }
    }

    static void SimularDeshacerRehacer(Stack<string> deshacer, Stack<string> rehacer)
    {
        Console.WriteLine("\n--- Simulación Deshacer/Rehacer ---");
        Console.WriteLine("1. Deshacer última acción");
        Console.WriteLine("2. Rehacer última acción deshecha");
        Console.Write("Seleccione una opción: ");

        string opcion = Console.ReadLine();

        try
        {
            if (opcion == "1")
            {
                if (deshacer.Count > 0)
                {
                    string accion = deshacer.Pop();
                    rehacer.Push(accion);
                    Console.WriteLine($"Se deshizo la acción: {accion}");
                }
                else
                {
                    Console.WriteLine("No hay acciones para deshacer.");
                }
            }
            else if (opcion == "2")
            {
                if (rehacer.Count > 0)
                {
                    string accion = rehacer.Pop();
                    deshacer.Push(accion);
                    Console.WriteLine($"Se rehízo la acción: {accion}");
                }
                else
                {
                    Console.WriteLine("No hay acciones para rehacer.");
                }
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al procesar la acción: " + ex.Message);
        }
    }

    static void MostrarDiferencias()
    {
        Console.WriteLine("\n--- Diferencias entre LIFO y FIFO ---");
        Console.WriteLine("PILA (LIFO - Last In, First Out):");
        Console.WriteLine("  • El último elemento insertado es el primero en salir.");
        Console.WriteLine("  • Ejemplo: Apilar platos, el último que colocas es el primero que retiras.\n");

        Console.WriteLine("COLA (FIFO - First In, First Out):");
        Console.WriteLine("  • El primer elemento insertado es el primero en salir.");
        Console.WriteLine("  • Ejemplo: Fila de personas, el primero en llegar es el primero en ser atendido.\n");
    }
}
