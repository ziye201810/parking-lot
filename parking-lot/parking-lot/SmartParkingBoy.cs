using System;
using System.Collections.Generic;

namespace parking_lot
{
    public class SmartParkingBoy : ParkingBoy
    {
        private List<ParkingLot> _parkingLots;

        private SmartParkingBoy()
        {
        }

        public SmartParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
            this._parkingLots = parkingLots;
        }

        public override object Park(Car car)
        {
            var indexOfParkingLotWithMostSpot = -1;
            var numberOfMostSpot = 0;
            for (var index = 0; index < _parkingLots.Count; index++)
            {
                if (_parkingLots[index].GetAvailableSpotNumber() > numberOfMostSpot)
                {
                    indexOfParkingLotWithMostSpot = index;
                    numberOfMostSpot = _parkingLots[index].GetAvailableSpotNumber();
                }
            }

            if (indexOfParkingLotWithMostSpot >= 0)
            {
                return _parkingLots[indexOfParkingLotWithMostSpot].Park(car);
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