using System;

namespace SlotMachineGame.Models
{
    public class BB8 : IRobot
    {
        private static int counter = 0;
        public int Id { get; private set; }
        public string Modelo { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public float NumeroVersion { get; private set; }

        public BB8()
        {
            Id = ++counter;
            Modelo = "BB8";
            FechaCreacion = GenerateRandomDate();
            NumeroVersion = GenerateRandomVersion();
        }

        private DateTime GenerateRandomDate()
        {
            Random rnd = new Random();
            int year = rnd.Next(2010, 2026);
            int month = rnd.Next(1, 13);
            int day = rnd.Next(1, 29);
            return new DateTime(year, month, day);
        }

        private float GenerateRandomVersion()
        {
            Random rnd = new Random();
            return (float)Math.Round(rnd.NextDouble() * 4 + 1, 2);
        }

        public int NumberOfFlights()
        {
            Random rnd = new Random();
            return rnd.Next(1, 16);
        }

        public int NumberOfRepairs()
        {
            Random rnd = new Random();
            return rnd.Next(1, 11);
        }

        public void ShowData()
        {
            Console.WriteLine($"BB8 - ID: {Id}, Modelo: {Modelo}, Fecha de Creación: {FechaCreacion.ToShortDateString()}, Versión: {NumeroVersion}, Vuelos: {NumberOfFlights()}, Reparaciones: {NumberOfRepairs()}");
        }
    }
}
