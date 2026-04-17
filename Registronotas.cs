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

        // inicializar vectores con el tamanio ingresado
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

        // mostrar reporte completo por estudiante
        MostrarReporte();

        // mostrar resumen final del grupo
        MostrarResumen();

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

    // convierte nota numerica a letra segun la escala del desafio
    static char NotaALetra(double nota)
    {
        if (nota >= 9) return 'A';
        if (nota >= 8) return 'B';
        if (nota >= 7) return 'C';
        if (nota >= 6) return 'D';
        return 'F';
    }

    // muestra reporte por estudiante: nombre, nota, letra y estado
    static void MostrarReporte()
    {
        Console.WriteLine("\n╔══════════════════════════════════════╗");
        Console.WriteLine("║         REPORTE POR ESTUDIANTE       ║");
        Console.WriteLine("╚══════════════════════════════════════╝");

        for (int i = 0; i < totalEstudiantes; i++)
        {
            char letra = NotaALetra(notas[i]);
            string estado = notas[i] >= 6.0 ? "Aprobado" : "Reprobado";

            Console.WriteLine("\nnombre : " + nombres[i]);
            Console.WriteLine("nota   : " + notas[i].ToString("F2"));
            Console.WriteLine("letra  : " + letra);
            Console.WriteLine("estado : " + estado);
        }
    }

    // muestra resumen final con totales y promedio general
    static void MostrarResumen()
    {
        int aprobados = 0;
        int reprobados = 0;
        double suma = 0;

        for (int i = 0; i < totalEstudiantes; i++)
        {
            suma += notas[i];

            if (notas[i] >= 6.0)
                aprobados++;
            else
                reprobados++;
        }

        double promedio = suma / totalEstudiantes;

        Console.WriteLine("\n╔══════════════════════════════════════╗");
        Console.WriteLine("║           RESUMEN DEL GRUPO          ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.WriteLine("total aprobados  : " + aprobados);
        Console.WriteLine("total reprobados : " + reprobados);
        Console.WriteLine("promedio general : " + promedio.ToString("F2"));
    }
}