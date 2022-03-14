namespace cv6{
    public class Program{
        public static void Main(string[] args){
            GrObjekt[] Objects = new GrObjekt[]
            {
                new Circle(10), new Rectangle(10, 5), new Ellipse(10, 5), new Triangle(10, 10, 14.2),
                new Cube(10, 5, 2), new Cyllinder(10, 5), new Sphere(10), new Pyramid(5, 10, 3)
            };
            foreach (GrObjekt CurrentObject in Objects)
            {
                CurrentObject.Draw();
                if(CurrentObject is Objekt2D){
                    Console.WriteLine("Object area : {0:F2}\n", ((Objekt2D)CurrentObject).CalculateArea());
                }
                else if(CurrentObject is Objekt3D){
                    Console.WriteLine("Object surface area : {0:F2}, ", ((Objekt3D)CurrentObject).CalculateSurfaceArea());
                    Console.WriteLine("Object volume : {0:F2}\n", ((Objekt3D)CurrentObject).CalculateVolume());
                }
            }
        }
    }
}
