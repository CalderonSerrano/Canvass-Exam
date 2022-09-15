namespace pr1
{
    abstract class Figure
    {
        public Canvas Canvas { get; set; }
        public string Id { get; set; }
        public double PosX { get; set; }
        public double PosY { get; set; }
        public Figure(string id)
        {
            Id = id;
        }

        abstract public double CalculateArea(); // Abstract method so the child classes can override it.
        abstract public double CalculatePerimeter();
        public bool Move(double moveX, double moveY) // Bool method which says if the figure was successfully moved.
        {
            bool ok = false;
            double newPosX = PosX + moveX;
            double newPosY = PosY + moveY;
            if (newPosX <= Canvas.Width && newPosX >= 0 && newPosY <= Canvas.Height && newPosY >= 0) // If the summatory of the new coordinates are inside the limits of the canvas, this method will return true.
            {
                PosX += moveX; // Then we do the summatory to get the new position.
                PosY += moveY;
                ok = true;
            }
            return ok;
        }
        public override string ToString()
        {
            return $"Id: {Id} | X Position: {PosX} | Y Position: {PosY} ";
        }
    }
}
