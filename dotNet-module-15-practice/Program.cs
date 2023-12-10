using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_module_15_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(MyClass);

            Console.WriteLine($"Имя класса: {type.Name}");

            ConstructorInfo[] constructors = type.GetConstructors();
            Console.WriteLine("Список конструкторов:");
            foreach (var constructor in constructors)
            {
                Console.WriteLine($"{constructor}");
            }

            Console.WriteLine("Список полей и свойств:");
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fields)
            {
                Console.WriteLine($"{field.FieldType} {field.Name}");
            }

            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in properties)
            {
                Console.WriteLine($"{prop.PropertyType} {prop.Name}");
            }

            Console.WriteLine("Список методов:");
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var method in methods)
            {
                Console.WriteLine($"{method.ReturnType} {method.Name}");
            }

            MyClass instance = (MyClass)Activator.CreateInstance(type);

            PropertyInfo propInfo = type.GetProperty("PublicProperty");
            propInfo.SetValue(instance, 20);

            MethodInfo methodInfo = type.GetMethod("PublicMethod");
            methodInfo.Invoke(instance, null);

            MethodInfo privateMethodInfo = type.GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            privateMethodInfo.Invoke(instance, null);

            Console.ReadLine();
        }
    }
}
class MyClass
{
    private int privateField = 10;

    public MyClass()
    {
    }

    public MyClass(int value)
    {
        privateField = value;
    }

    public int PublicProperty { get; set; }

    private void PrivateMethod()
    {
        Console.WriteLine("Private method called.");
    }

    public void PublicMethod()
    {
        Console.WriteLine("Public method called.");
    }
}
