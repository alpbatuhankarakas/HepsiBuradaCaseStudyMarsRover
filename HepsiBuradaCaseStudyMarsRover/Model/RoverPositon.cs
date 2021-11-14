using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaCaseStudyMarsRover.Model
{
    public class RoverPositon : IRoverPosition
    {
        private IPlateauGrid Plateau;
        public CardinalDirection Direction { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public RoverPositon(IPlateauGrid plateau, CardinalDirection direction, int x, int y)
        {
            Plateau = plateau;
            Direction = direction;
            X = x;
            Y = y;
        }

        public void ChangePosition(int x, int y)
        {
            if (Plateau.X0 > x)
            {
                Console.WriteLine("Come back to plateau. You are in the west.");
            }
            else if (Plateau.X1 < x)
            {
                Console.WriteLine("Come back to plateau. You are in the east.");
            }
            else if (Plateau.Y0 > y)
            {
                Console.WriteLine("Come back to plateau. You are in the south.");
            }
            else if (Plateau.Y1 < x)
            {
                Console.WriteLine("Come back to plateau. You are in the north.");
            }

            X = x;
            Y = y;
        }
    }
}
