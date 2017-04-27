using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp12.Paralle
{
    public  class OrderedParallelRangeGenerator:MandelBrotGenerator
    {
        private OrderedParallelRangeGenerator(ImageOptions options):base(options) { 
            
        }
        //static void Main() {
        //    var generator = new OrderedParallelRangeGenerator(ImageOptions.Default);
        //    generator.Display();
        //}
        protected override byte[] GeneratePixels()
        {
            var query = from row in Enumerable.Range(0, Height)
                        from col in Enumerable.Range(0, Width)
                        select ComputeIndex(row, col);
            return query.ToArray();
        }
        
    }
}
