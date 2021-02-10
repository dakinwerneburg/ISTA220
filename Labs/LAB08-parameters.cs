

using System;




namespace Parameters
{
    class Program
    {
        static void doWork()
        {
            int teri = 0;
            Console.WriteLine(teri);
            Pass.Value(teri);
            Console.WriteLine(teri);
            teri = Pass.SetTeri();
            Console.WriteLine(teri);

            Console.WriteLine("-----------");

            int i = 0;
            Console.WriteLine($"i is {i}");
            Pass.Value2(ref i);
            Console.WriteLine(i);

            Console.WriteLine("-----------");

            WrappedInt wi = new WrappedInt();
            Console.WriteLine(wi.Number);
            Pass.Reference(wi);
            Console.WriteLine(wi.Number);

            Console.WriteLine(wi.Idontknow);
            Pass.Reference2(wi);
            Console.WriteLine(wi.Idontknow);

            Console.WriteLine(wi.isTrue);
            Pass.Reference3(wi);
            Console.WriteLine(wi.isTrue);

            Console.ReadKey();

            Duck daffy = new Duck();
            Console.WriteLine($"daffy's name is [{daffy.Name}]");
            daffy.Name = "Daffy";
            Console.WriteLine($"daffy's name is now [{daffy.Name}]");

            daffy.SetName("daffidil");
            Console.WriteLine($"Daffy's Name is now {daffy.Name}");

            Duck huey = new Duck();
            huey.SetName("Huey");
            Console.WriteLine(huey.Name);

            Console.ReadKey();
        }


        



        static void Main(string[] args)
        {
            try
            {
                doWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class Pass
    {
        public static void Value(int param)
        {
            param = 42;
            Console.WriteLine($"    in value param is {param}");
        }

        public static void Value2(ref int param2)
        {
            param2 = 42;
            Console.WriteLine($"    in value param2 is {param2}");
        }

        internal static int SetTeri()
        {
            return 99;
        }

        public static void Reference(WrappedInt param)
        {
            param.Number = 42;
        }

        public static void Reference2(WrappedInt param)
        {
            param.Idontknow = "Hello World";
        }

        public static void Reference3(WrappedInt param)
        {
            param.isTrue = true;
        }
    }

    internal class Duck
    {
        public string Name;

        internal void SetName(string name)
        {
            Name = name;
        }
    }

    class WrappedInt
    {
        public int Number;
        public string Idontknow;
        public bool isTrue;
    }
}
