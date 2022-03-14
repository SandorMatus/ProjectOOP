using System;

namespace cv6
{
public class Cyllinder : Objekt3D{
        public double Height { get; private set;}
        public double BaseRadius { get; private set;}
        public Cyllinder(double height, double baseRadius){
            if(height < 0 || baseRadius < 0) throw new Exception("Cannor create object with negative dimensions");
            Height = height;
            BaseRadius = baseRadius;
        }
        public override void Draw()
        {
            Console.WriteLine("Cyllinder (h = {0}, r = {1})", Height, BaseRadius);
        }
        public override double CalculateSurfaceArea()
        {
            return 2 * Math.PI * BaseRadius * BaseRadius + 2 * Math.PI * BaseRadius * Height;
        }
        public override double CalculateVolume()
        {
            return Math.PI * BaseRadius * BaseRadius * Height;
        }
    }
}