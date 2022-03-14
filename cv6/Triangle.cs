using System;

namespace cv6
{
public class Triangle : Objekt2D
{
    public double SideA {get; private set;}
    public double SideB {get; private set;}
    public double SideC {get; private set;}
    public Triangle(double sideA, double sideB, double sideC){
        if(sideA < 0 || sideB < 0 || sideC < 0) throw new Exception("Cannot create object with negative dimensions");
        if(sideA + sideB < sideC || sideB + sideC < sideA || sideC + sideA < sideB) throw new Exception("This triangle does not exist");
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }
    public override void Draw(){
        Console.WriteLine("Triangle (a = {0}, b = {1}, c = {2})", SideA, SideB, SideC);
    }
    public override double CalculateArea(){
        //Heron's formula
        double s = (SideA + SideB + SideC) /2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }
}
}