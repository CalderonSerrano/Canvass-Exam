using System.Collections.Generic;

namespace pr1
{
    class Canvas
    {
        public string Name { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public List<Figure> Figures { get; set; }
        public Canvas(string name, double height, double witdh)
        {
            Name = name;
            Height = height;
            Width = witdh;
            Figures = new List<Figure>(); //Each time we create a new Canvas, a new Figures list is created.
        }
        public Figure ObtainFigure(string id) //The user introduces the name of the figure.
        {
            Figure figure1 = null; //We create an aux Figure class, so if we find the id inside the Figures list, we assign that id to the new figure.
            foreach (Figure figure2 in Figures)
            {
                if (figure2.Id == id) // id found.
                {
                    figure1 = figure2; //name searched = figure1.id
                }
            }
            return figure1; //This method returns a figure class (which has an id constructor) so at the end, it will return the data.
        }
        public bool AddFigure(Figure figure)
        {
            Figure figure1 = ObtainFigure(figure.Id); //First we look for the figure inside the Figures list.
            if (figure1 == null) // If we don't find the figure, then we can add it.
            {
                Figures.Add(figure);
            }
            return figure1 == null;
        }
        public double CalculateTotalArea()
        {
            double totalArea = 0; //aux needed to do the summatory.
            foreach (Figure figure in Figures) //We look inside the list to add all the area values.
            {
                totalArea += figure.CalculateArea(); //We call the abstract method in Figure (this way we can call the different AreaCalculator methods depending on the type of figure).
            }
            return totalArea;
        }
        public double CalculateTotalPerimeter()
        {
            double totalPerimeter = 0; //aux needed to do the summatory.
            foreach (Figure figure in Figures) //We look inside the list to add all the area values.
            {
                totalPerimeter += figure.CalculatePerimeter(); //We call the abstract method in Figure (this way we can call the different AreaCalculator methods depending on the type of figure).
            }
            return totalPerimeter;
        }
        public bool SearchFigure(string id) // We search the figure by its id
        {
            bool exists = false;
            foreach (Figure f in Figures)
            {
                if (f.Id == id) // If we find a match between the id and the figure's id in the list, we have found it.
                {
                    exists = true;
                }
            }
            return exists;
        }

        public int RectangleCounter() // This method counts the number of rectangles that the canvas has.
        {
            int quantity = 0;
            foreach (Figure figure1 in Figures)
            {
                if (figure1 is Rectangle) // If the figure is a Rectangle class, we add 1 to the summatory.
                {
                    quantity++;
                }
            }
            return quantity;
        }
        public int CircleCounter() // This method counts the number of circles that the canvas has.
        {
            int quantity = 0;
            foreach (Figure figure1 in Figures)
            {
                if (figure1 is Circle)
                {
                    quantity++;
                }
            }
            return quantity;
        }
    }
}
