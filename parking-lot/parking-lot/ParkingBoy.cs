using System;
using System.Collections.Generic;

namespace parking_lot
{
    public class ParkingBoy
    {
        private List<ParkingLot> _parkingLots;

        private ParkingBoy()
        {
        }

        public ParkingBoy(List<ParkingLot> parkingLots)
        {
            this._parkingLots = parkingLots;
        }

        public object Park(Car car)
        {
            foreach (var parkingLot in _parkingLots)
            {
                try
                {
                    var ticket = parkingLot.Park(car);
                    if (ticket != null)
                    {
                        return ticket;
                    }
                }
                catch (Exception e)
                {
                }
            }

            throw new Exception("No available parking spot");
        }

        public Car GetCar(object ticket)
        {
            Car result = null;
            _parkingLots.ForEach(l =>
            {
                try
                {
                    var car = l.GetCar(ticket);
                    if (car != null)
                    {
                        result = car as Car;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
              
            });
            if (result == null)
            {
                throw new Exception("Invalid ticket!");
            }
            return result;
        }
    }
}