﻿using System;
using System.Collections.Generic;
using parking_lot;
using Xunit;

namespace parking_lot_test
{
    public class parking_bot_facts
    {
        public class parking_boy_facts
        {
            private int _capacity = 20;

            [Fact]
            public void should_park_a_car_into_a_parking_lot_which_has_space_and_get_a_ticket()
            {
                var list = new List<ParkingLot> {new ParkingLot(_capacity)};
                var parkingBoy = new ParkingBoy(list);

                var ticket = parkingBoy.Park(new Car());

                Assert.NotNull(ticket);
            }

            [Fact]
            public void should_not_park_a_car_into_a_parking_lot_which_has_no_space()
            {
                var parkingBot = new ParkingLot(_capacity);
                for (var i = 0; i < 20; i++)
                {
                    parkingBot.Park(new Car());
                }

                var list = new List<ParkingLot> {parkingBot};
                var parkingBoy = new ParkingBoy(list);

                Assert.Throws<Exception>(() => parkingBoy.Park(new Car()));
            }

            [Fact]
            public void should_park_into_first_parking_lot_when_have_two_available_parking_lots()
            {
                var parkingBotA = new ParkingLot(_capacity);
                var parkingBotB = new ParkingLot(_capacity);
                var preNumOfCarA = parkingBotA.GetAvailableSpotNumber();
                var preNumOfCarB = parkingBotB.GetAvailableSpotNumber();
                var car = new Car();
                var list = new List<ParkingLot>() {parkingBotA, parkingBotB};
                var parkingBoy = new ParkingBoy(list);

                parkingBoy.Park(car);

                Assert.Equal(preNumOfCarA - 1, parkingBotA.GetAvailableSpotNumber());
                Assert.Equal(preNumOfCarB, parkingBotB.GetAvailableSpotNumber());
            }

            [Fact]
            public void should_park_into_first_parking_lot_when_have_two_parking_lots_and_first_is_available()
            {
                var parkingBotA = new ParkingLot(_capacity);
                var parkingBotB = new ParkingLot(_capacity);
                for (var i = 0; i < 20; i++)
                {
                    parkingBotB.Park(new Car());
                }

                var preNumOfCarA = parkingBotA.GetAvailableSpotNumber();
                var preNumOfCarB = parkingBotB.GetAvailableSpotNumber();
                var car = new Car();
                var list = new List<ParkingLot>() {parkingBotA, parkingBotB};
                var parkingBoy = new ParkingBoy(list);

                parkingBoy.Park(car);

                Assert.Equal(preNumOfCarA - 1, parkingBotA.GetAvailableSpotNumber());
                Assert.Equal(preNumOfCarB, parkingBotB.GetAvailableSpotNumber());
            }

            [Fact]
            public void should_park_into_second_parking_lot_when_have_two_parking_lots_and_second_is_available()
            {
                var parkingBotA = new ParkingLot(_capacity);
                var parkingBotB = new ParkingLot(_capacity);
                for (var i = 0; i < 20; i++)
                {
                    parkingBotA.Park(new Car());
                }

                var preNumOfCarA = parkingBotA.GetAvailableSpotNumber();
                var preNumOfCarB = parkingBotB.GetAvailableSpotNumber();
                var car = new Car();
                var list = new List<ParkingLot>() {parkingBotA, parkingBotB};
                var parkingBoy = new ParkingBoy(list);

                parkingBoy.Park(car);

                Assert.Equal(preNumOfCarA, parkingBotA.GetAvailableSpotNumber());
                Assert.Equal(preNumOfCarB - 1, parkingBotB.GetAvailableSpotNumber());
            }

            [Fact]
            public void should_return_exception_when_have_two_parking_lots_and_both_of_them_are_full()
            {
                var parkingBotA = new ParkingLot(_capacity);
                var parkingBotB = new ParkingLot(_capacity);
                for (var i = 0; i < 20; i++)
                {
                    parkingBotA.Park(new Car());
                    parkingBotB.Park(new Car());
                }

                var car = new Car();
                var list = new List<ParkingLot>() {parkingBotA, parkingBotB};
                var parkingBoy = new ParkingBoy(list);

                Assert.Throws<Exception>(() => parkingBoy.Park(car));
            }

            [Fact]
            public void should_get_the_right_car_when_parking_boy_get_car_given_a_valid_ticket_and_a_parking_lot()
            {
                var parkinglot = new ParkingLot(_capacity);
                var boy = new ParkingBoy(new List<ParkingLot> {parkinglot});
                var car = new Car();
                var ticket = boy.Park(car);


                var gettedCar = boy.GetCar(ticket);

                Assert.NotNull(gettedCar);
                Assert.Equal(car, gettedCar);
            }
        }
    }
}