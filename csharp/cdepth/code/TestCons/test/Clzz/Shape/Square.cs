using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.Clzz.Shape
{
    public class Square:IShape
    {
        public Point p { get; set; }
        public double Len { get; set; }
        private double area;
        public double Area {
            get {
                return Len * Len;
            }
            set {
                area = value;
            }
        }
        public Square(Point p,int Len) {
            this.p = p;
            this.Len = Len;
        }
    }
}
