namespace laby1
{
    partial class Program
    {
        public class Money
        {
            private decimal _value;

            private readonly Currency _currency;

            public decimal Value { get => _value; private set => _value = value; }
            public Currency Currency { get => _currency; }

            private Money(decimal value, Currency currency)
            {
                _value = value;
                _currency = currency;
            }
            public static Money? Of(decimal value, Currency currency)
            {

                if (value < 0)
                {
                    return new Money(value, currency);
                }
                else
                {
                    throw new System.Exception("Class instace creation exception");
                }
            }
            public static Money? ParseValue(string value, Currency currency)
            {
                return int.Parse(value) < 0 ? null : new Money(int.Parse(value), currency);
            }
            public static Money? OfWithException(decimal value, Currency currency)
            {
                return value < 0 ? null : new Money(value, currency);
            }

            public static Money operator *(Money money, decimal factor)
            {
                return new Money(money.Value * factor, money.Currency);
            }

            public static bool operator >(Money a, Money b)
            {
                return a.Value > b.Value;
            }

            public static bool operator <(Money a, Money b)
            {
                return a.Value < b.Value;
            }
        }
    }
}
