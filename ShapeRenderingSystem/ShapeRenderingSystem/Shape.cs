using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeRenderingSystem
{
    public abstract class Shape
    {
        public abstract double Area();

        public void Describe()
        {
            Console.WriteLine($"Class Name : {GetType().Name}");
            Console.WriteLine($"Area : {Area()}");
        }
    }
}
