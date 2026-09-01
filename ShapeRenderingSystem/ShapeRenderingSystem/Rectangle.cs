using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeRenderingSystem
{
    public class Rectangle : Shape, IDrawable,IResizable
    {
        public double Width {  get; set; }
        public double Height { get; set; }

        public override double Area()
        {
            return Width * Height;
        }

        public void Draw()
        {
            Console.WriteLine("*******");
            Console.WriteLine("*     *");
            Console.WriteLine("*******");
            Console.WriteLine($"Area = {Area()}");
        }

        public void Scale(double factor)
        {
           Width *= factor;
            Height *= factor;
        }
    }
}
