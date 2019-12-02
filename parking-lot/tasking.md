//停车：
1. 
given 一个有空位的停车场，一个packigBoy，一辆车
when pb停车
then 返回一个对应该停车场和车的ticket

2. 
given 一个full的停车场，一个packigBoy，一辆车
when pb停车
then 返回一个一个错误信息"车位已满"

3
given 两个停车场，第一个a，第二个b，一个packigBoy，一辆车，ab都有车位
when pb停车
then 停车成功，停到a， 返回一个ticket

4
given 两个停车场，第一个a，第二个b，一个packigBoy，一辆车，a有车位，b没有车位
when pb停车
then 停车成功，停到第一个停车场， 返回一个ticket

5
given 两个停车场，第一个a，第二个b，一个packigBoy，一辆车，a满了，b有空车位
when pb停车
then 停车成功，停到第二个停车场b， 返回一个ticket

6
given 两个停车场，第一个a，第二个b，一个packigBoy，一辆车，ab都满了
when pb停车
then 返回一个一个错误信息"车位已满"

7.？
given abc,3个停车场，，一个packigBoy之管理a,b，一辆车
when 停车
then 返回一个一个错误信息"车位已满"


//取车
given 一个停车场，一个packigBoy，一辆车，一张有效的ticket
when pb取车
then 取到对应的车

given 一个停车场，一个packigBoy，一辆车，一张无效的ticket
when pb取车
then 取不到对应的车，Message"无效票据"


given 两个停车场，车停在了B，一个有效ticket
when pb取车
then 取到车

given 两个停车场，PakingBOy管理A，不管理B，车停在了B，一个有效ticket
when pb取车
then 取不到车，"无效的票据"