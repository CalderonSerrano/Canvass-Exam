using System;
using System.Collections.Generic;

namespace pr1
{
    class Program
    {
        static CanvasManager cm = new CanvasManager(); // We need to declare the class to access to all the methods, from the Program Class' methods.
        static void Main(string[] args)
        {

            int option;
            do
            {
                Menu(); //Show Menu.
                option = Option(); //User enters the option
                switch (option) //Depending on the option selected, the program will show what was choosen.
                {
                    case 1:
                        {
                            Console.Clear();
                            CreateCanvas(); //There's a default canvas created, the user can create more.
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            ChangeCanvas(); //The user can change from one canvas to another.
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            AddRectangle(); //The user can add a rectangle to the active canvas.
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            AddCircle(); //The user can add a circle to the active canvas.
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            ShowActiveCanvas(); //The program shows a canvas with the figures in it.
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            MoveFigure(); //The user can move the parameters posX and posY of a figure.
                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            Mirror(); // The user can mirror a figure (create the same figure, but in the inversed coordinates).
                            break;
                        }
                    case 8:
                        {
                            Console.Clear();
                            DistinctFigures(); // The user can see how many figures are in the canvas.
                            break;
                        }
                    case 9:
                        {
                            Console.Clear();
                            FiguresInCentralDiagonal(); // The user can see which of the figures in the canvas belong to the principal diagonal.
                            break;
                        }
                    case 10:
                        {
                            Console.Clear();
                            Console.Write("                             Press enter to exit.");
                            ConsoleKey y;
                            ConsoleKeyInfo k = Console.ReadKey(true);
                            y = k.Key;
                            if(y == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                Console.WriteLine("              Press enter to exit.");
                            }
                            ConsoleKeyInfo j = Console.ReadKey(true);
                            y = j.Key;
                            if (y == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                Console.WriteLine("                                                       Press enter to exit.");
                            }
                            ConsoleKeyInfo f = Console.ReadKey(true);
                            y = f.Key;
                            if (y == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                Console.WriteLine("                            Press enter to exit.");
                            }
                            Console.Clear();
                            Console.WriteLine("Perdona, no me suspendas jajajaja.");
                            Console.WriteLine("Presiona 11 para salir.");
                            break;
                        }
                }
            } while (option < 11 && option > 0);
            Console.ReadKey();
        }
        public static void Menu()
        {
            Console.WriteLine(" _____________________________________________");
            Console.WriteLine("| ___________________ MENU ___________________|");
            Console.WriteLine("| 1.Create new canvas.                        |");
            Console.WriteLine("| 2.Change canvas.                            |");
            Console.WriteLine("| 3.Add rectangle.                            |");
            Console.WriteLine("| 4.Add circle.                               |");
            Console.WriteLine("| 5.Show canvas.                              |");
            Console.WriteLine("| 6.Move figure.                              |");
            Console.WriteLine("| 7.Mirror figure.                            |");
            Console.WriteLine("| 8.Count figures.                            |");
            Console.WriteLine("| 9.Figures in the principal diagonal.        |");
            Console.WriteLine("| 10.Exit.                                    |");
            Console.WriteLine("|_____________________________________________|");
        }
        public static int Option()
        {
            int option;
            Console.WriteLine();
            Console.Write("  Choose an option: ");
            return option = int.Parse(Console.ReadLine());
        }

        public static void CreateCanvas()
        {
            Console.Write("Indicate canvas' name: ");
            string name = Console.ReadLine(); //User enters the canvas' name
            int height, width;
            do
            {
                Console.Write("Indicate canvas' height: ");
                height = int.Parse(Console.ReadLine());
                if (height < 0) //Mistakes solver.
                {
                    Console.WriteLine("Height can't be negative.");
                }
            } while (height < 0); //This way we make sure the user enters a valid height.
            do
            {
                Console.Write("Indicate canvas' width: ");
                width = int.Parse(Console.ReadLine());
            } while (width < 0); //This way we make sure the user enters a valid width.
            Canvas c = new Canvas(name, height, width);
            if (cm.AddCanvas(c)) //We call this method to add a new canvas, and make it the active canvas.
            {
                Console.WriteLine($"Active Canvas: {c.Name}.");
            }
            else
            {
                Console.WriteLine("Error. This canvas already exists.");
            }
        }
        public static void ShowCanvas(List<Canvas> canvasList)
        {
            int num = 1; // We set this variable as 1, to show the user the options he has starting from 1 (due to the existance of the possition 0 in a list).
            foreach (Canvas canvas in canvasList)
            {
                Console.WriteLine($"{num} --> {canvas.Name}");
                num++;
            }
        }
        public static void ChangeCanvas()
        {
            Console.WriteLine("Canvas available: ");
            ShowCanvas(cm.canvasList); // We call the method ShowCanvas to show a menu with the different canvas available.
            Console.Write("Which canvas do you want to make the Active canvas?: ");
            int id = int.Parse(Console.ReadLine()); // The user introduces the canvas he wants to use.
            if (cm.ChangeActiveCanvas(id - 1))
            {
                Console.WriteLine("Active canvas: " + cm.activeCanvas.Name);
            }
            else
            {
                Console.WriteLine("Error. The canvas you are looking for doesn't exist.");
            }
        }

        public static void AddRectangle()
        {
            double posX, posY;
            Console.Write("Introduce rectangle's name: ");
            string id = Console.ReadLine();
            Console.Write("Would you like to indicate the position (y/n)?:");
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                Console.Write("Indicate X position: ");
                posX = int.Parse(Console.ReadLine());
                Console.Write("Indicate Y position: ");
                posY = int.Parse(Console.ReadLine());
            }
            else
            {
                posX = 0; // Default values.
                posY = 0;
            }
            if (posX > cm.activeCanvas.Width || posY > cm.activeCanvas.Height) // If the coordinates are out of the canvas' range, mistake solver.
            {
                Console.WriteLine("Error: Position must be inside the canvas range.");
            }
            else
            {
                Console.Write("Indicate rectangle's width: ");
                int width = int.Parse(Console.ReadLine());
                int height;
                do
                {
                    Console.Write("Indicate rectangle's height: ");
                    height = int.Parse(Console.ReadLine());
                    if (height == width) //Mistake solver.
                    {
                        Console.WriteLine($"A rectangle does not have same width[{width}] and height[{height}].");
                    }
                } while (width == height); //Mistake condition.
                Rectangle r = new Rectangle(height, width, id);
                r.PosX = posX;
                r.PosY = posY;
                r.Canvas = cm.activeCanvas;
                if (cm.activeCanvas.AddFigure(r)) // We add the figure to the canvas.
                {
                    cm.DiagonalFigures(r); // We call this method to know if the figure is in the principal diagonal.
                    Console.WriteLine("Figure added succesfuly.");
                }
                else
                {
                    Console.WriteLine("Error: The id does already exists.");
                }
            }
        }

        public static void AddCircle()
        {
            int posX, posY;
            Console.Write("Introduce circle's name: ");
            string id = Console.ReadLine();
            Console.Write("Would you like to indicate the position (y/n)?:");
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                Console.Write("Indicate X position: ");
                posX = int.Parse(Console.ReadLine());
                Console.Write("Indicate Y position: ");
                posY = int.Parse(Console.ReadLine());
            }
            else
            {
                posX = 0;
                posY = 0;
            }
            if (posX > cm.activeCanvas.Width || posY > cm.activeCanvas.Height)
            {
                Console.WriteLine("Error: Position must be inside the canvas range.");
            }
            else
            {
                Console.Write("Enter radius: ");
                float radius = float.Parse(Console.ReadLine());
                Circle c = new Circle(radius, id);
                c.PosX = posX;
                c.PosY = posY;
                c.Canvas = cm.activeCanvas;
                if (cm.activeCanvas.AddFigure(c))
                {
                    cm.DiagonalFigures(c);
                    Console.WriteLine("Figure added succesfuly.");
                }
                else
                {
                    Console.WriteLine("Error: The id does already exists.");
                }
            }
        }
        public static void MoveFigure()
        {
            Console.Write("Indicate the name of the figure you want to move: ");
            string id = Console.ReadLine();
            Figure figure = cm.activeCanvas.ObtainFigure(id); // If we don't find the figure, it returns null and it means that the user can creat it.
            if (figure != null)
            {
                Console.Write("Movement on X axis: ");
                double moveX = double.Parse(Console.ReadLine());
                Console.Write("Movement on Y axis: ");
                double moveY = double.Parse(Console.ReadLine());
                if (figure.Move(moveX, moveY))
                {
                    cm.DiagonalFigures(figure); // We take a look if the new coordinates are out of the principal diagonal or, instead, are now in the principal diagonal.
                    Console.WriteLine("Figure moved successfully.");
                }
                else
                {
                    Console.WriteLine("Error: The figure could not be moved because it was out of the canvas' range.");
                }
            }
            else
            {
                Console.WriteLine("The figure doesn't exist.");
            }
        }

        public static void ShowActiveCanvas()
        {
            if (cm.activeCanvas.Figures.Count > 0) // If we have at least one figure, this method will show all the attributes.
            {
                Console.WriteLine($"Figures in the canvas: \nActive canvas' name: {cm.activeCanvas.Name} | Width: {cm.activeCanvas.Width} | Height: {cm.activeCanvas.Height}");
                foreach (Figure figure1 in cm.activeCanvas.Figures)
                {
                    Console.WriteLine(figure1.ToString());
                }
                Console.WriteLine();
                Console.WriteLine($"Total perimeter: {cm.activeCanvas.CalculateTotalPerimeter()}");
                Console.WriteLine($"Total area: {cm.activeCanvas.CalculateTotalArea()}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"The {cm.activeCanvas.Name} canvas does not contain figures.");
            }
        }
        public static void Mirror()
        {
            Console.Write("Which figure do you want to mirror?: ");
            string id = Console.ReadLine();
            if (cm.activeCanvas.SearchFigure(id)) // We search if the figure already exists.
            {
                Type mirror = cm.activeCanvas.ObtainFigure(id).GetType(); // As we don't know what type of class the user wants to mirror, we get the type of that figure and ascribe it to mirror.
                if (mirror == typeof(Circle)) // If in this case, the GetType returns a Circle, enters the condition.
                {
                    Circle c1 = (Circle)cm.activeCanvas.ObtainFigure(id); // We create and convert the figure.
                    Console.Write("Introduce circle's name: ");
                    string idMirror = Console.ReadLine();
                    Circle c2 = new Circle(c1.Radius, idMirror); // As the figure must be equal, they share the same attributes but the id.
                    c2.Id = idMirror;
                    c2.PosX = c1.PosY;
                    c2.PosY = c1.PosX;
                    c2.Canvas = cm.activeCanvas;
                    if (cm.activeCanvas.AddFigure(c2))
                    {
                        cm.DiagonalFigures(c2); // We must look again if the mirror belongs to the principal diagonal.
                        Console.WriteLine("Figure added succesfully.");
                    }
                    else
                    {
                        Console.WriteLine("Error: The id does already exists.");
                    }
                }
                else if (mirror == typeof(Rectangle))
                {
                    Rectangle r1 = (Rectangle)cm.activeCanvas.ObtainFigure(id);
                    Console.Write("Introduce rectangle's name: ");
                    string idMirror = Console.ReadLine();
                    Rectangle r2 = new Rectangle(r1.Height, r1.Width, idMirror);
                    r2.PosX = r1.PosY;
                    r2.PosY = r1.PosX;
                    r2.Canvas = cm.activeCanvas;
                    if (cm.activeCanvas.AddFigure(r2))
                    {
                        cm.DiagonalFigures(r2);
                        Console.WriteLine("Figure added succesfully.");
                    }
                    else
                    {
                        Console.WriteLine("Error: The id does already exists.");
                    }
                }
            }
            else
            {
                Console.WriteLine("The figure you are looking for doesn't exist.");
            }
        }

        public static void DistinctFigures()
        {
            if (cm.activeCanvas.RectangleCounter() <= 0 && cm.activeCanvas.CircleCounter() <= 0) // If the canvas is empty: no figueres in it.
            {
                Console.WriteLine($"There are no figures in {cm.activeCanvas.Name}");
            }
            else
            {
                Console.WriteLine($"The number of rectangles in {cm.activeCanvas.Name} is: [{cm.activeCanvas.RectangleCounter()}]"); // Takes count of the number of rectangles in the canvas.
                Console.WriteLine($"The number of circles in {cm.activeCanvas.Name} is: [{cm.activeCanvas.CircleCounter()}]"); // Takes count of the number of circles in the canvas.
                Console.WriteLine($"Total figures in the canvas: [{cm.activeCanvas.RectangleCounter() + cm.activeCanvas.CircleCounter()}]"); // Takes count of the number of figures in the canvas.
            }
        }

        public static void FiguresInCentralDiagonal()
        {
            if (cm.activeCanvas.Height == cm.activeCanvas.Width) // First the canvas must be squared so it contains a principal diagonal (as in a matrix, if X is different from Y, it won't exist a principal diagonal).
            {
                if (cm.FiguresInDiagonal.Count > 0) // If there is minimum a figure, enters the condition.
                {
                    foreach (Figure figure in cm.FiguresInDiagonal)
                    {
                        Console.WriteLine(figure.ToString());
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Total perimeter: {cm.CalculateDiagonalPerimeter()}"); // Calculates the total perimeter of the figures in the principal diagonal.
                    Console.WriteLine($"Total area: {cm.CalculateDiagonalArea()}"); // Calculates the total area of the figures in the principal diagonal.
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("There are no figures in the principal diagonal.");
                }
            }
            else
            {
                Console.WriteLine($"The canvas does not contain a principal diagonal. \nThe active canvas {cm.activeCanvas.Name} is not squared.");
            }
        }
    }
}
