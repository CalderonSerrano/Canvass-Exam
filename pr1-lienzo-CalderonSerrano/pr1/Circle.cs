using System;

namespace pr1
{
    class Circle : Figure
    {
        public float Radius { get; set; }
        public Circle(float radius, string id) : base(id)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            double area;
            area = 2 * Math.PI * Radius * Radius;
            return area;
        }
        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * Radius;
            return perimeter;
        }
        public override string ToString()
        {
            return $"Circle: {base.ToString()} | Radius: {Radius} | Perimeter: {CalculatePerimeter()} | Area: {CalculateArea()}";
        }

    }
}
