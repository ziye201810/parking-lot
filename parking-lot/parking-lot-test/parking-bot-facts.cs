using System;
using System.Collections.Generic;
using parking_lot;
using Xunit;

namespace parking_lot_test
{
    public class parkingBotFacts
    {
         private int _capacity = 20;

        [Fact]
        public void should_park_a_car_into_a_parking_lot_which_has_space_and_get_a_ticket()
        {
            var list = new List<ParkingLot> {new ParkingLot(_capacity)};
            var parkingBoy = new ParkingBotOld(list);

            var ticket = parkingBoy.Park(new Car());

            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_not_park_a_car_into_a_parking_lot_which_has_no_space()
        {
            var parkingLot = new ParkingLot(_capacity);
            for (var i = 0; i < 20; i++)
            {
                parkingLot.Park(new Car());
            }
            var list = new List<ParkingLot> { parkingLot };
            var parkingBoy = new ParkingBotOld(list);


            Assert.Throws<Exception>(() => parkingBoy.Park(new Car()));
        }
        
        [Fact]
        public void should_park_into_first_parking_lot_when_have_two_available_parking_lots()
        {
            var parkingLotA = new ParkingLot(_capacity);
            var parkingLotB = new ParkingLot(_capacity);
            var preNumOfCarA = parkingLotA.GetAvailableSpotNumber();
            var preNumOfCarB = parkingLotB.GetAvailableSpotNumber();
            var car = new Car();
            var list = new List<ParkingLot>(){parkingLotA, parkingLotB};
            var parkingBoy = new ParkingBotOld(list);

            parkingBoy.Park(car);

            Assert.Equal(preNumOfCarA - 1, parkingLotA.GetAvailableSpotNumber());
            Assert.Equal(preNumOfCarB, parkingLotB.GetAvailableSpotNumber());
        }
        [Fact]
        public void should_park_into_first_parking_lot_when_have_two_parking_lots_and_first_is_available()
        {
            var parkingLotA = new ParkingLot(_capacity);
            var parkingLotB = new ParkingLot(_capacity);
            for (var i = 0; i < 20; i++)
            {
                parkingLotB.Park(new Car());
            }
            var preNumOfCarA = parkingLotA.GetAvailableSpotNumber();
            var preNumOfCarB = parkingLotB.GetAvailableSpotNumber();
            var car = new Car();
            var list = new List<ParkingLot>(){parkingLotA, parkingLotB};
            var parkingBoy = new ParkingBotOld(list);

            parkingBoy.Park(car);

            Assert.Equal(preNumOfCarA - 1, parkingLotA.GetAvailableSpotNumber());
            Assert.Equal(preNumOfCarB, parkingLotB.GetAvailableSpotNumber());
        }
        [Fact]
        public void should_park_into_second_parking_lot_when_have_two_parking_lots_and_second_is_available()
        {
            var parkingLotA = new ParkingLot(_capacity);
            var parkingLotB = new ParkingLot(_capacity);
            for (var i = 0; i < 20; i++)
            {
                parkingLotA.Park(new Car());
            }
            var preNumOfCarA = parkingLotA.GetAvailableSpotNumber();
            var preNumOfCarB = parkingLotB.GetAvailableSpotNumber();
            var car = new Car();
            var list = new List<ParkingLot>(){parkingLotA, parkingLotB};
            var parkingBoy = new ParkingBotOld(list);

            parkingBoy.Park(car);

            Assert.Equal(preNumOfCarA, parkingLotA.GetAvailableSpotNumber());
            Assert.Equal(preNumOfCarB - 1, parkingLotB.GetAvailableSpotNumber());
        }
        [Fact]
        public void should_return_exception_when_have_two_parking_lots_and_both_of_them_are_full()
        {
            var parkingLotA = new ParkingLot(_capacity);
            var parkingLotB = new ParkingLot(_capacity);
            for (var i = 0; i < 20; i++)
            {
                parkingLotA.Park(new Car());
                parkingLotB.Park(new Car());
            }
            var car = new Car();
            var list = new List<ParkingLot>(){parkingLotA, parkingLotB};
            var parkingBoy = new ParkingBotOld(list);

            Assert.Throws<Exception>(() => parkingBoy.Park(car));
        }

    }
}