1. 
given 一个有空位的停车场，一个packingBot，一辆车
when pb停车
then 返回一个ticket

2. 
given 一个full的停车场，一个packingBot，一辆车
when pb停车
then 返回一个一个错误信息"车位已满"

3
given 两个停车场，第一个a，第二个b，一个packigBot，一辆车，ab都有车位
when pb停车
then 停车成功，停到a， 返回一个ticket

4
given 两个停车场，第一个a，第二个b，一个packingBot，一辆车，a有车位，b没有车位
when pb停车
then 停车成功，停到第一个停车场a， 返回一个ticket

5
given 两个停车场，第一个a，第二个b，一个packingBot，一辆车，a满了，b有空车位
when pb停车
then 停车成功，停到第二个停车场b， 返回一个ticket
