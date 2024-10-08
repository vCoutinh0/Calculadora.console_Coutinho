﻿using System;
using System.IO;
using System.Linq;
using Application;
using Calculadora;

class Program
{
    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        Console.Clear();

        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("1 - Soma");
        Console.WriteLine("2 - Subtração");
        Console.WriteLine("3 - Divisão");
        Console.WriteLine("4 - Multiplicação");
        Console.WriteLine("5 - Sair");

        Console.WriteLine("----------");
        Console.WriteLine("Selecione uma opção: ");

        short res = short.Parse(Console.ReadLine());

        switch (res)
        {
            case 1: Soma(); break;
            case 2: Subtracao(); break;
            case 3: Divisao(); break;
            case 4: Multiplicacao(); break;
            case 5: Environment.Exit(0); break;
            default: Menu(); break;
        }
    }

    static void Soma()
    {
        Console.Clear();

        Console.WriteLine("Primeiro valor: ");
        float v1 = float.Parse(Console.ReadLine());

        Console.WriteLine("Segundo valor:");
        float v2 = float.Parse(Console.ReadLine());

        Console.WriteLine("");

        float resultado = Operacoes.Somar(v1, v2);

        Console.WriteLine($"O resultado da soma é {resultado}");

        var OperacoesHistorico = new OperacoesHistorico()
        {
            Nome = "Soma",
            Resultado = resultado,
            Data = DateTime.Now
        };

        using var dbContext = new ApplicationDbContext();
        dbContext.Add(OperacoesHistorico);
        dbContext.SaveChanges();

        SalvarUltimoComando();

        Console.ReadKey();
        Menu();
    }

    static void Subtracao()
    {
        Console.Clear();

        Console.WriteLine("Primeiro valor: ");
        float v1 = float.Parse(Console.ReadLine());

        Console.WriteLine("Segundo valor:");
        float v2 = float.Parse(Console.ReadLine());

        Console.WriteLine("");

        float resultado = Operacoes.Subtrair(v1, v2);
        Console.WriteLine($"O resultado da subtração é {resultado}");

        var OperacoesHistorico = new OperacoesHistorico()
        {
            Nome = "Subtracao",
            Resultado = resultado,
            Data = DateTime.Now
        };

        using var dbContext = new ApplicationDbContext();
        dbContext.Add(OperacoesHistorico);
        dbContext.SaveChanges();

        SalvarUltimoComando();

        Console.ReadKey();
        Menu();
    }

    static void Divisao()
    {
        Console.Clear();

        Console.WriteLine("Primeiro valor: ");
        float v1 = float.Parse(Console.ReadLine());

        Console.WriteLine("Segundo valor:");
        float v2 = float.Parse(Console.ReadLine());

        Console.WriteLine("");

        float resultado = Operacoes.Dividir(v1, v2);
        Console.WriteLine($"O resultado da dvisisão é {resultado}");

        var OperacoesHistorico = new OperacoesHistorico()
        {
            Nome = "Divisao",
            Resultado = resultado,
            Data = DateTime.Now
        };

        using var dbContext = new ApplicationDbContext();
        dbContext.Add(OperacoesHistorico);
        dbContext.SaveChanges();
        
        SalvarUltimoComando();

        Console.ReadKey();
        Menu();
    }

    static void Multiplicacao()
    {
        Console.Clear();

        Console.WriteLine("Primeiro valor: ");
        float v1 = float.Parse(Console.ReadLine());

        Console.WriteLine("Segundo valor:");
        float v2 = float.Parse(Console.ReadLine());

        Console.WriteLine("");

        float resultado = Operacoes.Multiplicar(v1, v2);
        Console.WriteLine($"O resultado da multiplicação é {resultado}");

        var OperacoesHistorico = new OperacoesHistorico()
        {
            Nome = "Multiplicacao",
            Resultado = resultado,
            Data = DateTime.Now
        };

        using var dbContext = new ApplicationDbContext();
        dbContext.Add(OperacoesHistorico);
        dbContext.SaveChanges();

        SalvarUltimoComando();

        Console.ReadKey();
        Menu();
    }

    static void SalvarUltimoComando()
    {
        using var dbContext = new ApplicationDbContext();
        var ultimoComando = dbContext.OperacoesHistorico
            .OrderByDescending(o => o.Data)
            .FirstOrDefault();
        
        FileInfo fileInfo = new FileInfo("ultimo_comando.txt");
        
        using (StreamWriter writer = fileInfo.CreateText())
        {
            writer.WriteLine(String.Concat(ultimoComando.Nome, " - ", ultimoComando.Data));
        }
    }
}