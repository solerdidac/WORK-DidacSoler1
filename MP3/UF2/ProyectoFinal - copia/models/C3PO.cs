using System;

namespace SlotMachineGame.Models
{
    public class C3PO : IRobot
    {
        private static int counter = 0;
        public int Id { get; private set; }
        public string Modelo { get; private set; }
        public DateTime FechaCreacion { get; private set; }

        public C3PO()
        {
            Id = ++counter;
            Modelo = "C3PO";
            FechaCreacion = GenerateRandomDate();
        }

        private DateTime GenerateRandomDate()
        {
            Random rnd = new Random();
            int year = rnd.Next(2010, 2026);
            int month = rnd.Next(1, 13);
            int day = rnd.Next(1, 29);
            return new DateTime(year, month, day);
        }

        public int NumberOfRepairs()
        {
            Random rnd = new Random();
            return rnd.Next(1, 11);
        }

        public void ShowData()
        {
            Console.WriteLine($"C3PO - ID: {Id}, Modelo: {Modelo}, Fecha de Creación: {FechaCreacion.ToShortDateString()}, Reparaciones: {NumberOfRepairs()}");
        }
    }
}
