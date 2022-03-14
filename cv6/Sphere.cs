using System;

namespace cv6
{
public class Sphere : Objekt3D{
       public double Radius { get; private set;}
       public Sphere(double radius){
           if(radius < 0) throw new Exception("Cannot create object with negative dimensions");
           Radius = radius;
       }
        public override void Draw()
        {
            Console.WriteLine("Sphere (r = {0})", Radius);
        }
        public override double CalculateSurfaceArea()
        {
            return 4 * Math.PI * Radius * Radius;
        }
        public override double CalculateVolume()
        {
            return 4/3 * Math.PI * Radius * Radius * Radius;
        }
    }
}