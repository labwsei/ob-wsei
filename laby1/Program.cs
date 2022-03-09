using System;

namespace laby1
{
  partial class Program
  {
    static void Main(string[] args)
    {
      Money money = Money.Of(10, Currency.PLN);
      Money result = money * 5.2m;
      Console.WriteLine(result.Value);
      Money sum = money + result;
      Money sum2 = sum;
      Console.WriteLine(sum2.Value);

      Tank tank1 = new Tank(30);
      Tank tank2 = new Tank(50);
      tank1.refuel(30);
      tank2.refuel(25);
      tank2.refuel(tank1, 10);
      Console.WriteLine(tank2.Level);
      Console.WriteLine(tank1.Level);
    }
  }
}
