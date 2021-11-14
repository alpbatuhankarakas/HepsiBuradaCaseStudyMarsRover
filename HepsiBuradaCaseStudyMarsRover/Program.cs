using HepsiBuradaCaseStudyMarsRover.Model;
using System;

namespace HepsiBuradaCaseStudyMarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello Mars Lover. We hope one day mankind will come to Mars!");

                PlateauGrid grid = GridSelector();

                Console.WriteLine("We have a Plateau");

                var platform = new RoverPlatform(grid);

                RoverSelector(platform, grid);

                Console.WriteLine("We are starting to action...");

                StartAction(platform);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private static void StartAction(RoverPlatform platform)
        {
            foreach (var rover in platform.Rovers)
            {
                foreach (var action in rover.Directions)
                {
                    switch (action)
                    {
                        case ActionType.L:
                            rover.Left();
                            break;

                        case ActionType.R:
                            rover.Right();
                            break;

                        case ActionType.M:
                            rover.Move();
                            break;
                    }
                }

                rover.Directions.Clear();
                Console.WriteLine($"Rover Action ended. Rover position is X={rover.Position.X} Y={rover.Position.Y} Direction={rover.Position.Direction}");
            }
        }
        private static bool RoverSelector(RoverPlatform platform,PlateauGrid grid)
        {
            var DoOperation = true;
            while (DoOperation)
            {
                Console.WriteLine("Please enter the coordinates and direction of the rover. Coordinates should be integer and direction should be a character and separated by space. Example->'2 1 N'");
                var roverInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(roverInput))
                {
                    var gridValues = roverInput.Split(' ');
                    if (gridValues.Length == 3)
                    {
                        int coorX;
                        if (int.TryParse(gridValues[0], out coorX))
                        {
                            int coorY;
                            if (int.TryParse(gridValues[1], out coorY))
                            {
                                CardinalDirection direction;

                                if (Enum.TryParse(gridValues[2]?.ToUpper(), out direction))
                                {
                                    var rover = new Rover(grid, coorX, coorY, direction);

                                    DoOperation = RoverActionSelector(rover);

                                    if (DoOperation)
                                    {
                                        platform.AddRover(rover);
                                        DoOperation = IsThereAdditionalRover();
                                        while (DoOperation)
                                        {
                                            DoOperation = RoverSelector(platform, grid);
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Direction have to be 'N' or 'S' or 'W' or 'R'");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Second character have to be an integer");
                            }
                        }
                        else
                        {
                            Console.WriteLine("First character have to be an integer.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have to enter two integers and a character.");
                    }
                }
            }
            return DoOperation;
        }
        private static bool IsThereAdditionalRover()
        {
            var DoOpeeration = true;
            while (DoOpeeration)
            {
                Console.WriteLine("Do you want to enter another rover. Yes 'Y' Or no 'N'");

                var continueInput = Console.ReadLine();

                if (continueInput == "Y")
                {
                    return true;
                }
                else if (continueInput == "N")
                {
                    return false;
                }
            }
            return true;
        }
        private static bool RoverActionSelector(Rover rover)
        {
            var DoOperation = true;
            while (DoOperation)
            {
                Console.WriteLine("Please enter the directions of the rover. Direction should be a character and separated by space. Example->'L S N'");
                var roverInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(roverInput))
                {
                    foreach (var direction in roverInput)
                    {
                        ActionType action;

                        if (Enum.TryParse(direction.ToString().ToUpper(), out action))
                        {
                            rover.Directions.Enqueue(action);
                        }
                        else
                        {
                            Console.WriteLine("Direction have to be 'R' or 'L' or 'M'");
                        }
                    }

                    return true;
                }
            }

            return false;
        }

        private static PlateauGrid GridSelector()
        {
            var DoOpeeration = true;
            while (DoOpeeration)
            {
                Console.WriteLine("Please enter the upper-right coordinates of the plateau. Coordinates have to be integer and separated by space. Example->'6 5'");
                var gridInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(gridInput))
                {
                    var gridValues = gridInput.Split(' ');
                    if (gridValues.Length == 2)
                    {
                        int coorX;
                        if (int.TryParse(gridValues[0], out coorX))
                        {
                            int coorY;
                            if (int.TryParse(gridValues[1], out coorY))
                            {
                                return new PlateauGrid(coorX, coorY);
                            }
                            else
                            {
                                Console.WriteLine("Second character have to be an integer");
                            }
                        }
                        else
                        {
                            Console.WriteLine("First character have to be an integer.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have to enter two integers.");
                    }
                }
            }

            return null;
        }
    }
}
