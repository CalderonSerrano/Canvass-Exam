namespace pr1
{
    class Rectangle : Figure
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public Rectangle(double height, double width, string id) : base(id)
        {
            Height = height;
            Width = width;
        }
        public override double CalculateArea()
        {
            double area;
            area = Height * Width;
            return area;
        }
        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Height + 2 * Width;
            return perimeter;
        }
        public override string ToString()
        {
            return $"Rectangle: {base.ToString()} | Height: {Height} | Width: {Width} | Perimeter: {CalculatePerimeter()} | Area: {CalculateArea()}";
        }
    }
}
