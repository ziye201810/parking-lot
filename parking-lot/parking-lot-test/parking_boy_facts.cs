using System;
using System.Collections.Generic;
using parking_lot;
using Xunit;

namespace parking_lot_test
{
    public class parking_boy_facts
    {

        [Fact]
        public void should_park_a_car_into_a_parking_lot_which_has_space_and_get_a_ticket()
        {
            var list = new List<ParkingLot> {new ParkingLot()};
            var parkingBoy = new ParkingBoy(list);

            var ticket = parkingBoy.Park(new Car());

            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_not_park_a_car_into_a_parking_lot_which_has_no_space()
        {
            var parkingLot = new ParkingLot();
            for (var i = 0; i < 20; i++)
            {
                parkingLot.Park(new Car());
            }
            var list = new List<ParkingLot> { parkingLot };
            var parkingBoy = new ParkingBoy(list);


            Assert.Throws<Exception>(() => parkingBoy.Park(new Car()));
        }

//        [Fact]
//        public void should_park_into_fist_parking_lot_when_have_two_available_parking_lots()
//        {
//           var A = new Mock<ParkingLot>();
//           var B = new Mock<ParkingLot>();
//           A.Setup(a => a.Park(It.IsAny<Car>())).Returns(new object());
//           B.Setup(b => b.Park(It.IsAny<Car>())).Returns(new Exception());
//           var car = new Car();
//           var list = new List<ParkingLot> { A.Object, B.Object };
//
//           var parkingBoy = new ParkingBoy(list);
//           parkingBoy.Park(car);
//
//           A.Verify(x => x.Park(It.IsAny<Car>()));
//        }
        [Fact]
        public void should_park_into_first_parking_lot_when_have_two_available_parking_lots()
        {
            var parkingLotA = new ParkingLot();
            var parkingLotB = new ParkingLot();
            var preNumOfCarA = parkingLotA.GetAvailableSpotNumber();
            var preNumOfCarB = parkingLotB.GetAvailableSpotNumber();
            var car = new Car();
            var list = new List<ParkingLot>(){parkingLotA, parkingLotB};
            var parkingBoy = new ParkingBoy(list);

            parkingBoy.Park(car);

            Assert.Equal(preNumOfCarA - 1, parkingLotA.GetAvailableSpotNumber());
            Assert.Equal(preNumOfCarB, parkingLotB.GetAvailableSpotNumber());
        }
        [Fact]
        public void should_park_into_first_parking_lot_when_have_two_parking_lots_and_first_is_available()
        {
            var parkingLotA = new ParkingLot();
            var parkingLotB = new ParkingLot();
            for (var i = 0; i < 20; i++)
            {
                parkingLotB.Park(new Car());
            }
            var preNumOfCarA = parkingLotA.GetAvailableSpotNumber();
            var preNumOfCarB = parkingLotB.GetAvailableSpotNumber();
            var car = new Car();
            var list = new List<ParkingLot>(){parkingLotA, parkingLotB};
            var parkingBoy = new ParkingBoy(list);

            parkingBoy.Park(car);

            Assert.Equal(preNumOfCarA - 1, parkingLotA.GetAvailableSpotNumber());
            Assert.Equal(preNumOfCarB, parkingLotB.GetAvailableSpotNumber());
        }
        [Fact]
        public void should_park_into_second_parking_lot_when_have_two_parking_lots_and_second_is_available()
        {
            var parkingLotA = new ParkingLot();
            var parkingLotB = new ParkingLot();
            for (var i = 0; i < 20; i++)
            {
                parkingLotA.Park(new Car());
            }
            var preNumOfCarA = parkingLotA.GetAvailableSpotNumber();
            var preNumOfCarB = parkingLotB.GetAvailableSpotNumber();
            var car = new Car();
            var list = new List<ParkingLot>(){parkingLotA, parkingLotB};
            var parkingBoy = new ParkingBoy(list);

            parkingBoy.Park(car);

            Assert.Equal(preNumOfCarA, parkingLotA.GetAvailableSpotNumber());
            Assert.Equal(preNumOfCarB - 1, parkingLotB.GetAvailableSpotNumber());
        }
        [Fact]
        public void should_return_exception_when_have_two_parking_lots_and_both_of_them_are_full()
        {
            var parkingLotA = new ParkingLot();
            var parkingLotB = new ParkingLot();
            for (var i = 0; i < 20; i++)
            {
                parkingLotA.Park(new Car());
                parkingLotB.Park(new Car());
            }
            var car = new Car();
            var list = new List<ParkingLot>(){parkingLotA, parkingLotB};
            var parkingBoy = new ParkingBoy(list);

            Assert.Throws<Exception>(() => parkingBoy.Park(car));
        }

        #region GetCar
        [Fact]
        public void should_get_the_right_car_when_parking_boy_get_car_given_a_valid_ticket_and_a_parking_lot()
        {
            var parkinglot=new ParkingLot();
            var boy=new ParkingBoy(new List<ParkingLot>{parkinglot});
            var car=new Car();
            var ticket = boy.Park(car);


            var gettedCar=boy.GetCar(ticket);
            
            Assert.NotNull(gettedCar);
            Assert.Equal(car,gettedCar);
        }


        [Fact]
        public void should_throw_exception_when_parking_boy_get_car_given_an_invalid_ticket_and_a_parking_lot()
        {
            var parkinglot = new ParkingLot();
            var boy = new ParkingBoy(new List<ParkingLot> {parkinglot});
            var car = new Car();
            boy.Park(car);

            Assert.Throws<Exception>(() => boy.GetCar(new object()));
        }

        [Fact]
        public void should_get_the_right_car_when_parking_boy_get_car_given_a_valid_ticket_and_two_parking_lot_and_parking_lot_A_is_full()
        {
            var parkinglotA=new ParkingLot();
            var parkinglotB=new ParkingLot();
            var boy=new ParkingBoy(new List<ParkingLot>{parkinglotA,parkinglotB});
            for (int i = 0; i < 20; i++)
            {
                parkinglotA.Park(new Car());
            }
            var car=new Car();
            var ticket = boy.Park(car);
            
            var gettedCar=boy.GetCar(ticket);
            
            Assert.NotNull(gettedCar);
            Assert.Equal(car,gettedCar);
        }

        [Fact]
        public void should_throw_exception_when_parking_boy_get_car_given_a_valid_ticket_and_two_parking_lot_and_parking_lot_A_is_managed_by_parking_boy()
        {
            var parkinglotA=new ParkingLot();
            var parkinglotB=new ParkingLot();
            var boy=new ParkingBoy(new List<ParkingLot>{parkinglotA});
            var car=new Car();
            var ticket = parkinglotB.Park(car);

            Assert.Throws<Exception>(() => boy.GetCar(ticket));
        }

        #endregion
    }
}
