using System;
using System.Collections.Generic;

namespace parking_lot
{
    public class ParkingLot
    {
        private Dictionary<object, Car> ticketToCars;
        private int ParkingLotSize;

        public ParkingLot()
        {
            ParkingLotSize = 20;
            ticketToCars = new Dictionary<object, Car>();
        }

        public int GetAvailableSpotNumber()
        {
            return ParkingLotSize - ticketToCars.Count;
        }

        public object Park(Car car)
        {
            var ticket = new object();
            var count = ticketToCars.Count;
            if (count < 20)
            {
                ticketToCars.Add(ticket, car);
                return ticket;
            }
            else
            {
                throw new Exception("ParkingLot is full");
            }
        }

        public object GetCar(object ticket)
        {
            if (ticketToCars.ContainsKey(ticket))
            {
                var car = ticketToCars[ticket];
                ticketToCars.Remove(ticket);
                return car;
            }

            throw new Exception("Invalid ticket!");
        }
    }
}