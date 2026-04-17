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

            // validar que la nota este entre 0 y 10
            notas[i] = PedirNota();
        }

        // calcular y mostrar estadisticas del grupo
        MostrarEstadisticas();

        Console.ReadLine();
    }

    // solicita y valida que la nota este en rango 0 - 10
    static double PedirNota()
    {
        double nota;
        do
        {
            Console.Write("nota (0.0 - 10.0): ");
            nota = double.Parse(Console.ReadLine());

            if (nota < 0 || nota > 10)
            {
                Console.WriteLine("nota invalida, debe estar entre 0 y 10");
            }
        } while (nota < 0 || nota > 10);

        return nota;
    }

    // calcula y muestra promedio, nota maxima y nota minima
    static void MostrarEstadisticas()
    {
        double suma = 0;
        double max = notas[0];
        double min = notas[0];

        for (int i = 0; i < totalEstudiantes; i++)
        {
            suma += notas[i];

            if (notas[i] > max) max = notas[i];
            if (notas[i] < min) min = notas[i];
        }

        double promedio = suma / totalEstudiantes;

        Console.WriteLine("\n--- estadisticas del grupo ---");
        Console.WriteLine("promedio: " + promedio.ToString("F2"));
        Console.WriteLine("nota maxima: " + max);
        Console.WriteLine("nota minima: " + min);
    }
}