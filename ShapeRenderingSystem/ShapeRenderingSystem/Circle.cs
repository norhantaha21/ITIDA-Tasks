using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeRenderingSystem
{
    public class Circle : Shape, IDrawable,IResizable
    {
        public double Redius {  get; set; }
        public override double Area()
        {
           return Math.PI * Redius* Redius;
        }

        public void Draw()
        {
            Console.WriteLine("  **");
            Console.WriteLine(" *  *");
            Console.WriteLine("  **");
            Console.WriteLine($"Area = {Area()}");
        }

        public void Scale(double factor)
        {
            Redius*=factor;
        }
    }
}
