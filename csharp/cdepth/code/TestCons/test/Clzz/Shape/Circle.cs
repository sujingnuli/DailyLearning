using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.Clzz.Shape
{
    public  class Circle:IShape
    {
        public Point p { get; set; }
        public double radius { get; set; }
        private double area;
        public double Area { get { 
            return 3.14*radius*radius;
        }
        set{
            area = value;
        }}
        public Circle(Point p, double radius) {
            this.p = p;
            this.radius = radius;
            
        }
      
    }
}
