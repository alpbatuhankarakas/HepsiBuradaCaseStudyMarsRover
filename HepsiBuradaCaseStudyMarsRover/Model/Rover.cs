using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaCaseStudyMarsRover.Model
{
    public class Rover : IRover
    {
        public IRoverPosition Position { get; set; }
        public Queue<ActionType> Directions { get; set; }

        private RoverAction Action;
        public Rover(PlateauGrid plateau , int x, int y, CardinalDirection cardinalDirection)
        {
            Position = new RoverPositon(plateau,cardinalDirection,x,y);
            Action = new RoverAction();
            Directions = new Queue<ActionType>();
        }
        public void Move()
        {
            Position = Action.Go(Position);
        }

        public void Right()
        {
            Position = Action.GoRight(Position);
        }

        public void Left()
        {
            Position = Action.GoLeft(Position);
        }
    }
}
