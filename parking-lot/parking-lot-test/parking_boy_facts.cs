using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Moq;
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

        [Fact]
        public void should_park_into_fist_parking_lot_when_have_two_available_parking_lots()
        {
           var A = new Mock<ParkingLot>();
           var B = new Mock<ParkingLot>();
           A.Setup(a => a.Park(It.IsAny<Car>())).Returns(new object());
           B.Setup(b => b.Park(It.IsAny<Car>())).Returns(new Exception());
           var car = new Car();
           var list = new List<ParkingLot> { A.Object, B.Object };

           var parkingBoy = new ParkingBoy(list);
           parkingBoy.Park(car);

           A.Verify(x => x.Park(It.IsAny<Car>()));
        }
    }
}
