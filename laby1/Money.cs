namespace laby1
{

    public class Money : System.IEquatable<Money>, System.IComparable<Money>
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

        public bool Equals(Money other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _value == other._value && _currency.Equals(other._currency);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Money)obj);
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(_value, _currency);
        }

        public int CompareTo(Money other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var currencyComparison = _currency.CompareTo(other._currency);
            if (currencyComparison != 0) return currencyComparison;
            return _value.CompareTo(other._value);
        }
    }

    public static class MoneyExtension
    {
        public static Money Percent(this Money money, decimal percent)
        {
            return Money.Of((money.Value * percent) / 100m, money.Currency) ?? throw new
            System.ArgumentException();
        }

        public static Money ToCurrency(this Money money, Currency targetCurrency, decimal value)
        {
            return Money.Of((money.Value / (targetCurrency == money.Currency ? 1 : value)) / 100m, targetCurrency) ?? throw new
            System.ArgumentException();
        }
    }
}
