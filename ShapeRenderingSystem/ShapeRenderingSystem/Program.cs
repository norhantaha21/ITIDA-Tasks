using System.Diagnostics;

namespace ShapeRenderingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes =
            {
                new Circle { Redius = 5 },
                new Rectangle { Width = 4, Height = 6 }
            };

            foreach (Shape shape in shapes)
            {
                shape.Describe();
                ((IDrawable)shape).Draw();
            }

            ScaleAll(new IResizable[]
            {
                new Circle { Redius = 5 },
                new Rectangle { Width = 4, Height = 6 }
            }, 2);
        }

        static void ScaleAll(IEnumerable<IResizable> shapes, double factor)
        {
            foreach (IResizable shape in shapes)
            {
                shape.Scale(factor);
            }
        }
    }
}