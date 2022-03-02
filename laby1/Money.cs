namespace laby1
{
    partial class Program
    {
        public class Money
        {
            private readonly decimal _value;

            private readonly Currency _currency;

            private Money(decimal value, Currency currency)
            {
                _value = value;
                _currency = currency;
            }
            public static Money? Of(decimal value, Currency currency)
            {

                if (value < 0)
                {
                    try
                    {
                        return new Money(value, currency);
                    }
                    catch (System.Exception ex)
                    {
                        throw new System.Exception("Class instace creation exception")
                    }
                }
                return null;
            }
            public static Money? OfWithException(decimal value, Currency currency)
            {
                return value < 0 ? null : new Money(value, currency);
            }
        }
    }
}
