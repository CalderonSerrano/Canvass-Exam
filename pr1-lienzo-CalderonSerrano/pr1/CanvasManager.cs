using System.Collections.Generic;

namespace pr1
{
    class CanvasManager
    {
        public List<Canvas> canvasList { get; set; } = new List<Canvas>();
        public List<Figure> FiguresInDiagonal { get; set; }
        public Canvas activeCanvas { get; set; } //Active canvas status.

        public CanvasManager()
        {
            AddCanvas(new Canvas("default", 100, 100)); //We call the method AddCanvas to let the program have a default canvas with 100x100 as dimensions.
            FiguresInDiagonal = new List<Figure>();
        }

        public Canvas ObtainCanvas(string name)
        {
            Canvas canvas1 = null;
            foreach (Canvas canvas2 in canvasList) //We go all over the canvasList.
            {
                if (canvas2.Name == name) //If we find the name inside the list, that's the canvas the user is looking for.
                {
                    canvas1 = canvas2;
                }
            }
            return canvas1;
        }
        public bool AddCanvas(Canvas canvas)
        {
            bool ok = false;
            if (ObtainCanvas(canvas.Name) == null) // If the name we are looking for is not in the canvasList, we add it.
            {
                canvasList.Add(canvas);
                ok = true;
            }
            activeCanvas = canvas; //Then, this canvas turns to be the new active canvas.
            return ok;
        }
        public bool ChangeActiveCanvas(int canvasNum)
        {
            bool ok = false;
            if (canvasNum >= 0 && canvasNum < canvasList.Count) //If the number introduced by the user is higher or equal to zero, and lower than the number of canvas in the list, enters the conditional.
            {
                activeCanvas = canvasList[canvasNum]; //Then, the active canvas turns to be the number in the list the user introduced.
                ok = true;
            }
            return ok;
        }
        public void DiagonalFigures(Figure figure)
        {
            if (figure.PosX == figure.PosY) // In a squared canvas, if PosX is equal to PosY, it means that the figure is in the Principal Diagonal.
            {
                FiguresInDiagonal.Add(figure); //Then we add it.
            }
            else
            {
                FiguresInDiagonal.Remove(figure); // If we move a figure, this "else" will remove the figure in case it doesn't belongs to the Principal Diagonal again.
            }
        }

        public double CalculateDiagonalPerimeter()
        {
            double diagonalPerimeter = 0;
            foreach(Figure figure in FiguresInDiagonal)
            {
                diagonalPerimeter += figure.CalculatePerimeter();
            }
            return diagonalPerimeter;
        }
        public double CalculateDiagonalArea()
        {
            double diagonalArea = 0;
            foreach (Figure figure in FiguresInDiagonal)
            {
                diagonalArea += figure.CalculateArea();
            }
            return diagonalArea;
        }
    }
}
