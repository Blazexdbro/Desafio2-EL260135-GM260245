using System;

class Ahorcado
{
    // vector unidimensional con las palabras
    static string[] palabras = new string[] { "programacion", "algoritmo", "computadora", "variable", "funcion", "vector", "ciclo", "condicion", "operador", "consola" };
    
    // vectores para controlar las letras seleccionadas
    static char[] letrasUsadas = new char[26];
    static int totalUsadas = 0;

    // arranca la configuracion de esta clase
    public static void Iniciar()
    {
        int opcion = 0;

        // ciclo repetitivo hasta que ingrese salir
        while (opcion != 3)
        {
            Console.Clear(); // <-- Limpia cuando vuelve a este menu

            Console.WriteLine("\nmenu ahorcado");
            Console.WriteLine("1 jugar");
            Console.WriteLine("2 instrucciones");
            Console.WriteLine("3 salir");
            Console.WriteLine("digite una opcion: ");
            
            // solicitar el numero
            opcion = int.Parse(Console.ReadLine());

            // evaluar respuesta
            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Jugar();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("en desarrollo las instrucciones...");
                    Console.ReadLine(); 
                    break;
                case 3:
                    break;
            }
        }
    }

    // funcion con toda la logica de pedir palabras etc
    static void Jugar()
    {
        Console.WriteLine("\nen desarrollo jueguito...");
        Console.ReadLine(); // Pausa para que el texto no huya
    }

    // funcion para ver si el vector estado ya descubrio la palabra
    static bool PalabraCompleta(char[] estado)
    {
        return false;
    }

    // aca se imprimira los dibujos del ahorcado
    static void MostrarAhorcado(int intentos)
    {
        Console.WriteLine("aqui saldra el ahorcado");
    }
}