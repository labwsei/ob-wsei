namespace laby1
{

  partial class Program
  {
    public class Money
    {
      private decimal _value;

      private readonly Currency _currency;

      public override string ToString()
      {
        return $"{_value} {_currency}";
      }

      public decimal Value { get => _value; private set => _value = value; }
      public Currency Currency { get => _currency; }

      private Money(decimal value, Currency currency)
      {
        _value = value;
        _currency = currency;
      }
      public static Money Of(decimal value, Currency currency)
      {

        if (value > 0)
        {
          return new Money(value, currency);
        }
        else
        {
          throw new System.Exception("Class instace creation exception");
        }
      }
      public static Money ParseValue(string value, Currency currency)
      {
        return int.Parse(value) < 0 ? null : Of(int.Parse(value), currency);
      }
      public static Money OfWithException(decimal value, Currency currency)
      {
        return value < 0 ? null : new Money(value, currency);
      }

      public static Money operator *(Money money, decimal factor)
      {
        return Of(money.Value * factor, money.Currency);
      }

      public static bool operator >(Money a, Money b)
      {
        if (a.Currency != b.Currency)
        {
          throw new System.Exception("Different currency type ");
        }
        return a.Value > b.Value;
      }

      public static Money operator +(Money a, Money b)
      {
        if (a.Currency != b.Currency)
        {
          throw new System.Exception("Different currency type ");
        }
        return Of(a.Value + b.Value, a.Currency);
      }

      public static bool operator <(Money a, Money b)
      {
        if (a.Currency != b.Currency)
        {
          throw new System.Exception("Different currency type ");
        }
        return a.Value < b.Value;
      }
      public static bool operator !=(Money a, Money b)
      {
        return !(a == b);
      }
      public static bool operator ==(Money a, Money b)
      {
        return (a == b);
      }

      public static implicit operator decimal(Money money)
      {
        return money.Value;
      }

      public static explicit operator double(Money money)
      {
        return (double)money.Value;
      }

      public static explicit operator float(Money money)
      {
        return (float)money.Value;
      }

      public override bool Equals(object obj)
      {
        if (ReferenceEquals(this, obj))
        {
          return true;
        }

        if (ReferenceEquals(obj, null))
        {
          return false;
        }

        throw new System.NotImplementedException();
      }

      public override int GetHashCode()
      {
        throw new System.NotImplementedException();
      }
    }
  }
}
