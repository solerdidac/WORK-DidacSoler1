using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SlotMachineGame.Models;
using SlotMachineGame.Managers;
using System.IO;

namespace SlotMachineGame
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Ingrese su nombre: ");
            string userName = Console.ReadLine();

            Console.WriteLine($"\nBienvenido, {userName}. Iniciando juego de Slots para producción de robots.");
            int tiradas = 10;
            int bonusTotal = 0;

            OrderManager<IRobot> orderManager = new OrderManager<IRobot>();

            using HttpClient client = new HttpClient();
            Random rnd = new Random();

            for (int i = 0; i < tiradas; i++)
            {
                string url = "https://www.randomnumberapi.com/api/v1.0/random?min=1&max=4&count=3";
                try
                {
                    string response = await client.GetStringAsync(url);
                    int[] numbers = JsonSerializer.Deserialize<int[]>(response);

                    List<IRobot> robotsTirada = new List<IRobot>();

                    for (int j = 0; j < numbers.Length; j++)
                    {
                        IRobot robot = CreateRobotFromNumber(numbers[j]);
                        robotsTirada.Add(robot);
                        orderManager.AddOrder(robot);
                    }

                    // Resultado Tirada
                    Console.Write("Tirada " + (i + 1) + ": ");
                    foreach (var robot in robotsTirada)
                    {
                        Console.Write($"[ {robot.Modelo} ] ");
                    }
                    Console.WriteLine();

                    // Calcular Tirada
                    int tiradaBonus = 0;
                    if (robotsTirada[0].Modelo == robotsTirada[1].Modelo && robotsTirada[1].Modelo == robotsTirada[2].Modelo)
                        tiradaBonus = 10;
                    else if (robotsTirada[0].Modelo == robotsTirada[1].Modelo ||
                             robotsTirada[1].Modelo == robotsTirada[2].Modelo ||
                             robotsTirada[0].Modelo == robotsTirada[2].Modelo)
                        tiradaBonus = 5;

                    bonusTotal += tiradaBonus;
                    Console.WriteLine($"Bonus en esta tirada: {tiradaBonus}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al llamar a la API: " + ex.Message);
                }

                int sleepTime = rnd.Next(500, 1200);
                Thread.Sleep(sleepTime);
            }

            // Puntos Extra
            int extraPoints = 0;
            foreach (var robot in orderManager.GetOrders())
            {
                switch (robot.Modelo)
                {
                    case "R2D2":
                        extraPoints += 3;
                        break;
                    case "C3PO":
                        extraPoints += 2;
                        break;
                    case "BB8":
                        extraPoints += 1;
                        break;
                }
            }

            int totalScore = bonusTotal + extraPoints;
            Console.WriteLine("\n--- Resumen de la Partida ---");
            Console.WriteLine($"Total Bonus acumulado: {bonusTotal}");
            Console.WriteLine($"Puntos extra por robots: {extraPoints}");
            Console.WriteLine($"Puntuación total final para {userName}: {totalScore}");

            // Guardar resultado 
            string record = $"{userName}:{totalScore}{Environment.NewLine}";
            string filePath = "scores.txt";
            File.AppendAllText(filePath, record);
            Console.WriteLine("\nEl registro de la partida se ha guardado en 'scores.txt'");

            // Top 3
            Console.WriteLine("\n--- Top 3 Puntuaciones ---");
            var top3 = GetTop3Scores(filePath);
            int rank = 1;
            foreach (var entry in top3)
            {
                Console.WriteLine($"{rank}. {entry.Item1} - {entry.Item2} puntos");
                rank++;
            }

            Console.ReadKey();
        }

        static IRobot CreateRobotFromNumber(int num)
        {
            return num switch
            {
                1 => new R2D2(),
                2 => new C3PO(),
                3 => new BB8(),
                _ => null
            };
        }

        static List<(string, int)> GetTop3Scores(string filePath)
        {
            var entries = new List<(string, int)>();
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(':');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int score))
                    {
                        entries.Add((parts[0], score));
                    }
                }
            }
            var top3 = entries.OrderByDescending(e => e.Item2).Take(3).ToList();
            return top3;
        }
    }
}