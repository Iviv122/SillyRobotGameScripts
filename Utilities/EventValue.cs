using System;
//-----!!CHATGPT GENERATED CLASS!!-----////
public class EventfullValue<T> where T : struct, IComparable, IConvertible
{
    private T _value;

    public event Action ValueChanged;

    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            ValueChanged?.Invoke();
        }
    }

    public EventfullValue(T initialValue)
    {
        _value = initialValue;
    }

    private static T ApplyOperation(T a, T b, Func<double, double, double> operation)
    {
        double da = a.ToDouble(System.Globalization.CultureInfo.InvariantCulture);
        double db = b.ToDouble(System.Globalization.CultureInfo.InvariantCulture);
        double result = operation(da, db);
        return (T)Convert.ChangeType(result, typeof(T));
    }

    private static T ApplyUnaryOperation(T a, Func<double, double> operation)
    {
        double da = a.ToDouble(System.Globalization.CultureInfo.InvariantCulture);
        double result = operation(da);
        return (T)Convert.ChangeType(result, typeof(T));
    }

    // Operator +
    public static EventfullValue<T> operator +(EventfullValue<T> a, T b)
    {
        a.Value = ApplyOperation(a._value, b, (x, y) => x + y);
        return a;
    }

    // Operator -
    public static EventfullValue<T> operator -(EventfullValue<T> a, T b)
    {
        a.Value = ApplyOperation(a._value, b, (x, y) => x - y);
        return a;
    }

    // Operator *
    public static EventfullValue<T> operator *(EventfullValue<T> a, T b)
    {
        a.Value = ApplyOperation(a._value, b, (x, y) => x * y);
        return a;
    }

    // Operator /
    public static EventfullValue<T> operator /(EventfullValue<T> a, T b)
    {
        a.Value = ApplyOperation(a._value, b, (x, y) => x / y);
        return a;
    }

    // Operator ++ (prefix)
    public static EventfullValue<T> operator ++(EventfullValue<T> a)
    {
        a.Value = ApplyUnaryOperation(a._value, x => x + 1);
        return a;
    }

    // Operator -- (prefix)
    public static EventfullValue<T> operator --(EventfullValue<T> a)
    {
        a.Value = ApplyUnaryOperation(a._value, x => x - 1);
        return a;
    }

    // Implicit conversion to T
    public static implicit operator T(EventfullValue<T> resource) => resource._value;

    // Implicit conversion from T
    public static implicit operator EventfullValue<T>(T value) => new EventfullValue<T>(value);

    public override string ToString()
    {
        return Value.ToString();
    }
}

