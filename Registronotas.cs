using System;

class Registronotas
{
    // vectores para registrar estudiantes y notas
    static string[] nombres;
    static double[] notas;
    static int totalEstudiantes;

    // arranca el sistema 
    public static void iniciar()
    {
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║     SISTEMA DE REGISTRO DE NOTAS     ║");
        Console.WriteLine("╚══════════════════════════════════════╝");

        // solicitar cantidad de estudiantes
        Console.Write("\ncuantos estudiantes desea registrar: ");
        totalEstudiantes = int.Parse(Console.ReadLine());

        // inicializar vectores con el tamaño ingresado
        nombres = new string[totalEstudiantes];
        notas = new double[totalEstudiantes];

        // ciclo para ingresar datos de cada estudiante
        for (int i = 0; i < totalEstudiantes; i++)
        {
            Console.WriteLine("\n--- estudiante " + (i + 1) + " ---");

            Console.Write("nombre: ");
            nombres[i] = Console.ReadLine();

            Console.Write("nota (0.0 - 10.0): ");
            notas[i] = double.Parse(Console.ReadLine());
        }

        Console.WriteLine("\ndatos ingresados correctamente.");
        Console.ReadLine();
    }
}