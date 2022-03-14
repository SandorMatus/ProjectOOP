using System;

namespace cv6
{
public class Rectangle : Objekt2D{
        public double Width { get; private set; }
        public double Height { get; private set; }
       public Rectangle(double width, double height)
       {
           if(width < 0 || height < 0) throw new Exception("Cannot create object with negative dimensions");
           Width = width;
           Height = height;
       }
        public override void Draw()
        {
            Console.WriteLine("Rectangle ({0} x {1})", Width, Height);
        }
        public override double CalculateArea()
        {
            return Width * Height;
        }
    }
}