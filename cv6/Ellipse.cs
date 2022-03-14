using System;

namespace cv6
{
public class Ellipse : Objekt2D
{
    public double Width { get; private set; }
        public double Height { get; private set; }
        public Ellipse(double width, double height)
        { 
            if( width < 0 || height < 0) throw new Exception("Cannot create object with negative dimensions");
            Width = width;
            Height = height;
        }
        public override double CalculateArea()
        {
            return Math.PI * Width * Height;
        }
        public override void Draw()
        {
            Console.WriteLine("Ellipse ({0},{1})", Width,Height);
        }
}}
