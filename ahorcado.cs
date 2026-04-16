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

        // ciclo while hasta que ingrese salir
        while (opcion != 3)
        {
            Console.Clear();

            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║         JUEGO DEL AHORCADO           ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.WriteLine("\n1 jugar");
            Console.WriteLine("2 instrucciones");
            Console.WriteLine("3 salir");
            Console.Write("digite una opcion: ");

            // solicitar el numero
            opcion = int.Parse(Console.ReadLine());

        
            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Jugar();
                    break;
                case 2:
                    Console.Clear();
                    MostrarInstrucciones();
                    Console.ReadLine();
                    break;
                case 3:
                    break;
            }
        }
    }

    // muestra las instrucciones del juego
    static void MostrarInstrucciones()
    {
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║           INSTRUCCIONES              ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.WriteLine("\n- Se escoge una palabra al azar");
        Console.WriteLine("- Debes adivinar letra por letra");
        Console.WriteLine("- Tienes maximo 6 intentos fallidos");
        Console.WriteLine("- No puedes repetir letras");
        Console.WriteLine("\npresiona enter para volver...");
    }

    // funcion con toda la logica de pedir palabras etc
    static void Jugar()
    {
        // limpiar letras usadas de partida anterior
        letrasUsadas = new char[26];
        totalUsadas = 0;

        // seleccion aleatoria de una palabra del vector
        Random random = new Random();
        int indice = random.Next(0, palabras.Length);
        string palabra = palabras[indice];

        // crear vector de estado con guiones bajos
        char[] estado = new char[palabra.Length];
        for (int i = 0; i < estado.Length; i++)
        {
            estado[i] = '_';
        }

        int intentos = 0;
        bool gano = false;

        // ciclo principal, maximo 6 intentos fallidos
        while (intentos < 6 && !PalabraCompleta(estado))
        {
            Console.Clear();

            // aca se imprimira los dibujos del ahorcado
            MostrarAhorcado(intentos);

            Console.WriteLine("\nintentos fallidos: " + intentos + " / 6");

            // mostrar letras ya ingresadas en cada turno
            Console.Write("letras usadas: ");
            for (int i = 0; i < totalUsadas; i++)
            {
                Console.Write(letrasUsadas[i] + " ");
            }
            Console.WriteLine();

            // mostrar estado actual de la palabra con guiones
            Console.Write("\npalabra: ");
            for (int i = 0; i < estado.Length; i++)
            {
                Console.Write(estado[i] + " ");
            }
            Console.WriteLine();

            // solicitar letra al usuario
            Console.Write("\ningrese una letra: ");
            string entrada = Console.ReadLine().ToLower();

            // validar que sea un solo caracter valido
            if (entrada.Length != 1 || !char.IsLetter(entrada[0]))
            {
                Console.WriteLine("ingrese solo una letra valida");
                Console.ReadLine();
                continue;
            }

            char letra = entrada[0];

            // validar que la letra no haya sido usada antes
            bool yaUsada = false;
            for (int i = 0; i < totalUsadas; i++)
            {
                if (letrasUsadas[i] == letra)
                {
                    yaUsada = true;
                    break;
                }
            }

            if (yaUsada)
            {
                Console.WriteLine("esa letra ya fue usada, intenta con otra");
                Console.ReadLine();
                continue;
            }

            // guardar letra en el vector de usadas
            letrasUsadas[totalUsadas] = letra;
            totalUsadas++;

            // revisar si la letra esta en la palabra y actualizar estado
            bool acierto = false;
            for (int i = 0; i < palabra.Length; i++)
            {
                if (palabra[i] == letra)
                {
                    estado[i] = letra;
                    acierto = true;
                }
            }

            // si no acerto sumar intento fallido
            if (!acierto)
            {
                intentos++;
            }
        }

        // funcion para ver si el vector estado ya descubrio la palabra
        gano = PalabraCompleta(estado);

        Console.Clear();
        MostrarAhorcado(intentos);

        // mostrar si gano o perdio y revelar la palabra
        if (gano)
        {
            Console.WriteLine("\n¡GANASTE! adivinaste la palabra: " + palabra);
        }
        else
        {
            Console.WriteLine("\nPERDISTE. la palabra era: " + palabra);
        }

        // preguntar si desea jugar de nuevo
        Console.Write("\ndeseas jugar de nuevo? (s/n): ");
        string respuesta = Console.ReadLine().ToLower();
        if (respuesta == "s")
        {
            Jugar();
        }
    }

    // funcion para ver si el vector estado ya descubrio la palabra
    static bool PalabraCompleta(char[] estado)
    {
        for (int i = 0; i < estado.Length; i++)
        {
            if (estado[i] == '_')
            {
                return false;
            }
        }
        return true;
    }

    // aca se imprimira los dibujos del ahorcado
    static void MostrarAhorcado(int intentos)
    {
        Console.WriteLine("  +---+");

        if (intentos >= 1)
            Console.WriteLine("  |   O");
        else
            Console.WriteLine("  |    ");

        if (intentos >= 3)
            Console.WriteLine("  |  \\|/");
        else if (intentos >= 2)
            Console.WriteLine("  |   |");
        else
            Console.WriteLine("  |    ");

        if (intentos >= 4)
            Console.WriteLine("  |   |");
        else
            Console.WriteLine("  |    ");

        if (intentos >= 6)
            Console.WriteLine("  |  / \\");
        else if (intentos >= 5)
            Console.WriteLine("  |  /  ");
        else
            Console.WriteLine("  |    ");

        Console.WriteLine("  |");
        Console.WriteLine("=====");
    }
}