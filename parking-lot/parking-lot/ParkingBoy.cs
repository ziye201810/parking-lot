using System;
using System.Collections.Generic;

namespace parking_lot
{
    public class ParkingBoy
    {
        private List<ParkingLot> _parkingLots;

        protected ParkingBoy()
        {
        }

        public ParkingBoy(List<ParkingLot> parkingLots)
        {
            this._parkingLots = parkingLots;
        }

        public virtual object Park(Car car)
        {
            foreach (var parkingLot in _parkingLots)
            {
                if (parkingLot.GetAvailableSpotNumber() > 0)
                {
                    var ticket = parkingLot.Park(car);
                    return ticket;
                }
            }

            throw new Exception("No available parking spot");
        }

        public Car GetCar(object ticket)
        {
            Car result = null;
            _parkingLots.ForEach(l =>
            {
                if (l.Exist(ticket))
                {
                    result = l.GetCar(ticket);
                }
            });
            if (result == null)
            {
                throw new NotFoundException("Invalid ticket!");
            }

            return result;
        }
    }
}