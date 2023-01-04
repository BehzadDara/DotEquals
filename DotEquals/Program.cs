// == handles null but .Equals throw an exception
string? p = null;
string? q = "notNull";
Console.WriteLine($"p={p}, q={q}");
Console.WriteLine($"p == q: {p == q}");
//Console.WriteLine(p.Equals(q)); // exception
Console.WriteLine("--------------------------------------------------");

// == and .Equals both compare the value of value types
int x = 5, y = 5, z = 10;

Console.WriteLine($"x={x}, y={y}, z={z}");
Console.WriteLine($"x == y: {x == y}");
Console.WriteLine($"x.Equals(y): {x.Equals(y)}");
Console.WriteLine($"x == z: {x == z}");
Console.WriteLine($"x.Equals(z): {x.Equals(z)}");
Console.WriteLine("--------------------------------------------------");

// == and .Equals both compare the equality of instance in reference types ( string compare the value )
MyClass a = new() { myField = "s1" };
MyClass b = a;
MyClass c = new() { myField = "s1" };

Console.WriteLine($"a={a.myField}, b={b.myField}, c={c.myField}");
Console.WriteLine($"a == b: {a == b}");
Console.WriteLine($"a.Equals(b): {a.Equals(b)}");
Console.WriteLine($"a == c: {a == c}");
Console.WriteLine($"a.Equals(c): {a.Equals(c)}");
Console.WriteLine("--------------------------------------------------");

// .Equals method can be overridden ( +, -, ++, ..... can be overridden too )
MyClass2 d = new("s1");
MyClass2 e = new("s1");

Console.WriteLine($"d={d.MyField}, e={e.MyField}");
Console.WriteLine($"d == e: {d == e}");
Console.WriteLine($"d.Equals(e): {d.Equals(e)}");
Console.WriteLine($"d + e: {(d + e).MyField}");
Console.WriteLine($"d++: {d++.MyField}");
Console.WriteLine("--------------------------------------------------");

class MyClass
{
    public string? myField;
}

class MyClass2 : IEquatable<object>
{
    public MyClass2(string myField)
    {
        MyField = myField;
    }

    private string? _MyField;
    public string MyField
    {
        get => _MyField ?? string.Empty;
        set => _MyField = value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not MyClass2 item) return false;

        return item.MyField == MyField;
    }

    public static bool operator ==(MyClass2? obj1, MyClass2? obj2)
    {
        if (ReferenceEquals(obj1, obj2))
            return true;
        if (obj1 is null)
            return false;
        return obj1.Equals(obj2);
    }

    public static bool operator !=(MyClass2 obj1, MyClass2 obj2) => !(obj1 == obj2);

    public override int GetHashCode()
    {
        return MyField.GetHashCode();
    }

    public static MyClass2 operator +(MyClass2 obj1, MyClass2 obj2)
    {
        return new(obj1.MyField + obj2.MyField);
    }

    public static MyClass2 operator ++(MyClass2 obj1)
    {
        obj1.MyField = obj1.MyField.ToUpper();
        return obj1;
    }

}