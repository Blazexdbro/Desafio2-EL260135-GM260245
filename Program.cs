using System;

class Program
{
    static void Main(string[] args)
    {
        int opcion = 0;

        // ciclo principal del menu
        while (opcion != 3)
        {
            Console.Clear(); // <-- limpia el texto viejo en cada vuelta

            // diseño principal
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║     BIENVENIDO AL DESAFÍO 2 PAL404   ║");
            Console.WriteLine("╚══════════════════════════════════════╝");

            Console.WriteLine("\nmenu principal");
            Console.WriteLine("1 juego del ahorcado");
            Console.WriteLine("2 registro de notas");
            Console.WriteLine("3 salir");
            Console.Write("digite una opcion: ");

            // leer opcion del usuario
            string entrada = Console.ReadLine();
            if (!int.TryParse(entrada, out opcion))
            {
                Console.WriteLine("por favor digite un numero");
                Console.ReadLine();
                continue; // fix de el crasheo al presionar enter sin digitar un numero
            }


            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Ahorcado.Iniciar();
                    break;
                case 2: // aqui ari se encargara de agregar el ejercicio 2
                    Console.Clear();
                    Registronotas.Iniciar();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("adios");
                    break;
                default:
                // aca un default tmb
                    Console.WriteLine("opcion invalida, intente de nuevo");
                    Console.ReadLine();
                    break;
            }
        }
    }
}