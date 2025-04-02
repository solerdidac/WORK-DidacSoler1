using System;

namespace SlotMachineGame.Models
{
    public class R2D2 : IRobot
    {
        private static int counter = 0;
        public int Id { get; private set; }
        public string Modelo { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public int NumeroVersion { get; private set; }

        public R2D2()
        {
            Id = ++counter;
            Modelo = "R2D2";
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

        private int GenerateRandomVersion()
        {
            Random rnd = new Random();
            return rnd.Next(1, 5);
        }

        public int NumberOfBattles()
        {
            Random rnd = new Random();
            return rnd.Next(1, 21);
        }

        public void ShowData()
        {
            Console.WriteLine($"R2D2 - ID: {Id}, Modelo: {Modelo}, Fecha de Creación: {FechaCreacion.ToShortDateString()}, Versión: {NumeroVersion}, Batallas: {NumberOfBattles()}");
        }
    }
}
