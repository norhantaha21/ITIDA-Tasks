using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeRenderingSystem
{
    public class Triangle : Shape, IDrawable
    {
        public double Base {  get; set; }
        public double Height { get; set; }
        public override double Area()
        {
            return 0.5 * Base * Height;
        }

        public void Draw()
        {
            Console.WriteLine("    *");
            Console.WriteLine("  ***");
            Console.WriteLine(" *****");
            Console.WriteLine($"Area = {Area()}");
        }
    }
}
