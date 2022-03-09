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
      Console.WriteLine(tank2);
      Console.WriteLine(tank1);

      Console.WriteLine(money.ToString());


      Money[] bank =
{
    Money.Of(3, Currency.PLN),
    Money.Of(3m, Currency.USD),
    Money.Of(1m, Currency.PLN),
    Money.Of(4m, Currency.USD),
};

      Array.Sort(bank);
      for (int i = 0; i < bank.Length; i++)
      {
        Console.WriteLine(bank[i]);
      }



      Student[] students =
{
    new Student("Bingus", "Dingus", 6),
     new Student("Amogus", "Zingus", 10),
       new Student("Śmingus", "Roingus", 2.5m),
    new Student("Lingus", "Mingus", 25),
    new Student("Gingus", "Kongus", 12),
};

      Array.Sort(students);
      for (int i = 0; i < students.Length; i++)
      {
        Console.WriteLine(students[i]);
      }
    }
  }
}
