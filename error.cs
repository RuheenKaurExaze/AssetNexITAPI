using System;
using System.Collections.Generic;
using ConsoleApp_FirstApp.ConsoleApp_FirstApp;

namespace ConsoleApp_FirstApp

{
    class Program
    {
        static void Main(string[] args)
        {
            Conosle.WriteLine("Welcome to Galaxy News!");
            IterateThroughList();
            ConsoleApp.ReadKey();


        }

        private static void IterateThroughlist()
        {
            var theGalaxies = new List<Galaxy>

            {
                new Galaxy() { Name = "Tadpole", MegaLightYears = 400, GalaxyType = new GType('S') },
                new Galaxy() { Name = "Pinwheel", MegaLightYears = 25, GalaxyType = new GType('S') },
                new Galaxy() { Name = "Cartwheel", MegaLightYears = 500, GalaxyType = new GType('L') },
                new Galaxy() { Name = "Small Magellanic Cloud", MegaLightYears = 2, GalaxyType = new GType('I') },
                new Galaxy() { Name = "Andromeda", MegaLightYears = 3, GalaxyType = new GType('S') },
                new Galaxy() { Name = "Maffei 1", MegaLightYears = 11, GalaxyType = new GType('E') }
            };

            foreach (Galaxy theGalaxy in theGalaxies)
            {
                ConsoleApp_FirstApp.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears + ", " + theGalaxy.GalaxyType);
            }


            public class Galaxy
        {

            public string Name { get; set; }
            public double MegaLightYears { get; set; }
            public object GalaxyType { get; set; }
        }

        public class GType //name of the class that stores the galaxy type , therfore we try to show tha galaxy type not the class name

        {
            public GType(char type)
            {
                switch (type)

                {
                    case 'S':
                        MyGType = Type.Spiral;
                        break;
                    case 'E':
                        MyGtype = Type.Elliptical;
                        break;
                    case 'I':
                        MyGType = Type.Irregular;
                    case 'L':
                        MyGType = Type.Lenticular;
                        break;
                    default:
                        break;
                }

            }
            public object MyGtype { get; set; }
            private enum Type { Spiral, Elliptical, Irregular, Lentricular}
        }
    }

}

}

    }


   using System;

class ArrayExample
{
	static void Main()
	{
		char[] letters = { 'f', 'r', 'e', 'd', ' ', 's', 'm', 'i', 't', 'h' };
		string name = "";
		int[] a = new int[10];
		for (int i = 0; i < letters.Length; i++)
		{
			name += letters[i];
			a[i] = i + 1;
			SendMessage(name, a[i]);
		}
		Console.ReadKey();
	}




	static void SendMessage(string name, int msg)
	{
		Console.WriteLine("Hello, " + name + "! Count to " + msg);
	}

   class ArrayExample
    { }
    static void Main()
    {

    }

	public class Program
	{

		public static void Main(String[] args)
		{
			Console.WriteLine("Average finder v0.1");
			double avg = FindAverage(args);
			Console.WriteLine("The average is " + avg);
		}

		private static double FindAverage(String[] input)
		{
			double result = 0;
			foreach (String s in input)
			{
				result += Int32.Parse(s);
			}
			return result;
        }
    }

    public class Program
    { }
    public static void Main(string[] args)
    {
        Console.WriteLine("Average finder ");
        double avg = FindAverage(args);
        Console.WriteLine("The average is " + avg);

    }

    private static double FindAverage(string[] input)
    {
        double result = 0;
        foreach (string s in input)
        {
            result += Int32.Parse(s);

        }
        return result;

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Average finder");
            double avg = FindAverage(args);
            Console.WriteLine("The average is" + avg);

        }

        private static double FindAverage(string[] input)
        {
            double result = 0;
            foreach(string s in input)
            {
                result += Int32.Parse(s);

            }

            return result;

        }


        public class Program
        { }
        public static void Main(string[] args)
        {
            Console.WriteLine("Average Finder");
            double avg = FindAverage(args);
            Console.WriteLine("The average is" + avg);

        }

        private static double FindAverage(string[] input)
        {
            double result = 0;
            foreach(string s in input)
            {
                result += Int32.Parse(s);
            }

            return result;

        }
    }
