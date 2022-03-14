using System;

namespace cv6
{
public class Circle : Objekt2D{
    public double Radius {get; private set;}
    public Circle(double radius)
        {
            if (radius < 0 ) throw new Exception("Cannot create object with negative dimensions");
            Radius = radius;
        }
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
        public override void Draw()
        {
            Console.WriteLine("Circle {0} ", Radius);
        }
    }
}