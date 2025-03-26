using System;
using System.Collections.Generic;
using System.Linq;

namespace SlotMachineGame.Managers
{
    public class OrderManager<T>
    {
        private List<T> orders = new List<T>();

        public void AddOrder(T order)
        {
            orders.Add(order);
        }

        public List<T> GetOrders()
        {
            return orders;
        }

        // Puntos Totales 
        public int CalculateTotalPoints(Func<T, int> pointsCalculator)
        {
            return orders.Sum(o => pointsCalculator(o));
        }

        public int CalculateMaxPoints(Func<T, int> pointsCalculator)
        {
            return orders.Any() ? orders.Max(o => pointsCalculator(o)) : 0;
        }

        public int CalculateMinPoints(Func<T, int> pointsCalculator)
        {
            return orders.Any() ? orders.Min(o => pointsCalculator(o)) : 0;
        }
    }
}
