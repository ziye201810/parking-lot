using System;
using System.Collections.Generic;

namespace parking_lot
{
    public class ParkingLot
    {
        private Dictionary<object, Car> ticketToCars;
        private readonly int _parkingLotSize;

        public ParkingLot(int capacity)
        {
            _parkingLotSize = capacity;
            ticketToCars = new Dictionary<object, Car>();
        }

        public int GetAvailableSpotNumber()
        {
            return _parkingLotSize - ticketToCars.Count;
        }

        public object Park(Car car)
        {
            var ticket = new object();
            if (GetAvailableSpotNumber() > 0)
            {
                ticketToCars.Add(ticket, car);
                return ticket;
            }

            throw new Exception("ParkingLot is full");
        }

        public Car GetCar(object ticket)
        {
            if (ticketToCars.ContainsKey(ticket))
            {
                var car = ticketToCars[ticket];
                ticketToCars.Remove(ticket);
                return car;
            }

            throw new Exception("Invalid ticket!");
        }

        public bool Exist(object ticket)
        {
            if (ticketToCars.ContainsKey(ticket))
            {
                return true;
            }

            return false;
        }
    }
}