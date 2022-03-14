using System;

namespace cv6
{
public class Pyramid : Objekt3D{
    public int NumberOfSides {get; private set;}
    public double SideLength{get; private set;}
    public double Height{get; private set;}
    public Pyramid(int numberOfSides, double sideLength, double height){
        if(sideLength < 0 || height < 0) throw new Exception("Cannot create object with negative dimensions");
        if(numberOfSides < 3) throw new Exception("The pyramid must have atleast 3 sides");
        NumberOfSides = numberOfSides;
        SideLength = sideLength;
        Height = height;
    }
        public override void Draw()
        {
            Console.WriteLine("Pyramid (sides: {0}, side lenght = {1}, height = {2})", NumberOfSides, SideLength, Height);
        }
        private double BaseTriangleHeight()
        {
            return (SideLength/2) / Math.Tan(2 * Math.PI / NumberOfSides /2);
        }
        private double BaseArea()
        {
            return NumberOfSides * 1/2 * SideLength * BaseTriangleHeight();
        }
        public override double CalculateSurfaceArea()
        {
            double sideTriangleHeight = Math.Sqrt(Height * Height + BaseTriangleHeight() * BaseTriangleHeight());
            return BaseArea() + NumberOfSides * 1/2 * sideTriangleHeight * SideLength;
        }
        public override double CalculateVolume()
        {
            return 1.0 / 3 * BaseArea() * Height;
        }
    }
}