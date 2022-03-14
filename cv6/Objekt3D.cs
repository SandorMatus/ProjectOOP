using System;

namespace cv6
{
public abstract class Objekt3D : GrObjekt{
        public abstract double CalculateSurfaceArea();
        public abstract double CalculateVolume();
    }
}