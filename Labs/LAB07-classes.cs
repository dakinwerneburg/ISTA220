
Paper View
using System;


namespace Classes
{
    class Program
    {
        static void doWork()
        {
            Point origin = new Point(2,5);
            Point origin2 = new Point();
            Point origin3 = new Point(3, 5, 7);
            Point bottomRight = new Point(1366, 768);
            Point point1 = new Point(0, 0);
            Point point2 = new Point(3, 4);
            Point origin4 = new Point(1, 2, 3);
            Console.WriteLine($"Distance between point 1 and point 2 is: " +
                $"{point1.DistanceTo(point2)}");
            Console.WriteLine($"Distance between point 2 and point 1 is: " +
                $"{point2.DistanceTo(point1)}");
            Console.WriteLine($"Distance between point 1 and point 1 is: " +
               $"{point1.DistanceTo(point1)}");
            Console.WriteLine($"The number of points created is: " +
                $"{Point.ObjectCount()}");
            Console.WriteLine($"Distance between origin 3 and origin 4 is: " +
                $"{origin3.DistanceToTriple(origin4)}");
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

    class Point
    {

        private int _x = 0;
        private int _y = 0;
        private int _z = 0;
        private int serialNum;
        private static int objectCount = 0;
        public static int ObjectCount()
        {
            return objectCount;
        }
        public Point()
        {
            _x = -1;
            _y = -1;
            objectCount++;
            serialNum = objectCount;
            Console.WriteLine($"Default constructor called, point number {serialNum}");
        }
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
            objectCount++;
            serialNum = objectCount;
            Console.WriteLine($"x: {x}, y: {y}, point number {serialNum}");
        }

        public Point(int x, int y, int z)
        {
            _x = x;
            _y = y;
            _z = z;
            objectCount++;
            serialNum = objectCount;
            Console.WriteLine($"x: {_x}, y: {_y}, z: {_z}, point number {serialNum}");
        }

        public double DistanceTo(Point other)
        {
            int xDiff = _x - other._x;
            int yDiff = _y - other._y;
            double distance = Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff));
            return distance;
        }

        public double DistanceToTriple(Point other2)
        {
            int xDiff = _x - other2._x;
            int yDiff = _y - other2._y;
            int zDiff = _z - other2._z;
            double distance = Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff) + (zDiff * zDiff));
            return distance;
        }
    }
}