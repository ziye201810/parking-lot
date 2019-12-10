﻿using System;
using System.Collections.Generic;

namespace parking_lot
{
    public class ParkingBot
    {
        private List<ParkingLot> _parkingLots;

        protected ParkingBot()
        {
        }

        public ParkingBot(List<ParkingLot> parkingLots)
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
    }
}