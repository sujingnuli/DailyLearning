using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.Clzz.Shape
{
    class AreaComparer : IComparer<IShape> { 
     
        public int Compare(IShape x, IShape y)
        {
            return x.Area.CompareTo(y.Area);
        }
}
   public class ShapeTest
    {
       List<Circle> circles;
       List<Square> squares;
       public void Init() {
           circles = new List<Circle>
           {
               new Circle(new Point(0,0),5),
               new Circle(new Point(10,5),20)
           };
           squares = new List<Square>
           {
               new Square(new Point(5,10),5),
               new Square(new Point(-10,0),2)
           };
       }
       public void test1() {

           IComparer<IShape> areaComparer = new AreaComparer();
           circles.Sort(areaComparer);

           circles.ForEach(circle =>
           {
               Console.WriteLine("radius ={0},Area={1}", circle.radius, circle.Area);
           });
       }
       public void test2() {
           Func<Square> squareFactory = () => new Square(new Point(5, 5), 10);
           Func<IShape> shapeFactory = squareFactory;

           Action<IShape> shapePrinter = shape => Console.WriteLine(shape.Area);
           Action<Square> squarePrinter = shapePrinter;

           shapePrinter(shapeFactory());
           squarePrinter(squareFactory());
       }
    }
}
