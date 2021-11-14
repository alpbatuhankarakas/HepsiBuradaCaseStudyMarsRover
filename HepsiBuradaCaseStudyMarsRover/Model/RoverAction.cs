using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaCaseStudyMarsRover.Model
{
    public class RoverAction
    {
        public IRoverPosition Go(IRoverPosition position)
        {
            return Move(position);
        }
        public IRoverPosition GoRight(IRoverPosition position)
        {
            position.Direction = position.Direction switch
            {
                CardinalDirection.W => CardinalDirection.N,
                CardinalDirection.E => CardinalDirection.S,
                CardinalDirection.N => CardinalDirection.E,
                CardinalDirection.S => CardinalDirection.W,
                _ => throw new InvalidOperationException("Your have to have a direction!!!"),
            };

            return Move(position);
        }
        public IRoverPosition GoLeft(IRoverPosition position)
        {
            position.Direction = position.Direction switch
            {
                CardinalDirection.W => CardinalDirection.S,
                CardinalDirection.E => CardinalDirection.N,
                CardinalDirection.N => CardinalDirection.W,
                CardinalDirection.S => CardinalDirection.E,
                _ => throw new InvalidOperationException("Your have to have a direction!!!"),
            };
            return Move(position);
        }
        private IRoverPosition Move(IRoverPosition position)
        {
            switch (position.Direction)
            {
                case CardinalDirection.W:
                    position.ChangePosition(position.X - 1, position.Y);
                    break;
                case CardinalDirection.E:
                    position.ChangePosition(position.X + 1, position.Y);
                    break;
                case CardinalDirection.N:
                    position.ChangePosition(position.X, position.Y + 1);
                    break;
                case CardinalDirection.S:
                    position.ChangePosition(position.X, position.Y - 1);
                    break;
                default:
                    throw new InvalidOperationException("Your have to have a direction!!!");
            }

            return position;
        }
    }
}
