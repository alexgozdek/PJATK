using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderPattern
{
    static class Program
    {
        public static string UppercaseFirstLetter(this string value)
        {
            if (value.Length > 0)
            {
                char[] array = value.ToCharArray();
                array[0] = char.ToUpper(array[0]);
                return new string(array);
            }
            return value;
        }

        class Car
        {
            private List<string> _parts = new List<string>();

            public void Add(string part)
            {
                _parts.Add(part);
            }

            public void Show()
            {
                Console.WriteLine("Car Parts -------");
                foreach (string part in _parts)
                    Console.WriteLine(part);
            }
        }

        abstract class Builder
        {
            public abstract void BuildDoors();
            public abstract void BuildEngine();
            public abstract Car GetCar();
        }

        class AudiBuilder : Builder
        {
            private Car _car = new Car();

            public override void BuildDoors()
            {
                _car.Add("Audi Doors");
            }

            public override void BuildEngine()
            {
                _car.Add("Audi Engine");
            }

            public override Car GetCar()
            {
                return _car;
            }
        }

        class BmbBuilder : Builder
        {
            private Car _car = new Car();

            public override void BuildDoors()
            {
                _car.Add("Bmw doors");
            }

            public override void BuildEngine()
            {
                _car.Add("Bmw Engine");
            }

            public override Car GetCar()
            {
                return _car;
            }
        }

        class Director
        {
            // Builder uses a complex series of steps
            public void Construct(Builder builder)
            {
                builder.BuildDoors();
                builder.BuildEngine();
            }
        }

        public sealed class ManufactorySingleton
        {
           private static ManufactorySingleton instance;

           private ManufactorySingleton() {}

           public static ManufactorySingleton Instance
           {
              get
              {
                 if (instance == null)
                 {
                    instance = new ManufactorySingleton();
                 }
                 return instance;
              }
           }
        }

        static void Main(string[] args)
        {
            var manufactory = ManufactorySingleton.Instance;

            // Create director and builders
            Director director = new Director();

            Builder b1 = new AudiBuilder();
            director.Construct(b1);
            Car p1 = b1.GetCar();
            p1.Show();

            Console.WriteLine("poczatek zdania.".UppercaseFirstLetter());                      
            Console.Read();
        }
    }
}

